using AnyDeckBuilder.Data;

namespace AnyDeckBuilder
{
    public partial class CardDisplay : UserControl
    {
        public Card card;
        public CardDisplay(Card card)
        {
            InitializeComponent();
            CreateContextMenu();
            this.card = card;
            DragEnter += CardDisplay_DragEnter;
            DragDrop += CardDisplay_DragDrop;
            SetCard(card);
        }

        public void SetCard(Card card)
        {
            this.card = card;
            if (card.imagePath != null)
            {
                cardImage.Image = Bitmap.FromFile(card.imagePath);
            }
            else
            {
                cardImage.Image = Properties.Resources.Black;
                cardImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void CardDisplay_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void CardDisplay_DragDrop(object? sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files?.Length == 1)
            {
                Console.WriteLine(files[0]);
                var img = Bitmap.FromFile(files[0]);
                if (img != null)
                    cardImage.Image = img;
                /*MessageBox.Show("Would you like to edit and replace this card's image?\nGo to settings to disable this warning", "Replace Action Warning",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);*/
            }
        }


        private void cardImage_DoubleClick(object sender, EventArgs e)
        {
            // Show a display form
        }

        private void CreateContextMenu()
        {
            ContextMenuStrip menuStrip = new ContextMenuStrip();

            ToolStripMenuItem editCardMenuItem = new ToolStripMenuItem();
            editCardMenuItem.Name = "editCardMenuItem";
            editCardMenuItem.Text = "Edit";
            editCardMenuItem.Click += EditCardMenuItem_Click;

            ToolStripMenuItem removeCardMenuItem = new ToolStripMenuItem();
            removeCardMenuItem.Name = "removeCardMenuItem";
            removeCardMenuItem.Text = "Remove";
            removeCardMenuItem.Click += RemoveCardMenuItem_Click;

            menuStrip.Items.Add(editCardMenuItem);
            menuStrip.Items.Add(removeCardMenuItem);
            ContextMenuStrip = menuStrip;

        }

        private void RemoveCardMenuItem_Click(object? sender, EventArgs e)
        {
            Console.WriteLine("Removing card from deck");
        }

        private void EditCardMenuItem_Click(object? sender, EventArgs e)
        {
            Console.WriteLine("Opening card edit form");
            CardCustomizationForm form = new CardCustomizationForm(this);
            form.ShowDialog();
        }
    }
}
