namespace AnyDeckBuilder
{
    public static class ImageLibrary
    {
        private static Dictionary<string, Image> m_imageDictionary = new Dictionary<string, Image>();
        private const string DRIVE_DOWNLOAD_URL = "https://drive.google.com/uc?export=download&id=";
        public static async Task<Image> GetImageAsync(string path)
        {
            if (m_imageDictionary.ContainsKey(path))
                return m_imageDictionary[path];

            Image image;
            if (Utility.PathIsUrl(path))
            {
                var verifiedDownloadURL = TryConvertGoogleDriveToDownloadable(path);
                image = await GetImageViaURL(verifiedDownloadURL);
            }
            else
                image = GetImageViaPath(path);

            if (image == null)
                return null;

            m_imageDictionary.TryAdd(path, image);
            return image;
        }

        static async Task<Image> GetImageViaURL(string url)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();

                // Read the response to a MemoryStream, then create an Image copy that is independent
                using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                using (var ms = new MemoryStream())
                {
                    await contentStream.CopyToAsync(ms);
                    var bytes = ms.ToArray();

                    // Load into an Image, then create a Bitmap clone so it doesn't depend on the stream
                    using (var loaded = Image.FromStream(new MemoryStream(bytes)))
                    {
                        var clone = new Bitmap(loaded);
                        return clone;
                    }
                }
            }
        }

        private static string TryConvertGoogleDriveToDownloadable(string link)
        {
            if (link.Contains(DRIVE_DOWNLOAD_URL))
                return link;

            var array = link.Split("/d/");
            link = $"{DRIVE_DOWNLOAD_URL}" + array[1].Substring(0, 33);
            return link;
        }

        private static Image GetImageViaPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return Properties.Resources.Black;
            return new Bitmap(path);
        }
    }
}
