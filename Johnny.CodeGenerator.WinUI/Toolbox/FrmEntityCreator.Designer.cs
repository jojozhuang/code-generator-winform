namespace Johnny.CodeGenerator.WinUI.Toolbox
{
    partial class FrmEntityCreator
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
            this.dgvFields = new System.Windows.Forms.DataGridView();
            this.EntityNo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FieldType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRun = new System.Windows.Forms.Button();
            this.tabCodeCreator = new System.Windows.Forms.TabControl();
            this.tabPageFields = new System.Windows.Forms.TabPage();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.tabPageXml = new System.Windows.Forms.TabPage();
            this.btnSaveXml = new System.Windows.Forms.Button();
            this.richTextXml = new ICSharpCode.TextEditor.TextEditorControl();
            this.tabPageTemplate = new System.Windows.Forms.TabPage();
            this.btnSaveTemplate = new System.Windows.Forms.Button();
            this.richTextTemplate = new ICSharpCode.TextEditor.TextEditorControl();
            this.tabPageCode = new System.Windows.Forms.TabPage();
            this.richTextCode = new ICSharpCode.TextEditor.TextEditorControl();
            this.lblEntityTemplate = new System.Windows.Forms.Label();
            this.txtTemplatePath = new System.Windows.Forms.TextBox();
            this.btnSelectTemplate = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).BeginInit();
            this.tabCodeCreator.SuspendLayout();
            this.tabPageFields.SuspendLayout();
            this.tabPageXml.SuspendLayout();
            this.tabPageTemplate.SuspendLayout();
            this.tabPageCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFields
            // 
            this.dgvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EntityNo,
            this.FieldType,
            this.FieldName});
            this.dgvFields.Location = new System.Drawing.Point(6, 6);
            this.dgvFields.Name = "dgvFields";
            this.dgvFields.RowTemplate.Height = 23;
            this.dgvFields.Size = new System.Drawing.Size(457, 362);
            this.dgvFields.TabIndex = 1;
            // 
            // EntityNo
            // 
            this.EntityNo.HeaderText = "No.";
            this.EntityNo.Name = "EntityNo";
            // 
            // FieldType
            // 
            this.FieldType.HeaderText = "Type";
            this.FieldType.Items.AddRange(new object[] {
            "Int",
            "String",
            "Bool"});
            this.FieldType.Name = "FieldType";
            // 
            // FieldName
            // 
            this.FieldName.HeaderText = "Name";
            this.FieldName.Name = "FieldName";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(11, 525);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // tabCodeCreator
            // 
            this.tabCodeCreator.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabCodeCreator.Controls.Add(this.tabPageFields);
            this.tabCodeCreator.Controls.Add(this.tabPageXml);
            this.tabCodeCreator.Controls.Add(this.tabPageTemplate);
            this.tabCodeCreator.Controls.Add(this.tabPageCode);
            this.tabCodeCreator.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabCodeCreator.Location = new System.Drawing.Point(0, 0);
            this.tabCodeCreator.Multiline = true;
            this.tabCodeCreator.Name = "tabCodeCreator";
            this.tabCodeCreator.SelectedIndex = 0;
            this.tabCodeCreator.Size = new System.Drawing.Size(731, 488);
            this.tabCodeCreator.TabIndex = 3;
            // 
            // tabPageFields
            // 
            this.tabPageFields.Controls.Add(this.txtClassName);
            this.tabPageFields.Controls.Add(this.txtNameSpace);
            this.tabPageFields.Controls.Add(this.dgvFields);
            this.tabPageFields.Location = new System.Drawing.Point(4, 4);
            this.tabPageFields.Name = "tabPageFields";
            this.tabPageFields.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFields.Size = new System.Drawing.Size(723, 463);
            this.tabPageFields.TabIndex = 0;
            this.tabPageFields.Text = "Fields";
            this.tabPageFields.UseVisualStyleBackColor = true;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(561, 65);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(137, 21);
            this.txtClassName.TabIndex = 3;
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(561, 24);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(137, 21);
            this.txtNameSpace.TabIndex = 2;
            // 
            // tabPageXml
            // 
            this.tabPageXml.Controls.Add(this.btnSaveXml);
            this.tabPageXml.Controls.Add(this.richTextXml);
            this.tabPageXml.Location = new System.Drawing.Point(4, 4);
            this.tabPageXml.Name = "tabPageXml";
            this.tabPageXml.Size = new System.Drawing.Size(723, 463);
            this.tabPageXml.TabIndex = 3;
            this.tabPageXml.Text = "XML";
            this.tabPageXml.UseVisualStyleBackColor = true;
            // 
            // btnSaveXml
            // 
            this.btnSaveXml.Location = new System.Drawing.Point(3, 428);
            this.btnSaveXml.Name = "btnSaveXml";
            this.btnSaveXml.Size = new System.Drawing.Size(75, 23);
            this.btnSaveXml.TabIndex = 26;
            this.btnSaveXml.Text = "Save";
            this.btnSaveXml.UseVisualStyleBackColor = true;
            this.btnSaveXml.Click += new System.EventHandler(this.btnSaveXml_Click);
            // 
            // richTextXml
            // 
            this.richTextXml.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextXml.IsReadOnly = false;
            this.richTextXml.Location = new System.Drawing.Point(0, 0);
            this.richTextXml.Name = "richTextXml";
            this.richTextXml.Size = new System.Drawing.Size(723, 422);
            this.richTextXml.TabIndex = 2;
            this.richTextXml.Text = "richTextXml";
            // 
            // tabPageTemplate
            // 
            this.tabPageTemplate.Controls.Add(this.btnSaveTemplate);
            this.tabPageTemplate.Controls.Add(this.richTextTemplate);
            this.tabPageTemplate.Location = new System.Drawing.Point(4, 4);
            this.tabPageTemplate.Name = "tabPageTemplate";
            this.tabPageTemplate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTemplate.Size = new System.Drawing.Size(723, 463);
            this.tabPageTemplate.TabIndex = 1;
            this.tabPageTemplate.Text = "Template";
            this.tabPageTemplate.UseVisualStyleBackColor = true;
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.Location = new System.Drawing.Point(3, 434);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTemplate.TabIndex = 26;
            this.btnSaveTemplate.Text = "Save";
            this.btnSaveTemplate.UseVisualStyleBackColor = true;
            this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // richTextTemplate
            // 
            this.richTextTemplate.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextTemplate.IsReadOnly = false;
            this.richTextTemplate.Location = new System.Drawing.Point(3, 3);
            this.richTextTemplate.Name = "richTextTemplate";
            this.richTextTemplate.Size = new System.Drawing.Size(717, 425);
            this.richTextTemplate.TabIndex = 0;
            this.richTextTemplate.Text = "richTextTemplate";
            // 
            // tabPageCode
            // 
            this.tabPageCode.Controls.Add(this.richTextCode);
            this.tabPageCode.Location = new System.Drawing.Point(4, 4);
            this.tabPageCode.Name = "tabPageCode";
            this.tabPageCode.Size = new System.Drawing.Size(723, 463);
            this.tabPageCode.TabIndex = 2;
            this.tabPageCode.Text = "Code";
            this.tabPageCode.UseVisualStyleBackColor = true;
            // 
            // richTextCode
            // 
            this.richTextCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextCode.IsReadOnly = false;
            this.richTextCode.Location = new System.Drawing.Point(0, 0);
            this.richTextCode.Name = "richTextCode";
            this.richTextCode.Size = new System.Drawing.Size(723, 463);
            this.richTextCode.TabIndex = 1;
            this.richTextCode.Text = "richTextCode";
            // 
            // lblEntityTemplate
            // 
            this.lblEntityTemplate.AutoSize = true;
            this.lblEntityTemplate.Location = new System.Drawing.Point(18, 499);
            this.lblEntityTemplate.Name = "lblEntityTemplate";
            this.lblEntityTemplate.Size = new System.Drawing.Size(59, 12);
            this.lblEntityTemplate.TabIndex = 15;
            this.lblEntityTemplate.Text = "Template:";
            // 
            // txtTemplatePath
            // 
            this.txtTemplatePath.Location = new System.Drawing.Point(83, 496);
            this.txtTemplatePath.Name = "txtTemplatePath";
            this.txtTemplatePath.Size = new System.Drawing.Size(394, 21);
            this.txtTemplatePath.TabIndex = 16;
            // 
            // btnSelectTemplate
            // 
            this.btnSelectTemplate.Location = new System.Drawing.Point(483, 494);
            this.btnSelectTemplate.Name = "btnSelectTemplate";
            this.btnSelectTemplate.Size = new System.Drawing.Size(31, 23);
            this.btnSelectTemplate.TabIndex = 24;
            this.btnSelectTemplate.Text = "...";
            this.btnSelectTemplate.UseVisualStyleBackColor = true;
            this.btnSelectTemplate.Click += new System.EventHandler(this.btnSelectTemplate_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(330, 525);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 25;
            this.btnNext.Text = "=>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // FrmEntityCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 556);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnSelectTemplate);
            this.Controls.Add(this.tabCodeCreator);
            this.Controls.Add(this.txtTemplatePath);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblEntityTemplate);
            this.Name = "FrmEntityCreator";
            this.TabText = "FrmEntityCreator";
            this.Text = "FrmEntityCreator";
            this.Load += new System.EventHandler(this.FrmEntityCreator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).EndInit();
            this.tabCodeCreator.ResumeLayout(false);
            this.tabPageFields.ResumeLayout(false);
            this.tabPageFields.PerformLayout();
            this.tabPageXml.ResumeLayout(false);
            this.tabPageTemplate.ResumeLayout(false);
            this.tabPageCode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFields;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EntityNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn FieldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TabControl tabCodeCreator;
        private System.Windows.Forms.TabPage tabPageFields;
        private System.Windows.Forms.TabPage tabPageTemplate;
        private ICSharpCode.TextEditor.TextEditorControl richTextTemplate;
        private System.Windows.Forms.TabPage tabPageCode;
        private ICSharpCode.TextEditor.TextEditorControl richTextCode;
        private System.Windows.Forms.Label lblEntityTemplate;
        private System.Windows.Forms.TextBox txtTemplatePath;
        private System.Windows.Forms.Button btnSelectTemplate;
        private System.Windows.Forms.TabPage tabPageXml;
        private ICSharpCode.TextEditor.TextEditorControl richTextXml;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Button btnSaveXml;
        private System.Windows.Forms.Button btnSaveTemplate;



    }
}