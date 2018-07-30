using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using Johnny.Library.Helper;

namespace Johnny.CodeGenerator.WinUI.Toolbox
{
    public partial class FrmBase64Convertor : FrmToolBase
    {
        public FrmBase64Convertor()
        {
            InitializeComponent();
        }

        private void Base64Convertor_Load(object sender, EventArgs e)
        {
            txtCode.Text = "65001";
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            try
            {
                txtBase64Code.Text = Base64Helper.EncodingForString(txtSourceCode.Text, System.Text.Encoding.GetEncoding(DataConvert.GetInt32(txtCode.Text)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            try
            {
                txtSourceCode.Text = Base64Helper.DecodingForString(txtBase64Code.Text, System.Text.Encoding.GetEncoding(DataConvert.GetInt32(txtCode.Text)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}