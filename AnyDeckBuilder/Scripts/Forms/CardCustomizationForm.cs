using AnyDeckBuilder.Data;
using System.Security;

namespace AnyDeckBuilder
{
    public partial class CardCustomizationForm : Form
    {
        public CardDisplay? display;
        public Card? PreEditCard;
        public Card Card;
        public bool isEditing;
        public static event EventHandler<Card>? OnCardCreate;
        public static event EventHandler<CardChangeArgs>? OnCardUpdate;
        public CardCustomizationForm()
        {
            InitializeComponent();
            InitializeSettings();
            LoadDefaults();
            Card = new Card();
        }

        private void LoadDefaults()
        {
            for (int i = 0; i < Utility.GetCardTemplates().Length; i++)
            {
                var template = Utility.GetCardTemplates()[i];
                if (template == null)
                    continue;

                var displayName = template.name;
                if (string.IsNullOrEmpty(template.name))
                    displayName = "Unnamed Template";

                templateComboBox.Items.Add(displayName);
                if (templateComboBox.SelectedIndex == -1)
                    templateComboBox.SelectedIndex = 0;

                if (Card != null && Card.IsUsingTemplate(template))
                    templateComboBox.SelectedIndex = i;
            }
        }

        public CardCustomizationForm(CardDisplay display)
        {
            this.Text = "Edit Card";
            this.display = display;
            this.Card = display.card;
            this.PreEditCard = new Card(display.card);
            InitializeComponent();
            InitializeSettings();
            LoadDefaults();
            LoadData();
        }

        private void LoadData()
        {
            if (Card.imagePath != null)
                SetCardImageLocation(Card.imagePath);
            else
            {
                cardPictureBox.Image = Properties.Resources.Black;
                HideControls();
            }


            isEditing = true;
            nameTextBox.Text = Card.name;
            descriptionTextBox.Text = Card.description;

            if (Card.properties == null)
                return;

            if (Card.templateName != null)
            {
                if (Utility.TryGetCardTemplate(Card.templateName, out var template))
                {
                    LoadProperties(template);
                    return;
                }
            }

            foreach (var template in Utility.GetCardTemplates())
            {
                if (Card.IsUsingTemplate(template))
                {
                    LoadProperties(template);
                    return;
                }
            }
        }

        private void LoadProperties(CardTemplate? template)
        {
            if (template == null || template.properties == null)
                return;

            for (var i = 0; i < template.properties.Length; i++)
            {
                var property = template.properties[i];
                var control = AddPropertyControl(property);
                if (Card.properties != null)
                {
                    control?.SetValue(Card.properties[i].Values);
                }
            }
        }

        private PropertyControl? AddPropertyControl(CardProperty property)
        {
            if (!property.isValid)
                return null;

            Console.WriteLine($"Adding {property}");
            PropertyControl prop = new PropertyControl(Card, property);
            prop.Name = property.Name + " propertyControl";
            propertiesPanel.Controls.Add(prop);
            return prop;
        }

        private void ClearProperties()
        {
            propertiesPanel.Controls.Clear();
        }

        private void InitializeSettings()
        {
            addToCurrentDeckCheckBox.Checked = ProjectFile.Current.autoAddCardToCurrentDeck;
        }

        private void SelectImageClick(object sender, EventArgs e)
        {
            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openImageFileDialog.FileName;
                    using (Stream str = openImageFileDialog.OpenFile())
                    {
                        SetCardImageLocation(filePath);
                    }
                    HideControls();
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void HideControls()
        {
            orLabel.Visible = false;
            selectImageButton.Visible = false;
            urlTextBox.SetBounds(80, 570, urlTextBox.Width, urlTextBox.Height);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveCard(ref Card);
            if (!isEditing)
            {
                ProjectFile.Current.AddCard(Card);
                OnCardCreate?.Invoke(this, Card);
            }
            else
            {
                OnCardUpdate?.Invoke(this, new CardChangeArgs(PreEditCard,Card));
            }
            Close();
        }

        private void SaveCard(ref Card card)
        {
            card.name = $"{nameTextBox.Text}";
            card.description = $"{descriptionTextBox.Text}";
            if (display != null)
                display.SetCard(card);

            if (templateComboBox.Items == null || templateComboBox.Items.Count <= 1)
                return;

            string? name = templateComboBox.Items?[templateComboBox.SelectedIndex].ToString();
            if (Utility.TryGetCardTemplate(name, out var template) && template != null)
            {
                card.templateName = template.name;
                if (template.properties == null)
                    return;

                SaveCardPropertiesUsingTemplate(ref card, template);
            }
        }

        private void SaveCardPropertiesUsingTemplate(ref Card card, CardTemplate template)
        {
            Console.WriteLine("Saving card properties");
            if (template.properties == null)
                return;

            string value = string.Empty;
            card.properties = (CardProperty[])template.properties.Clone();
            for (int i = 0; i < template.properties.Length; i++)
            {
                var controls = propertiesPanel.Controls;
                switch (template.properties[i].controlType)
                {
                    case ControlType.Text:
                    case ControlType.Number:
                        value = "Test value";
                        card.properties[i].SetValue(value);
                        break;
                    case ControlType.DropDown:
                    case ControlType.DropDownMultiSelect:
                        var control = controls.Find(template.properties[i].Name + PropertyControl.INPUT_TAG, true)[0];
                        if (control == null)
                        {
                            Console.WriteLine("Unable to find control");
                            continue;
                        }
                        ComboBox? comboBox = control as ComboBox;
                        if (comboBox != null)
                        {
                            int index = comboBox.SelectedIndex;
                            if (index == 0)
                            {
                                if (string.IsNullOrEmpty(card.properties[i].Value))
                                    card.properties[i].ClearValues();
                                continue;
                            }

                            value = template.properties[i].Values[index - 1];
                            Console.WriteLine("Value: " + value);
                            card.properties[i].SetValue(value);
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine($"Set value to " + value);
                Console.WriteLine($"Saved property {template.properties[i].Name}");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ProjectFile.Current.autoAddCardToCurrentDeck = addToCurrentDeckCheckBox.Checked;
        }

        private void templateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = templateComboBox.SelectedIndex;
            string? name = templateComboBox.Items?[index].ToString();
            Console.WriteLine($"Selection Changed: {index} {name}");
            if (Utility.TryGetCardTemplate(name, out var template))
            {
                if (template == null)
                {
                    Console.WriteLine("Template Null exception");
                    return;
                }
                if (Card.IsUsingTemplate(template) || template.properties == null)
                    return;

                ClearProperties();
                LoadProperties(template);
            }
            else
            {
                return;
            }
        }



        private void UrlTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Console.WriteLine("Pressed");
                this.ActiveControl = null;
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void UrlTextBox_LostFocus(object sender, EventArgs e)
        {
            SetCardImageLocation($"{urlTextBox.Text}");
            Console.WriteLine("Lost focus");
        }

        private void SetCardImageLocation(string location)
        {
            if (string.IsNullOrEmpty(location))
                return;

            cardPictureBox.ImageLocation = location;
            Card.imagePath = location;
            HideControls();
        }
    }
}
