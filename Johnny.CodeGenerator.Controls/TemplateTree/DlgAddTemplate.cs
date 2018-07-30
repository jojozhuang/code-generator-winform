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

namespace Johnny.CodeGenerator.Controls.TemplateTree
{
    public partial class DlgAddTemplate : Form
    {
        private string _newtemplatename;

        public DlgAddTemplate()
        {
            InitializeComponent();
        }

        #region DlgAddTemplate_Load
        private void DlgAddTemplate_Load(object sender, EventArgs e)
        {
            txtTemplateName.Select();
        }
        #endregion

        #region btnOk_Click
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTemplateName.Text == string.Empty)
                {
                    txtTemplateName.Select();
                    MessageBox.Show("Please input the Template name!", CGConstants.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ConfigCtrl.IsTemplateExist(txtTemplateName.Text))
                {
                    txtTemplateName.Select();
                    MessageBox.Show("The template has already existed!", CGConstants.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ConfigCtrl.AddTemplate(txtTemplateName.Text);

                _newtemplatename = txtTemplateName.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        public string NewTemplateName
        {
            get { return _newtemplatename; }
            set { _newtemplatename = value; }
        }

    }
}