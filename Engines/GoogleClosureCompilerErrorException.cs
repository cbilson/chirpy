using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zippy.Chirp
{
   public class GoogleClosureCompilerErrorException : Exception
    {
        #region "constructor"
        public GoogleClosureCompilerErrorException()
            : base()
        {
        }

        public GoogleClosureCompilerErrorException(string message)
            : base(message)
        {
        }
        #endregion
    }
}
