namespace Zippy.Chirp
{
    /// <summary>
    /// Three levels of compilation, ranging from simple removal of whitespace and comments to aggressive code transformations
    /// </summary>
    public enum ClosureCompilerCompressMode
    {
        /// <summary>
        /// Not set
        /// </summary>
        None = 0,

       /// <summary>
        /// removes comments from your code and also removes line breaks, unnecessary spaces, and other whitespace.Renaming local variables and function parameters to shorter names
       /// </summary>
        SIMPLE_OPTIMIZATIONS = 1,

       /// <summary>
        /// removes comments from your code and also removes line breaks, unnecessary spaces, and other whitespace
       /// </summary>
        WHITESPACE_ONLY = 2,

       /// <summary>
       /// Advanced mode
       /// </summary>
        ADVANCED_OPTIMIZATIONS = 3
    }
}
