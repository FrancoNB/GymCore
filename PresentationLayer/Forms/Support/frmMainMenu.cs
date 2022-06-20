using BusinessLayer.Cache;
using PresentationLayer.Forms.ConfigSystem;
using PresentationLayer.Forms.Support;
using PresentationLayer.Forms.Register;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using PresentationLayer.Forms.Queries;
using PresentationLayer.Utilities;
using BusinessLayer.Models;
using PresentationLayer.Forms.Management;
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
            SubscriptionsCache.GetInstance().Resource = await new SubscriptionsModel().GetAll();
            CurrentAccountsCache.GetInstance().Resource = await new CurrentAccountsModel().GetAll();
            PaymentsCache.GetInstance().Resource = await new PaymentsModel().GetAll();
            AssistsCache.GetInstance().Resource = await new AssistsModel().GetAll();

            LoadNotification.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que deseas salir del programa ?", "Sistema de Alertas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnEndSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que deseas cerrar sesión ?", "Sistema de Alertas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            {
                if (!PackagesCache.GetInstance().isEmpty())
                    frmManagementSubscriptions.GetInstance().ShowDialog(this);
                else
                    MessageBox.Show("No hay ningun paquete de subscripcion cargado en el sistema, no puedes acceder al manejo de suscripciones... !", "Servicio de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("No hay ningun cliente cargado en el sistema, no puedes acceder al manejo de suscripciones... !", "Servicio de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnQueriesCurrentAccounts_Click(object sender, EventArgs e)
        {
            if (!ClientsCache.GetInstance().isEmpty())
                frmQueriesCurrentAccounts.GetInstance().ShowDialog(this);
            else
                MessageBox.Show("No hay ningun cliente cargado en el sistema, no puedes acceder a la consulta de cuentas corrientes... !", "Servicio de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);          
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            if (!ClientsCache.GetInstance().isEmpty())
                frmManagementPayments.GetInstance().ShowDialog(this);
            else
                MessageBox.Show("No hay ningun cliente cargado en el sistema, no puedes acceder al manejo de pagos... !", "Servicio de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnManagentAssits_Click(object sender, EventArgs e)
        {
            if (!ClientsCache.GetInstance().isEmpty())
            {
                if (!SubscriptionsCache.GetInstance().isEmpty())
                    frmManagementAssists.GetInstance().ShowDialog(this);
                else
                    MessageBox.Show("No hay ninguna subscripcion cargada en el sistema, no puedes acceder al manejo de asistencias... !", "Servicio de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                MessageBox.Show("No hay ningun cliente cargado en el sistema, no puedes acceder al manejo de asistencias... !", "Servicio de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
