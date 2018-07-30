namespace Johnny.CodeGenerator.WinUI.Toolbox
{
    partial class FrmJsonConvertor
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
            this.txtSourceCode = new System.Windows.Forms.TextBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtJsonCode = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSourceCode
            // 
            this.txtSourceCode.Location = new System.Drawing.Point(1, 2);
            this.txtSourceCode.Multiline = true;
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSourceCode.Size = new System.Drawing.Size(344, 447);
            this.txtSourceCode.TabIndex = 1;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(351, 172);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "==>";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtJsonCode
            // 
            this.txtJsonCode.Location = new System.Drawing.Point(432, 2);
            this.txtJsonCode.Multiline = true;
            this.txtJsonCode.Name = "txtJsonCode";
            this.txtJsonCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtJsonCode.Size = new System.Drawing.Size(357, 447);
            this.txtJsonCode.TabIndex = 4;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(351, 221);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // FrmJsonConvertor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 461);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtJsonCode);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtSourceCode);
            this.Name = "FrmJsonConvertor";
            this.TabText = "FrmJsonConvertor";
            this.Text = "FrmJsonConvertor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourceCode;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtJsonCode;
        private System.Windows.Forms.Button btnFilter;
    }
}