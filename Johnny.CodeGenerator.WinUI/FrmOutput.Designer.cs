namespace Johnny.CodeGenerator.WinUI
{
    partial class FrmOutput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOutput));
            this.outputTab = new Johnny.Controls.Windows.OutputTab.OutputTab();
            this.SuspendLayout();
            // 
            // outputTab
            // 
            this.outputTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTab.Location = new System.Drawing.Point(0, 2);
            this.outputTab.Name = "outputTab";
            this.outputTab.Size = new System.Drawing.Size(837, 176);
            this.outputTab.TabIndex = 0;
            // 
            // FrmOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(837, 180);
            this.Controls.Add(this.outputTab);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmOutput";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide;
            this.TabText = "Output";
            this.Text = "Output";
            this.Load += new System.EventHandler(this.FrmOutput_Load);
            this.ResumeLayout(false);

		}
		#endregion

        public Johnny.Controls.Windows.OutputTab.OutputTab outputTab;


    }
}