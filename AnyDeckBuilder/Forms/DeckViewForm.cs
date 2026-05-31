using AnyDeckBuilder.Data;
using System.Drawing.Imaging;
using System.Security;
using System.Text;

namespace AnyDeckBuilder
{
    public partial class DeckViewForm : Form
    {
        private const int EXPORT_COLUMNS = 10;
        public Deck? selectedDeck;
        public DeckViewForm()
        {
            InitializeComponent();
            LoadProjectData();
            AdjustContentSize();
            CardCustomizationForm.OnCardCreate += UpdateDeckView;
        }
        #region Main Toolbar
        private void newFileButton_Click(object sender, EventArgs e)
        {
            var deckView = new DeckViewForm();
            deckView.Show();
            Hide();
        }
        private void saveProjectButton_Click(object sender, EventArgs e)
        {
            SaveCurrent();
        }

        private void SaveCurrent()
        {
            if (ProjectFile.Current.FilePath == null || ProjectFile.Current.FilePath == string.Empty)
            {
                SaveAs();
                return;
            }

            try
            {
                using (var stream = new FileStream(ProjectFile.Current.FilePath, FileMode.Create))
                {
                    // get bytes from text you want to save
                    byte[] data = new UTF8Encoding().GetBytes(ProjectFile.Current.ToJSON());
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                }
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                $"Details:\n\n{ex.StackTrace}");
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void SaveAs()
        {
            saveProjectDIalog.FileName = ProjectFile.Current.Name;
            if (saveProjectDIalog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var stream = new FileStream(saveProjectDIalog.FileName, FileMode.Create))
                    {
                        ProjectFile.Current.FilePath = saveProjectDIalog.FileName;

                        // get bytes from text you want to save
                        byte[] data = new UTF8Encoding().GetBytes(ProjectFile.Current.ToJSON());
                        stream.Write(data, 0, data.Length);
                        stream.Flush();
                    }

                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (openProjectDialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new FileStream(openProjectDialog.FileName, FileMode.Open))
                {
                    using (var sr = new StreamReader(stream))
                    {
                        var jsonString = sr.ReadToEnd();
                        var projectFile = Newtonsoft.Json.JsonConvert.DeserializeObject<ProjectFile>(jsonString);
                        Console.WriteLine($"Opening project file {stream.Name}");
                        ProjectFile.SetCurrent(projectFile);
                        LoadProjectData();
                    }
                }
            }
        }
        private void LoadProjectData()
        {
            if (ProjectFile.Current.decks.Count <= 0)
            {
                selectedDeck = new Deck("Untitled Deck");
                ProjectFile.Current.AddDeck(selectedDeck);
            }
            else
            {
                selectedDeck = ProjectFile.Current.decks[0];
            }

            ReloadNodesPanel();
            LoadDeck(selectedDeck);
        }

        private void ReloadNodesPanel()
        {
            deckView.Nodes.Clear();
            for (int i = 0; i < ProjectFile.Current.decks.Count; i++)
            {
                var deck = ProjectFile.Current.decks[i];
                deckView.Nodes.Add(deck.name);

                if (deck.cards == null)
                    continue;

                foreach (var card in deck.cards)
                {
                    deckView.Nodes[i].Nodes.Add(card.name);
                }
            }
        }

        private void LoadDeck(Deck selectedDeck)
        {
            if (selectedDeck == null)
                return;

            if (layoutPanel.Controls.Count > 0)
                EmptyLayout();

            foreach (var card in selectedDeck.cards)
            {
                AddCardDisplay(card);
            }
        }

        private void EmptyLayout()
        {
            for (int i = layoutPanel.Controls.Count - 1; i >= 0; i--)
            {
                var control = layoutPanel.Controls[i];
                layoutPanel.Controls.RemoveAt(i);
                control.Dispose();
            }
        }

        private void AddCardDisplay(Card card)
        {
            var display = new CardDisplay(card);
            display.Size = currentSize;
            layoutPanel.Controls.Add(display);
        }
        #endregion
        #region Panel1
        private void deckView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Parent == null)
            {
                // open card editing
                return;
            }

