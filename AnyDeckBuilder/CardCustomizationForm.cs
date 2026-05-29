using AnyDeckBuilder.Data;
using AnyDeckBuilder.Data;
using System.Security;

namespace AnyDeckBuilder
{
    public partial class CardCustomizationForm : Form
    {
        public CardDisplay? display;
        public Card card;
        public bool isEditing;
        public static event EventHandler<Card>? OnCardCreate;
        public event EventHandler<Card>? OnCardUpdate;
        public CardCustomizationForm()
        {
            InitializeComponent();
            InitializeSettings();
            card = new Card();
        }

        public CardCustomizationForm(CardDisplay display)
        {
            this.display = display;
            this.card = display.card;
            InitializeComponent();
            InitializeSettings();
            if (card.imagePath != null)
                cardImage.Image = Bitmap.FromFile(card.imagePath);
            else
            {
                cardImage.Image = Properties.Resources.Black;
            }

            isEditing = true;
            idTextBox.Text = card.id;
            nameTextBox.Text = card.name;
            descriptionTextBox.Text = card.description;
        }

        private void InitializeSettings()
        {
            addToCurrentDeckCheckBox.Checked = ProjectFile.Current.autoAddCardToCurrentDeck;
        }

        private void cardImage_Click(object sender, EventArgs e)
        {
            if (openImageFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openImageFileDialog.FileName;
                    using (Stream str = openImageFileDialog.OpenFile())
                    {
                        var img = Bitmap.FromStream(str);
                        cardImage.Image = img;
                        card.imagePath = filePath;
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveCard(ref card);
            if (!isEditing)
            {
                ProjectFile.Current.AddCard(card);
                OnCardCreate?.Invoke(this, card);
            }
            else
            {
                Console.WriteLine("Saving Edits");
                OnCardUpdate?.Invoke(this, card);
            }
            Close();
        }

        private void SaveCard(ref Card card)
        {
            card.name = $"{nameTextBox.Text}";
            card.id = $"{idTextBox.Text}";
            card.description = $"{descriptionTextBox.Text}";
            if (display != null)
                display.SetCard(card);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ProjectFile.Current.autoAddCardToCurrentDeck = addToCurrentDeckCheckBox.Checked;
        }
    }
}
