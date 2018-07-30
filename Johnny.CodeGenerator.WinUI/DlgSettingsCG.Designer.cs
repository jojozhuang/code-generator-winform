namespace Johnny.CodeGenerator.WinUI
{
    partial class DlgSettingsCG
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgSettingsCG));
            this.btnOK = new System.Windows.Forms.Button();
            this.grpDirectory = new System.Windows.Forms.GroupBox();
            this.btnWorkingFolder = new System.Windows.Forms.Button();
            this.txtWorkingFolder = new System.Windows.Forms.TextBox();
            this.lblWorkingFolder = new System.Windows.Forms.Label();
            this.lblVsTemplate = new System.Windows.Forms.Label();
            this.btnVsTemplate = new System.Windows.Forms.Button();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.txtVsTemplate = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtEntity = new System.Windows.Forms.TextBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.grpDirectory.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(168, 216);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grpDirectory
            // 
            this.grpDirectory.Controls.Add(this.btnWorkingFolder);
            this.grpDirectory.Controls.Add(this.txtWorkingFolder);
            this.grpDirectory.Controls.Add(this.lblWorkingFolder);
            this.grpDirectory.Controls.Add(this.lblVsTemplate);
            this.grpDirectory.Controls.Add(this.btnVsTemplate);
            this.grpDirectory.Controls.Add(this.btnTemplate);
            this.grpDirectory.Controls.Add(this.txtVsTemplate);
            this.grpDirectory.Controls.Add(this.txtOutput);
            this.grpDirectory.Controls.Add(this.lblOutput);
            this.grpDirectory.Controls.Add(this.txtEntity);
            this.grpDirectory.Controls.Add(this.lblEntity);
            this.grpDirectory.Controls.Add(this.txtTemplate);
            this.grpDirectory.Controls.Add(this.lblTemplate);
            this.grpDirectory.Location = new System.Drawing.Point(12, 13);
            this.grpDirectory.Name = "grpDirectory";
            this.grpDirectory.Size = new System.Drawing.Size(540, 186);
            this.grpDirectory.TabIndex = 1;
            this.grpDirectory.TabStop = false;
            this.grpDirectory.Text = "Directory";
            // 
            // btnWorkingFolder
            // 
            this.btnWorkingFolder.Location = new System.Drawing.Point(497, 30);
            this.btnWorkingFolder.Name = "btnWorkingFolder";
            this.btnWorkingFolder.Size = new System.Drawing.Size(25, 25);
            this.btnWorkingFolder.TabIndex = 18;
            this.btnWorkingFolder.Text = "...";
            this.btnWorkingFolder.UseVisualStyleBackColor = true;
            this.btnWorkingFolder.Click += new System.EventHandler(this.btnWorkingFolder_Click);
            // 
            // txtWorkingFolder
            // 
            this.txtWorkingFolder.Location = new System.Drawing.Point(105, 33);
            this.txtWorkingFolder.Name = "txtWorkingFolder";
            this.txtWorkingFolder.Size = new System.Drawing.Size(386, 20);
            this.txtWorkingFolder.TabIndex = 17;
            // 
            // lblWorkingFolder
            // 
            this.lblWorkingFolder.AutoSize = true;
            this.lblWorkingFolder.Location = new System.Drawing.Point(22, 36);
            this.lblWorkingFolder.Name = "lblWorkingFolder";
            this.lblWorkingFolder.Size = new System.Drawing.Size(82, 13);
            this.lblWorkingFolder.TabIndex = 16;
            this.lblWorkingFolder.Text = "Working Folder:";
            // 
            // lblVsTemplate
            // 
            this.lblVsTemplate.AutoSize = true;
            this.lblVsTemplate.Location = new System.Drawing.Point(22, 92);
            this.lblVsTemplate.Name = "lblVsTemplate";
            this.lblVsTemplate.Size = new System.Drawing.Size(71, 13);
            this.lblVsTemplate.TabIndex = 13;
            this.lblVsTemplate.Text = "VS Template:";
            // 
            // btnVsTemplate
            // 
            this.btnVsTemplate.Location = new System.Drawing.Point(497, 88);
            this.btnVsTemplate.Name = "btnVsTemplate";
            this.btnVsTemplate.Size = new System.Drawing.Size(25, 25);
            this.btnVsTemplate.TabIndex = 12;
            this.btnVsTemplate.Text = "...";
            this.btnVsTemplate.UseVisualStyleBackColor = true;
            this.btnVsTemplate.Click += new System.EventHandler(this.btnVsTemplate_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.Location = new System.Drawing.Point(497, 58);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(25, 25);
            this.btnTemplate.TabIndex = 10;
            this.btnTemplate.Text = "...";
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // txtVsTemplate
            // 
            this.txtVsTemplate.Location = new System.Drawing.Point(105, 89);
            this.txtVsTemplate.Name = "txtVsTemplate";
            this.txtVsTemplate.Size = new System.Drawing.Size(386, 20);
            this.txtVsTemplate.TabIndex = 14;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(148, 118);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(158, 20);
            this.txtOutput.TabIndex = 5;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(22, 121);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(120, 13);
            this.lblOutput.TabIndex = 4;
            this.lblOutput.Text = "Folder Name for Output:";
            // 
            // txtEntity
            // 
            this.txtEntity.Location = new System.Drawing.Point(148, 146);
            this.txtEntity.Name = "txtEntity";
            this.txtEntity.Size = new System.Drawing.Size(158, 20);
            this.txtEntity.TabIndex = 3;
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Location = new System.Drawing.Point(22, 149);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(114, 13);
            this.lblEntity.TabIndex = 2;
            this.lblEntity.Text = "Folder Name for Entity:";
            // 
            // txtTemplate
            // 
            this.txtTemplate.Location = new System.Drawing.Point(105, 61);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(386, 20);
            this.txtTemplate.TabIndex = 1;
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Location = new System.Drawing.Point(22, 64);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(54, 13);
            this.lblTemplate.TabIndex = 0;
            this.lblTemplate.Text = "Template:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(318, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // DlgSettingsCG
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(563, 259);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpDirectory);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgSettingsCG";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Code Generator Settings";
            this.Load += new System.EventHandler(this.DlgSettingsCG_Load);
            this.grpDirectory.ResumeLayout(false);
            this.grpDirectory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox grpDirectory;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtEntity;
        private System.Windows.Forms.Label lblEntity;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnVsTemplate;
        private System.Windows.Forms.Button btnTemplate;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.TextBox txtVsTemplate;
        private System.Windows.Forms.Label lblVsTemplate;
        private System.Windows.Forms.Button btnWorkingFolder;
        private System.Windows.Forms.TextBox txtWorkingFolder;
        private System.Windows.Forms.Label lblWorkingFolder;
    }
}