            foreach (var deck in ProjectFile.Current.decks)
            {
                if (deck.name == e.Node?.Name)
                {
                    selectedDeck = deck;
                    return;
                }
            }
        }
        #endregion
        #region Panel 2
        public AspectRatio sizeAspectRatio = new AspectRatio { height = 3, width = 2 };
        private Size currentSize => sizeAspectRatio.GetSize(sizeIndex);
        public int sizeIndex
        {
            get => m_sizeIndex; set
            {
                m_sizeIndex = Math.Clamp(value, 1, 10);
                Console.WriteLine("Set size to " + sizeIndex);
            }
        }
        private int m_sizeIndex = 5;


        private void AdjustContentSize()
        {
            AdjustMaxContentSize(sizeAspectRatio.GetSize(10));
            AdjustMinimumContentSize(sizeAspectRatio.GetSize(1));
            AdjustContentSize(currentSize);
        }

        private void UpdateDeckView(object? sender, Card card)
        {
            if (!ProjectFile.Current.autoAddCardToCurrentDeck) return;
            selectedDeck?.AddCard(card);
            AddCardDisplay(card);
        }

        #region Zoom
        private void MinusZoomButton_Click(object sender, EventArgs e)
        {
            AdjustContentSize(sizeAspectRatio.GetSize(--sizeIndex));
        }
        private void PlusZoomButton_Click(object sender, EventArgs e)
        {
            AdjustContentSize(sizeAspectRatio.GetSize(++sizeIndex));
        }

        private void AdjustContentSize(Size size)
        {
            zoomAmountDropDown.Text = $"{sizeIndex * 20}%";
            foreach (Control control in layoutPanel.Controls)
            {
                control.Size = size;
            }
        }

        private void AdjustMaxContentSize(Size size)
        {
            foreach (Control control in layoutPanel.Controls)
            {
                control.MaximumSize = size;
            }
        }

        private void AdjustMinimumContentSize(Size size)
        {
            foreach (Control control in layoutPanel.Controls)
            {
                control.MinimumSize = size;
            }
        }
        private void ZoomAmountDropDown_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem?.Text)
            {
                case "20%":
                    sizeIndex = 1;
                    break;
                case "40%":
                    sizeIndex = 2;
                    break;
                case "60%":
                    sizeIndex = 3;
                    break;
                case "80%":
                    sizeIndex = 4;
                    break;
                case "100%":
                    sizeIndex = 5;
                    break;
                case "120%":
                    sizeIndex = 6;
                    break;
                case "140%":
                    sizeIndex = 7;
                    break;
                case "160%":
                    sizeIndex = 8;
                    break;
                case "180%":
                    sizeIndex = 9;
                    break;
                case "200%":
                    sizeIndex = 10;
                    break;
            }
            AdjustContentSize(sizeAspectRatio.GetSize(sizeIndex));
        }
        #endregion

        private void newCardButton_Click(object sender, EventArgs e)
        {
            new CardCustomizationForm().ShowDialog();
        }
        #endregion

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedDeck == null || selectedDeck.cards == null)
                return;

            int count = selectedDeck.cards.Count;
            int rows = (count / EXPORT_COLUMNS) + 1;

            var referenceCard = selectedDeck.cards[0];
            for (int i = 1; i < count && referenceCard.imagePath == null; i++)
            {
                referenceCard = selectedDeck.cards[i];
            }
            Image referenceImage = Bitmap.FromFile(referenceCard.imagePath);
            var refWidth = referenceImage.Width;
            var refHeight = referenceImage.Height;
            using (var canvas = new Bitmap(refWidth * EXPORT_COLUMNS, refHeight * rows, PixelFormat.Format32bppArgb))
            {
                using (var gr = Graphics.FromImage(canvas))
                {
                    gr.Clear(Color.Black);
                    int index = 0;
                    foreach (var currentCard in selectedDeck.cards)
                    {
                        if (currentCard.imagePath == null)
                            continue;

                        Image image = Bitmap.FromFile(currentCard.imagePath);
                        int width = refWidth * index;
                        int height = refHeight * (index / EXPORT_COLUMNS);
                        var rectangle = new Rectangle(width, height, refWidth, refHeight);
                        Console.WriteLine($"Rectangle: {rectangle}");
                        gr.DrawImage(image, rectangle);
                        string path = Path.Combine(Path.GetDirectoryName(ProjectFile.Current.FilePath), "TestExport.png");
                        canvas.Save(path, ImageFormat.Png);

                        index++;
                    }
                }
            }
        }
    }
}
