using AnyDeckBuilder.Data;
using System.Data;

namespace AnyDeckBuilder
{
    public partial class DataViewForm : Form
    {
        public DataViewForm()
        {
            InitializeComponent();
        }

        public static event Action<string>? OnFailedImport;
        public static event Action<Card[]>? OnSuccessfulImport;
        public static event Action? OnDeckImport;

        public DataViewForm(DataTable table, string? path = null)
        {
            InitializeComponent();
            SetData(table);
            if (path != null)
                textBox1.Text = path;
        }

        public void SetData(DataTable table)
        {
            ClearGrid();
            dataGridView1.DataSource = table;
        }

        private void ClearGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            OnFailedImport?.Invoke("Cancel");
            Close();
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        using (var sr = new StreamReader(stream))
                        {
                            var table = Utility.ParseFile(sr, ",");
                            SetData(table);
                            textBox1.Text = openFileDialog.FileName;
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            List<Card> cardsToImport = new List<Card>();
            bool includesDeck = dataGridView1.Columns.Contains("DECK");
            if (includesDeck)
            {
                ImportDecks();
                Close();
                return;
            }

            int max = includesDeck ? Card.Table.COLUMNS_LENGTH + 1 : Card.Table.COLUMNS_LENGTH;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row == null)
                    continue;

                if (row.IsNewRow)
                    continue;

                int index = includesDeck ? 1 : 0;
                Card.Builder builder = new Card.Builder()
                    .SetGUID(row.GetValueAt(index++))
                    .SetName(row.GetValueAt(index++))
                    .SetDescription(row.GetValueAt(index++))
                    .SetImagePath(row.GetValueAt(index++))
                    .SetTemplate(row.GetValueAt(index++));

                for (int i = row.Cells.Count - 1; i >= max; i--)
                    builder.SetProperty(i - max, row.GetValueAt(i - max));

                Card card = builder.Build();
                if (card != null && !string.IsNullOrEmpty(card.guid))
                    cardsToImport.Add(card);
            }

            var cardsArray = cardsToImport.ToArray();
            ProjectFile.Current.AddCards(cardsArray);
            OnSuccessfulImport?.Invoke(cardsArray);
            Close();
        }

        private void ImportDecks()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row == null)
                    continue;

                if (row.IsNewRow)
                    continue;

                int index = 1;
                const int BASE_COLUMNS_LENGTH = 6;
                Card.Builder builder = new Card.Builder()
                    .SetGUID(row.GetValueAt(index++))
                    .SetName(row.GetValueAt(index++))
                    .SetDescription(row.GetValueAt(index++))
                    .SetImagePath(row.GetValueAt(index++))
                    .SetTemplate(row.GetValueAt(index++));

                for (int i = row.Cells.Count - 1; i >= BASE_COLUMNS_LENGTH; i--)
                {
                    builder.SetProperty(i - BASE_COLUMNS_LENGTH, row.GetValueAt(i));
                    Console.WriteLine($"Index: {i} Property Index: {i - BASE_COLUMNS_LENGTH}");
                }

                Card card = builder.Build();
                ProjectFile.Current.AddCard(card);

                string? deckName = row.GetValueAt(0);
                if (string.IsNullOrEmpty(deckName))
                    continue;

                var deck = ProjectFile.Current.GetOrAddDeck(row.GetValueAt(0));
                deck.AddCard(card.guid);
            }
            OnDeckImport?.Invoke();
        }
    }
}
