using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Johnny.Controls.Windows.CommonMessageBox
{
    public partial class FrmMessageBox : Form
    {
        private ShrinkArea shrinkAreaADetail;
        private string _strTroubleShootingGuideline;

        public FrmMessageBox()
        {
            InitializeComponent();
            shrinkAreaADetail = new ShrinkArea(this, 100, 250);
            shrinkAreaADetail.Expanded = false;
        }

        private void FrmMessageBox_Load(object sender, EventArgs e)
        {
            this.btnDetail.Text = "▼详细信息(&D)";
            if (String.IsNullOrEmpty(_strTroubleShootingGuideline))
                btnSolution.Visible = false;
            else
                btnSolution.Visible = true;
        }

        //public string Message
        //{
        //    set
        //    {
        //        if (!String.IsNullOrEmpty(value))
        //        {
        //            lblMessage.Text = value;
        //        }
        //    }
        //}

        //public string FullMessage
        //{
        //    set
        //    {
        //        if (!String.IsNullOrEmpty(value))
        //        {
        //            txtFullMessage.Text = value;
        //        }
        //    }
        //}

        public string Module
        {
            set { lblModule.Text = value + "出错啦！"; }
        }
        public Exception Exception
        {
            set 
            {
                if (value != null)
                {
                    lblMessage.Text = value.Message;

                    string strMsg = string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    "Message: {0}\r\nSource: {1}\r\nTargetSite: {2}\r\nStack Trace: {3}\r\n", value.Message, value.Source, value.TargetSite, value.StackTrace);

                    txtFullMessage.Text = strMsg;
                }
            }
        }

        public string TroubleShooting
        {
            set { _strTroubleShootingGuideline = value; }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            try
            {
                shrinkAreaADetail.Toggle();

                // Update button text depending on state of shrink area.

                if (shrinkAreaADetail.Expanded)
                {
                    this.btnDetail.Text = "▲详细信息(&D)";
                }
                else
                {
                    this.btnDetail.Text = "▼详细信息(&D)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSolution_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(_strTroubleShootingGuideline))
                    MessageBox.Show(_strTroubleShootingGuideline, "如何解决", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}