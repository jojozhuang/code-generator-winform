namespace Johnny.CodeGenerator.WinUI
{
    partial class FrmProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProperty));
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.cmbCollection = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(208, 241);
            this.propertyGrid.TabIndex = 0;
            // 
            // cmbCollection
            // 
            this.cmbCollection.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbCollection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollection.Items.AddRange(new object[] {
            "propertyGrid"});
            this.cmbCollection.Location = new System.Drawing.Point(0, 3);
            this.cmbCollection.Name = "cmbCollection";
            this.cmbCollection.Size = new System.Drawing.Size(208, 21);
            this.cmbCollection.TabIndex = 1;
            this.cmbCollection.SelectedIndexChanged += new System.EventHandler(this.cmbCollection_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.propertyGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 241);
            this.panel1.TabIndex = 2;
            // 
            // FrmProperty
            // 
            this.ClientSize = new System.Drawing.Size(208, 268);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbCollection);
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProperty";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.TabText = "Property";
            this.Text = "Property";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.ComboBox cmbCollection;
        private System.Windows.Forms.Panel panel1;
    }
}