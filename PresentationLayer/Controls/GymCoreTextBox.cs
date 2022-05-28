﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Controls
{
    public class GymCoreTextBox : TextBox
    {
        private readonly Color _foreColor = Color.FromArgb(139, 166, 145);
        private readonly Color _backColor = Color.FromArgb(12, 19, 46);

        private readonly Color _disableBackColor = Color.FromArgb(50, 50, 50);

        public GymCoreTextBox()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            BackColor = _backColor;
            Size = new Size() { Height = 406 };
            Font = new Font("Calibri", 12.0f);
            BorderStyle = BorderStyle.FixedSingle;
            ForeColor = _foreColor;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (!Enabled)
            {
                BackColor = _disableBackColor;
            }
            else
            {
                ForeColor = _foreColor;
                BackColor = _backColor;
            }

            base.OnEnabledChanged(e);

            Invalidate();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
