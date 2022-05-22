using BusinessLayer.Cache;
using Presentation.Forms.Support;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            this.WindowState = FormWindowState.Maximized;

            ShowLogin();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEndSesion_Click(object sender, EventArgs e)
        {
            ShowLogin();
        }

        private void ShowLogin()
        {
            lblState.ForeColor = Color.Brown;
            lblState.Text = "Sesión no iniciada";

            var result = new frmLogin().ShowDialog();

            if (result == DialogResult.Cancel)
                Application.Exit();

            lblState.ForeColor = Color.DarkGreen;
            lblState.Text = "Usuario: " + UserCache.Username + " - Tipo: " + UserCache.Type;
        }
    }
}
