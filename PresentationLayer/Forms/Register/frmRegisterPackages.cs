using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using System.Windows.Forms;
using PresentationLayer.Utilities;
using BusinessLayer.ValueObjects;

namespace Presentation.Forms.Register
{
    public partial class frmRegisterPackages : Form
    {
        private static frmRegisterPackages instance;

        private static readonly object _lock = new object();
        public static frmRegisterPackages GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmRegisterPackages();
                }
            }

            return instance;
        }

        private readonly PackagesModel packageWorkingModel;
        private IEnumerable<PackagesModel> packagesList;

        public frmRegisterPackages()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            packageWorkingModel = new PackagesModel();
        }

        private void ClearData()
        {
            txtName.Clear();
            txtNumberSessions.Clear();
            txtAvailableDays.Clear();
            txtPrice.Clear();
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

            LoadPackageList();

            btnNew.Select();
        }

        private async void LoadPackageList()
        {
            LoadNotification.Show("Cargando listado de paquetes de suscripcion...");

            packagesList = await packageWorkingModel.GetAll();

            LoadDgvPackagesList(packagesList);

            LoadNotification.Hide();
        }

        private void LoadDgvPackagesList(IEnumerable<PackagesModel> packagesList)
        {
            dgvPackagesList.Rows.Clear();

            if (packagesList != null)
            {
                foreach (PackagesModel package in packagesList)
                {
                    dgvPackagesList.Rows.Add(package.IdPackages, package.Name, package.Price);
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

            txtName.Select();
        }

        private void ClearSelectionDgv()
        {
            ClearData();

            dgvPackagesList.CurrentCell = null;
            dgvPackagesList.ClearSelection();
        }


        private void frmRegisterPackages_Load(object sender, EventArgs e)
        {
            dgvPackagesList.Columns.Clear();
            dgvPackagesList.Columns.Add("idPackage", "ID PAQUETE");
            dgvPackagesList.Columns.Add("Name", "NOMBRE DEL PAQUETE");
            dgvPackagesList.Columns.Add("Price", "PRECIO");

            dgvPackagesList.Columns["idPackage"].Visible = false;

            dgvPackagesList.Columns["Price"].Width = 100;

            SetControlsDefaultState();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            packageWorkingModel.Name = txtName.Text;
        }

        private void txtNumberSessions_TextChanged(object sender, EventArgs e)
        {
            packageWorkingModel.NumberSessions = Convert.ToInt32(txtNumberSessions.Text);
        }

        private void txtAvailableDays_TextChanged(object sender, EventArgs e)
        {
            packageWorkingModel.AvailableDays = Convert.ToInt32(txtAvailableDays.Text);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            packageWorkingModel.Price = Convert.ToDouble(txtPrice.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                LoadDgvPackagesList(packagesList.ToList().FindAll(package => package.Name.ToLower().Contains(txtSearch.Text.ToLower())));
            }
            else
            {
                LoadDgvPackagesList(packagesList);
            }
        }

        private void dgvPackagesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var selectPackage = packagesList.ToList().Find(package => package.IdPackages == Convert.ToInt32(dgvPackagesList.CurrentRow.Cells["idPackage"].Value));

                packageWorkingModel.IdPackages = selectPackage.IdPackages;

                txtName.Text = selectPackage.Name;
                txtNumberSessions.Text = selectPackage.NumberSessions.ToString();
                txtAvailableDays.Text = selectPackage.AvailableDays.ToString();
                txtPrice.Text = selectPackage.Price.ToString();

                btnUpdate.Select();
            }
            else
            {
                ClearSelectionDgv();
            }
        }

        private void dgvPackagesList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dgvPackagesList.HitTest(e.X, e.Y).Equals(DataGridView.HitTestInfo.Nowhere))
                {
                    ClearSelectionDgv();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            packageWorkingModel.Operation = Operation.Insert;

            ClearSelectionDgv();

            SetControlsActiveState();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvPackagesList.CurrentCell != null)
            {
                packageWorkingModel.Operation = Operation.Update;

                SetControlsActiveState();
            }
            else
            {
                MessageBox.Show("Debes seleccionar el paquete de suscripcion que deseas modificar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPackagesList.CurrentCell != null)
            {
                DialogResult confirm = MessageBox.Show("Eliminar paquete de suscripcion ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (confirm == DialogResult.OK)
                {
                    LoadNotification.Show("Eliminando paquete de suscripcion...");

                    packageWorkingModel.Operation = Operation.Delete;

                    var acctionResult = await packageWorkingModel.SaveChanges();

                    LoadNotification.Hide();

                    if (acctionResult.Result)
                    {
                        txtSearch.Clear();

                        LoadPackageList();

                        MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnNew.Select();
                    }
                    else
                    {
                        MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar el paquete de suscripcion que deseas eliminar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string footMsg;
            DialogResult confirm;

            if (packageWorkingModel.Operation == Operation.Insert)
            {
                confirm = MessageBox.Show("Guardar paquete de suscripcion ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                footMsg = "Guardando paquete de suscripcion...";
            }
            else if (packageWorkingModel.Operation == Operation.Update)
            {
                confirm = MessageBox.Show("Modificar paquete de suscripcion ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                footMsg = "Modificando paquete de suscripcion...";
            }
            else
            {
                MessageBox.Show("No se establecio la operacion a realizar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (confirm == DialogResult.OK)
            {
                LoadNotification.Show(footMsg);

                var acctionResult = await packageWorkingModel.SaveChanges();

                LoadNotification.Hide();

                if (!acctionResult.Result)
                {
                    MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Select();
                }
                else
                {
                    MessageBox.Show(acctionResult.Message, "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetControlsDefaultState();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetControlsDefaultState();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
