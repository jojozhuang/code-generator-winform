using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Johnny.CodeGenerator.Core;
using System.IO;
using System.Configuration;
using System.Collections.ObjectModel;

using Johnny.CodeGenerator.Core;
using Johnny.CodeGenerator.DBEngine;
using Johnny.Library.Helper;

namespace Johnny.CodeGenerator.WinUI
{
    public partial class FrmSingleGenerator : DockContent
    {
        public string _connectionstring = "";
        public string _server;
        public string _database;
        public string _table;

        public FrmSingleGenerator()
        {
            InitializeComponent();
        }

        #region FrmSingleGenerator_Load
        private void FrmSingleGenerator_Load(object sender, EventArgs e)
        {
            try
            {
                txtNameSpacePrefix.Text = "Johnny.CMS";
                txtNameSpaceSuffix.Text = "Access";
                tabSingleGenerator.SelectedIndex = 0;

                //initial richtextbox
                richtxtCode.Dock = DockStyle.Fill;
                richtxtCode.SetHighlighting("C#");
                richtxtCode.ShowEOLMarkers = false;
                richtxtCode.ShowSpaces = false;
                richtxtCode.ShowTabs = false;
                richtxtCode.ShowInvalidLines = false;
                richtxtCode.ShowVRuler = false;

                richtxtTemplate.Dock = DockStyle.Top;
                richtxtTemplate.SetHighlighting("XML");
                richtxtTemplate.ShowEOLMarkers = false;
                richtxtTemplate.ShowSpaces = false;
                richtxtTemplate.ShowTabs = false;
                richtxtTemplate.ShowInvalidLines = false;
                richtxtTemplate.ShowVRuler = false;

                richtxtEntity.Dock = DockStyle.Top;
                richtxtEntity.SetHighlighting("XML");
                richtxtEntity.ShowEOLMarkers = false;
                richtxtEntity.ShowSpaces = false;
                richtxtEntity.ShowTabs = false;
                richtxtEntity.ShowInvalidLines = false;
                richtxtEntity.ShowVRuler = false;

                richtxtFieldText.Dock = DockStyle.Top;
                richtxtFieldText.SetHighlighting("XML");
                richtxtFieldText.ShowEOLMarkers = false;
                richtxtFieldText.ShowSpaces = false;
                richtxtFieldText.ShowTabs = false;
                richtxtFieldText.ShowInvalidLines = false;
                richtxtFieldText.ShowVRuler = false;                

                grpTable.Text = _table;

                //templates
                Collection<TemplateInfo> templates = ConfigCtrl.GetTemplates();
                foreach (TemplateInfo item in templates)
                {
                    cmbTemplateGroup.Items.Add(item);
                }
                if (cmbTemplateGroup.Items.Count > 0)
                    cmbTemplateGroup.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }
        #endregion

        #region ShowDgv
        public void ShowDgv()
        {
            try
            {
                DataTable tb = Sql2kDriver.GetColumns(_connectionstring, _table);
                BindingSource dbs = new BindingSource();
                dbs.DataSource = tb;
                this.dgvTable.DataSource = dbs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }
        #endregion

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                //create entity
                CodeGeneratorSettingsInfo folder = ConfigCtrl.GetCodeGeneratorSettings();
                Collection<TableInfo> tables = Johnny.CodeGenerator.Core.DatabaseCtrl.GetTables(_connectionstring, _server, _database);
                foreach (TableInfo tb in tables)
                {
                    if (tb.TableName == _table)
                    {
                        string entityFolder = Path.Combine(folder.WorkingFolder, "Temp");
                        entityFolder = Path.Combine(entityFolder, folder.Entity);
                        Generator.GenerateEntityXmlFromTable(tb, entityFolder, txtNameSpacePrefix.Text, txtNameSpaceSuffix.Text);
                        break;
                    }
                }

                

                richtxtCode.Text = Johnny.CodeGenerator.Core.Generator.GenerateSingle(_connectionstring, _database, _server,GetModelName(_table), cmbTemplateGroup.Items[cmbTemplateGroup.SelectedIndex].ToString(), cmbTemplate.Items[cmbTemplate.SelectedIndex].ToString());

                tabSingleGenerator.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnGenXml_Click(object sender, EventArgs e)
        {
            CodeGeneratorSettingsInfo folder = ConfigCtrl.GetCodeGeneratorSettings();
            Generator.GenerateEntityXml(_connectionstring, _table, "dbo", _server, _database, folder.Entity, txtNameSpacePrefix.Text, txtNameSpaceSuffix.Text);
        }

        public static string GetModelName(string input)
        {
            string[] models = input.Split('_');
            return models[1].Substring(0, 1).ToUpper() + models[1].Substring(1, models[1].Length - 1);
        }

        private void btnXmlLoad_Click(object sender, EventArgs e)
        {
            
        }

        #region cmbTemplateGroup_SelectedIndexChanged
        private void cmbTemplateGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTemplateGroup.SelectedIndex < 0)
                return;

            cmbTemplate.Items.Clear();

            TemplateInfo template = cmbTemplateGroup.SelectedItem as TemplateInfo;
            if (template != null)
            {
                Collection<ModuleInfo> modules = ConfigCtrl.GetModules(template.FullPath);
                foreach (ModuleInfo item in modules)
                {
                    cmbTemplate.Items.Add(item);
                }
                if (cmbTemplate.Items.Count > 0)
                    cmbTemplate.SelectedIndex = 0;
            }
        }
        #endregion

