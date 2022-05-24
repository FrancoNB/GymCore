using BusinessLayer.Cache;
using Presentation.Forms.Support;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmMainMenu : Form
    {
        private static frmMainMenu instance;

        private static readonly object _lock = new object();

        private frmMainMenu()
        {
            InitializeComponent();
        }

        public static frmMainMenu GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmMainMenu();
                }
            }

            return instance;
        }

        public string FooterMessage { get => lblState.Text; set => lblState.Text = value; }

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

            if (frmLogin.GetInstance().ShowDialog() == DialogResult.Cancel)
                Application.Exit();

            lblState.ForeColor = Color.DarkGreen;
            lblState.Text = "Usuario: " + UserCache.Username + " - Tipo: " + UserCache.Type;
        }
    }
}
