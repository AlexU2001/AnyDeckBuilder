


namespace AnyDeckBuilder
{
    partial class CardDisplay
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
            cardImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)cardImage).BeginInit();
            SuspendLayout();
            // 
            // cardImage
            // 
            cardImage.Dock = DockStyle.Fill;
            cardImage.Image = Properties.Resources.ClickToSelectAnImage;
            cardImage.Location = new Point(0, 0);
            cardImage.Name = "cardImage";
            cardImage.Size = new Size(540, 810);
            cardImage.SizeMode = PictureBoxSizeMode.Zoom;
            cardImage.TabIndex = 0;
            cardImage.TabStop = false;
            cardImage.DoubleClick += cardImage_DoubleClick;
            // 
            // CardDisplay
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cardImage);
            Name = "CardDisplay";
            Size = new Size(540, 810);
            ((System.ComponentModel.ISupportInitialize)cardImage).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private PictureBox cardImage;
    }
}
