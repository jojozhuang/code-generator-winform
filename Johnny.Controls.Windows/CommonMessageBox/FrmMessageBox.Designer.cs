namespace Johnny.Controls.Windows.CommonMessageBox
{
    partial class FrmMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessageBox));
            this.txtFullMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.picError = new System.Windows.Forms.PictureBox();
            this.lblModule = new System.Windows.Forms.Label();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSolution = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFullMessage
            // 
            this.txtFullMessage.BackColor = System.Drawing.SystemColors.Control;
            this.txtFullMessage.Location = new System.Drawing.Point(6, 127);
            this.txtFullMessage.Multiline = true;
            this.txtFullMessage.Name = "txtFullMessage";
            this.txtFullMessage.ReadOnly = true;
            this.txtFullMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFullMessage.Size = new System.Drawing.Size(400, 151);
            this.txtFullMessage.TabIndex = 0;
            this.txtFullMessage.WordWrap = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoEllipsis = true;
            this.lblMessage.Location = new System.Drawing.Point(96, 40);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(304, 38);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "lblMessage";
            // 
            // picError
            // 
            this.picError.Image = ((System.Drawing.Image)(resources.GetObject("picError.Image")));
            this.picError.Location = new System.Drawing.Point(23, 15);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(51, 63);
            this.picError.TabIndex = 2;
            this.picError.TabStop = false;
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModule.ForeColor = System.Drawing.Color.Red;
            this.lblModule.Location = new System.Drawing.Point(92, 12);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(90, 24);
            this.lblModule.TabIndex = 3;
            this.lblModule.Text = "出错啦！";
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(310, 87);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(96, 25);
            this.btnDetail.TabIndex = 4;
            this.btnDetail.Text = "详细信息(&D)";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(211, 87);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 25);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnSolution
            // 
            this.btnSolution.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSolution.Location = new System.Drawing.Point(6, 87);
            this.btnSolution.Name = "btnSolution";
            this.btnSolution.Size = new System.Drawing.Size(96, 25);
            this.btnSolution.TabIndex = 6;
            this.btnSolution.Text = "如何解决";
            this.btnSolution.UseVisualStyleBackColor = true;
            this.btnSolution.Click += new System.EventHandler(this.btnSolution_Click);
            // 
            // FrmMessageBox
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(412, 284);
            this.Controls.Add(this.btnSolution);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.lblModule);
            this.Controls.Add(this.picError);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtFullMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMessageBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "开心助手";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFullMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.PictureBox picError;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSolution;
    }
}