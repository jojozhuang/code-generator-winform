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
    public partial class DlgAddProject : Form
    {
        private string _newprojectname;
        private VsTemplateInfo _vsversion;

        public DlgAddProject()
        {
            InitializeComponent();
        }

        private void DlgAddProject_Load(object sender, EventArgs e)
        {
            txtProjectName.Select();
        }

        #region btnOk_Click
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProjectName.Text == string.Empty)
                {
                    txtProjectName.Select();
                    MessageBox.Show("Please input the project name!", CGConstants.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ConfigCtrl.IsProjectExist(_vsversion, txtProjectName.Text))
                {
                    txtProjectName.Select();
                    MessageBox.Show("The project has already existed!", CGConstants.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ConfigCtrl.AddProject(_vsversion, txtProjectName.Text);

                _newprojectname = txtProjectName.Text;

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

        public string NewProjectName
        {
            get { return _newprojectname; }
            set { _newprojectname = value; }
        }


    }
}