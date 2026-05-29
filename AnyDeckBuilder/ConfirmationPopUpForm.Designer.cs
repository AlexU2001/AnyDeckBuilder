namespace AnyDeckBuilder
{
    partial class ConfirmationPopUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmationPopUpForm));
            cancelButton = new Button();
            confirmButton = new Button();
            actionLabel = new Label();
            hideWarningCheckbox = new CheckBox();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.IndianRed;
            cancelButton.FlatStyle = FlatStyle.Popup;
            cancelButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            cancelButton.Location = new Point(131, 287);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(170, 60);
            cancelButton.TabIndex = 0;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // confirmButton
            // 
            confirmButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            confirmButton.BackColor = SystemColors.Control;
            confirmButton.FlatStyle = FlatStyle.Popup;
            confirmButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            confirmButton.Location = new Point(519, 287);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(170, 60);
            confirmButton.TabIndex = 0;
            confirmButton.Text = "Confirm";
            confirmButton.UseVisualStyleBackColor = false;
            // 
            // actionLabel
            // 
            actionLabel.Dock = DockStyle.Fill;
            actionLabel.Font = new Font("Segoe UI", 24F);
            actionLabel.Location = new Point(0, 0);
            actionLabel.Name = "actionLabel";
            actionLabel.Padding = new Padding(0, 100, 0, 0);
            actionLabel.Size = new Size(778, 444);
            actionLabel.TabIndex = 1;
            actionLabel.Text = "Do you want to confirm this action?";
            actionLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // hideWarningCheckbox
            // 
            hideWarningCheckbox.AutoSize = true;
            hideWarningCheckbox.Location = new Point(250, 400);
            hideWarningCheckbox.Margin = new Padding(0);
            hideWarningCheckbox.Name = "hideWarningCheckbox";
            hideWarningCheckbox.Size = new Size(197, 29);
            hideWarningCheckbox.TabIndex = 2;
            hideWarningCheckbox.Text = "Do Not Show Again";
            hideWarningCheckbox.TextAlign = ContentAlignment.MiddleCenter;
            hideWarningCheckbox.UseVisualStyleBackColor = true;
            // 
            // ConfirmationPopUpForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 444);
            Controls.Add(hideWarningCheckbox);
            Controls.Add(confirmButton);
            Controls.Add(cancelButton);
            Controls.Add(actionLabel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfirmationPopUpForm";
            ShowInTaskbar = false;
            Text = "Confirm Action";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button confirmButton;
        private Label actionLabel;
        private CheckBox hideWarningCheckbox;
    }
}