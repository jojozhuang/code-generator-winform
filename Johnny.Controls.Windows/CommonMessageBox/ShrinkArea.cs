using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace Johnny.Controls.Windows.CommonMessageBox
{
    public class ShrinkArea
    {
        int shrinkAreaHeight;
        bool expanded = true;
        Form form;
        Hashtable shrinkAreaControls = new Hashtable();
        Hashtable belowShrinkAreaControls = new Hashtable();

        public ShrinkArea(Form form, int shrinkAreaTop, int shrinkAreaBottom)
        {
            // shrinkAreaTop should be top point of the most top control in the
            // shrink area.

            // shrinkAreaBottom should be top point of the most top control 
            // below the shrink area.

            // Store the form the shrink area belongs to.

            this.form = form;

            // Calculate and store height of shrink area so we later know how 
            // much to move controls up that are below shrink area and how much
            // to shrink the whole form.

            this.shrinkAreaHeight = shrinkAreaBottom - shrinkAreaTop;

            // Loop through the form's controls and add controls with the 
            // shrink area to the shrinkAreaControls and controls below the 
            // shrink area to belowShrinkAreaControls.

            foreach (Control control in form.Controls)
            {
                if (shrinkAreaTop <= control.Location.Y &&
                    control.Location.Y < shrinkAreaBottom)
                {
                    shrinkAreaControls.Add(control, null);
                }

                if (control.Location.Y >= shrinkAreaBottom)
                {
                    belowShrinkAreaControls.Add(control, null);
                }
            }
        }

        public void Toggle()
        {
            // If the shrink area is expanded we want to shrink it (subtract 
            // shrinkAreaHeight) else expand it (add shrinkAreaHeight).

            int diff = expanded ? -shrinkAreaHeight : shrinkAreaHeight;

            // Temporarily suspends layout changes until we done them all.

            form.SuspendLayout();

            // Loop through the form's controls and toggle visibility for 
            // controls within the shrink area and move contols below the 
            // shrink area either up or down depending on if we are expanding 
            // or shrinking the form.

            foreach (Control control in form.Controls)
            {
                if (shrinkAreaControls.Contains(control))
                {
                    control.Visible = !expanded;
                }

                if (belowShrinkAreaControls.Contains(control))
                {
                    control.Top += diff;
                }
            }

            form.Size = new Size(form.Size.Width,
                                 form.Size.Height + diff);

            // Resume layout changes now when we are done with them all.

            form.ResumeLayout();

            // The shrink area's state have changed, update the member variable
            // expanded to show it.

            expanded = !expanded;
        }

        public bool Expanded
        {
            get
            {
                return expanded;
            }
            set
            {
                // We only want to shrink if the shrink area is expanded and
                // only expand if the shrink area is not expanded.

                if (expanded == value)
                {
                    return;
                }

                Toggle();
            }
        }
    }
}
