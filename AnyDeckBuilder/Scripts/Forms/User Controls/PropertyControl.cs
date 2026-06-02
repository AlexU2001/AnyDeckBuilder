using AnyDeckBuilder.Data;

namespace AnyDeckBuilder
{
    public partial class PropertyControl : UserControl
    {
        public Card card;
        public CardProperty cardProperty;
        public PropertyControl(Card card, CardProperty cardProperty)
        {
            this.card = card;
            this.cardProperty = cardProperty;
            InitializeComponent();
            propertyLabel.Text = cardProperty.Name;
            switch (cardProperty.controlType)
            {
                case ControlType.Text:
                    TextBox textBox = new TextBox();
                    splitContainer.Panel2.Controls.Add(textBox);
                    textBox.Dock = DockStyle.Fill;
                    break;
                case ControlType.Number:
                    break;
                case ControlType.DropDown:
                    ComboBox comboBox = new ComboBox();
                    break;
                default:
                    break;
            }
        }
    }
}
