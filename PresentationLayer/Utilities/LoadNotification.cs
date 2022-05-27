using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Utilities
{
    public static class LoadNotification
    {
        private static string contextFooterMessage;
        private static Cursor contextCursor;

        private static List<Form> auxListDisableForms = new List<Form>();

        public static void Show(string msg = "Cargando...")
        {
            contextFooterMessage = frmMainMenu.GetInstance().FooterMessage;
            contextCursor = Cursor.Current;

            frmMainMenu.GetInstance().FooterMessage = msg;
            Cursor.Current = Cursors.WaitCursor;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Modal)
                {
                    frm.Enabled = false;
                    auxListDisableForms.Add(frm);
                }
            }
        }

        public static void Hide()
        {
            frmMainMenu.GetInstance().FooterMessage = contextFooterMessage;

            foreach (Form frm in auxListDisableForms)
            {
                frm.Enabled = true;
            }

            auxListDisableForms.Clear();

            Cursor.Current = contextCursor;     
        }
    }
}
