using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Utilities
{
    public static class ControlsUtilities
    {
        private readonly static List<Control> ListDisableControls = new List<Control>();

        public static void DisableAllControls()
        {
            foreach (Form frm in Application.OpenForms)
            {
                foreach (Control ctrl in frm.Controls) 
                {
                    DisableControls(ctrl);
                }
            }
        }

        private static void DisableControls(Control element)
        {
            if (element.Controls.Count > 0)
            {
                foreach (Control ctrl in element.Controls)
                {
                    DisableControls(ctrl);
                }
            }
            else
            {
                if (element.Enabled)
                {
                    if (element is TextBox || element is ComboBox || element is Button || element is DataGridView || element is RadioButton)
                    {
                        element.Enabled = false;
                        element.Refresh();
                        ListDisableControls.Add(element);
                    }
                }
            }
        }

        public static void EnabledAllControls()
        {
            foreach (Control ctrl in ListDisableControls)
            {
                ctrl.Enabled = true;
                ctrl.Refresh();
            }

            ListDisableControls.Clear();
        }

        public static void EnabledContainerControls(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                ctrl.Enabled = true;
                ctrl.Refresh();
            }
        }

        public static void DisableContainerControls(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is TextBox || ctrl is ComboBox || ctrl is Button || ctrl is DataGridView || ctrl is RadioButton)
                {
                    ctrl.Enabled = false;
                    ctrl.Refresh();

                }
            }
        }
    }
}
