using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Johnny.Library.Helper;

namespace Johnny.Controls.Windows.DateTimer
{
    public partial class TimeSelector : UserControl
    {
        private int _hour;
        private int _minute;

        public TimeSelector()
        {
            InitializeComponent();
        }

        private void TimeSelector_Load(object sender, EventArgs e)
        {
            cmbHour.Location = new Point(0, 0);
            cmbMinute.Location = new Point(cmbHour.Width, 0);
            this.Width = cmbHour.Width + cmbMinute.Width;
            this.Height = cmbHour.Height;
            for (int ix = 0; ix < 24; ix++)
            {
                cmbHour.Items.Add(ix.ToString());
            }
            for (int ix = 0; ix < 60; ix++)
            {
                cmbMinute.Items.Add(ix.ToString());
            }
        }

        public new void Select()
        {
            cmbHour.Select();
        }
        public void Clear()
        {
            cmbHour.SelectedIndex = -1;
            cmbMinute.SelectedIndex = -1;
        }
        public int Hour
        {
            get
            {
                if (cmbHour.Text != string.Empty)
                    _hour = DataConvert.GetInt32(cmbHour.Text);
                else
                    _hour = -1;
                return _hour;
            }
            set
            {
                _hour = value;
                if (_hour > 23 || _hour < 0)
                    cmbHour.SelectedIndex = -1;
                else
                    cmbHour.SelectedIndex = _hour;
            }
        }

        public int Minute
        {
            get
            {
                if (cmbMinute.Text != string.Empty)
                    _minute = DataConvert.GetInt32(cmbMinute.Text);
                else
                    _minute = -1;
                return _minute;
            }
            set
            {
                _minute = value;
                if (_minute > 59 || _minute < 0)
                    cmbMinute.SelectedIndex = -1;
                else
                    cmbMinute.SelectedIndex = _minute;
            }
        }

        private void cmbHour_Leave(object sender, EventArgs e)
        {
            if (!DataValidation.IsInt32(cmbHour.Text))
                cmbHour.Text = "";
            else if (DataConvert.GetInt32(cmbHour.Text) < 0 || DataConvert.GetInt32(cmbHour.Text) > 23)
                cmbHour.Text = "";
        }

        private void cmbMinute_Leave(object sender, EventArgs e)
        {
            if (!DataValidation.IsInt32(cmbMinute.Text))
                cmbMinute.Text = "";
            else if (DataConvert.GetInt32(cmbMinute.Text) < 0 || DataConvert.GetInt32(cmbMinute.Text) > 59)
                cmbMinute.Text = "";
        }        
    }
}