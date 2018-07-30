using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;

using WeifenLuo.WinFormsUI.Docking;

using Johnny.CodeGenerator.Controls.DatabaseTree;

namespace Johnny.CodeGenerator.WinUI
{
    public partial class FrmDatabaseExplorer : DockContent
    {
        public FrmDatabaseExplorer()
        {
            InitializeComponent();
        }

        private void FrmDatabaseExplorer_Load(object sender, EventArgs e)
        {
            try
            {                
                dbTree.TableNodeClick += new DatabaseTree.TableNodeClickEventHandler(dbTree_TableNodeClick);
                dbTree.InitialNodes();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmDatabaseManager.DataBaseExplorer_Load", ex);
            }
        }               

        private void dbTree_TableNodeClick(object sender, TableNodeClickEventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.ShowCodeGenerator(e.ConnectionString, e.Server, e.Database, e.Table);

            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmDatabaseManager.dbTree_TableNodeClick", ex);
            }            
        }
        
    }
}