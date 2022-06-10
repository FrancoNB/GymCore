using BusinessLayer.Cache;
using BusinessLayer.Models;
using BusinessLayer.ValueObjects;
using PresentationLayer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PresentationLayer.Forms.Register
{
    public partial class frmRegisterExercises : Form, ISubscriber<ExercisesModel>
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

            btnNew.Select();
        }

        private void LoadDgvExercisesList()
        {
            IEnumerable<ExercisesModel> exercisesList = this.exercisesList;

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                exercisesList = exercisesList.ToList().FindAll(exercise => exercise.Name.ToLower().Contains(txtSearch.Text.ToLower()));

            dgvExercisesList.Rows.Clear();

            foreach (ExercisesModel exercise in exercisesList)
            {
                dgvExercisesList.Rows.Add(exercise.IdExercises, exercise.Name);
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

            ExercisesCache.GetInstance().Attach(this);

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
                txtQuadriceps.SelectionLength = txtQuadriceps.TextLength;
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
                txtHamstring.SelectionLength = txtHamstring.TextLength;
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
                txtCalves.SelectionLength = txtCalves.TextLength;
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
                txtAductors.SelectionLength = txtAductors.TextLength;
                txtAductors.TextChanged += txtAductors_TextChanged;
            }

            exerciseWorkingModel.AdductorPoints = (int)FormatUtilities.NumbersOnly(txtAductors.Text);
        }

        private void txtTrapezius_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTrapezius.Text))
            {
                txtTrapezius.TextChanged -= txtTrapezius_TextChanged;
                txtTrapezius.Text = "0";
                txtTrapezius.SelectionLength = txtTrapezius.TextLength;
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
                txtDorsals.SelectionLength = txtDorsals.TextLength;
                txtDorsals.TextChanged += txtDorsals_TextChanged;
            }

            exerciseWorkingModel.DorsalsPoints = (int)FormatUtilities.NumbersOnly(txtDorsals.Text);
        }

        private void txtLumbars_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLumbars.Text))
            {
                txtLumbars.TextChanged -= txtLumbars_TextChanged;
                txtLumbars.Text = "0";
                txtLumbars.SelectionLength = txtLumbars.TextLength;
                txtLumbars.TextChanged += txtLumbars_TextChanged;
            }

            exerciseWorkingModel.LumbarsPoints = (int)FormatUtilities.NumbersOnly(txtLumbars.Text);
        }

        private void txtButtocks_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtButtocks.Text))
            {
                txtButtocks.TextChanged -= txtButtocks_TextChanged;
                txtButtocks.Text = "0";
                txtButtocks.SelectionLength = txtButtocks.TextLength;
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
                txtPectorals.SelectionLength = txtPectorals.TextLength;
                txtPectorals.TextChanged += txtPectorals_TextChanged;
            }

            exerciseWorkingModel.PectoralsPoints = (int)FormatUtilities.NumbersOnly(txtPectorals.Text);
        }

        private void txtAbdominals_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAbdominals.Text))
            {
                txtAbdominals.TextChanged -= txtAbdominals_TextChanged;
                txtAbdominals.Text = "0";
                txtAbdominals.SelectionLength = txtAbdominals.TextLength;
                txtAbdominals.TextChanged += txtAbdominals_TextChanged;
            }

            exerciseWorkingModel.AbdominalsPoints = (int)FormatUtilities.NumbersOnly(txtAbdominals.Text);
        }

        private void txtObliques_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtObliques.Text))
            {
                txtObliques.TextChanged -= txtObliques_TextChanged;
                txtObliques.Text = "0";
                txtObliques.SelectionLength = txtObliques.TextLength;
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
                txtBiceps.SelectionLength = txtBiceps.TextLength;
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
                txtTriceps.SelectionLength = txtTriceps.TextLength;
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
                txtForeArm.SelectionLength = txtForeArm.TextLength;
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
                txtPosteriorDeltoid.SelectionLength = txtPosteriorDeltoid.TextLength;
                txtPosteriorDeltoid.TextChanged += txtPosteriorDeltoid_TextChanged;
            }

            exerciseWorkingModel.PosteriorDeltoidPoints = (int)FormatUtilities.NumbersOnly(txtPosteriorDeltoid.Text);
        }

        private void txtLateralDeltoid_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLateralDeltoid.Text))
            {
                txtLateralDeltoid.TextChanged -= txtLateralDeltoid_TextChanged;
                txtLateralDeltoid.Text = "0";
                txtLateralDeltoid.SelectionLength = txtLateralDeltoid.TextLength;
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
                txtAnteriorDeltoid.SelectionLength = txtAnteriorDeltoid.TextLength;
                txtAnteriorDeltoid.TextChanged += txtAnteriorDeltoid_TextChanged;
            }

            exerciseWorkingModel.AnteriorDeltoidPoints = (int)FormatUtilities.NumbersOnly(txtAnteriorDeltoid.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDgvExercisesList();
        }

        private void txtQuadriceps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtHamstring_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtCalves_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtAductors_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtTrapezius_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtDorsals_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtLumbars_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtButtocks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtPectorals_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtAbdominals_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtObliques_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtBiceps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtTriceps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtForeArm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtPosteriorDeltoid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtLateralDeltoid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void txtAnteriorDeltoid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)46)
                e.Handled = true;
        }

        private void dgvExercisesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var selectExercise = exercisesList.ToList().Find(exercise => exercise.IdExercises == Convert.ToInt32(dgvExercisesList.CurrentRow.Cells["idExercise"].Value));

                exerciseWorkingModel.IdExercises = selectExercise.IdExercises;
     
                txtName.Text = selectExercise.Name;
                txtDetail.Text = selectExercise.Detail;
                txtQuadriceps.Text = selectExercise.QuadricepsPoints.ToString();
                txtHamstring.Text = selectExercise.HamstringPoints.ToString();
                txtCalves.Text = selectExercise.CalvesPoints.ToString();
                txtButtocks.Text = selectExercise.ButtocksPoints.ToString();
                txtTrapezius.Text = selectExercise.TrapeziusPoints.ToString();
                txtDorsals.Text = selectExercise.DorsalsPoints.ToString();
                txtLumbars.Text = selectExercise.LumbarsPoints.ToString();
                txtPectorals.Text = selectExercise.PectoralsPoints.ToString();
                txtAbdominals.Text = selectExercise.AbdominalsPoints.ToString();
                txtObliques.Text = selectExercise.ObliquesPoints.ToString();
                txtBiceps.Text = selectExercise.BicepsPoints.ToString();
                txtTriceps.Text = selectExercise.TricepsPoints.ToString();
                txtForeArm.Text = selectExercise.ForeArmPoints.ToString();
                txtPosteriorDeltoid.Text = selectExercise.PosteriorDeltoidPoints.ToString();
                txtLateralDeltoid.Text = selectExercise.LateralDeltoidPoints.ToString();
                txtAnteriorDeltoid.Text = selectExercise.AnteriorDeltoidPoints.ToString();
                txtAductors.Text = selectExercise.AdductorPoints.ToString();

                btnUpdate.Select();
            }
            else
            {
                ClearSelectionDgv();
            }
        }

        private void dgvExercisesList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (dgvExercisesList.HitTest(e.X, e.Y).Equals(DataGridView.HitTestInfo.Nowhere))
                {
                    ClearSelectionDgv();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            exerciseWorkingModel.Operation = Operation.Insert;

            ClearSelectionDgv();

            SetControlsActiveState();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvExercisesList.CurrentCell != null)
            {
                exerciseWorkingModel.Operation = Operation.Update;

                SetControlsActiveState();
            }
            else
            {
                MessageBox.Show("Debes seleccionar el ejercicio que deseas modificar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvExercisesList.CurrentCell != null)
            {
                DialogResult confirm = MessageBox.Show("Eliminar ejercicio ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (confirm == DialogResult.OK)
                {
                    LoadNotification.Show("Eliminando ejercicio...");

                    exerciseWorkingModel.Operation = Operation.Delete;

                    var acctionResult = await exerciseWorkingModel.SaveChanges();

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
                MessageBox.Show("Debes seleccionar el ejercicio que deseas eliminar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string footMsg;
            DialogResult confirm;

            if (exerciseWorkingModel.Operation == Operation.Insert)
            {
                confirm = MessageBox.Show("Guardar ejercicio ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                footMsg = "Guardando ejercicio...";
            }
            else if (exerciseWorkingModel.Operation == Operation.Update)
            {
                confirm = MessageBox.Show("Modificar ejercicio ?", "Sistema de Alertas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                footMsg = "Modificando ejercicio...";
            }
            else
            {
                MessageBox.Show("No se establecio la operacion a realizar... !", "Sistema de Alertas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (confirm == DialogResult.OK)
            {
                LoadNotification.Show(footMsg);

                var acctionResult = await exerciseWorkingModel.SaveChanges();

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
            ExercisesCache.GetInstance().Detach(this);

            this.Close();
        }

        public void Update(IEnumerable<ExercisesModel> resource)
        {
            exercisesList = resource;

            LoadDgvExercisesList();
        }
    }
}
