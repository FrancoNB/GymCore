﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Controls
{
    public class GymCoreButton : Button
    {
        private readonly Color _foreColor = Color.FromArgb(139, 166, 145);
        private readonly Color _backColor = Color.FromArgb(12, 19, 46);

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            if(Enabled)
            {
                BackColor = _foreColor;
                ForeColor = _backColor;

                Cursor.Current = Cursors.Hand;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            if (Enabled)
            {
                BackColor = _backColor;
                ForeColor = _foreColor;

                Cursor.Current = Cursors.Default;
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if (Enabled)
            {
                BackColor = _foreColor;
                ForeColor = _backColor;
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (Enabled)
            {
                BackColor = _backColor;
                ForeColor = _foreColor;
            }
        }

        public GymCoreButton()
        {
            BackColor = _backColor;
            Size = new Size(140, 31);
            FlatStyle = FlatStyle.Flat;
            Font = new Font("Calibri", 9.75f, FontStyle.Bold);
            ForeColor = _foreColor;
            UseVisualStyleBackColor = false;
            FlatAppearance.BorderColor = ForeColor;
            FlatAppearance.BorderSize = 1;
        }
    }
}
