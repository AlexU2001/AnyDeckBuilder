
namespace AnyDeckBuilder.Data
{
    public class CardTemplate
    {
        public string? name;
        public Size size;
        public bool dynamicSize = true;
        public CardProperty[]? properties;
        /// <summary>
        /// If the property should be treated as a tag when exporting to other platforms. Example, Table Top Simulator
        /// </summary>
        public bool propertyAsTag = true;

        public override string ToString()
        {
            string propertiesText = string.Empty;

            if (properties != null)
            {
                propertiesText += $"Contains {properties.Length} properties";
                foreach (var prop in properties)
                {
                    propertiesText += "\t\n" + prop.ToString();
                }
            }
            return $"Name: {name} Size: {size} Dynamic: {dynamicSize} \n{propertiesText}";
        }
    }
}
