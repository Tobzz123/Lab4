namespace Lab4B
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabel = new System.Windows.Forms.Label();
            this.htmlListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.processToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(404, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkTagsToolStripMenuItem});
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.processToolStripMenuItem.Text = "&Process";
            // 
            // checkTagsToolStripMenuItem
            // 
            this.checkTagsToolStripMenuItem.Name = "checkTagsToolStripMenuItem";
            this.checkTagsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.checkTagsToolStripMenuItem.Text = "&Check Tags";
            this.checkTagsToolStripMenuItem.Click += new System.EventHandler(this.checkTagsToolStripMenuItem_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 42);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(35, 13);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "label1";
            // 
            // htmlListBox
            // 
            this.htmlListBox.FormattingEnabled = true;
            this.htmlListBox.Location = new System.Drawing.Point(31, 86);
            this.htmlListBox.Name = "htmlListBox";
            this.htmlListBox.Size = new System.Drawing.Size(344, 316);
            this.htmlListBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 450);
            this.Controls.Add(this.htmlListBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Ola\'s Simple HTML File Checker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkTagsToolStripMenuItem;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ListBox htmlListBox;
    }
}

