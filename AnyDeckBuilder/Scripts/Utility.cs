using AnyDeckBuilder.Data;
using System.Drawing.Imaging;

namespace AnyDeckBuilder
{
    public static class Utility
    {
        private static Dictionary<string, CardTemplate> m_cardTemplatesDict = new Dictionary<string, CardTemplate>();

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

        public static CardTemplate[] GetCardTemplates()
        {
            if (m_cardTemplatesDict == null)
                m_cardTemplatesDict = new Dictionary<string, CardTemplate>();

            if (m_cardTemplatesDict.Count == 0)
                AddTemplatesToDictionary();

            return m_cardTemplatesDict.Values.ToArray();
        }

        public static bool TryGetCardTemplate(string name, out CardTemplate? template)
        {
            template = null;
            if (string.IsNullOrEmpty(name))
                return false;

            if (m_cardTemplatesDict.TryGetValue(name, out template))
                return true;
            return false;
        }

        private static void AddTemplatesToDictionary()
        {
            var files = Directory.GetFiles("Card Templates");
            foreach (var filepath in files)
            {
                Console.WriteLine(filepath);
                if (Path.GetExtension(filepath) != ".json")
                    continue;

                FileStream stream = File.Open(filepath, FileMode.Open);
                TextReader reader = new StreamReader(stream);
                string json = reader.ReadToEnd();

                var template = Newtonsoft.Json.JsonConvert.DeserializeObject<CardTemplate>(json);
                Console.WriteLine("Template Summary\n" + template.ToString());
                if (template != null)
                {
                    m_cardTemplatesDict.Add(template.name, template);
                }
            }
        }
    }
}
