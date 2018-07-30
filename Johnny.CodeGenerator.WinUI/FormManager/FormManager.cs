using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Reflection;

using Johnny.CodeGenerator.WinUI.Toolbox;

namespace Johnny.CodeGenerator.WinUI.FormManager
{
    public sealed class FormManager
    {
        private static FormManager _instance = null;
        private static readonly object _syncRoot = new Object();
        private FormCollection _forms = new FormCollection();

        public static FormManager Instance
        {
            get
            {
                return FormManager.GetInstance();
            }
        }

        public static FormManager GetInstance()
        {
            if (_instance == null)
            {
                lock (_syncRoot)
                {
                    if (_instance == null)
                        _instance = new FormManager();
                }
            }

            return _instance;
        }

        public FrmToolBase GetWindow(string uniqueId)
        {
            // Look for an existing window with the specified uniqueId
            FrmToolBase form = this.FindExistingWindow(uniqueId);
            if (form == null)
            {
                form = (FrmToolBase)Assembly.GetExecutingAssembly().CreateInstance(uniqueId);
                form.FormClosed += new FormClosedEventHandler(form_FormClosed);
                this.RegisterWindow(form, uniqueId);
            }
            return form;
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                _forms[(FrmToolBase)sender].RegisteredForm.FormClosed -= form_FormClosed;
                _forms.Remove(_forms[(FrmToolBase)sender]);
            }
            catch
            {
            }
        }

        public FrmToolBase FindExistingWindow(string uniqueId)
        {
            // Look for existing window with the specified uniqueId
            FormItem form = _forms[uniqueId];
            return (form != null) ? form.RegisteredForm : null;
        }

        public void RegisterWindow(FrmToolBase form, string uniqueId)
        {
            if (this._forms[uniqueId] != null)
                throw new InvalidOperationException("Window is already registered.");
            if (string.IsNullOrEmpty(uniqueId))
                throw new ArgumentNullException("uniqueId cannot be null.", "uniqueId");
            
            FormItem fi = new FormItem(form, uniqueId);
            _forms.Add(fi);
        }
    }
}
