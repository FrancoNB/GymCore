using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Utilities
{
    public static class LoadNotification
    {
        private static string contextFooterMessage;
        private static Cursor contextCursor;

        public static void Show(string msg = "Cargando...")
        {
            contextFooterMessage = frmMainMenu.GetInstance().FooterMessage;
            contextCursor = Cursor.Current;

            frmMainMenu.GetInstance().FooterMessage = msg;
            Cursor.Current = Cursors.WaitCursor;

            ControlsUtilities.DisableAllControls();

            frmMainMenu.GetInstance().Refresh();
        }

        public static void Hide()
        {
            frmMainMenu.GetInstance().FooterMessage = contextFooterMessage;

            ControlsUtilities.EnabledAllControls();

            Cursor.Current = contextCursor;     
        }
    }
}
