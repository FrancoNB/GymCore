using BusinessLayer.Models;
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
        private UsersModel userModel;

        public frmLogin()
        {
            userModel = new UsersModel();

            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
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
                    var acctionResult = userModel.LogIn(txtUsername.Text, txtPassword.Text);

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
