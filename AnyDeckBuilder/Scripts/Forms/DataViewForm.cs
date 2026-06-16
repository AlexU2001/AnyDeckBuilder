using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyDeckBuilder
{
    public partial class DataViewForm : Form
    {
        public DataViewForm()
        {
            InitializeComponent();
        }


        public DataViewForm(DataTable table)
        {
            InitializeComponent();
            SetData(table);
        }

        public void SetData(DataTable table)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = table;
        }
    }
}
