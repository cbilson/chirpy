
using System;
using System.Collections.Generic;
using System.Linq;

namespace Zippy.Chirp.Threading
{
    public class ServiceQueue<T> : IDisposable
    {
        private ServicePool pool;
        private long running = 0;
        private long finished = 0;

        private System.Collections.Generic.Queue<T> queue = new System.Collections.Generic.Queue<T>();
        private System.Threading.AutoResetEvent notifier = new System.Threading.AutoResetEvent(false);
        private Action<T> action = t => { };
        private Action<T, Exception> onError = (t, e) => { };
        private bool isDisposed = false;

        #region "constructor"
        public ServiceQueue(Action<T> action = null, Action<T, Exception> onError = null, int? numThreads = null, string name = "Worker", System.Threading.ThreadPriority priority = System.Threading.ThreadPriority.Normal)
        {
            this.action = action;
            this.onError = onError;
            this.pool = new ServicePool(this.ProcessQueue, numThreads ?? System.Environment.ProcessorCount, name, priority);
        }
        #endregion

        public bool IsDisposed
        {
            get { return this.isDisposed; }
        }

        public long Finished
        {
            get
            {
                return this.finished;
            }
        }

        public long Total
        {
            get
            {
                return this.Finished + this.Length;
            }
        }

        public long Length
        {
            get
            {
                if (this.isDisposed) 
                { 
                    return 0;
                }

                return this.queue.Count + this.running;
            }
        }

        public long Running
        {
            get { return this.running; }
        }

        public bool IsActive
        {
            get { return this.Length > 0; }
        }

        public virtual void Enqueue(T obj)
        {
            lock (this.queue)
                this.queue.Enqueue(obj);
            this.notifier.Set();
        }

        public bool Any(Func<T, bool> predicate)
        {
            lock (this.queue) return this.queue.Any(predicate);
        }

        public virtual void Enqueue(IEnumerable<T> objs)
        {
            lock (this.queue)
                foreach (var x in objs)
                {
                    this.queue.Enqueue(x);
                }

            this.notifier.Set();
        }

        public void Dispose()
        {
            this.isDisposed = true;
            if (this.pool != null)
            {
                this.pool.Dispose();
            }

            this.queue = null;
            this.pool = null;
        }

        public void Wait()
        {
            this.Wait(100, null);
        }

        public void Wait(int waitInterval, Action whileWaiting)
        {
            var mre = new System.Threading.ManualResetEvent(false);
            while (this.IsActive)
            {
                mre.WaitOne(100);
                if (whileWaiting != null)
                {
                    whileWaiting();
                }
            }
        }

        protected virtual void Process(T item)
        {
            this.action(item);
        }

        protected virtual void Error(T item, Exception ex)
        {
            this.onError(item, ex);
        }

        private void ProcessQueue()
        {
            while (!this.isDisposed)
            {
                this.notifier.WaitOne(300);

                T obj = default(T);
                bool exec = false;
                if (!this.isDisposed && this.queue != null && this.queue.Count > 0)
                {
                    lock (this.queue)
                    {
                        // Now that we have an exclusive lock on the queue, it could be empty
                        if (this.queue.Count > 0)
                        {
                            System.Threading.Interlocked.Increment(ref this.running);

                            // Ensure that CurrentlyExecuting + QueueLength <> 0
                            obj = this.queue.Dequeue();
                            exec = true;
                        }
                    }
                }

                if (exec)
                {
                    try
                    {
                        this.Process(obj);
                    }
                    catch (Exception ex)
                    {
                        if (!this.isDisposed)
                        {
                            if (this.onError != null)
                            {
                                this.onError(obj, ex);
                            }
                        }
                    }
                    finally
                    {
                        System.Threading.Interlocked.Decrement(ref this.running);
                        System.Threading.Interlocked.Increment(ref this.finished);
                        if (obj is IDisposable)
                        {
                            ((IDisposable)obj).Dispose();
                        }
                    }
                }
            }
        }
    }
}