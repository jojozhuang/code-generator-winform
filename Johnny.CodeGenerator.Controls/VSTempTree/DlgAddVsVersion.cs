using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.Controls.VSTempTree
{
    public partial class DlgAddVsVersion : Form
    {
        private string _newvsversionname;

        public DlgAddVsVersion()
        {
            InitializeComponent();
        }

        #region DlgAddVsVersion_Load
        private void DlgAddVsVersion_Load(object sender, EventArgs e)
        {
            txtVsVersion.Select();
        }
        #endregion

        #region btnOk_Click
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtVsVersion.Text == string.Empty)
                {
                    txtVsVersion.Select();
                    MessageBox.Show("Please input the VS Version name!", CGConstants.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ConfigCtrl.IsVsTemplateExist(txtVsVersion.Text))
                {
                    txtVsVersion.Select();
                    MessageBox.Show("The VS Version has already existed!", CGConstants.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ConfigCtrl.AddVsTemplate(txtVsVersion.Text);

                _newvsversionname = txtVsVersion.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        public string NewVsVersionName
        {
            get { return _newvsversionname; }
            set { _newvsversionname = value; }
        }

    }
}