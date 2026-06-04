namespace AnyDeckBuilder
{
    partial class CardCustomizationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardCustomizationForm));
            cardImage = new PictureBox();
            openImageFileDialog = new OpenFileDialog();
            nameTextBox = new TextBox();
            nameLabel = new Label();
            cardPropertiesLabel = new Label();
            descriptionLabel = new Label();
            descriptionTextBox = new TextBox();
            idTextBox = new TextBox();
            idLabel = new Label();
            cancelButton = new Button();
            saveButton = new Button();
            addToCurrentDeckCheckBox = new CheckBox();
            templateComboBox = new ComboBox();
            templateLabel = new Label();
            propertiesPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)cardImage).BeginInit();
            SuspendLayout();
            // 
            // cardImage
            // 
            cardImage.Image = Properties.Resources.ClickToSelectAnImage;
            cardImage.Location = new Point(35, 93);
            cardImage.Name = "cardImage";
            cardImage.Size = new Size(326, 457);
            cardImage.SizeMode = PictureBoxSizeMode.Zoom;
            cardImage.TabIndex = 0;
            cardImage.TabStop = false;
            cardImage.Click += cardImage_Click;
            // 
            // openImageFileDialog
            // 
            openImageFileDialog.FileName = "Select an image file";
            openImageFileDialog.Filter = "Image Files (*.png)|*.png";
            openImageFileDialog.Title = "Open image file";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(675, 93);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.PlaceholderText = "New Card Name";
            nameTextBox.Size = new Size(280, 31);
            nameTextBox.TabIndex = 2;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(599, 96);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(59, 25);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Name";
            // 
            // cardPropertiesLabel
            // 
            cardPropertiesLabel.AutoSize = true;
            cardPropertiesLabel.Location = new Point(389, 280);
            cardPropertiesLabel.Name = "cardPropertiesLabel";
            cardPropertiesLabel.Size = new Size(159, 25);
            cardPropertiesLabel.TabIndex = 5;
            cardPropertiesLabel.Text = "Custom Properties";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(388, 143);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(102, 25);
            descriptionLabel.TabIndex = 4;
            descriptionLabel.Text = "Description";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(491, 143);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.PlaceholderText = "New Card Description";
            descriptionTextBox.Size = new Size(464, 123);
            descriptionTextBox.TabIndex = 3;
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(491, 96);
            idTextBox.MinimumSize = new Size(40, 0);
            idTextBox.Name = "idTextBox";
            idTextBox.PlaceholderText = "#";
            idTextBox.Size = new Size(102, 31);
            idTextBox.TabIndex = 1;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(446, 99);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(30, 25);
            idLabel.TabIndex = 4;
            idLabel.Text = "ID";
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(314, 616);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 34);
            cancelButton.TabIndex = 4;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(467, 616);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(202, 34);
            saveButton.TabIndex = 5;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // addToCurrentDeckCheckBox
            // 
            addToCurrentDeckCheckBox.AutoSize = true;
            addToCurrentDeckCheckBox.Checked = true;
            addToCurrentDeckCheckBox.CheckState = CheckState.Checked;
            addToCurrentDeckCheckBox.Location = new Point(467, 667);
            addToCurrentDeckCheckBox.Name = "addToCurrentDeckCheckBox";
            addToCurrentDeckCheckBox.Size = new Size(202, 29);
            addToCurrentDeckCheckBox.TabIndex = 6;
            addToCurrentDeckCheckBox.Text = "Add To Current Deck";
            addToCurrentDeckCheckBox.UseVisualStyleBackColor = true;
            addToCurrentDeckCheckBox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // templateComboBox
            // 
            templateComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            templateComboBox.FormattingEnabled = true;
            templateComboBox.Location = new Point(613, 41);
            templateComboBox.Name = "templateComboBox";
            templateComboBox.Size = new Size(182, 33);
            templateComboBox.TabIndex = 0;
            templateComboBox.SelectedIndexChanged += templateComboBox_SelectedIndexChanged;
            // 
            // templateLabel
            // 
            templateLabel.AutoSize = true;
            templateLabel.Location = new Point(524, 44);
            templateLabel.Name = "templateLabel";
            templateLabel.Size = new Size(83, 25);
            templateLabel.TabIndex = 10;
            templateLabel.Text = "Template";
            // 
            // propertiesPanel
            // 
            propertiesPanel.Location = new Point(400, 325);
            propertiesPanel.Name = "propertiesPanel";
            propertiesPanel.Size = new Size(526, 269);
            propertiesPanel.TabIndex = 11;
            // 
            // CardCustomizationForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 708);
            Controls.Add(propertiesPanel);
            Controls.Add(templateLabel);
            Controls.Add(templateComboBox);
            Controls.Add(addToCurrentDeckCheckBox);
            Controls.Add(saveButton);
            Controls.Add(cancelButton);
            Controls.Add(cardImage);
            Controls.Add(cardPropertiesLabel);
            Controls.Add(descriptionLabel);
            Controls.Add(idLabel);
            Controls.Add(nameLabel);
            Controls.Add(descriptionTextBox);
            Controls.Add(idTextBox);
            Controls.Add(nameTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CardCustomizationForm";
            Text = "Edit Card";
            ((System.ComponentModel.ISupportInitialize)cardImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox cardImage;
        private OpenFileDialog openImageFileDialog;
        private TextBox nameTextBox;
        private Label nameLabel;
        private Label cardPropertiesLabel;
        private Label descriptionLabel;
        private TextBox descriptionTextBox;
        private TextBox idTextBox;
        private Label idLabel;
        private Button cancelButton;
        private Button saveButton;
        private CheckBox addToCurrentDeckCheckBox;
        private ComboBox templateComboBox;
        private Label templateLabel;
        private FlowLayoutPanel propertiesPanel;
    }
}