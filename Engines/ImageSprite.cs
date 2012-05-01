using System.Linq;

namespace Zippy.Chirp.Engines
{
    public static class ImageSprite
    {
        private static System.Text.RegularExpressions.Regex regexImage = new System.Text.RegularExpressions.Regex(@"\.(jpg|gif|png)$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

        public static bool IsImage(string path)
        {
            return regexImage.IsMatch(path);
        }

        public static byte[] Build(Xml.FileGroupXml group, string spriteFile)
        {
            var bmps = group.Files.Select(x => new System.Drawing.Bitmap(x.Path));

            var maxWidth = bmps.Max(x => x.Width);
            var totalHeight = bmps.Sum(x => x.Height);

            int top = 0;
            using (var sprite = new System.Drawing.Bitmap(maxWidth, totalHeight))
            using (var mem = new System.IO.MemoryStream())
            using (var g = System.Drawing.Graphics.FromImage(sprite))
            {
                foreach (var bmp in bmps)
                {
                    using (bmp)
                    {
                        g.DrawImage(bmp, new System.Drawing.Rectangle(0, top, bmp.Width, bmp.Height), new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.GraphicsUnit.Pixel);
                        top += bmp.Height;
                    }
                }

                sprite.Save(mem, GetFormat(spriteFile) ?? System.Drawing.Imaging.ImageFormat.Png);
                return mem.ToArray();
            }
        }

        private static System.Drawing.Imaging.ImageFormat GetFormat(string file)
        {
            var ext = System.IO.Path.GetExtension(file).ToLower();
            if (ext == ".jpg")
            {
                return System.Drawing.Imaging.ImageFormat.Jpeg;
            }

            if (ext == ".gif")
            {
                return System.Drawing.Imaging.ImageFormat.Gif;
            }

            if (ext == ".png")
            {
                return System.Drawing.Imaging.ImageFormat.Png;
            }

            return null;
        }
    }
}
