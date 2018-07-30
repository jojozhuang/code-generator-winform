namespace Johnny.CodeGenerator.WinUI
{
    partial class FrmToolbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmToolbox));
            Johnny.Controls.Windows.Toolbox.ToolboxCategory toolboxCategory1 = new Johnny.Controls.Windows.Toolbox.ToolboxCategory();
            Johnny.Controls.Windows.Toolbox.ToolboxItem toolboxItem1 = new Johnny.Controls.Windows.Toolbox.ToolboxItem();
            Johnny.Controls.Windows.Toolbox.ToolboxItem toolboxItem2 = new Johnny.Controls.Windows.Toolbox.ToolboxItem();
            Johnny.Controls.Windows.Toolbox.ToolboxItem toolboxItem3 = new Johnny.Controls.Windows.Toolbox.ToolboxItem();
            Johnny.Controls.Windows.Toolbox.ToolboxCategory toolboxCategory2 = new Johnny.Controls.Windows.Toolbox.ToolboxCategory();
            Johnny.Controls.Windows.Toolbox.ToolboxItem toolboxItem4 = new Johnny.Controls.Windows.Toolbox.ToolboxItem();
            Johnny.Controls.Windows.Toolbox.ToolboxItem toolboxItem5 = new Johnny.Controls.Windows.Toolbox.ToolboxItem();
            Johnny.Controls.Windows.Toolbox.ToolboxItem toolboxItem6 = new Johnny.Controls.Windows.Toolbox.ToolboxItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.myToolbox = new Johnny.Controls.Windows.Toolbox.Toolbox();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Mouse.bmp");
            this.imageList.Images.SetKeyName(1, "Minus.gif");
            this.imageList.Images.SetKeyName(2, "Plus.gif");
            this.imageList.Images.SetKeyName(3, "Microsoft.AnalysisServices.Project.DLL6.ico");
            this.imageList.Images.SetKeyName(4, "delete_16x.ico");
            this.imageList.Images.SetKeyName(5, "Messages.ico");
            this.imageList.Images.SetKeyName(6, "fonfile.ico");
            this.imageList.Images.SetKeyName(7, "Rally.ico");
            // 
            // myToolbox
            // 
            toolboxCategory1.ImageIndex = 0;
            toolboxCategory1.IsOpen = true;
            toolboxItem1.ImageIndex = 3;
            toolboxItem1.Name = "Entity Creator";
            toolboxItem1.Parent = null;
            toolboxItem2.ImageIndex = 5;
            toolboxItem2.Name = "群发消息";
            toolboxItem2.Parent = null;
            toolboxItem3.ImageIndex = 7;
            toolboxItem3.Name = "组建车队";
            toolboxItem3.Parent = null;
            toolboxCategory1.Items.Add(toolboxItem1);
            toolboxCategory1.Items.Add(toolboxItem2);
            toolboxCategory1.Items.Add(toolboxItem3);
            toolboxCategory1.Name = "Common Tools";
            toolboxCategory1.Parent = null;
            toolboxCategory2.ImageIndex = 0;
            toolboxCategory2.IsOpen = true;
            toolboxItem4.ImageIndex = 6;
            toolboxItem4.Name = "汉字<->拼音";
            toolboxItem4.Parent = null;
            toolboxItem5.ImageIndex = 5;
            toolboxItem5.Name = "Json Convertor";
            toolboxItem5.Parent = null;
            toolboxItem6.ImageIndex = 5;
            toolboxItem6.Name = "Base64 Convertor";
            toolboxItem6.Parent = null;
            toolboxCategory2.Items.Add(toolboxItem4);
            toolboxCategory2.Items.Add(toolboxItem5);
            toolboxCategory2.Items.Add(toolboxItem6);
            toolboxCategory2.Name = "Others";
            toolboxCategory2.Parent = null;
            this.myToolbox.Categories.Add(toolboxCategory1);
            this.myToolbox.Categories.Add(toolboxCategory2);
            this.myToolbox.CategoryBackColor = System.Drawing.Color.WhiteSmoke;
            this.myToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myToolbox.ImageList = this.imageList;
            this.myToolbox.Location = new System.Drawing.Point(0, 2);
            this.myToolbox.Name = "myToolbox";
            this.myToolbox.Size = new System.Drawing.Size(221, 391);
            this.myToolbox.TabIndex = 0;
            this.myToolbox.Text = "myToolbox";
            this.myToolbox.Click += new System.EventHandler(this.myToolbox_Click);
            // 
            // FrmToolbox
            // 
            this.ClientSize = new System.Drawing.Size(221, 395);
            this.Controls.Add(this.myToolbox);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmToolbox";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide;
            this.TabText = "Toolbox";
            this.Text = "Toolbox";
            this.Load += new System.EventHandler(this.DummyToolbox_Load);
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.ImageList imageList;
        private Johnny.Controls.Windows.Toolbox.Toolbox myToolbox;   
    }
}