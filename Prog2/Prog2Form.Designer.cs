namespace UPVApp
{
    partial class Prog2Form
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
            this.parcelMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.letterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listAddressesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listParcelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportTxt = new System.Windows.Forms.TextBox();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addressMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parcelMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // parcelMenuStrip
            // 
            this.parcelMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.parcelMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editMenuItem,
            this.insertToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.parcelMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.parcelMenuStrip.Name = "parcelMenuStrip";
            this.parcelMenuStrip.Size = new System.Drawing.Size(779, 28);
            this.parcelMenuStrip.TabIndex = 0;
            this.parcelMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.openMenuItem,
            this.saveAsMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aboutToolStripMenuItem.Text = "A&bout";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openMenuItem.Text = "&Open";
            this.openMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveAsMenuItem.Text = "&Save As";
            this.saveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addressToolStripMenuItem,
            this.letterToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.insertToolStripMenuItem.Text = "&Insert";
            // 
            // addressToolStripMenuItem
            // 
            this.addressToolStripMenuItem.Name = "addressToolStripMenuItem";
            this.addressToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.addressToolStripMenuItem.Text = "&Address";
            this.addressToolStripMenuItem.Click += new System.EventHandler(this.addressToolStripMenuItem_Click);
            // 
            // letterToolStripMenuItem
            // 
            this.letterToolStripMenuItem.Name = "letterToolStripMenuItem";
            this.letterToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.letterToolStripMenuItem.Text = "&Letter";
            this.letterToolStripMenuItem.Click += new System.EventHandler(this.letterToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listAddressesToolStripMenuItem,
            this.listParcelsToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.reportToolStripMenuItem.Text = "&Report";
            // 
            // listAddressesToolStripMenuItem
            // 
            this.listAddressesToolStripMenuItem.Name = "listAddressesToolStripMenuItem";
            this.listAddressesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.listAddressesToolStripMenuItem.Text = "List &Addresses";
            this.listAddressesToolStripMenuItem.Click += new System.EventHandler(this.listAddressesToolStripMenuItem_Click);
            // 
            // listParcelsToolStripMenuItem
            // 
            this.listParcelsToolStripMenuItem.Name = "listParcelsToolStripMenuItem";
            this.listParcelsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.listParcelsToolStripMenuItem.Text = "List &Parcels";
            this.listParcelsToolStripMenuItem.Click += new System.EventHandler(this.listParcelsToolStripMenuItem_Click);
            // 
            // reportTxt
            // 
            this.reportTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportTxt.Location = new System.Drawing.Point(16, 55);
            this.reportTxt.Margin = new System.Windows.Forms.Padding(4);
            this.reportTxt.Multiline = true;
            this.reportTxt.Name = "reportTxt";
            this.reportTxt.ReadOnly = true;
            this.reportTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.reportTxt.Size = new System.Drawing.Size(745, 621);
            this.reportTxt.TabIndex = 1;
            // 
            // editMenuItem
            // 
            this.editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addressMenuItem});
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editMenuItem.Text = "&Edit";
            // 
            // addressMenuItem
            // 
            this.addressMenuItem.Name = "addressMenuItem";
            this.addressMenuItem.Size = new System.Drawing.Size(224, 26);
            this.addressMenuItem.Text = "&Address";
            this.addressMenuItem.Click += new System.EventHandler(this.EditAddressMenuItem_Click);
            // 
            // Prog2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 692);
            this.Controls.Add(this.reportTxt);
            this.Controls.Add(this.parcelMenuStrip);
            this.MainMenuStrip = this.parcelMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Prog2Form";
            this.Text = "Program 3";
            this.parcelMenuStrip.ResumeLayout(false);
            this.parcelMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip parcelMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listAddressesToolStripMenuItem;
        private System.Windows.Forms.TextBox reportTxt;
        private System.Windows.Forms.ToolStripMenuItem letterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listParcelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addressMenuItem;
    }
}

