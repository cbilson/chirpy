using System;

namespace Zippy.Chirp.Engines
{
    public class EnvironmentDirectory : IDisposable
    {
        private string currentDirectory = string.Empty;

        public EnvironmentDirectory(string file)
        {
            this.currentDirectory = System.Environment.CurrentDirectory;
            Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(file);
        }

        public void Dispose()
        {
            System.Environment.CurrentDirectory = this.currentDirectory;
        }
    }
}
