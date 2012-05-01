using System;

namespace Zippy.Chirp.Threading
{
    public class ServicePool : IDisposable
    {
        private System.Threading.Thread[] threads;
        private System.Threading.ThreadStart threadDelegate;
        private long runnning;
        private bool isDisposed;

        #region "constructor"
        public ServicePool(System.Threading.ThreadStart callback, int numThreads)
            : this(callback, numThreads, "ServicePool", System.Threading.ThreadPriority.Normal)
        {
        }

        public ServicePool(System.Threading.ThreadStart callback, int numThreads, string name, System.Threading.ThreadPriority priority)
        {
            this.threadDelegate = callback;
            this.threads = new System.Threading.Thread[numThreads];
            this.runnning = numThreads;
            for (int i = 0; i <= this.threads.Length - 1; i++)
            {
                var th = new System.Threading.Thread(this.Execute);
                th.Name = string.Concat(name, " #", i + 1);
                th.Priority = priority;
                th.Start();
                this.threads[i] = th;
            }
        }
        #endregion

        public bool IsActive
        {
            get { return this.runnning > 0; }
        }

        public void Dispose()
        {
            if (this.isDisposed)
            {
                return;
            }

            this.isDisposed = true;
            foreach (System.Threading.Thread th in this.threads)
            {
                if (th != null)
                {
                    th.Abort();
                }
            }

            this.threads = null;
        }

        private void Execute()
        {
            this.threadDelegate();
            System.Threading.Interlocked.Decrement(ref this.runnning);
        }
    }
}