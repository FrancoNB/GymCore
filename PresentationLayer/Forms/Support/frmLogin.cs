using BusinessLayer.Models;
using PresentationLayer.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms.Support
{
    public partial class frmLogin : Form
    {
        private static frmLogin instance;

        private static readonly object _lock = new object();

        public static frmLogin GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmLogin();
                }
            }

            return instance;
        }

        private frmLogin()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            userModel = new UsersModel();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.Clear();
            txtUsername.Clear();

            txtUsername.Select();
        }

        private UsersModel userModel;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            LoadNotification.Show("Iniciando Sesión...");

            var acctionResult = await userModel.LogIn();

            LoadNotification.Hide();

            if (acctionResult.Result)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Select();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            userModel.Username = txtUsername.Text;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            userModel.Password = txtPassword.Text;
        }
    }
}
