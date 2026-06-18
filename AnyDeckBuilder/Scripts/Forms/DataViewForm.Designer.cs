namespace AnyDeckBuilder
{
    partial class DataViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            splitContainer1 = new SplitContainer();
            chooseFileButton = new Button();
            textBox1 = new TextBox();
            cancelButton = new Button();
            importButton = new Button();
            openFileDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(800, 373);
            dataGridView1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(chooseFileButton);
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Panel2.Controls.Add(cancelButton);
            splitContainer1.Panel2.Controls.Add(importButton);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 373;
            splitContainer1.TabIndex = 1;
            // 
            // chooseFileButton
            // 
            chooseFileButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            chooseFileButton.Location = new Point(598, 17);
            chooseFileButton.Name = "chooseFileButton";
            chooseFileButton.Size = new Size(68, 34);
            chooseFileButton.TabIndex = 3;
            chooseFileButton.Text = "Path";
            chooseFileButton.UseVisualStyleBackColor = true;
            chooseFileButton.Click += chooseFileButton_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(141, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(455, 31);
            textBox1.TabIndex = 2;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelButton.Location = new Point(23, 17);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 34);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // importButton
            // 
            importButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            importButton.Location = new Point(669, 17);
            importButton.Name = "importButton";
            importButton.Size = new Size(112, 34);
            importButton.TabIndex = 0;
            importButton.Text = "Import";
            importButton.UseVisualStyleBackColor = true;
            importButton.Click += importButton_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "CSV File|*.csv|All Files|*.*";
            // 
            // DataViewForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "DataViewForm";
            Text = "DataViewForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private SplitContainer splitContainer1;
        private Button importButton;
        private Button cancelButton;
        private Button chooseFileButton;
        private TextBox textBox1;
        private OpenFileDialog openFileDialog;
    }
}