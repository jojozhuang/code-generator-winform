namespace Johnny.CodeGenerator.WinUI
{
    partial class FrmSingleGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSingleGenerator));
            this.tabSingleGenerator = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpNameSpace = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtNameSpacePrefix = new System.Windows.Forms.TextBox();
            this.txtDAL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBLL = new System.Windows.Forms.TextBox();
            this.txtNameSpaceSuffix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpParameter = new System.Windows.Forms.GroupBox();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.cmbTemplateGroup = new System.Windows.Forms.ComboBox();
            this.grpTable = new System.Windows.Forms.GroupBox();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richtxtCode = new ICSharpCode.TextEditor.TextEditorControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.grpTemplateFile = new System.Windows.Forms.GroupBox();
            this.txtTemplatePath = new System.Windows.Forms.TextBox();
            this.lblTemplatePath = new System.Windows.Forms.Label();
            this.richtxtTemplate = new ICSharpCode.TextEditor.TextEditorControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtEntityPath = new System.Windows.Forms.TextBox();
            this.lblEntityFile = new System.Windows.Forms.Label();
            this.richtxtEntity = new ICSharpCode.TextEditor.TextEditorControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnLoadFieldText = new System.Windows.Forms.Button();
            this.richtxtFieldText = new ICSharpCode.TextEditor.TextEditorControl();
            this.tabSingleGenerator.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpNameSpace.SuspendLayout();
            this.grpParameter.SuspendLayout();
            this.grpTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.grpTemplateFile.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSingleGenerator
            // 
            this.tabSingleGenerator.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabSingleGenerator.Controls.Add(this.tabPage1);
            this.tabSingleGenerator.Controls.Add(this.tabPage2);
            this.tabSingleGenerator.Controls.Add(this.tabPage3);
            this.tabSingleGenerator.Controls.Add(this.tabPage4);
            this.tabSingleGenerator.Controls.Add(this.tabPage5);
            this.tabSingleGenerator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSingleGenerator.Location = new System.Drawing.Point(0, 0);
            this.tabSingleGenerator.Name = "tabSingleGenerator";
            this.tabSingleGenerator.SelectedIndex = 0;
            this.tabSingleGenerator.Size = new System.Drawing.Size(731, 750);
            this.tabSingleGenerator.TabIndex = 0;
            this.tabSingleGenerator.SelectedIndexChanged += new System.EventHandler(this.tabSingleGenerator_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpNameSpace);
            this.tabPage1.Controls.Add(this.grpParameter);
            this.tabPage1.Controls.Add(this.grpTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(723, 724);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Setting";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpNameSpace
            // 
            this.grpNameSpace.Controls.Add(this.label4);
            this.grpNameSpace.Controls.Add(this.label6);
            this.grpNameSpace.Controls.Add(this.btnGenerate);
            this.grpNameSpace.Controls.Add(this.txtModel);
            this.grpNameSpace.Controls.Add(this.txtNameSpacePrefix);
            this.grpNameSpace.Controls.Add(this.txtDAL);
            this.grpNameSpace.Controls.Add(this.label1);
            this.grpNameSpace.Controls.Add(this.label2);
            this.grpNameSpace.Controls.Add(this.txtBLL);
            this.grpNameSpace.Controls.Add(this.txtNameSpaceSuffix);
            this.grpNameSpace.Controls.Add(this.label3);
            this.grpNameSpace.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpNameSpace.Location = new System.Drawing.Point(3, 308);
            this.grpNameSpace.Name = "grpNameSpace";
            this.grpNameSpace.Size = new System.Drawing.Size(717, 151);
            this.grpNameSpace.TabIndex = 27;
            this.grpNameSpace.TabStop = false;
            this.grpNameSpace.Text = "Name Space";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "DAL NameSpace£º";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(319, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Model NameSpace£º";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(20, 100);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(432, 82);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(266, 20);
            this.txtModel.TabIndex = 25;
            // 
            // txtNameSpacePrefix
            // 
            this.txtNameSpacePrefix.Location = new System.Drawing.Point(129, 35);
            this.txtNameSpacePrefix.Name = "txtNameSpacePrefix";
            this.txtNameSpacePrefix.Size = new System.Drawing.Size(163, 20);
            this.txtNameSpacePrefix.TabIndex = 7;
            this.txtNameSpacePrefix.TextChanged += new System.EventHandler(this.txtNameSpacePrefix_TextChanged);
            // 
            // txtDAL
            // 
            this.txtDAL.Location = new System.Drawing.Point(432, 55);
            this.txtDAL.Name = "txtDAL";
            this.txtDAL.ReadOnly = true;
            this.txtDAL.Size = new System.Drawing.Size(266, 20);
            this.txtDAL.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "NameSpace Prefix:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "NameSpace Suffix:";
            // 
            // txtBLL
            // 
            this.txtBLL.Location = new System.Drawing.Point(432, 28);
            this.txtBLL.Name = "txtBLL";
            this.txtBLL.ReadOnly = true;
            this.txtBLL.Size = new System.Drawing.Size(266, 20);
            this.txtBLL.TabIndex = 22;
            // 
            // txtNameSpaceSuffix
            // 
            this.txtNameSpaceSuffix.Location = new System.Drawing.Point(129, 68);
            this.txtNameSpaceSuffix.Name = "txtNameSpaceSuffix";
            this.txtNameSpaceSuffix.Size = new System.Drawing.Size(163, 20);
            this.txtNameSpaceSuffix.TabIndex = 20;
            this.txtNameSpaceSuffix.TextChanged += new System.EventHandler(this.txtNameSpaceSuffix_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "BLL NameSpace£º";
            // 
            // grpParameter
            // 
            this.grpParameter.Controls.Add(this.cmbTemplate);
            this.grpParameter.Controls.Add(this.label5);
            this.grpParameter.Controls.Add(this.lblTemplate);
            this.grpParameter.Controls.Add(this.cmbTemplateGroup);
            this.grpParameter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpParameter.Location = new System.Drawing.Point(3, 220);
            this.grpParameter.Name = "grpParameter";
            this.grpParameter.Size = new System.Drawing.Size(717, 88);
            this.grpParameter.TabIndex = 3;
            this.grpParameter.TabStop = false;
            this.grpParameter.Text = "Parameter";
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.Location = new System.Drawing.Point(118, 55);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(146, 21);
            this.cmbTemplate.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Template:";
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Location = new System.Drawing.Point(17, 26);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(86, 13);
            this.lblTemplate.TabIndex = 15;
            this.lblTemplate.Text = "Template Group:";
            // 
            // cmbTemplateGroup
            // 
            this.cmbTemplateGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplateGroup.FormattingEnabled = true;
            this.cmbTemplateGroup.Location = new System.Drawing.Point(118, 22);
            this.cmbTemplateGroup.Name = "cmbTemplateGroup";
            this.cmbTemplateGroup.Size = new System.Drawing.Size(121, 21);
            this.cmbTemplateGroup.TabIndex = 14;
            this.cmbTemplateGroup.SelectedIndexChanged += new System.EventHandler(this.cmbTemplateGroup_SelectedIndexChanged);
            // 
            // grpTable
            // 
            this.grpTable.Controls.Add(this.dgvTable);
            this.grpTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTable.Location = new System.Drawing.Point(3, 3);
            this.grpTable.Name = "grpTable";
            this.grpTable.Size = new System.Drawing.Size(717, 217);
            this.grpTable.TabIndex = 1;
            this.grpTable.TabStop = false;
            this.grpTable.Text = "TableName";
            // 
            // dgvTable
            // 
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTable.Location = new System.Drawing.Point(3, 16);
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.ReadOnly = true;
            this.dgvTable.RowTemplate.Height = 23;
            this.dgvTable.Size = new System.Drawing.Size(711, 198);
            this.dgvTable.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richtxtCode);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(723, 724);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Code";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richtxtCode
            // 
            this.richtxtCode.IsReadOnly = false;
            this.richtxtCode.Location = new System.Drawing.Point(378, 194);
            this.richtxtCode.Name = "richtxtCode";
            this.richtxtCode.ShowEOLMarkers = true;
            this.richtxtCode.ShowSpaces = true;
            this.richtxtCode.ShowTabs = true;
            this.richtxtCode.Size = new System.Drawing.Size(100, 108);
            this.richtxtCode.TabIndex = 0;
            this.richtxtCode.Text = "textEditorControl1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.grpTemplateFile);
            this.tabPage3.Controls.Add(this.richtxtTemplate);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(723, 724);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Template";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // grpTemplateFile
            // 
            this.grpTemplateFile.Controls.Add(this.txtTemplatePath);
            this.grpTemplateFile.Controls.Add(this.lblTemplatePath);
            this.grpTemplateFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTemplateFile.Location = new System.Drawing.Point(0, 348);
            this.grpTemplateFile.Name = "grpTemplateFile";
            this.grpTemplateFile.Size = new System.Drawing.Size(723, 108);
            this.grpTemplateFile.TabIndex = 4;
            this.grpTemplateFile.TabStop = false;
            this.grpTemplateFile.Text = "File";
            // 
            // txtTemplatePath
            // 
            this.txtTemplatePath.Location = new System.Drawing.Point(40, 26);
            this.txtTemplatePath.Name = "txtTemplatePath";
            this.txtTemplatePath.ReadOnly = true;
            this.txtTemplatePath.Size = new System.Drawing.Size(661, 20);
            this.txtTemplatePath.TabIndex = 24;
            // 
            // lblTemplatePath
            // 
            this.lblTemplatePath.AutoSize = true;
            this.lblTemplatePath.Location = new System.Drawing.Point(8, 29);
            this.lblTemplatePath.Name = "lblTemplatePath";
            this.lblTemplatePath.Size = new System.Drawing.Size(32, 13);
            this.lblTemplatePath.TabIndex = 23;
            this.lblTemplatePath.Text = "Path:";
            // 
            // richtxtTemplate
            // 
            this.richtxtTemplate.Dock = System.Windows.Forms.DockStyle.Top;
            this.richtxtTemplate.IsReadOnly = false;
            this.richtxtTemplate.Location = new System.Drawing.Point(0, 0);
            this.richtxtTemplate.Name = "richtxtTemplate";
            this.richtxtTemplate.ShowEOLMarkers = true;
            this.richtxtTemplate.ShowSpaces = true;
            this.richtxtTemplate.ShowTabs = true;
            this.richtxtTemplate.Size = new System.Drawing.Size(723, 348);
            this.richtxtTemplate.TabIndex = 1;
            this.richtxtTemplate.Text = "textEditorControl1";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.richtxtEntity);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(723, 724);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Xml";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtEntityPath);
            this.groupBox3.Controls.Add(this.lblEntityFile);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 392);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(723, 108);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Entity";
            // 
            // txtEntityPath
            // 
            this.txtEntityPath.Location = new System.Drawing.Point(47, 44);
            this.txtEntityPath.Name = "txtEntityPath";
            this.txtEntityPath.ReadOnly = true;
            this.txtEntityPath.Size = new System.Drawing.Size(661, 20);
            this.txtEntityPath.TabIndex = 26;
            // 
            // lblEntityFile
            // 
            this.lblEntityFile.AutoSize = true;
            this.lblEntityFile.Location = new System.Drawing.Point(15, 47);
            this.lblEntityFile.Name = "lblEntityFile";
            this.lblEntityFile.Size = new System.Drawing.Size(32, 13);
            this.lblEntityFile.TabIndex = 25;
            this.lblEntityFile.Text = "Path:";
            // 
            // richtxtEntity
            // 
            this.richtxtEntity.Dock = System.Windows.Forms.DockStyle.Top;
            this.richtxtEntity.IsReadOnly = false;
            this.richtxtEntity.Location = new System.Drawing.Point(0, 0);
            this.richtxtEntity.Name = "richtxtEntity";
            this.richtxtEntity.ShowEOLMarkers = true;
            this.richtxtEntity.ShowSpaces = true;
            this.richtxtEntity.ShowTabs = true;
            this.richtxtEntity.Size = new System.Drawing.Size(723, 392);
            this.richtxtEntity.TabIndex = 2;
            this.richtxtEntity.Text = "textEditorControl1";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnLoadFieldText);
            this.tabPage5.Controls.Add(this.richtxtFieldText);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(723, 724);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "FieldText";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnLoadFieldText
            // 
            this.btnLoadFieldText.Location = new System.Drawing.Point(20, 429);
            this.btnLoadFieldText.Name = "btnLoadFieldText";
            this.btnLoadFieldText.Size = new System.Drawing.Size(75, 25);
            this.btnLoadFieldText.TabIndex = 5;
            this.btnLoadFieldText.Text = "Load";
            this.btnLoadFieldText.UseVisualStyleBackColor = true;
            this.btnLoadFieldText.Click += new System.EventHandler(this.btnLoadFieldText_Click);
            // 
            // richtxtFieldText
            // 
            this.richtxtFieldText.Dock = System.Windows.Forms.DockStyle.Top;
            this.richtxtFieldText.IsReadOnly = false;
            this.richtxtFieldText.Location = new System.Drawing.Point(3, 3);
            this.richtxtFieldText.Name = "richtxtFieldText";
            this.richtxtFieldText.ShowEOLMarkers = true;
            this.richtxtFieldText.ShowSpaces = true;
            this.richtxtFieldText.ShowTabs = true;
            this.richtxtFieldText.Size = new System.Drawing.Size(717, 392);
            this.richtxtFieldText.TabIndex = 3;
            this.richtxtFieldText.Text = "textEditorControl1";
            // 
            // FrmSingleGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 750);
            this.Controls.Add(this.tabSingleGenerator);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSingleGenerator";
            this.TabText = "Single Generator";
            this.Text = "Single Generator";
            this.Load += new System.EventHandler(this.FrmSingleGenerator_Load);
            this.tabSingleGenerator.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpNameSpace.ResumeLayout(false);
            this.grpNameSpace.PerformLayout();
            this.grpParameter.ResumeLayout(false);
            this.grpParameter.PerformLayout();
            this.grpTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.grpTemplateFile.ResumeLayout(false);
            this.grpTemplateFile.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSingleGenerator;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox grpParameter;
        private System.Windows.Forms.GroupBox grpTable;
        private System.Windows.Forms.Button btnGenerate;
        private ICSharpCode.TextEditor.TextEditorControl richtxtCode;
        private System.Windows.Forms.TabPage tabPage3;
        private ICSharpCode.TextEditor.TextEditorControl richtxtTemplate;
        private System.Windows.Forms.TabPage tabPage4;
        private ICSharpCode.TextEditor.TextEditorControl richtxtEntity;
        private System.Windows.Forms.DataGridView dgvTable;
        private System.Windows.Forms.ComboBox cmbTemplateGroup;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.ComboBox cmbTemplate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameSpacePrefix;
        private System.Windows.Forms.TextBox txtNameSpaceSuffix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtDAL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBLL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpNameSpace;
        private System.Windows.Forms.GroupBox grpTemplateFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage tabPage5;
        private ICSharpCode.TextEditor.TextEditorControl richtxtFieldText;
        private System.Windows.Forms.Button btnLoadFieldText;
        private System.Windows.Forms.TextBox txtTemplatePath;
        private System.Windows.Forms.Label lblTemplatePath;
        private System.Windows.Forms.TextBox txtEntityPath;
        private System.Windows.Forms.Label lblEntityFile;


    }
}