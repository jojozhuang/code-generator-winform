namespace Johnny.CodeGenerator.WinUI.Toolbox
{
    partial class FrmBase64Convertor
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
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnEncode = new System.Windows.Forms.Button();
            this.txtBase64Code = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSourceCode
            // 
            this.txtSourceCode.Location = new System.Drawing.Point(12, 12);
            this.txtSourceCode.Multiline = true;
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSourceCode.Size = new System.Drawing.Size(261, 373);
            this.txtSourceCode.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(289, 68);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 7;
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(296, 213);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 23);
            this.btnDecode.TabIndex = 6;
            this.btnDecode.Text = "<==";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(296, 129);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(75, 23);
            this.btnEncode.TabIndex = 5;
            this.btnEncode.Text = "==>";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // txtBase64Code
            // 
            this.txtBase64Code.Location = new System.Drawing.Point(404, 12);
            this.txtBase64Code.Multiline = true;
            this.txtBase64Code.Name = "txtBase64Code";
            this.txtBase64Code.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBase64Code.Size = new System.Drawing.Size(261, 373);
            this.txtBase64Code.TabIndex = 8;
            // 
            // Base64Convertor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 418);
            this.Controls.Add(this.txtBase64Code);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.txtSourceCode);
            this.Name = "Base64Convertor";
            this.TabText = "Base64Convertor";
            this.Text = "Base64Convertor";
            this.Load += new System.EventHandler(this.Base64Convertor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourceCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.TextBox txtBase64Code;
    }
}