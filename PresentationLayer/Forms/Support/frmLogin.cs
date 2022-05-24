using BusinessLayer.Models;
using Presentation.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms.Support
{
    public partial class frmLogin : Form
    {
        private static frmLogin instance;

        private static readonly object _lock = new object();

        private frmLogin()
        {
            userModel = new UsersModel();

            InitializeComponent();
        }

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

        private UsersModel userModel;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Debes introducir un Username... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsername.Select();
            }
            else
            {
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Debes introducir una Contraseña... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword.Select();
                }
                else
                {
                    LoadNotification.Show("Iniciando Sesión...");

                    var acctionResult = await userModel.LogIn(txtUsername.Text, txtPassword.Text);

                    LoadNotification.Hide();

                    if (acctionResult.Result)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                        MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
