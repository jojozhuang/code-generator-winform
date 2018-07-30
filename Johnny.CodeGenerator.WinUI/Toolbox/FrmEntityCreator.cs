using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.IO;

using WeifenLuo.WinFormsUI.Docking;
using Johnny.CodeGenerator.Core;
using Johnny.Library.Helper;

namespace Johnny.CodeGenerator.WinUI.Toolbox
{
    public partial class FrmEntityCreator : FrmToolBase
    {
        public FrmEntityCreator()
        {
            InitializeComponent();
        }

        private void FrmEntityCreator_Load(object sender, EventArgs e)
        {
            try
            {
                txtNameSpace.Text = "Johnny.Project.OM";
                txtClassName.Text = "user";
                txtTemplatePath.Text = Path.Combine(Application.StartupPath, "Model.xslt");
                StreamReader sr = new StreamReader(txtTemplatePath.Text);
                richTextTemplate.FileName = txtTemplatePath.Text;
                richTextTemplate.Text = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();

                richTextXml.SetHighlighting("XML");
                richTextXml.Font = new Font("新宋体", 9);
                //richTextXml.Dock = DockStyle.Fill;
                richTextXml.ShowEOLMarkers = false;
                richTextXml.ShowSpaces = false;
                richTextXml.ShowTabs = false;
                richTextXml.ShowInvalidLines = false;
                richTextXml.ShowVRuler = false;

                richTextTemplate.SetHighlighting("XML");
                richTextTemplate.Font = new Font("新宋体", 9);
                //richTextTemplate.Dock = DockStyle.Fill;
                richTextTemplate.ShowEOLMarkers = false;
                richTextTemplate.ShowSpaces = false;
                richTextTemplate.ShowTabs = false;
                richTextTemplate.ShowInvalidLines = false;
                richTextTemplate.ShowVRuler = false;

                richTextCode.SetHighlighting("C#");
                richTextCode.Font = new Font("新宋体", 9);
                //richTextCode.Dock = DockStyle.Fill;
                richTextCode.ShowEOLMarkers = false;
                richTextCode.ShowSpaces = false;
                richTextCode.ShowTabs = false;
                richTextCode.ShowInvalidLines = false;
                richTextCode.ShowVRuler = false;
                
                dgvFields.Rows.Add(new DataGridViewRow());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected string[] BuildListView()
        {
            string[] subItem = new string[3];
            subItem[0] = "1";
            subItem[1] = "20020101";
            subItem[2] = "sdfsdf";
            return subItem;
        }

        private void btnSelectTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = Application.ExecutablePath;
                dialog.Filter = "XSLT files (*.xslt)|*.xslt|All files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    txtTemplatePath.Text = dialog.FileName;
                }
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmEntityCreator.btnSelectTemplate_Click", ex);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
              
                Generator.Transform(txtTemplatePath.Text, new string[] { Path.Combine(Application.StartupPath, txtClassName.Text + ".xml") }, Application.StartupPath, "cs");
                StreamReader sr = new StreamReader(Path.Combine(Application.StartupPath, txtClassName.Text + ".cs"));
                richTextCode.Text = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                tabCodeCreator.SelectedIndex = 3;
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmEntityCreator.btnNext_Click", ex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                EntityInfo entity = new EntityInfo();
                entity.NameSpace = txtNameSpace.Text;
                entity.ClassName = txtClassName.Text;
                Collection<FieldInfo> fields = new Collection<FieldInfo>();
                for (int ix = 0; ix < dgvFields.Rows.Count; ix++)
                {
                    FieldInfo field = new FieldInfo();
                    field.Type = DataConvert.GetString(dgvFields.Rows[ix].Cells[1].Value);
                    field.Name = DataConvert.GetString(dgvFields.Rows[ix].Cells[2].Value);
                    if (!String.IsNullOrEmpty(field.Type) && (!String.IsNullOrEmpty(field.Name)))
                        fields.Add(field);
                }
                entity.Fileds = fields;

                Generator.GenerateEntityXml(Application.StartupPath, entity);
                StreamReader sr = new StreamReader(Path.Combine(Application.StartupPath, entity.ClassName + ".xml"));
                richTextXml.Text = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                tabCodeCreator.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmEntityCreator.btnNext_Click", ex);
            }
        }

        private void btnSaveXml_Click(object sender, EventArgs e)
        {
            try
            {                
                StreamWriter streamWriter = new StreamWriter(richTextXml.FileName);
                streamWriter.Write(richTextXml.Text);
                streamWriter.Flush();
                streamWriter.Close();
                MessageBox.Show("Save Successfully!");
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmEntityCreator.btnSaveXml_Click", ex);
            }
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter streamWriter = new StreamWriter(richTextTemplate.FileName);
                streamWriter.Write(richTextTemplate.Text);
                streamWriter.Flush();
                streamWriter.Close();
                MessageBox.Show("Save Successfully!");
            }
            catch (Exception ex)
            {
                Program.ShowMessageBox("FrmEntityCreator.btnSaveTemplate_Click", ex);
            }
        }
    }
}