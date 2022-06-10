using BusinessLayer.Cache;
using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using PresentationLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer.Forms.ConfigSystem
{
    public partial class frmUsers : Form, ISubscriber<UsersModel>
    {
        private static frmUsers instance;

        private static readonly object _lock = new object();
        public static frmUsers GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmUsers();
                }
            }

            return instance;
        }

        private readonly UsersModel userWorkingModel;
        private IEnumerable<UsersModel> usersList;

        private frmUsers()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            userWorkingModel = new UsersModel();
        }

        private void ClearData()
        {
            txtPassword.Clear();
            txtUsername.Clear();
            txtRepeatPassword.Clear();
            cbxType.SelectedItem = null;
            cbxType.Text = string.Empty;
        }

        private void SetControlsDefaultState()
        {
            ClearData();

            ControlsUtilities.DisableContainerControls(pnlData);
            ControlsUtilities.EnabledContainerControls(pnlList);

            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnClose.Enabled = true;
            btnCancel.Enabled = false;

            btnNew.Select();
        }

        private void LoadDgvUsersList()
        {
            IEnumerable<UsersModel> usersList = this.usersList;

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                usersList = usersList.ToList().FindAll(user => user.Username.ToLower().Contains(txtSearch.Text.ToLower()));

            dgvUsersList.Rows.Clear();

            if (usersList != null)
            {
                foreach (UsersModel user in usersList)
                {
                    dgvUsersList.Rows.Add(user.IdUsers, user.RegisterDateString, user.Username, user.LastConnectionString);
                }

                ClearSelectionDgv();
            }
        }

        private void SetControlsActiveState()
        {
            btnNew.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnClose.Enabled = false;
            btnCancel.Enabled = true;

            ControlsUtilities.DisableContainerControls(pnlList);
            ControlsUtilities.EnabledContainerControls(pnlData);

            txtSearch.Clear();

            txtUsername.Select();
        }

        private void ClearSelectionDgv()
        {
            ClearData();

            dgvUsersList.CurrentCell = null;
            dgvUsersList.ClearSelection();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            cbxType.Items.Clear();
            cbxType.Items.Add("Administrador");
            cbxType.Items.Add("Entrenador");
            cbxType.Items.Add("Cajero");

            dgvUsersList.Columns.Clear();
            dgvUsersList.Columns.Add("idUser", "ID USUARIO");
            dgvUsersList.Columns.Add("RegisterDate", "FEC. ALTA");
            dgvUsersList.Columns.Add("Username", "USUARIO");
            dgvUsersList.Columns.Add("LastConnection", "ULT. CONEXION");

            dgvUsersList.Columns["idUser"].Visible = false;

            dgvUsersList.Columns["RegisterDate"].Width = 60;
            dgvUsersList.Columns["LastConnection"].Width = 115;

            UsersCache.GetInstance().Attach(this);

            SetControlsDefaultState();        
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            userWorkingModel.Username = txtUsername.Text;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            userWorkingModel.Password = txtPassword.Text;
        }

        private void cbxType_TextChanged(object sender, EventArgs e)
        {
            if (cbxType.Text == "Administrador")
                userWorkingModel.Type = UsersModel.UsersTypes.Manager;
            else if (cbxType.Text == "Entrenador")
                userWorkingModel.Type = UsersModel.UsersTypes.Trainer;
            else if (cbxType.Text == "Cajero")
                userWorkingModel.Type = UsersModel.UsersTypes.Accountant;
            else
                userWorkingModel.Type = UsersModel.UsersTypes.Null;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDgvUsersList();
        }

        private void dgvUsersList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var selectUser = usersList.ToList().Find(user => user.IdUsers == Convert.ToInt32(dgvUsersList.CurrentRow.Cells["idUser"].Value));

                userWorkingModel.IdUsers = selectUser.IdUsers;
                userWorkingModel.RegisterDate = selectUser.RegisterDate;
                userWorkingModel.LastConnection = selectUser.LastConnection;
                txtUsername.Text = selectUser.Username;
                txtPassword.Text = selectUser.Password;
                txtRepeatPassword.Text = selectUser.Password;
                cbxType.Text = selectUser.TypeString;

                btnUpdate.Select();
            }
            else
            {
                ClearSelectionDgv();
            }
        }

        private void dgvUsersList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dgvUsersList.HitTest(e.X, e.Y).Equals(DataGridView.HitTestInfo.Nowhere))
                {
                    ClearSelectionDgv();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            userWorkingModel.Operation = Operation.Insert;

            ClearSelectionDgv();

            SetControlsActiveState();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.CurrentCell != null)
            {
                userWorkingModel.Operation = Operation.Update;

                SetControlsActiveState();
            }
            else
            {
                MessageBox.Show("Debes seleccionar el usuario que deseas modificar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsersList.CurrentCell != null)
            {
                DialogResult confirm = MessageBox.Show("Eliminar usuario ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (confirm == DialogResult.OK)
                {
                    LoadNotification.Show("Eliminando usuario...");

                    userWorkingModel.Operation = Operation.Delete;

                    var acctionResult = await userWorkingModel.SaveChanges();

                    LoadNotification.Hide();

                    if (acctionResult.Result)
                    {
                        MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtSearch.Clear();
                    }
                    else
                        MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    btnNew.Select();
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar el usuario que deseas eliminar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_ClickAsync(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtRepeatPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Select();
                return;
            }

            string footMsg;
            DialogResult confirm;

            if (userWorkingModel.Operation == Operation.Insert)
            {
                confirm = MessageBox.Show("Guardar usuario ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                footMsg = "Guardando usuario...";
            }
            else if (userWorkingModel.Operation == Operation.Update)
            {
                confirm = MessageBox.Show("Modificar usuario ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                footMsg = "Modificando usuario...";
            } 
            else
            {
                MessageBox.Show("No se establecio la operacion a realizar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(confirm == DialogResult.OK)
            {
                LoadNotification.Show(footMsg);

                var acctionResult = await userWorkingModel.SaveChanges();

                LoadNotification.Hide();

                if (!acctionResult.Result)
                {
                    MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Select();
                }   
                else
                {
                    MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetControlsDefaultState();
                    
                    if (userWorkingModel.Operation == Operation.Update && userWorkingModel.IdUsers == LoginCache.IdUsers)
                    {
                        this.Hide();
                        frmMainMenu.GetInstance().ShowLogin();
                        this.Close();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControlsDefaultState();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            UsersCache.GetInstance().Detach(this);

            this.Close();
        }

        public void Update(IEnumerable<UsersModel> resource)
        {
            usersList = resource;

            LoadDgvUsersList();
        }
    }
}
