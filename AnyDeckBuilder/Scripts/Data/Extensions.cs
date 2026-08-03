namespace AnyDeckBuilder.Data
{
    public static class Extensions
    {
        public static bool IsUsingTemplate(this Card card, CardTemplate template)
        {
            if (card == null || template == null)
                return false;

            if (!string.IsNullOrEmpty(card.templateName) && card.templateName.Equals(template.name))
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

        public static string? GetValueAt(this DataGridViewRow row, int index)
        {
            if (row == null)
            {
                throw new Exception("Row cannot be null");
            }
            var val = row.Cells[index].Value;
            if (string.IsNullOrEmpty(val.ToString()))
                return string.Empty;
            return val.ToString();
        }
    }
}