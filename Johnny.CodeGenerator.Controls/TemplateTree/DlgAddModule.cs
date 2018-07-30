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
    public partial class DlgAddModule : Form
    {
        private TemplateInfo _template;

        public DlgAddModule()
        {
            InitializeComponent();
        }

        private void DlgAddModule_Load(object sender, EventArgs e)
        {
            txtModuleName.Select();
        }

        #region btnOk_Click
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtModuleName.Text == string.Empty)
                {
                    txtModuleName.Select();
                    MessageBox.Show("Please input the module name!", CGConstants.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ConfigCtrl.IsModuleExist(_template, txtModuleName.Text))
                {
                    txtModuleName.Select();
                    MessageBox.Show("The module has already existed!", CGConstants.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ConfigCtrl.AddModule(_template, txtModuleName.Text);

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        public TemplateInfo Template
        {
            get { return _template; }
            set { _template = value; }
        }

    }
}