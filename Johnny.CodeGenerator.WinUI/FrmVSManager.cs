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

using Johnny.CodeGenerator.Controls.VSTempTree;

namespace Johnny.CodeGenerator.WinUI
{
    public partial class FrmVSManager : DockContent
    {
        public FrmVSManager()
        {
            InitializeComponent();
        }

        private void FrmVSManager_Load(object sender, EventArgs e)
        {
            try
            {
                vstempTree.OpenSolutionTemplate += new VSTempTree.OpenSolutionTemplateEventHandler(projectTree_OpenSolutionTemplate);
                vstempTree.OpenProjectTemplate += new VSTempTree.OpenProjectTemplateEventHandler(projectTree_OpenProjectTemplate);
                vstempTree.InitialNodes();
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmVSManager.FrmVSManager_Load", ex);
            }
        }

        private void projectTree_OpenSolutionTemplate(object sender, SolutionNodeEventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.OpenFile(e.Solution.FileName, e.Solution.SolutionName);

            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmVSManager.projectTree_OpenSolutionTemplate", ex);
            } 
        }

        private void projectTree_OpenProjectTemplate(object sender, ProjectNodeEventArgs e)
        {
            try
            {
                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform != null)
                    mainform.OpenFile(e.Project.FileName, e.Project.ProjectName);

            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmVSManager.projectTree_OpenProjectTemplate", ex);
            }
        }
            
    }
}