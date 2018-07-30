namespace Johnny.CodeGenerator.WinUI
{
    partial class FrmDocument
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocument));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.richtxtContent = new ICSharpCode.TextEditor.TextEditorControl();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // richtxtContent
            // 
            this.richtxtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richtxtContent.IsReadOnly = false;
            this.richtxtContent.Location = new System.Drawing.Point(0, 4);
            this.richtxtContent.Name = "richtxtContent";
            this.richtxtContent.ShowEOLMarkers = true;
            this.richtxtContent.ShowSpaces = true;
            this.richtxtContent.ShowTabs = true;
            this.richtxtContent.Size = new System.Drawing.Size(448, 389);
            this.richtxtContent.TabIndex = 3;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "textdoc.ico");
            this.imageList.Images.SetKeyName(1, "csfile.ico");
            this.imageList.Images.SetKeyName(2, "newfile.ico");
            this.imageList.Images.SetKeyName(3, "module.ico");
            this.imageList.Images.SetKeyName(4, "html.ico");
            this.imageList.Images.SetKeyName(5, "xml.ico");
            // 
            // FrmDocument
            // 
            this.ClientSize = new System.Drawing.Size(448, 393);
            this.Controls.Add(this.richtxtContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDocument";
            this.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDocument_FormClosing);
            this.Load += new System.EventHandler(this.FrmXmlDocument_Load);
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.ToolTip toolTip;
        private ICSharpCode.TextEditor.TextEditorControl richtxtContent;
        private System.Windows.Forms.ImageList imageList;
    }
}