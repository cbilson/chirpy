
namespace Zippy.Chirp.Yui
{
    public class CssSettings
    {
         #region Constructors
        public CssSettings()
        {
            this.ColumnWidth = 0;
            this.RemoveComments = true;
        }
        #endregion

        public int ColumnWidth { get; set; }

        public bool RemoveComments { get; set; }
    }
}
