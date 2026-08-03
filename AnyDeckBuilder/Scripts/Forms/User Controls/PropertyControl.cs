using AnyDeckBuilder.Data;

namespace AnyDeckBuilder
{
    public partial class PropertyControl : UserControl
    {
        public const string INPUT_TAG = " Input";
        public Card card;
        public CardProperty cardProperty;

        public ComboBox? dropDown;
        public TextBox? textBox;
        public PropertyControl(Card card, CardProperty cardProperty)
        {
            this.card = card;
            this.cardProperty = cardProperty;
            InitializeComponent();
            propertyLabel.Text = cardProperty.Name;

            if (!cardProperty.isValid)
            {
                Console.WriteLine($"Card {card.name} contains an invalid property: {cardProperty.Name}");
                return;
            }
            switch (cardProperty.controlType)
            {
                case ControlType.Text:
                case ControlType.Number:
                    textBox = new TextBox();
                    textBox.Name = cardProperty.Name + INPUT_TAG;
                    splitContainer.Panel2.Controls.Add(textBox);
                    textBox.Dock = DockStyle.Fill;
                    break;
                case ControlType.DropDown:
                case ControlType.DropDownMultiSelect:
                    dropDown = new ComboBox();
                    dropDown.Name = cardProperty.Name + " Input";
                    dropDown.DropDownStyle = ComboBoxStyle.DropDownList;
                    splitContainer.Panel2.Controls.Add(dropDown);
                    dropDown.Dock = DockStyle.Fill;

                    dropDown.Items.Add("Unset");
                    dropDown.SelectedIndex = 0;
                    foreach (var option in cardProperty.Values)
                    {
                        dropDown.Items.Add(option);
                    }
                    break;
                default:
                    break;
            }
        }

        public void SetValue(params string[] values)
        {
            if (values == null || values.Length == 0)
                return;

            switch (cardProperty.controlType)
            {
                case ControlType.Text:
                case ControlType.Number:
                    if (textBox != null)
                        textBox.Text = values[0];
                    break;
                case ControlType.DropDown:
                    if (dropDown != null)
                        dropDown.SelectedItem = values[0];
                    break;
                case ControlType.DropDownMultiSelect:
                    if (dropDown != null)
                        dropDown.SelectedItem = values[0];
                    break;
                default:
                    break;
            }
        }
    }
}
