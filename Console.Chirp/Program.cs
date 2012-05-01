using System.Collections.Generic;
using System.IO;
using Zippy.Chirp;
using Zippy.Chirp.Engines;

namespace Console.Chirp 
{
    class Program
    {
        static void Main(string[] args)
        {
            string findPath = string.Empty;
            if (args.Length > 0)
            {
                findPath = args[0];
            }

           
            // config file
            ConfigDirectory(findPath);
            EngineDirectory(findPath);
            foreach (var directory in Directory.GetDirectories(findPath, "*", SearchOption.AllDirectories))
            {
                ConfigDirectory(directory);
                EngineDirectory(directory);
            }
        }

        /// <summary>
        /// process directory to config engine
        /// </summary>
        /// <param name="directoryPath">Directory full path</param>
       static void ConfigDirectory(string directoryPath)
        {
            var configEngine = new ConfigEngine();
            var settings = new Settings(directoryPath);
            foreach (string filename in Directory.GetFiles(directoryPath, "*" + settings.ChirpConfigFile, SearchOption.TopDirectoryOnly))
            {
                try
                {
                    System.Console.WriteLine(string.Format("ConfigEngine -- {0}", filename));
                    configEngine.Run(filename, null);
                }
                catch (System.IO.FileNotFoundException)
                {
                    System.Console.WriteLine(string.Format("File not found in config file={0}", filename));
                }
            }
        }

        /// <summary>
        /// Process directory in all engine
        /// </summary>
       /// <param name="directoryPath">Directory full path</param>
       static void EngineDirectory(string directoryPath)
       {
           List<TransformEngine> listTrasformEngine = new List<TransformEngine>();

           listTrasformEngine.Add(new DeanEdwardsPackerEngine());
           listTrasformEngine.Add(new YuiCssEngine());
           listTrasformEngine.Add(new YuiJsEngine());
           listTrasformEngine.Add(new ClosureCompilerEngine());
           listTrasformEngine.Add(new LessEngine());
           listTrasformEngine.Add(new SassEngine());
           listTrasformEngine.Add(new CoffeeScriptEngine());
           listTrasformEngine.Add(new UglifyEngine());
           listTrasformEngine.Add(new MsJsEngine());
           listTrasformEngine.Add(new MsCssEngine());
           //// listTrasformEngine.Add(new ConfigEngine());
           listTrasformEngine.Add(new ViewEngine());
           //// listTrasformEngine.Add(new T4Engine());

           var settings = new Settings(directoryPath);
           foreach (TransformEngine transformEngine in listTrasformEngine)
           {
               transformEngine.Settings = settings;
               foreach (string extension in transformEngine.Extensions)
               {
                   foreach (
                       string filename in
                           Directory.GetFiles(directoryPath, "*" + extension, SearchOption.TopDirectoryOnly))
                   {
                       if (filename.Contains(".min."))
                       {
                           continue;
                       }

                       string text = System.IO.File.ReadAllText(filename);
                       string minFileName = Utilities.GetBaseFileName(filename, extension) +
                                            transformEngine.GetOutputExtension(filename);
                       text = transformEngine.Transform(filename, text, null);
                       System.IO.File.WriteAllText(minFileName, text);
                       System.Console.WriteLine(string.Format("{0} -- {1}", transformEngine.GetType().Name, filename));
                   }
               }
           }
       }
    }
}
