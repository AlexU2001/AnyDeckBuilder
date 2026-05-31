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
    public enum ConfirmationActionType { ReplaceAction, DeleteAction }
    public partial class ConfirmationPopUpForm : Form
    {
        private ConfirmationPopUpForm()
        {
            InitializeComponent();
        }

        public ConfirmationPopUpForm(string label, ConfirmationActionType actionType)
        {
            actionLabel.Text = label;
            hideWarningCheckbox.Location = new Point(Width / 2, Height - 100);
        }
    }
}
