using BusinessLayer.Cache;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer.Forms.Lists
{
    public partial class frmPackagesList : Form, ISubscriber<PackagesModel>
    {
        private static frmPackagesList instance;

        private static readonly object _lock = new object();
        public static frmPackagesList GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmPackagesList();
                }
            }

            return instance;
        }

        private IEnumerable<PackagesModel> packagesList;
        private PackagesModel _selectedPackage;
        public PackagesModel SelectedPackage { get => _selectedPackage; }

        private frmPackagesList()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void ClearSelectionDgv()
        {
            dgvPackagesList.CurrentCell = null;
            dgvPackagesList.ClearSelection();
        }

        public void LoadDgvPackagesList()
        {
            IEnumerable<PackagesModel> packagesList = this.packagesList;

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                packagesList = packagesList.ToList().FindAll(package => package.Name.ToLower().Contains(txtSearch.Text.ToLower()));

            dgvPackagesList.Rows.Clear();

            foreach (PackagesModel package in packagesList)
            {
                dgvPackagesList.Rows.Add(package.IdPackages, package.Name, package.NumberSessions, package.AvailableDays + " Dias", string.Format("$ {0:#,##0.00}", package.Price));
            }

            ClearSelectionDgv();
        }

        private void frmPackagesList_Load(object sender, EventArgs e)
        {      
            dgvPackagesList.Columns.Clear();
            dgvPackagesList.Columns.Add("idPackage", "ID PAQUETE");
            dgvPackagesList.Columns.Add("Name", "NOMBRE");
            dgvPackagesList.Columns.Add("NumberSessions", "NRO. DE CLASES");
            dgvPackagesList.Columns.Add("AvailableDays", "VIGENCIA");
            dgvPackagesList.Columns.Add("Price", "PRECIO");

            dgvPackagesList.Columns["idPackage"].Visible = false;

            dgvPackagesList.Columns["NumberSessions"].Width = 60;
            dgvPackagesList.Columns["AvailableDays"].Width = 60;
            dgvPackagesList.Columns["Price"].Width = 120;

            dgvPackagesList.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPackagesList.Columns["AvailableDays"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPackagesList.Columns["NumberSessions"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            txtSearch.Clear();

            _selectedPackage = null;
            
            PackagesCache.GetInstance().Attach(this);

            txtSearch.Select();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDgvPackagesList();
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

        private void dgvPackagesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > -1)
            {
                _selectedPackage = packagesList.ToList().Find(package => package.IdPackages == Convert.ToInt32(dgvPackagesList.CurrentRow.Cells["idPackage"].Value));

                PackagesCache.GetInstance().Detach(this);

                this.Close();
            }
            else
            {
                ClearSelectionDgv();
            }
        }
    }
}
