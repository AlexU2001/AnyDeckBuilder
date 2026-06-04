namespace AnyDeckBuilder.Data
{
    public static class Extensions
    {
        public static bool IsUsingTemplate(this Card card, CardTemplate template)
        {
            if (card == null || template == null)
                return false;

            if (card.templateName != null && card.templateName.Equals(template.name))
                return true;

            if (card.properties == null && template.properties == null)
                return true;

            if (card.properties?.Length != template.properties?.Length)
                return false;

            for (int i = 0; i < card.properties?.Length; i++)
            {
                if (!card.properties[i].Equals(template.properties?[i]))
                    return false;
            }
            return true;
        }
    }
}