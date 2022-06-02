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

        private readonly ExercisesModel exerciseWorkingModel;
        private IEnumerable<ExercisesModel> exercisesList;

        public frmRegisterExercises()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            exerciseWorkingModel = new ExercisesModel();
        }

        private void ClearData()
        {
            txtName.Clear();
            txtDetail.Clear();
            txtQuadriceps.Clear();
            txtHamstring.Clear();
            txtCalves.Clear();
            txtButtocks.Clear();
            txtTrapezius.Clear();
            txtDorsals.Clear();
            txtLumbars.Clear();
            txtPectorals.Clear();
            txtDorsals.Clear();
            txtAbdominals.Clear();
            txtObliques.Clear();
            txtBiceps.Clear();
            txtTriceps.Clear();
            txtForeArm.Clear();
            txtPosteriorDeltoid.Clear();
            txtLateralDeltoid.Clear();
            txtAnteriorDeltoid.Clear();
            txtAductors.Clear();
        }

        private void SetControlsDefaultState()
        {
            ClearData();

            ControlsUtilities.DisableContainerControls(pnlData);
            ControlsUtilities.DisableContainerControls(pnlPoints);
            ControlsUtilities.EnabledContainerControls(pnlList);

            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnClose.Enabled = true;
            btnCancel.Enabled = false;

            LoadExercisesList();

            btnNew.Select();
        }

        private async void LoadExercisesList()
        {
            LoadNotification.Show("Cargando listado de ejercicios...");

            exercisesList = await exerciseWorkingModel.GetAll();

            LoadDgvexercisesList(exercisesList);

            LoadNotification.Hide();
        }

        private void LoadDgvexercisesList(IEnumerable<ExercisesModel> exercisesList)
        {
            dgvExercisesList.Rows.Clear();

            if (exercisesList != null)
            {
                foreach (ExercisesModel exercise in exercisesList)
                {
                    dgvExercisesList.Rows.Add(exercise.IdExercises, exercise.Name);
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
            ControlsUtilities.EnabledContainerControls(pnlPoints);

            txtSearch.Clear();

            txtName.Select();
        }

        private void ClearSelectionDgv()
        {
            ClearData();

            dgvExercisesList.CurrentCell = null;
            dgvExercisesList.ClearSelection();
        }

        private void frmRegisterExercises_Load(object sender, EventArgs e)
        {
            dgvExercisesList.Columns.Clear();
            dgvExercisesList.Columns.Add("idExercise", "ID EJERCICIO");
            dgvExercisesList.Columns.Add("Name", "NOMBRE");

            dgvExercisesList.Columns["idExercise"].Visible = false;

            SetControlsDefaultState();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            exerciseWorkingModel.Name = txtName.Text;
        }

        private void txtDetail_TextChanged(object sender, EventArgs e)
        {
            exerciseWorkingModel.Detail = txtDetail.Text;
        }

        private void txtQuadriceps_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtQuadriceps.Text))
            {
                txtQuadriceps.TextChanged -= txtQuadriceps_TextChanged;
                txtQuadriceps.Text = "0";
                txtQuadriceps.TextChanged += txtQuadriceps_TextChanged;
            }

            exerciseWorkingModel.QuadricepsPoints = (int)FormatUtilities.NumbersOnly(txtQuadriceps.Text);
        }

        private void txtHamstring_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHamstring.Text))
            {
                txtHamstring.TextChanged -= txtHamstring_TextChanged;
                txtHamstring.Text = "0";
                txtHamstring.TextChanged += txtHamstring_TextChanged;
            }

            exerciseWorkingModel.HamstringPoints = (int)FormatUtilities.NumbersOnly(txtHamstring.Text);
        }

        private void txtCalves_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCalves.Text))
            {
                txtCalves.TextChanged -= txtCalves_TextChanged;
                txtCalves.Text = "0";
                txtCalves.TextChanged += txtCalves_TextChanged;
            }

            exerciseWorkingModel.CalvesPoints = (int)FormatUtilities.NumbersOnly(txtCalves.Text);
        }

        private void txtAductors_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAductors.Text))
            {
                txtAductors.TextChanged -= txtAductors_TextChanged;
                txtAductors.Text = "0";
                txtAductors.TextChanged += txtAductors_TextChanged;
            }

            exerciseWorkingModel.AddcutorPoints = (int)FormatUtilities.NumbersOnly(txtAductors.Text);
        }

        private void txtTrapezius_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrapezius.Text))
            {
                txtTrapezius.TextChanged -= txtTrapezius_TextChanged;
                txtTrapezius.Text = "0";
                txtTrapezius.TextChanged += txtTrapezius_TextChanged;
            }

            exerciseWorkingModel.TrapeziusPoints = (int)FormatUtilities.NumbersOnly(txtTrapezius.Text);
        }

        private void txtDorsals_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDorsals.Text))
            {
                txtDorsals.TextChanged -= txtDorsals_TextChanged;
                txtDorsals.Text = "0";
                txtDorsals.TextChanged += txtDorsals_TextChanged;
            }

            exerciseWorkingModel.DorsalPoints = (int)FormatUtilities.NumbersOnly(txtDorsals.Text);
        }

        private void txtLumbars_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLumbars.Text))
            {
                txtLumbars.TextChanged -= txtLumbars_TextChanged;
                txtLumbars.Text = "0";
                txtLumbars.TextChanged += txtLumbars_TextChanged;
            }

            exerciseWorkingModel.LumbarPoints = (int)FormatUtilities.NumbersOnly(txtLumbars.Text);
        }

        private void txtButtocks_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtButtocks.Text))
            {
                txtButtocks.TextChanged -= txtButtocks_TextChanged;
                txtButtocks.Text = "0";
                txtButtocks.TextChanged += txtButtocks_TextChanged;
            }

            exerciseWorkingModel.ButtocksPoints = (int)FormatUtilities.NumbersOnly(txtButtocks.Text);
        }

        private void txtPectorals_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPectorals.Text))
            {
                txtPectorals.TextChanged -= txtPectorals_TextChanged;
                txtPectorals.Text = "0";
                txtPectorals.TextChanged += txtPectorals_TextChanged;
            }

            exerciseWorkingModel.PectoralPoints = (int)FormatUtilities.NumbersOnly(txtPectorals.Text);
        }

        private void txtAbdominals_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAbdominals.Text))
            {
                txtAbdominals.TextChanged -= txtAbdominals_TextChanged;
                txtAbdominals.Text = "0";
                txtAbdominals.TextChanged += txtAbdominals_TextChanged;
            }

            exerciseWorkingModel.AbdominalPoints = (int)FormatUtilities.NumbersOnly(txtAbdominals.Text);
        }

        private void txtObliques_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtObliques.Text))
            {
                txtObliques.TextChanged -= txtObliques_TextChanged;
                txtObliques.Text = "0";
                txtObliques.TextChanged += txtObliques_TextChanged;
            }

            exerciseWorkingModel.ObliquesPoints = (int)FormatUtilities.NumbersOnly(txtObliques.Text);
        }

        private void txtBiceps_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBiceps.Text))
            {
                txtBiceps.TextChanged -= txtBiceps_TextChanged;
                txtBiceps.Text = "0";
                txtBiceps.TextChanged += txtBiceps_TextChanged;
            }

            exerciseWorkingModel.BicepsPoints = (int)FormatUtilities.NumbersOnly(txtBiceps.Text);
        }

        private void txtTriceps_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTriceps.Text))
            {
                txtTriceps.TextChanged -= txtTriceps_TextChanged;
                txtTriceps.Text = "0";
                txtTriceps.TextChanged += txtTriceps_TextChanged;
            }

            exerciseWorkingModel.TricepsPoints = (int)FormatUtilities.NumbersOnly(txtTriceps.Text);
        }

        private void txtForeArm_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtForeArm.Text))
            {
                txtForeArm.TextChanged -= txtForeArm_TextChanged;
                txtForeArm.Text = "0";
                txtForeArm.TextChanged += txtForeArm_TextChanged;
            }

            exerciseWorkingModel.ForeArmPoints = (int)FormatUtilities.NumbersOnly(txtForeArm.Text);
        }

        private void txtPosteriorDeltoid_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPosteriorDeltoid.Text))
            {
                txtPosteriorDeltoid.TextChanged -= txtPosteriorDeltoid_TextChanged;
                txtPosteriorDeltoid.Text = "0";
                txtPosteriorDeltoid.TextChanged += txtPosteriorDeltoid_TextChanged;
            }

            exerciseWorkingModel.PosteriorDeltoidsPoints = (int)FormatUtilities.NumbersOnly(txtPosteriorDeltoid.Text);
        }

        private void txtLateralDeltoid_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLateralDeltoid.Text))
            {
                txtLateralDeltoid.TextChanged -= txtLateralDeltoid_TextChanged;
                txtLateralDeltoid.Text = "0";
                txtLateralDeltoid.TextChanged += txtLateralDeltoid_TextChanged;
            }

            exerciseWorkingModel.LateralDeltoidPoints = (int)FormatUtilities.NumbersOnly(txtLateralDeltoid.Text);
        }

        private void txtAnteriorDeltoid_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnteriorDeltoid.Text))
            {
                txtAnteriorDeltoid.TextChanged -= txtAnteriorDeltoid_TextChanged;
                txtAnteriorDeltoid.Text = "0";
                txtAnteriorDeltoid.TextChanged += txtAnteriorDeltoid_TextChanged;
            }

            exerciseWorkingModel.AnteriorDeltoidPoints = (int)FormatUtilities.NumbersOnly(txtAnteriorDeltoid.Text);
        }
    }
}
