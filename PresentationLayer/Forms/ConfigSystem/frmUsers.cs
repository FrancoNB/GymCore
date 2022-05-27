using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms.ConfigSystem
{
    public partial class frmUsers : Form
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

        public frmUsers()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            dgvUsersList.Columns.Add("col1", "COLUMN 1");
            dgvUsersList.Columns.Add("col1", "COLUMN 2");
            dgvUsersList.Columns.Add("col1", "COLUMN 3");
            dgvUsersList.Columns.Add("col1", "COLUMN 4");

            dgvUsersList.Rows.Add("ROW 1-1", "ROW 1-2", "ROW 1-3", "ROW 1-4");
            dgvUsersList.Rows.Add("ROW 2-1", "ROW 2-2", "ROW 2-3", "ROW 2-4");
            dgvUsersList.Rows.Add("ROW 3-1", "ROW 3-2", "ROW 3-3", "ROW 3-4");
            dgvUsersList.Rows.Add("ROW 4-1", "ROW 4-2", "ROW 4-3", "ROW 4-4");
        }
    }
}
