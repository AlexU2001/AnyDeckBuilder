namespace AnyDeckBuilder
{
    partial class DeckViewForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckViewForm));
            splitContainer1 = new SplitContainer();
            deckView = new TreeView();
            layoutPanel = new FlowLayoutPanel();
            deckToolbar = new ToolStrip();
            newCardButton = new ToolStripButton();
            addCardsButton = new ToolStripDropDownButton();
            importjsonToolStripMenuItem = new ToolStripMenuItem();
            importcsvToolStripMenuItem = new ToolStripMenuItem();
            csvToolStripMenuItem = new ToolStripMenuItem();
            tsvToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            searchLabel = new ToolStripLabel();
            searchTextbox = new ToolStripTextBox();
            zoomLabel = new ToolStripLabel();
            minusZoomButton = new ToolStripButton();
            zoomAmountDropDown = new ToolStripDropDownButton();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripMenuItem8 = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripMenuItem10 = new ToolStripMenuItem();
            toolStripMenuItem11 = new ToolStripMenuItem();
            plusZoomButton = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            BottomToolStripPanel = new ToolStripPanel();
            TopToolStripPanel = new ToolStripPanel();
            RightToolStripPanel = new ToolStripPanel();
            LeftToolStripPanel = new ToolStripPanel();
            ContentPanel = new ToolStripContentPanel();
            newFileButton = new ToolStripButton();
            openToolStripButton = new ToolStripButton();
            printToolStripButton = new ToolStripButton();
            toolStripSeparator = new ToolStripSeparator();
            cutToolStripButton = new ToolStripButton();
            copyToolStripButton = new ToolStripButton();
            pasteToolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            helpToolStripButton = new ToolStripButton();
            projectToolbar = new ToolStrip();
            toolStripButton2 = new ToolStripDropDownButton();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            openRecentToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            saveToolStripMenuItem1 = new ToolStripMenuItem();
            saveAsToolStripMenuItem1 = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            printToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            closeToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            saveDropdownButton = new ToolStripDropDownButton();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton1 = new ToolStripButton();
            saveProjectDIalog = new SaveFileDialog();
            openProjectDialog = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            deckToolbar.SuspendLayout();
            projectToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 36);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(deckView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(layoutPanel);
            splitContainer1.Panel2.Controls.Add(deckToolbar);
            splitContainer1.Size = new Size(1147, 943);
            splitContainer1.SplitterDistance = 381;
            splitContainer1.TabIndex = 0;
            // 
            // deckView
            // 
            deckView.Dock = DockStyle.Fill;
            deckView.Location = new Point(0, 0);
            deckView.Name = "deckView";
            deckView.Size = new Size(381, 943);
            deckView.TabIndex = 0;
            deckView.AfterSelect += deckView_AfterSelect;
            // 
            // layoutPanel
            // 
            layoutPanel.AccessibleDescription = " ";
            layoutPanel.BackColor = SystemColors.ControlDark;
            layoutPanel.Dock = DockStyle.Fill;
            layoutPanel.Location = new Point(0, 34);
            layoutPanel.Name = "layoutPanel";
            layoutPanel.Size = new Size(762, 909);
            layoutPanel.TabIndex = 3;
            // 
            // deckToolbar
            // 
            deckToolbar.ImageScalingSize = new Size(24, 24);
            deckToolbar.Items.AddRange(new ToolStripItem[] { newCardButton, addCardsButton, toolStripSeparator3, searchLabel, searchTextbox, zoomLabel, minusZoomButton, zoomAmountDropDown, plusZoomButton, toolStripSeparator2 });
            deckToolbar.Location = new Point(0, 0);
            deckToolbar.Name = "deckToolbar";
            deckToolbar.Size = new Size(762, 34);
            deckToolbar.TabIndex = 2;
            deckToolbar.Text = "toolStrip1";
            // 
            // newCardButton
            // 
            newCardButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newCardButton.Image = (Image)resources.GetObject("newCardButton.Image");
            newCardButton.ImageTransparentColor = Color.Magenta;
            newCardButton.Name = "newCardButton";
            newCardButton.Size = new Size(34, 29);
            newCardButton.Text = "New Card";
            newCardButton.Click += newCardButton_Click;
            // 
            // addCardsButton
            // 
            addCardsButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            addCardsButton.DropDownItems.AddRange(new ToolStripItem[] { importjsonToolStripMenuItem, importcsvToolStripMenuItem });
            addCardsButton.Image = (Image)resources.GetObject("addCardsButton.Image");
            addCardsButton.ImageTransparentColor = Color.Magenta;
            addCardsButton.Name = "addCardsButton";
            addCardsButton.Size = new Size(42, 29);
            addCardsButton.Text = "Add Existing Cards";
            // 
            // importjsonToolStripMenuItem
            // 
            importjsonToolStripMenuItem.Name = "importjsonToolStripMenuItem";
            importjsonToolStripMenuItem.Size = new Size(269, 34);
            importjsonToolStripMenuItem.Text = "import .json";
            // 
            // importcsvToolStripMenuItem
            // 
            importcsvToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { csvToolStripMenuItem, tsvToolStripMenuItem });
            importcsvToolStripMenuItem.Name = "importcsvToolStripMenuItem";
            importcsvToolStripMenuItem.Size = new Size(269, 34);
            importcsvToolStripMenuItem.Text = "import spreadsheet";
            // 
            // csvToolStripMenuItem
            // 
            csvToolStripMenuItem.Name = "csvToolStripMenuItem";
            csvToolStripMenuItem.Size = new Size(143, 34);
            csvToolStripMenuItem.Text = ".csv";
            // 
            // tsvToolStripMenuItem
            // 
            tsvToolStripMenuItem.Name = "tsvToolStripMenuItem";
            tsvToolStripMenuItem.Size = new Size(143, 34);
            tsvToolStripMenuItem.Text = ".tsv";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 34);
            // 
            // searchLabel
            // 
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(64, 29);
            searchLabel.Text = "Search";
            // 
            // searchTextbox
            // 
            searchTextbox.Name = "searchTextbox";
            searchTextbox.Size = new Size(200, 34);
            // 
            // zoomLabel
            // 
            zoomLabel.Name = "zoomLabel";
            zoomLabel.Size = new Size(64, 29);
            zoomLabel.Text = "Zoom:";
            // 
            // minusZoomButton
            // 
            minusZoomButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            minusZoomButton.Image = (Image)resources.GetObject("minusZoomButton.Image");
            minusZoomButton.ImageTransparentColor = Color.Magenta;
            minusZoomButton.Name = "minusZoomButton";
            minusZoomButton.Size = new Size(34, 29);
            minusZoomButton.Text = "-";
            minusZoomButton.ToolTipText = "Zoom Out";
            minusZoomButton.Click += MinusZoomButton_Click;
            // 
            // zoomAmountDropDown
            // 
            zoomAmountDropDown.DisplayStyle = ToolStripItemDisplayStyle.Text;
            zoomAmountDropDown.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem6, toolStripMenuItem7, toolStripMenuItem8, toolStripMenuItem9, toolStripMenuItem10, toolStripMenuItem11 });
            zoomAmountDropDown.Image = (Image)resources.GetObject("zoomAmountDropDown.Image");
            zoomAmountDropDown.ImageTransparentColor = Color.Magenta;
            zoomAmountDropDown.Name = "zoomAmountDropDown";
            zoomAmountDropDown.Size = new Size(75, 29);
            zoomAmountDropDown.Text = "100%";
            zoomAmountDropDown.ToolTipText = "Zoom Amount";
            zoomAmountDropDown.DropDownItemClicked += ZoomAmountDropDown_DropDownItemClicked;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(159, 34);
            toolStripMenuItem2.Text = "20%";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(159, 34);
            toolStripMenuItem3.Text = "40%";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(159, 34);
            toolStripMenuItem4.Text = "60%";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(159, 34);
            toolStripMenuItem5.Text = "80%";
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(159, 34);
            toolStripMenuItem6.Text = "100%";
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(159, 34);
            toolStripMenuItem7.Text = "120%";
            // 
            // toolStripMenuItem8
            // 
            toolStripMenuItem8.Name = "toolStripMenuItem8";
            toolStripMenuItem8.Size = new Size(159, 34);
            toolStripMenuItem8.Text = "140%";
            // 
            // toolStripMenuItem9
            // 
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Size = new Size(159, 34);
            toolStripMenuItem9.Text = "160%";
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new Size(159, 34);
            toolStripMenuItem10.Text = "180%";
            // 
            // toolStripMenuItem11
            // 
            toolStripMenuItem11.Name = "toolStripMenuItem11";
            toolStripMenuItem11.Size = new Size(159, 34);
            toolStripMenuItem11.Text = "200%";
            // 
            // plusZoomButton
            // 
            plusZoomButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            plusZoomButton.Image = (Image)resources.GetObject("plusZoomButton.Image");
            plusZoomButton.ImageTransparentColor = Color.Magenta;
            plusZoomButton.Name = "plusZoomButton";
            plusZoomButton.Size = new Size(34, 29);
            plusZoomButton.Text = "+";
            plusZoomButton.ToolTipText = "Zoom In";
            plusZoomButton.Click += PlusZoomButton_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 34);
            // 
            // BottomToolStripPanel
            // 
            BottomToolStripPanel.Location = new Point(0, 0);
            BottomToolStripPanel.Name = "BottomToolStripPanel";
            BottomToolStripPanel.Orientation = Orientation.Horizontal;
            BottomToolStripPanel.RowMargin = new Padding(4, 0, 0, 0);
            BottomToolStripPanel.Size = new Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            TopToolStripPanel.Location = new Point(0, 0);
            TopToolStripPanel.Name = "TopToolStripPanel";
            TopToolStripPanel.Orientation = Orientation.Horizontal;
            TopToolStripPanel.RowMargin = new Padding(4, 0, 0, 0);
            TopToolStripPanel.Size = new Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            RightToolStripPanel.Location = new Point(0, 0);
            RightToolStripPanel.Name = "RightToolStripPanel";
            RightToolStripPanel.Orientation = Orientation.Horizontal;
            RightToolStripPanel.RowMargin = new Padding(4, 0, 0, 0);
            RightToolStripPanel.Size = new Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            LeftToolStripPanel.Location = new Point(0, 0);
            LeftToolStripPanel.Name = "LeftToolStripPanel";
            LeftToolStripPanel.Orientation = Orientation.Horizontal;
            LeftToolStripPanel.RowMargin = new Padding(4, 0, 0, 0);
            LeftToolStripPanel.Size = new Size(0, 0);
            // 
            // ContentPanel
            // 
            ContentPanel.Size = new Size(225, 237);
            // 
            // newFileButton
            // 
            newFileButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newFileButton.Image = (Image)resources.GetObject("newFileButton.Image");
            newFileButton.ImageTransparentColor = Color.Magenta;
            newFileButton.Name = "newFileButton";
            newFileButton.Size = new Size(34, 29);
            newFileButton.Text = "&New";
            newFileButton.Click += newFileButton_Click;
            // 
            // openToolStripButton
            // 
            openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openToolStripButton.Image = (Image)resources.GetObject("openToolStripButton.Image");
            openToolStripButton.ImageTransparentColor = Color.Magenta;
            openToolStripButton.Name = "openToolStripButton";
            openToolStripButton.Size = new Size(34, 29);
            openToolStripButton.Text = "&Open";
            openToolStripButton.Click += openToolStripButton_Click;
            // 
            // printToolStripButton
            // 
            printToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            printToolStripButton.Image = (Image)resources.GetObject("printToolStripButton.Image");
            printToolStripButton.ImageTransparentColor = Color.Magenta;
            printToolStripButton.Name = "printToolStripButton";
            printToolStripButton.Size = new Size(34, 29);
            printToolStripButton.Text = "&Print";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(6, 34);
            // 
            // cutToolStripButton
            // 
            cutToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            cutToolStripButton.Image = (Image)resources.GetObject("cutToolStripButton.Image");
            cutToolStripButton.ImageTransparentColor = Color.Magenta;
            cutToolStripButton.Name = "cutToolStripButton";
            cutToolStripButton.Size = new Size(34, 29);
            cutToolStripButton.Text = "C&ut";
            // 
            // copyToolStripButton
            // 
            copyToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            copyToolStripButton.Image = (Image)resources.GetObject("copyToolStripButton.Image");
            copyToolStripButton.ImageTransparentColor = Color.Magenta;
            copyToolStripButton.Name = "copyToolStripButton";
            copyToolStripButton.Size = new Size(34, 29);
            copyToolStripButton.Text = "&Copy";
            // 
            // pasteToolStripButton
            // 
            pasteToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            pasteToolStripButton.Image = (Image)resources.GetObject("pasteToolStripButton.Image");
            pasteToolStripButton.ImageTransparentColor = Color.Magenta;
            pasteToolStripButton.Name = "pasteToolStripButton";
            pasteToolStripButton.Size = new Size(34, 29);
            pasteToolStripButton.Text = "&Paste";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 34);
            // 
            // helpToolStripButton
            // 
            helpToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            helpToolStripButton.Image = (Image)resources.GetObject("helpToolStripButton.Image");
            helpToolStripButton.ImageTransparentColor = Color.Magenta;
            helpToolStripButton.Name = "helpToolStripButton";
            helpToolStripButton.Size = new Size(34, 29);
            helpToolStripButton.Text = "He&lp";
            // 
            // projectToolbar
            // 
            projectToolbar.ImageScalingSize = new Size(24, 24);
            projectToolbar.Items.AddRange(new ToolStripItem[] { toolStripButton2, toolStripSeparator4, newFileButton, openToolStripButton, saveDropdownButton, printToolStripButton, toolStripSeparator, cutToolStripButton, copyToolStripButton, pasteToolStripButton, toolStripSeparator1, helpToolStripButton, toolStripButton1 });
            projectToolbar.Location = new Point(0, 0);
            projectToolbar.Name = "projectToolbar";
            projectToolbar.Size = new Size(1147, 34);
            projectToolbar.TabIndex = 1;
            projectToolbar.Text = "toolStrip2";
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, openRecentToolStripMenuItem, toolStripSeparator7, saveToolStripMenuItem1, saveAsToolStripMenuItem1, exportToolStripMenuItem, toolStripSeparator5, printToolStripMenuItem, toolStripSeparator6, closeToolStripMenuItem, exitToolStripMenuItem });
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(56, 29);
            toolStripButton2.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(270, 34);
            newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(270, 34);
            openToolStripMenuItem.Text = "Open";
            // 
            // openRecentToolStripMenuItem
            // 
            openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
            openRecentToolStripMenuItem.Size = new Size(270, 34);
            openRecentToolStripMenuItem.Text = "Open Recent";
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(267, 6);
            // 
            // saveToolStripMenuItem1
            // 
            saveToolStripMenuItem1.Image = Properties.Resources.Save_Icon;
            saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            saveToolStripMenuItem1.Size = new Size(270, 34);
            saveToolStripMenuItem1.Text = "Save";
            // 
            // saveAsToolStripMenuItem1
            // 
            saveAsToolStripMenuItem1.Image = Properties.Resources.SaveAs_Icon;
            saveAsToolStripMenuItem1.Name = "saveAsToolStripMenuItem1";
            saveAsToolStripMenuItem1.Size = new Size(270, 34);
            saveAsToolStripMenuItem1.Text = "Save As";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(270, 34);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(267, 6);
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.Size = new Size(270, 34);
            printToolStripMenuItem.Text = "Print";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(267, 6);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(270, 34);
            closeToolStripMenuItem.Text = "Close";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(270, 34);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 34);
            // 
            // saveDropdownButton
            // 
            saveDropdownButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveDropdownButton.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, saveAsToolStripMenuItem });
            saveDropdownButton.Image = Properties.Resources.Save_Icon;
            saveDropdownButton.ImageTransparentColor = Color.Magenta;
            saveDropdownButton.Name = "saveDropdownButton";
            saveDropdownButton.Size = new Size(42, 29);
            saveDropdownButton.Text = "&Save";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = Properties.Resources.Save_Icon;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(285, 34);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveProjectButton_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Image = Properties.Resources.SaveAs_Icon;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(285, 34);
            saveAsToolStripMenuItem.Text = "Save As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.Alignment = ToolStripItemAlignment.Right;
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = Properties.Resources.GearIcon;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(34, 29);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // saveProjectDIalog
            // 
            saveProjectDIalog.Filter = "AnyDeckBuilder File |*.adbp";
            saveProjectDIalog.Title = "Save Project";
            // 
            // openProjectDialog
            // 
            openProjectDialog.FileName = "Open Project";
            openProjectDialog.Filter = "AnyDeckBuilder File |*.adbp";
            // 
            // DeckViewForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(1147, 975);
            Controls.Add(projectToolbar);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DeckViewForm";
            Text = "Any Deck Builder";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            deckToolbar.ResumeLayout(false);
            deckToolbar.PerformLayout();
            projectToolbar.ResumeLayout(false);
            projectToolbar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private SplitContainer splitContainer1;
        private ToolStrip deckToolbar;
        private FlowLayoutPanel layoutPanel;
        private ToolStripTextBox searchTextbox;
        private ToolStripButton newCardButton;
        private ToolStripLabel searchLabel;
        private ToolStripButton minusZoomButton;
        private ToolStripButton plusZoomButton;
        private ToolStripLabel zoomLabel;
        private ToolStripDropDownButton zoomAmountDropDown;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem toolStripMenuItem9;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        private ToolStripButton newFileButton;
        private ToolStripButton openToolStripButton;
        private ToolStripButton printToolStripButton;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton cutToolStripButton;
        private ToolStripButton copyToolStripButton;
        private ToolStripButton pasteToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton helpToolStripButton;
        private ToolStrip projectToolbar;
        private SaveFileDialog saveProjectDIalog;
        private OpenFileDialog openProjectDialog;
        private TreeView deckView;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripDropDownButton addCardsButton;
        private ToolStripMenuItem importcsvToolStripMenuItem;
        private ToolStripMenuItem importjsonToolStripMenuItem;
        private ToolStripMenuItem csvToolStripMenuItem;
        private ToolStripMenuItem tsvToolStripMenuItem;
        private ToolStripDropDownButton saveDropdownButton;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripDropDownButton toolStripButton2;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem1;
        private ToolStripMenuItem openRecentToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem saveAsToolStripMenuItem1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}
