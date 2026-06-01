using System.Drawing.Imaging;

namespace AnyDeckBuilder
{
    public static class Utility
    {
        public static ImageFormat GetImageFormat(string filename)
        {
            string ext = Path.GetExtension(filename);
            var argExcpetion = new ArgumentException($"Unable to determine file extension for fileName: {filename}");
            if (string.IsNullOrEmpty(ext))
                throw argExcpetion;

            switch (ext.ToLower())
            {
                case @".png":
                    return ImageFormat.Png;
                case @".jpg":
                case @".jpeg":
                    return ImageFormat.Jpeg;
                default:
                    throw argExcpetion;
            }
        }
    }
}
