namespace Johnny.CodeGenerator.WinUI
{
    partial class FrmTaskExplorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaskExplorer));
            this.taskTree = new Johnny.CodeGenerator.Controls.TaskTree.TaskTree();
            this.SuspendLayout();
            // 
            // taskTree
            // 
            this.taskTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskTree.HideSelection = false;
            this.taskTree.ImageIndex = 0;
            this.taskTree.LabelEdit = true;
            this.taskTree.Location = new System.Drawing.Point(0, 26);
            this.taskTree.Name = "taskTree";
            this.taskTree.SelectedImageIndex = 0;
            this.taskTree.Size = new System.Drawing.Size(245, 322);
            this.taskTree.TabIndex = 1;
            // 
            // FrmTaskManager
            // 
            this.ClientSize = new System.Drawing.Size(245, 349);
            this.Controls.Add(this.taskTree);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((((WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTaskManager";
            this.Padding = new System.Windows.Forms.Padding(0, 26, 0, 1);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.TabText = "Task Explorer";
            this.Text = "Task Explorer";
            this.Load += new System.EventHandler(this.FrmTaskManager_Load);
            this.ResumeLayout(false);

		}
		#endregion

        private Johnny.CodeGenerator.Controls.TaskTree.TaskTree taskTree;
    }
}