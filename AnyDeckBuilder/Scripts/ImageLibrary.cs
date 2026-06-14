namespace AnyDeckBuilder
{
    public static class ImageLibrary
    {
        private static Dictionary<string, Image> m_imageDictionary = new Dictionary<string, Image>();

        public static async Task<Image> GetImageAsync(string path)
        {
            if (m_imageDictionary.ContainsKey(path))
                return m_imageDictionary[path];
            
            Image image;
            if (Utility.PathIsUrl(path))
                image = await GetImageViaURL(path);
            else
                image = GetImageViaPath(path);

            m_imageDictionary.Add(path, image);
            return image;
        }

        static async Task<Image> GetImageViaURL(string url)
        {
            Console.WriteLine("Getting image from url: " + url);
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

        private static Image GetImageViaPath(string path)
        {
            return new Bitmap(path);
        }
    }
}
