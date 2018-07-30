using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Collections.ObjectModel;

using Johnny.CodeGenerator.Core;

namespace Johnny.CodeGenerator.Controls.DatabaseTree
{
    public partial class DlgAddSqlServer : Form
    {
        public ServerInfo NewSqlServer;

        public DlgAddSqlServer()
        {
            NewSqlServer = new ServerInfo();
            InitializeComponent();
        }

        #region AddSqlServer_Load
        private void AddSqlServer_Load(object sender, EventArgs e)
        {            
            rdbWindows.Checked = true;
            rdbWindows_CheckedChanged(null, null);
        }
        #endregion

        #region rdbWindows_CheckedChanged
        private void rdbWindows_CheckedChanged(object sender, EventArgs e)
        {
            this.lblLoginName.Enabled = !rdbWindows.Checked;
            this.lblPassword.Enabled = !rdbWindows.Checked;
            this.txtLoginName.Enabled = !rdbWindows.Checked;
            this.txtPassword.Enabled = !rdbWindows.Checked;
        }
        #endregion

        #region btnConnect_Click
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            this.Cursor = Cursors.WaitCursor;

            cmbDatabase.Items.Clear();
            cmbDatabase.Items.Add("Select All");

            try
            {
                Collection<DatabaseInfo> dbs = DatabaseCtrl.GetDataBases(GetConnectionString(), "", "");

                foreach (DatabaseInfo database in dbs)
                {
                    cmbDatabase.Items.Add(database);
                }    

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                cmbDatabase.SelectedIndex = 0;
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        
        #region btnOk_Click
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            this.Cursor = Cursors.WaitCursor;

            try
            {
                NewSqlServer.DatabaseType = "SQL2000";
                NewSqlServer.ServerName = txtServer.Text;
                NewSqlServer.ConnectionString = GetConnectionString();
                if (cmbDatabase.SelectedIndex <= 0)
                    NewSqlServer.DatabaseName = "";
                else
                    NewSqlServer.DatabaseName = cmbDatabase.SelectedItem.ToString();

                string ret = ConfigCtrl.EditServer(NewSqlServer);
                if (ret != CGConstants.STATUS_SUCCESS)
                {
                    MessageBox.Show(ret, CGConstants.MSG_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region ValidateInput
        private bool ValidateInput()
        {
            if (txtServer.Text == string.Empty)
            {
                txtServer.Select();
                MessageBox.Show("Server can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!rdbWindows.Checked && txtLoginName.Text == string.Empty)
            {
                txtLoginName.Select();
                MessageBox.Show("Login name can't be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        #region GetConnectionString
        private string GetConnectionString()
        {
            string connectionString = "";

            if (rdbWindows.Checked)
                connectionString += "Server=" + txtServer.Text + ";Integrated Security=SSPI;";
            else
                connectionString += "Server=" + txtServer.Text + ";User ID=" + txtLoginName.Text + ";Password=" + txtPassword.Text + ";";

            return connectionString;
        }
        #endregion
    }
}