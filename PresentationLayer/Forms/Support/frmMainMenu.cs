using BusinessLayer.Cache;
using PresentationLayer.Forms.ConfigSystem;
using PresentationLayer.Forms.Support;
using PresentationLayer.Forms.Register;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using Presentation.Forms.Lists;
using PresentationLayer.Utilities;
using BusinessLayer.Models;
using Presentation.Forms.Management;

namespace PresentationLayer
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

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-AR");
            CultureInfo.DefaultThreadCurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            CultureInfo.DefaultThreadCurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            CultureInfo.DefaultThreadCurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            CultureInfo.DefaultThreadCurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            CultureInfo.DefaultThreadCurrentCulture.NumberFormat.NumberGroupSeparator = ",";

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

            LoadCache();
            ShowLogin();
        }

        private async void LoadCache()
        {
            LoadNotification.Show("Iniciando sistema...");

            PackagesCache.GetInstance().Resource = await new PackagesModel().GetAll();
            UsersCache.GetInstance().Resource = await new UsersModel().GetAll();
            ClientsCache.GetInstance().Resource = await new ClientsModel().GetAll();
            ExercisesCache.GetInstance().Resource = await new ExercisesModel().GetAll();

            LoadNotification.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEndSesion_Click(object sender, EventArgs e)
        {
            ShowLogin();
        }

        public void ShowLogin()
        {
            lblState.Text = "Sesión no iniciada";

            if (frmLogin.GetInstance().ShowDialog(this) == DialogResult.Cancel)
                Application.Exit();

            lblState.Text = "Usuario: " + LoginCache.Username + " - Tipo: " + LoginCache.Type;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmUsers.GetInstance().ShowDialog(this);
        }

        private void btnRegisterClients_Click(object sender, EventArgs e)
        {
            frmRegisterClients.GetInstance().ShowDialog(this);
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            frmRegisterPackages.GetInstance().ShowDialog(this);
        }

        private void btnExercises_Click(object sender, EventArgs e)
        {
            frmRegisterExercises.GetInstance().ShowDialog(this);
        }

        private void btnSubscriptions_Click(object sender, EventArgs e)
        {
            if (!ClientsCache.GetInstance().isEmpty())
                frmManagementSubscriptions.GetInstance().ShowDialog(this);
            else
                MessageBox.Show("No hay ningun cliente cargado en el sistema, no puedes acceder al manejo de suscripciones... !", "Servicio de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
