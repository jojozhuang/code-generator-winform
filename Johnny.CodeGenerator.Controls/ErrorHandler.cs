using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Johnny.CodeGenerator.Core;
using Johnny.Library.Log;
using Johnny.Controls.Windows.CommonMessageBox;

namespace Johnny.CodeGenerator.Controls
{
    public static class ErrorHandler
    {
        public static void ShowMessageBox(string module, Exception ex)
        {
            ShowMessageBox(module, "", ex);
        }

        public static void ShowMessageBox(string module, string troubleshooting, Exception ex)
        {
            //ex.TargetSite()
            //string strMsg = "";
            //strMsg = "Message:" + ex.Message + "\r\n";
            //strMsg += "Source:" + ex.Source + "\r\n";
            //strMsg += "TargetSite:" + ex.TargetSite + "\r\n";
            //strMsg += "StackTrace:" + ex.StackTrace + "\r\n";
            //MessageBox.Show(strMsg, Constants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log4Helper.Write(module, ex);
            FrmMessageBox frmMsg = new FrmMessageBox();
            frmMsg.Module = module;
            frmMsg.Exception = ex;
            frmMsg.TroubleShooting = troubleshooting;
            frmMsg.ShowDialog();
        }
    }
}
