
using System;
using System.Linq.Expressions;
namespace Zippy.Chirp.JavaScript {

    public abstract class Environment : IDisposable {
        public Uri BaseLocation { get; set; }

        private class Object : Jurassic.Library.ObjectInstance {
            public Object(Jurassic.ScriptEngine engine) : base(engine) { }
        }

        private Jurassic.Library.ObjectInstance GetObject(object obj) {
            var type = obj.GetType();
            var inst = new Object(_ctx);
            foreach (var prop in type.GetProperties()) {
                var value = prop.GetValue(obj, null);
                if (!prop.PropertyType.IsValueType && prop.PropertyType != typeof(string) && value != null) {
                    value = GetObject(value);
                }
                inst.DefineProperty(prop.Name, new Jurassic.Library.PropertyDescriptor(value, Jurassic.Library.PropertyAttributes.FullAccess), true);
            }
            return inst;
        }

        private void Init() {
            if (BaseLocation == null)
                BaseLocation = Extensibility.Instance.GetBaseLocation(this) ?? new Uri(System.Environment.CurrentDirectory);

            _ctx = new Jurassic.ScriptEngine();
            _ctx.SetGlobalFunction("getContents", (Func<string, string>)GetContents);
            _ctx.SetGlobalFunction("getFullFilename", (Func<string, string>)GetFullFilename);
            Run(Zippy.Chirp.Properties.Resources.env);
            OnInit();
        }

        protected virtual void OnInit() { }

        Jurassic.ScriptEngine _ctx;
        private Jurassic.ScriptEngine Context {
            get {
                if (_ctx == null) lock (this) if (_ctx == null) Init();
                return _ctx;
            }
        }

        public void Dispose() {
            // if (_ctx != null) _ctx.Dispose();
            _ctx = null;
        }

        public object this[string name] {
            get { return Context.GetGlobalValue(name); }
            set {
                if (!(value is ValueType) && !(value is string) && value != null) {
                    value = GetObject(value);
                }
                Context.SetGlobalValue(name, value ?? Jurassic.Null.Value);
            }
        }

        public void Run(string script, params Expression<Func<object, object>>[] vars) {
            foreach (var @var in vars) {
                this[@var.Parameters[0].Name] = @var.Compile()(null);
            }
            try {
                Context.Execute(script);

            } catch (Exception ex) {
                Console.Write(ex);
                throw;
            }
        }

        public string GetContents(string file) {
            return Extensibility.Instance.GetContents(BaseLocation, file);
        }

        public string GetFullFilename(string file) {
            return new Uri(BaseLocation, file).ToString();
        }

        public void RunFile(string file) {
            var script = GetContents(file);
            Run(script);
        }
    }
}
