// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Kr¨¹ger" email="mike@icsharpcode.net"/>
//     <version>$Revision: 2608 $</version>
// </file>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Runtime.InteropServices;

namespace Johnny.CodeGenerator.WinUI
{
    
    public class SplashScreenForm : Form
    {
        public string VersionText = ".NET Develop Assistant V" + typeof(MainForm).Assembly.GetName().Version.ToString() + " Testing Version \r\nBy Johnny";

        static SplashScreenForm splashScreen;
        static List<string> requestedFileList = new List<string>();
        static List<string> parameterList = new List<string>();
        private ImageList imageList;
        private System.ComponentModel.IContainer components;
        Bitmap bitmap;

        public static SplashScreenForm SplashScreen
        {
            get
            {
                return splashScreen;
            }
            set
            {
                splashScreen = value;
            }
        }

        public SplashScreenForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
#if DEBUG
			string versionText = VersionText + " (debug)";
#else
            string versionText = VersionText;
#endif
            // Stream must be kept open for the lifetime of the bitmap
            Assembly myAssem = Assembly.GetEntryAssembly();
            ResourceManager rm = new ResourceManager(typeof(Johnny.CodeGenerator.WinUI.MyResource));

            if (rm != null)
            {
                bitmap = rm.GetObject("SplashScreen") as Bitmap;
            }            
              
            //bitmap = new Bitmap(typeof(SplashScreenForm).Assembly.GetManifestResourceStream("MyResource.Resources_SplashScreen"));
            this.ClientSize = bitmap.Size;
            using (Font font = new Font("Sans Serif", 4))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawString(versionText, font, Brushes.Black, 100, 142);
                }
            }
            BackgroundImage = bitmap;

        }

        public static void ShowSplashScreen()
        {
            splashScreen = new SplashScreenForm();
            splashScreen.Show();
        }

        static void tm2_Tick(object sender, EventArgs e)
        {
           splashScreen.Opacity = splashScreen.Opacity - 0.005;
        }

        public void tm_Tick(object sender, EventArgs e)
        {
            this.Opacity = splashScreen.Opacity - 0.005;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                    bitmap = null;
                }
            }
            base.Dispose(disposing);
        }

        public static string[] GetParameterList()
        {
            return parameterList.ToArray();
        }

        public static string[] GetRequestedFileList()
        {
            return requestedFileList.ToArray();
        }

        public static void SetCommandLineArgs(string[] args)
        {
            requestedFileList.Clear();
            parameterList.Clear();

            foreach (string arg in args)
            {
                if (arg.Length == 0) continue;
                if (arg[0] == '-' || arg[0] == '/')
                {
                    int markerLength = 1;

                    if (arg.Length >= 2 && arg[0] == '-' && arg[1] == '-')
                    {
                        markerLength = 2;
                    }

                    parameterList.Add(arg.Substring(markerLength));
                }
                else
                {
                    requestedFileList.Add(arg);
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenForm));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Resources.SplashScreen.jpg");
            // 
            // SplashScreenForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "SplashScreenForm";
            this.ResumeLayout(false);

        }        
    }
}
