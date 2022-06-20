using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Controls
{
    public class GymCoreComboBox : ComboBox
    {
        private readonly Color _foreColor = Color.FromArgb(139, 166, 145);
        private readonly Color _backColor = Color.FromArgb(12, 19, 46);

        public GymCoreComboBox() 
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            BackColor = _backColor;
            Size = new Size() { Height = 406 };
            Font = new Font("Calibri", 12.0f);
            ForeColor = _foreColor;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar.Equals((char)Keys.Enter))   
                SendKeys.Send("{TAB}");

            e.Handled = true;
        }
    }
}
