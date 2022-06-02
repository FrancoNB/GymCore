using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms.Register
{
    public partial class frmRegisterExercises : Form
    {
        private static frmRegisterExercises instance;

        private static readonly object _lock = new object();
        public static frmRegisterExercises GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new frmRegisterExercises();
                }
            }

            return instance;
        }

        //private readonly ClientsModel clientWorkingModel;
        //private IEnumerable<ClientsModel> clientsList;

        public frmRegisterExercises()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //clientWorkingModel = new ClientsModel();
        }

    }
}
