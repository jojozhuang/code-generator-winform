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
    public partial class DlgAddSolution : Form
    {
        private string _newsolutionname;
        private VsTemplateInfo _vsversion;

        public DlgAddSolution()
        {
            InitializeComponent();
        }

        #region DlgAddSolution_Load
        private void DlgAddSolution_Load(object sender, EventArgs e)
        {
            txtSolutionName.Select();
        }
        #endregion

        #region btnOk_Click
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSolutionName.Text == string.Empty)
                {
                    txtSolutionName.Select();
                    MessageBox.Show("Please input the solution name!", CGConstants.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ConfigCtrl.IsSolutionExist(_vsversion, txtSolutionName.Text))
                {
                    txtSolutionName.Select();
                    MessageBox.Show("The template has already existed!", CGConstants.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ConfigCtrl.AddSolution(_vsversion, txtSolutionName.Text);

                _newsolutionname = txtSolutionName.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        public VsTemplateInfo VsVersion
        {
            get { return _vsversion; }
            set { _vsversion = value; }
        }

        public string NewSolutionName
        {
            get { return _newsolutionname; }
            set { _newsolutionname = value; }
        }

    }
}