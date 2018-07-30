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

using Johnny.CodeGenerator.Controls.TemplateTree;

namespace Johnny.CodeGenerator.WinUI
{
    public partial class FrmTemplateExplorer : DockContent
    {
        public FrmTemplateExplorer()
        {
            InitializeComponent();
        }

        private void FrmTemplateExplorer_Load(object sender, EventArgs e)
        {
            try
            {
                templateTree.OpenModule += new TemplateTree.OpenModuleTemplateEventHandler(templateTree_OpenModule);
                templateTree.InitialNodes();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTemplateManager.DataBaseExplorer_Load", ex);
            }
        }

        private void templateTree_OpenModule(object sender, ModuleNodeEventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.OpenFile(e.Module.FullName, e.Module.ModuleName);

            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmTemplateManager.templateTree_OpenXsltTemplate", ex);
            }  
        }              
    }
}