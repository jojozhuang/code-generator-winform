using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Johnny.Library.Log;
using Johnny.CodeGenerator.Core;
using Johnny.Controls.Windows.CommonMessageBox;

namespace Johnny.CodeGenerator.WinUI
{
    static class Program
    {
        private delegate void ExceptionDelegate(Exception ex);
        static private MainForm _mainform;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomain_UnhandledException);
            Application.SetCompatibleTextRenderingDefault(false);
            _mainform = new MainForm();
            Application.Run(_mainform);            
        }
        
        private static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {            
            Exception exception;
            exception = e.ExceptionObject as Exception;
            if (exception == null)
            { 
                // this is an unmanaged exception, you may want to handle it differently    
                return;
            }
            PublishOnMainThread(exception);
        }
        private static void PublishOnMainThread(Exception exception)
        {
            if (_mainform.InvokeRequired)
            {
                // Invoke executes a delegate on the thread that owns _MainForms's underlying window handle.    
                _mainform.Invoke(new ExceptionDelegate(HandleException), new object[] { exception });
            }
            else
            {
                HandleException(exception);
            }
        }
        private static void HandleException(Exception exception)
        {
            

            //System.ComponentModel.CancelEventArgs e= new System.ComponentModel.CancelEventArgs();
            //e.Cancel = true;
            //Application.Exit(e);
          
            //Application.Exit();
            //Environment.Exit(0);

            if (SystemInformation.UserInteractive)
            {
                ShowMessageBox("UnhandledException", exception);
                
                //return;
                using (ThreadExceptionDialog dialog = new ThreadExceptionDialog(exception))
                {
                    if (dialog.ShowDialog() == DialogResult.Cancel)
                        return;
                }
                Application.Exit();
                Environment.Exit(0);
            }
        }

        public static void ShowMessageBox(string module, Exception ex)
        {
            ShowMessageBox(module, "", ex);
        }

        public static void ShowMessageBox(string module, string troubleshooting, Exception ex)
        {
            Log4Helper.Write(module, ex);
            //MessageBox.Show(strMsg, Constants.MSG_SYSTEMERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            FrmMessageBox frmMsg = new FrmMessageBox();
            frmMsg.Module = module;
            frmMsg.Exception = ex;
            frmMsg.TroubleShooting = troubleshooting;
            frmMsg.ShowDialog();
        }
    }
}