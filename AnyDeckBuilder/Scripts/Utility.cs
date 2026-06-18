using AnyDeckBuilder.Data;
using Microsoft.VisualBasic.FileIO;
using System.Data;
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

            if (m_cardTemplatesDict == null || m_cardTemplatesDict.Values.Count == 0)
                GetCardTemplates();

            if (m_cardTemplatesDict.TryGetValue(name.ToLower(), out template))
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
                    m_cardTemplatesDict.Add(template.name.ToLower(), template);
                }
            }
        }

        public static bool PathIsLocalFile(string path)
        {
            return File.Exists(path);
        }

        public static bool PathIsUrl(string path)
        {
            if (File.Exists(path))
                return false;
            try
            {
                Uri uri = new Uri(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static DataTable ParseFile(StreamReader reader, params string[] delimeters)
        {
            if (delimeters.Length == 0)
                return Card.Table.GetEmpty();
            DataTable table = Card.Table.GetEmpty();
            using (TextFieldParser parser = new TextFieldParser(reader))
            {
                bool hasHeaderBeenSkipped = false;
                var headerFields = new string[0];
                parser.SetDelimiters(delimeters);
                while (!parser.EndOfData)
                {
                    string[]? fields = parser.ReadFields();
                    if (fields == null)
                        continue;

                    if (!hasHeaderBeenSkipped)
                    {
                        if (fields[0].ToUpper().Equals("DECK"))
                            table.Columns.Add("DECK").SetOrdinal(0);

                        headerFields = fields;
                        hasHeaderBeenSkipped = true;
                        continue;
                    }


                    DataRow row = table.NewRow();

                    Console.WriteLine($"Parsing {fields.Length} fields");
                    if (table.Columns.Count == fields.Length || fields.Length < table.Columns.Count)
                        row.ItemArray = fields;
                    else if (fields.Length > table.Columns.Count)
                    {
                        Console.WriteLine("Expanding table...");
                        for (int i = table.Columns.Count; i < fields.Length; i++)
                        {
                            table.Columns.Add($"{headerFields[i]}");
                        }
                        row = table.NewRow();
                        row.ItemArray = fields;
                        foreach (string item in row.ItemArray)
                            Console.WriteLine(item);
                    }
                    table.Rows.Add(row);
                    Console.WriteLine($"Rows: {table.Rows.Count}");
                }
                return table;
            }
        }
    }
}
