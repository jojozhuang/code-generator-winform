using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

using System.Xml;

using Johnny.Controls.Windows.Toolbox;
using Johnny.CodeGenerator.WinUI.Toolbox;
using Johnny.CodeGenerator.WinUI.Utility;
using Johnny.Library.Helper;

namespace Johnny.CodeGenerator.WinUI
{
    public partial class FrmToolbox : DockContent
    {
        public FrmToolbox()
        {
            InitializeComponent();
        }

        private void DummyToolbox_Load(object sender, EventArgs e)
        {
            try
            {
                myToolbox.Categories.Clear();
                XmlDocument objXmlDoc = ConfigCtrl.GetToolboxItemsConfigFile();
                if (objXmlDoc == null)
                    return;

                XmlNodeList categoryNodes = objXmlDoc.SelectNodes("ToolBox/Category");
                for (int ix = 0; ix < categoryNodes.Count; ix++)
                {
                    ToolboxCategory category = new ToolboxCategory();
                    category.Name = categoryNodes[ix].Attributes["Name"].Value;
                    category.ImageIndex = DataConvert.GetInt32(categoryNodes[ix].Attributes["ImageIndex"].Value);
                    category.IsOpen = true;
                    myToolbox.Categories.Add(category);
                    XmlNodeList toolitemNodes = categoryNodes[ix].SelectNodes("ToolItem");
                    for (int iy = 0; iy < toolitemNodes.Count; iy++)
                    {
                        ToolboxItem toolitem = new ToolboxItem();
                        toolitem.Name = toolitemNodes[iy].Attributes["Name"].Value;
                        toolitem.ImageIndex = DataConvert.GetInt32(toolitemNodes[iy].Attributes["ImageIndex"].Value);
                        toolitem.ClassName = toolitemNodes[iy].Attributes["ClassName"].Value;
                        category.Items.Add(toolitem);
                    }
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmToolbox", ex);
            }
        }

        private void myToolbox_Click(object sender, EventArgs e)
        {
            try
            {
                if (myToolbox.SelectedItem == null)
                    return;

                //get the top form
                MainForm mainform = this.TopLevelControl as MainForm;
                if (mainform == null)
                    return;

                mainform.ShowToolForm(myToolbox.SelectedItem.ClassName);
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmToolbox", ex);
            }
        }

        
    }
}