        private void txtNameSpacePrefix_TextChanged(object sender, EventArgs e)
        {
            BuildNameSpace();
        }

        private void txtNameSpaceSuffix_TextChanged(object sender, EventArgs e)
        {
            BuildNameSpace();
        }

        private void BuildNameSpace()
        {
            txtBLL.Text = string.Concat(txtNameSpacePrefix.Text, ".BLL.", txtNameSpaceSuffix.Text);
            txtDAL.Text = string.Concat(txtNameSpacePrefix.Text, ".DAL.", txtNameSpaceSuffix.Text);
            txtModel.Text = string.Concat(txtNameSpacePrefix.Text, ".OM.", txtNameSpaceSuffix.Text);
        }

        private void btnLoadFieldText_Click(object sender, EventArgs e)
        {
           
        }

        private void tabSingleGenerator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabSingleGenerator.SelectedIndex == 2) //Template
            {
                CodeGeneratorSettingsInfo folder = ConfigCtrl.GetCodeGeneratorSettings();

                if (cmbTemplateGroup.SelectedIndex >= 0 && cmbTemplate.SelectedIndex >= 0)
                {
                    string strFile = DataConvert.GetString(cmbTemplate.Items[cmbTemplate.SelectedIndex]) + ".xslt";
                    string xsltFolder = Path.Combine(folder.Template, DataConvert.GetString(cmbTemplateGroup.Items[cmbTemplateGroup.SelectedIndex]));
                    //xsltFolder = Path.Combine(xsltFolder, DataConvert.GetString(cmbTemplate.Items[cmbTemplate.SelectedIndex]));
                    string xsltFile = Path.Combine(xsltFolder, strFile);
                    txtTemplatePath.Text = xsltFile;
                    using (StreamReader sr = new StreamReader(xsltFile, Encoding.UTF8))
                    {
                        richtxtTemplate.Text = sr.ReadToEnd();
                        sr.Close();
                    }                    
                }
            }
            else if (tabSingleGenerator.SelectedIndex == 3)
            {
                CodeGeneratorSettingsInfo folder = ConfigCtrl.GetCodeGeneratorSettings();

                string xmlFile = Path.Combine(folder.EntityFullPath, GetModelName(_table) + ".xml");
                txtEntityPath.Text = xmlFile;
                using (StreamReader sr = new StreamReader(xmlFile, Encoding.UTF8))
                {
                    richtxtEntity.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            else if (tabSingleGenerator.SelectedIndex == 4)
            {
                CodeGeneratorSettingsInfo folder = ConfigCtrl.GetCodeGeneratorSettings();

                string xmlFolder = @"D:\WorkSpace\Projects_GitHub\CodeGenerator\Dev\Src\CodeGenerator\";
                string xmlFile = xmlFolder + @"\" + GetModelName(_table) + ".xml";
                using (StreamReader sr = new StreamReader(xmlFile, Encoding.UTF8))
                {
                    richtxtFieldText.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
        }
    }
}