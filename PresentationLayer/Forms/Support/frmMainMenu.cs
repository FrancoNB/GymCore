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

        private frmMainMenu()
        {
            InitializeComponent();

            mstPPal.Renderer = new MenuStripRenderer();
        }

        private class MenuStripRenderer : ToolStripProfessionalRenderer
        {
            public MenuStripRenderer() : base(new MenuStripColors()) { }
        }

        private class MenuStripColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(8, 11, 18); }
            }
            public override Color MenuItemBorder
            {
                get { return Color.FromArgb(8, 11, 18); }
            }
            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.FromArgb(8, 11, 18); }
            }
            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.FromArgb(8, 11, 18); }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.FromArgb(8, 11, 18); }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.FromArgb(8, 11, 18); }
            }
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
            lblState.Text = "Sesión no iniciada";

            if (frmLogin.GetInstance().ShowDialog() == DialogResult.Cancel)
                Application.Exit();

            lblState.Text = "Usuario: " + UserCache.Username + " - Tipo: " + UserCache.Type;
        }
    }
}
