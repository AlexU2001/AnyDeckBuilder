using AnyDeckBuilder.Data;
using System.Drawing.Imaging;
using System.Security;
using System.Text;

namespace AnyDeckBuilder
{
    public partial class DeckViewForm : Form
    {
        private const int EXPORT_COLUMNS = 10;
        private const string TTS_SCRIPT_TEMPLATE = "Resources/TabletopSimulatorScriptTemplate.lua";
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
        private void saveProjectAsButton_Click(object sender, EventArgs e)
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
            if (ProjectFile.isNull || ProjectFile.Current.decks.Count == 0)
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

                foreach (var cardGuid in deck.cards)
                {
                    if (!ProjectFile.Current.TryGetCard(cardGuid, out Card card))
                        continue;

                    deckView.Nodes[i].Nodes.Add(card.name);
                }
            }
        }

        private void LoadDeck(Deck deck)
        {
            if (deck == null)
                return;

            if (layoutPanel.Controls.Count > 0)
                EmptyLayout();

            foreach (var cardGuid in deck.cards)
            {
                if (!ProjectFile.Current.TryGetCard(cardGuid, out Card card))
                    continue;
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

        private void AddCardToDeck(Deck deck, Card card, bool addDisplay = false)
        {
            if (deck == null)
                return;

            if (!ProjectFile.Current.cardsDict.ContainsKey(card.guid))
                ProjectFile.Current.AddCard(card);

            deck.AddCard(card.guid);
            if (addDisplay)
                AddCardDisplay(card);
        }
        #endregion
        #region Panel1
        private void DeckView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
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
                    if (deck == selectedDeck)
                        return;

                    selectedDeck = deck;
                    LoadDeck(deck);
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

            if (selectedDeck == null)
                return;

            AddCardToDeck(selectedDeck, card, true);
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
        private void LayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void LayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                Card card = new Card()
                {
                    name = Path.GetFileNameWithoutExtension(file),
                    imagePath = file,
                };
                AddCardToDeck(selectedDeck, card, true);
            }
        }
        #endregion

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedDeck == null || selectedDeck.cards == null)
                return;

            ExportAs();
        }

        private void ExportAs()
        {
            if (selectedDeck == null || selectedDeck.cards == null)
                return;

            if (!string.IsNullOrEmpty(selectedDeck.exportPath))
                saveExportedFileDialog.InitialDirectory = Path.GetDirectoryName(selectedDeck.exportPath);

            saveExportedFileDialog.FileName = selectedDeck.exportName;
            if (saveExportedFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var stream = new FileStream(saveExportedFileDialog.FileName, FileMode.Create))
                    {
                        selectedDeck.exportPath = saveExportedFileDialog.FileName;
                        ExportFileToPath(stream);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void ExportFileToPath(FileStream stream)
        {
            if (selectedDeck?.cards == null)
                return;

            var cardSize = GetCardSize();
            var dimensions = GetExportDimensions();
            var canvasSize = GetCanvasSize(cardSize, dimensions);

            using (var canvas = new Bitmap(canvasSize.Width, canvasSize.Height))
            {
                //Console.WriteLine($"Canvas Size: {canvas.Size}");
                using (var gr = Graphics.FromImage(canvas))
                {
                    gr.Clear(Color.Black);
                    int index = 0;
                    foreach (var cardGuid in selectedDeck.cards)
                    {
                        if (!ProjectFile.Current.TryGetCard(cardGuid, out Card card))
                            continue;

                        if (card.imagePath == null)
                            continue;

                        int x = cardSize.Width * (index % dimensions.Width);
                        int y = cardSize.Height * (index / dimensions.Width);
                        var rectangle = new Rectangle(x, y, cardSize.Width, cardSize.Height);
                        Console.WriteLine($"{card.name}'s Rectangle: {rectangle}");
                        Image image = Bitmap.FromFile(card.imagePath);
                        gr.DrawImage(image, rectangle);
                        index++;
                    }
                    var format = GetFormatFromFilterIndex(saveExportedFileDialog.FilterIndex);
                    canvas.Save(stream, format);
                }
            }
        }

        private ImageFormat GetFormatFromFilterIndex(int index)
        {
            switch (index)
            {
                case 1:
                    return ImageFormat.Png;
                case 2:
                    return ImageFormat.Jpeg;
                default:
                    throw new ArgumentException("Unable to determine file format");
            }
        }

        private Size GetExportDimensions()
        {
            if (selectedDeck == null)
                return ProjectFile.Current.exportDimensions;

            var dimensions = ProjectFile.Current.exportDimensions;
            if (ProjectFile.Current.autoExportSize && selectedDeck.cards != null)
            {
                dimensions.Width = EXPORT_COLUMNS;
                dimensions.Height = (selectedDeck.cards.Count / EXPORT_COLUMNS) + 1;
            }
            selectedDeck.exportX = dimensions.Width;
            selectedDeck.exportY = dimensions.Height;
            return dimensions;
        }

        private Size GetCardSize()
        {
            if (selectedDeck == null || selectedDeck.cards == null)
            {
                Console.WriteLine("Exiting, null deck or empty cards list");
                return ProjectFile.Current.cardSize;
            }

            foreach (var cardGuid in selectedDeck.cards)
            {
                if (!ProjectFile.Current.TryGetCard(cardGuid, out Card card))
                    continue;


                if (Utility.TryGetCardTemplate(card.templateName, out var template))
                {
                    if (!template.dynamicSize)
                        return template.size;
                }

                if (card.imagePath != null)
                {
                    Image referenceImage = Bitmap.FromFile(card.imagePath);
                    return new Size(referenceImage.Width, referenceImage.Height);
                }
            }
            Console.WriteLine("Failed to get card size");
            return new Size(100, 100);
        }

        private Size GetCanvasSize(Size cardSize, Size dimensions)
        {
            int columns = dimensions.Width;
            int rows = dimensions.Height;
            Console.WriteLine($"Card Size: {cardSize} Dimensions: {dimensions}");
            return new Size(cardSize.Width * columns, cardSize.Height * rows);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tTSDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedDeck == null)
                return;

            string jsonFile = $"jsonString = [[{ProjectFile.Current.ToJSON()}]]"; 
            string script = jsonFile + "\n" + File.ReadAllText(TTS_SCRIPT_TEMPLATE);
            if (script == null)
                return;

            Clipboard.SetText(script);
            Console.WriteLine($"Copied Lua Script: \n {script}");
        }
    }
}
