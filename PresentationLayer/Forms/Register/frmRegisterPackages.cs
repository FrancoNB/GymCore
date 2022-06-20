using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Models;
using System.Windows.Forms;
using PresentationLayer.Utilities;
using BusinessLayer.ValueObjects;
using BusinessLayer.Cache;

namespace PresentationLayer.Forms.Register
{
    public partial class frmRegisterPackages : Form, ISubscriber<PackagesModel>
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

            btnNew.Select();
        }

        private void LoadDgvPackagesList()
        {
            IEnumerable<PackagesModel> packagesList = this.packagesList;

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                packagesList = packagesList.ToList().FindAll(package => package.Name.ToLower().Contains(txtSearch.Text.ToLower()));

            dgvPackagesList.Rows.Clear();

            foreach (PackagesModel package in packagesList)
            {
                dgvPackagesList.Rows.Add(package.IdPackages, package.Name, string.Format("$ {0:#,##0.00}", package.Price));
            }

            ClearSelectionDgv();
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

            PackagesCache.GetInstance().Attach(this);

            SetControlsDefaultState();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            packageWorkingModel.Name = txtName.Text;
        }

        private void txtNumberSessions_TextChanged(object sender, EventArgs e)
        {
            packageWorkingModel.NumberSessions = (int)FormatUtilities.NumbersOnly(txtNumberSessions.Text);
        }

        private void txtNumberSessions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtNumberSessions_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNumberSessions.Text))
            {
                txtNumberSessions.Text = string.Format("{0:#,##}", FormatUtilities.NumbersOnly(txtNumberSessions.Text));
            }
        }

        private void txtAvailableDays_TextChanged(object sender, EventArgs e)
        {
            packageWorkingModel.AvailableDays = (int)FormatUtilities.NumbersOnly(txtAvailableDays.Text);
        }

        private void txtAvailableDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtAvailableDays_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAvailableDays.Text))
            {
                txtAvailableDays.Text = string.Format("{0:#,##}", FormatUtilities.NumbersOnly(txtAvailableDays.Text));
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            packageWorkingModel.Price = FormatUtilities.NumbersOnly(txtPrice.Text);
        }

        private void txtPrice_Validated(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                txtPrice.Text = string.Format("$ {0:#,##0.00}", FormatUtilities.NumbersOnly(txtPrice.Text));
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDgvPackagesList();
        }

        private void dgvPackagesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var selectPackage = packagesList.ToList().Find(package => package.IdPackages == Convert.ToInt32(dgvPackagesList.CurrentRow.Cells["idPackage"].Value));

                packageWorkingModel.IdPackages = selectPackage.IdPackages;

                txtName.Text = selectPackage.Name;
                txtNumberSessions.Text = string.Format("{0:#,##}", selectPackage.NumberSessions);
                txtAvailableDays.Text = string.Format("{0:#,##}", selectPackage.AvailableDays);
                txtPrice.Text = string.Format("$ {0:#,##0.00}", selectPackage.Price);

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
            PackagesCache.GetInstance().Detach(this);

            this.Close();
        }

        public void Update(IEnumerable<PackagesModel> resource)
        {
            packagesList = resource;

            LoadDgvPackagesList();
        }
    }
}
