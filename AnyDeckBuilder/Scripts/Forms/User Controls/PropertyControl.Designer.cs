namespace AnyDeckBuilder
{
    partial class PropertyControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            propertyLabel = new Label();
            splitContainer = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.SuspendLayout();
            SuspendLayout();
            // 
            // propertyLabel
            // 
            propertyLabel.AutoSize = true;
            propertyLabel.Dock = DockStyle.Fill;
            propertyLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            propertyLabel.Location = new Point(3, 3);
            propertyLabel.Name = "propertyLabel";
            propertyLabel.Size = new Size(196, 32);
            propertyLabel.TabIndex = 0;
            propertyLabel.Text = "Property Name:";
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(propertyLabel);
            splitContainer.Panel1.Padding = new Padding(3);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Padding = new Padding(5);
            splitContainer.Size = new Size(637, 41);
            splitContainer.SplitterDistance = 212;
            splitContainer.TabIndex = 1;
            // 
            // PropertyControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer);
            Name = "PropertyControl";
            Size = new Size(637, 41);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label propertyLabel;
        private SplitContainer splitContainer;
    }
}
