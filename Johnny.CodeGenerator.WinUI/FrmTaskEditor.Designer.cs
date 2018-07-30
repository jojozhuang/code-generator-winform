namespace Johnny.CodeGenerator.WinUI
{
    partial class FrmTaskEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaskEditor));
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUnselectOne = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectOne = new System.Windows.Forms.Button();
            this.lstSelectedTables = new System.Windows.Forms.ListBox();
            this.lstAllTables = new System.Windows.Forms.ListBox();
            this.grpTables = new System.Windows.Forms.GroupBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.txtNameSpacePrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameSpacePreview = new System.Windows.Forms.TextBox();
            this.txtNameSpaceSuffix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.chkWriteLogToFile = new System.Windows.Forms.CheckBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.selectorModule = new Johnny.CodeGenerator.Controls.ListBoxSelector.ModuleSelector();
            this.grpTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Location = new System.Drawing.Point(196, 237);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(40, 25);
            this.btnUnselectAll.TabIndex = 16;
            this.btnUnselectAll.Text = "<<";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(597, 237);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 46);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUnselectOne
            // 
            this.btnUnselectOne.Location = new System.Drawing.Point(196, 179);
            this.btnUnselectOne.Name = "btnUnselectOne";
            this.btnUnselectOne.Size = new System.Drawing.Size(40, 25);
            this.btnUnselectOne.TabIndex = 15;
            this.btnUnselectOne.Text = "<";
            this.btnUnselectOne.UseVisualStyleBackColor = true;
            this.btnUnselectOne.Click += new System.EventHandler(this.btnUnselectOne_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(196, 120);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(40, 25);
            this.btnSelectAll.TabIndex = 14;
            this.btnSelectAll.Text = ">>";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSelectOne
            // 
            this.btnSelectOne.Location = new System.Drawing.Point(196, 64);
            this.btnSelectOne.Name = "btnSelectOne";
            this.btnSelectOne.Size = new System.Drawing.Size(40, 25);
            this.btnSelectOne.TabIndex = 13;
            this.btnSelectOne.Text = ">";
            this.btnSelectOne.UseVisualStyleBackColor = true;
            this.btnSelectOne.Click += new System.EventHandler(this.btnSelectOne_Click);
            // 
            // lstSelectedTables
            // 
            this.lstSelectedTables.FormattingEnabled = true;
            this.lstSelectedTables.Location = new System.Drawing.Point(251, 52);
            this.lstSelectedTables.Name = "lstSelectedTables";
            this.lstSelectedTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSelectedTables.Size = new System.Drawing.Size(182, 225);
            this.lstSelectedTables.TabIndex = 12;
            // 
            // lstAllTables
            // 
            this.lstAllTables.FormattingEnabled = true;
            this.lstAllTables.Location = new System.Drawing.Point(8, 52);
            this.lstAllTables.Name = "lstAllTables";
            this.lstAllTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstAllTables.Size = new System.Drawing.Size(174, 225);
            this.lstAllTables.TabIndex = 8;
            // 
            // grpTables
            // 
            this.grpTables.Controls.Add(this.selectorModule);
            this.grpTables.Controls.Add(this.btnReload);
            this.grpTables.Controls.Add(this.txtNameSpacePrefix);
            this.grpTables.Controls.Add(this.btnSave);
            this.grpTables.Controls.Add(this.label1);
            this.grpTables.Controls.Add(this.label2);
            this.grpTables.Controls.Add(this.txtNameSpacePreview);
            this.grpTables.Controls.Add(this.txtNameSpaceSuffix);
            this.grpTables.Controls.Add(this.label3);
            this.grpTables.Controls.Add(this.lblTemplate);
            this.grpTables.Controls.Add(this.cmbTemplate);
            this.grpTables.Controls.Add(this.lblDatabase);
            this.grpTables.Controls.Add(this.cmbDatabase);
            this.grpTables.Controls.Add(this.chkWriteLogToFile);
            this.grpTables.Controls.Add(this.lblServer);
            this.grpTables.Controls.Add(this.cmbServer);
            this.grpTables.Controls.Add(this.btnSelectAll);
            this.grpTables.Controls.Add(this.btnUnselectAll);
            this.grpTables.Controls.Add(this.lstSelectedTables);
            this.grpTables.Controls.Add(this.btnUnselectOne);
            this.grpTables.Controls.Add(this.lstAllTables);
            this.grpTables.Controls.Add(this.btnSelectOne);
            this.grpTables.Location = new System.Drawing.Point(8, 7);
            this.grpTables.Name = "grpTables";
            this.grpTables.Size = new System.Drawing.Size(855, 589);
            this.grpTables.TabIndex = 25;
            this.grpTables.TabStop = false;
            this.grpTables.Text = "Tables";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(473, 237);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(85, 46);
            this.btnReload.TabIndex = 48;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // txtNameSpacePrefix
            // 
            this.txtNameSpacePrefix.Location = new System.Drawing.Point(554, 52);
            this.txtNameSpacePrefix.Name = "txtNameSpacePrefix";
            this.txtNameSpacePrefix.Size = new System.Drawing.Size(163, 20);
            this.txtNameSpacePrefix.TabIndex = 48;
            this.txtNameSpacePrefix.TextChanged += new System.EventHandler(this.txtNameSpacePrefix_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "NameSpace Prefix:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "NameSpace Suffix:";
            // 
            // txtNameSpacePreview
            // 
            this.txtNameSpacePreview.Location = new System.Drawing.Point(554, 120);
            this.txtNameSpacePreview.Name = "txtNameSpacePreview";
            this.txtNameSpacePreview.ReadOnly = true;
            this.txtNameSpacePreview.Size = new System.Drawing.Size(269, 20);
            this.txtNameSpacePreview.TabIndex = 53;
            // 
            // txtNameSpaceSuffix
            // 
            this.txtNameSpaceSuffix.Location = new System.Drawing.Point(554, 78);
            this.txtNameSpaceSuffix.Name = "txtNameSpaceSuffix";
            this.txtNameSpaceSuffix.Size = new System.Drawing.Size(163, 20);
            this.txtNameSpaceSuffix.TabIndex = 51;
            this.txtNameSpaceSuffix.TextChanged += new System.EventHandler(this.txtNameSpaceSuffix_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(439, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "NameSpace Preview:";
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Location = new System.Drawing.Point(5, 311);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(54, 13);
            this.lblTemplate.TabIndex = 44;
            this.lblTemplate.Text = "Template:";
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.Location = new System.Drawing.Point(65, 308);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(142, 21);
            this.cmbTemplate.TabIndex = 43;
            this.cmbTemplate.SelectedIndexChanged += new System.EventHandler(this.cmbTemplate_SelectedIndexChanged);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(211, 22);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(56, 13);
            this.lblDatabase.TabIndex = 42;
            this.lblDatabase.Text = "Database:";
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(281, 16);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(142, 21);
            this.cmbDatabase.TabIndex = 41;
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
            // 
            // chkWriteLogToFile
            // 
            this.chkWriteLogToFile.AutoSize = true;
            this.chkWriteLogToFile.Location = new System.Drawing.Point(442, 196);
            this.chkWriteLogToFile.Name = "chkWriteLogToFile";
            this.chkWriteLogToFile.Size = new System.Drawing.Size(103, 17);
            this.chkWriteLogToFile.TabIndex = 31;
            this.chkWriteLogToFile.Text = "Save Log to File";
            this.chkWriteLogToFile.UseVisualStyleBackColor = true;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(5, 22);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(41, 13);
            this.lblServer.TabIndex = 40;
            this.lblServer.Text = "Server:";
            // 
            // cmbServer
            // 
            this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(53, 19);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(142, 21);
            this.cmbServer.TabIndex = 18;
            this.cmbServer.SelectedIndexChanged += new System.EventHandler(this.cmbServer_SelectedIndexChanged);
            // 
            // selectorModule
            // 
            this.selectorModule.AllItems = ((System.Collections.ObjectModel.Collection<Johnny.CodeGenerator.Core.ModuleInfo>)(resources.GetObject("selectorModule.AllItems")));
            this.selectorModule.AllSelectedItems = ((System.Collections.ObjectModel.Collection<Johnny.CodeGenerator.Core.ModuleInfo>)(resources.GetObject("selectorModule.AllSelectedItems")));
            this.selectorModule.Location = new System.Drawing.Point(4, 335);
            this.selectorModule.Name = "selectorModule";
            this.selectorModule.Size = new System.Drawing.Size(440, 231);
            this.selectorModule.TabIndex = 54;
            // 
            // FrmTaskEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(875, 623);
            this.Controls.Add(this.grpTables);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(750, 400);
            this.Name = "FrmTaskEditor";
            this.Load += new System.EventHandler(this.FrmTaskEditor_Load);
            this.grpTables.ResumeLayout(false);
            this.grpTables.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUnselectOne;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSelectOne;
        private System.Windows.Forms.ListBox lstSelectedTables;
        private System.Windows.Forms.ListBox lstAllTables;
        private System.Windows.Forms.GroupBox grpTables;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.CheckBox chkWriteLogToFile;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.ComboBox cmbTemplate;
        private System.Windows.Forms.TextBox txtNameSpacePrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNameSpacePreview;
        private System.Windows.Forms.TextBox txtNameSpaceSuffix;
        private System.Windows.Forms.Label label3;
        private Controls.ListBoxSelector.ModuleSelector selectorModule;

    }
}