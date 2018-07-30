using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Johnny.CodeGenerator.Core;
using Johnny.Library.Helper;

namespace Johnny.CodeGenerator.WinUI
{
    public partial class DlgSettingsCG : Form
    {
        public DlgSettingsCG()
        {
            InitializeComponent();
        }

        private void DlgSettingsCG_Load(object sender, EventArgs e)
        {
            try
            {
                //load config info
                CodeGeneratorSettingsInfo cgsettings = ConfigCtrl.GetCodeGeneratorSettings();
                if (cgsettings != null)
                {
                    txtWorkingFolder.Text = cgsettings.WorkingFolder;
                    txtTemplate.Text = cgsettings.Template;
                    txtVsTemplate.Text = cgsettings.VsTemplate;
                    txtOutput.Text = cgsettings.Output;
                    txtEntity.Text = cgsettings.Entity;
                }

                txtWorkingFolder.Select();
                txtOutput.Text = "Output";
                txtEntity.Text = "Entity";
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("DlgSettingsCG.DlgSettingsCG_Load", ex);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtWorkingFolder.Text == string.Empty)
                {
                    txtWorkingFolder.Select();
                    MessageBox.Show("Working folder can't be empty!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!Directory.Exists(txtWorkingFolder.Text))
                {
                    txtWorkingFolder.Select();
                    MessageBox.Show("Invalid path of Working folder!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtTemplate.Text == string.Empty)
                {
                    txtTemplate.Select();
                    MessageBox.Show("Template folder can't be empty!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Directory.Exists(txtTemplate.Text))
                {
                    txtTemplate.Select();
                    MessageBox.Show("Invalid path of Template folder!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtVsTemplate.Text == string.Empty)
                {
                    txtVsTemplate.Select();
                    MessageBox.Show("Visual Studio Template folder can't be empty!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!Directory.Exists(txtVsTemplate.Text))
                {
                    txtVsTemplate.Select();
                    MessageBox.Show("Invalid path of Visual Studio Template folder!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtOutput.Text == string.Empty)
                {
                    txtOutput.Select();
                    MessageBox.Show("Output folder can't be empty!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DataValidation.IsValidPathName(txtOutput.Text))
                {
                    txtOutput.Select();
                    MessageBox.Show("Invalid charaters for Output folder name!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtEntity.Text == string.Empty)
                {
                    txtEntity.Select();
                    MessageBox.Show("Entity folder name can't be empty!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!DataValidation.IsValidPathName(txtEntity.Text))
                {
                    txtEntity.Select();
                    MessageBox.Show("Invalid charaters for Entity folder name", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CodeGeneratorSettingsInfo cgsettings = new CodeGeneratorSettingsInfo();
                cgsettings.WorkingFolder = txtWorkingFolder.Text;
                cgsettings.Template = txtTemplate.Text;
                cgsettings.VsTemplate = txtVsTemplate.Text;
                cgsettings.Output = txtOutput.Text;
                cgsettings.Entity = txtEntity.Text;

                if (!ConfigCtrl.SetCodeGeneratorSettings(cgsettings))
                {
                    MessageBox.Show("Failed to save!", MainConstants.MESSAGEBOX_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("DlgWorkingFolderSetting.btnOK_Click", ex);
            }
        }

        private void btnWorkingFolder_Click(object sender, EventArgs e)
        {
            dlgFolderBrowser.SelectedPath = txtWorkingFolder.Text;
            if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
                txtWorkingFolder.Text = dlgFolderBrowser.SelectedPath;
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            dlgFolderBrowser.SelectedPath = txtTemplate.Text;
            if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
                txtTemplate.Text = dlgFolderBrowser.SelectedPath;
        }

        private void btnVsTemplate_Click(object sender, EventArgs e)
        {
            dlgFolderBrowser.SelectedPath = txtOutput.Text;
            if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
                txtVsTemplate.Text = dlgFolderBrowser.SelectedPath;
        }
          
    }
}