namespace Presentation.Forms.Management
{
    partial class frmManagementAssists
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientMail = new PresentationLayer.Controls.GymCoreTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientPhone = new PresentationLayer.Controls.GymCoreTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClientResidence = new PresentationLayer.Controls.GymCoreTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new PresentationLayer.Controls.GymCoreButton();
            this.pnlClientSelection = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClientObservations = new PresentationLayer.Controls.GymCoreTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClient = new PresentationLayer.Controls.GymCoreTextBox();
            this.pnlList = new System.Windows.Forms.Panel();
            this.dgvAssistsClientList = new PresentationLayer.Controls.GymCoreDataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDelete = new PresentationLayer.Controls.GymCoreButton();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnAdd = new PresentationLayer.Controls.GymCoreButton();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlClientSelection.SuspendLayout();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssistsClientList)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.txtClientMail);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.txtClientPhone);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.txtClientResidence);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 558);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1024, 42);
            this.panel6.TabIndex = 49;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label5.Location = new System.Drawing.Point(9, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 15);
            this.label5.TabIndex = 41;
            this.label5.Text = "Datos del Cliente   |";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label2.Location = new System.Drawing.Point(745, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 40;
            this.label2.Text = "Mail";
            // 
            // txtClientMail
            // 
            this.txtClientMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtClientMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClientMail.Enabled = false;
            this.txtClientMail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtClientMail.Location = new System.Drawing.Point(784, 10);
            this.txtClientMail.MaxLength = 100;
            this.txtClientMail.Name = "txtClientMail";
            this.txtClientMail.NumbersOnly = false;
            this.txtClientMail.Size = new System.Drawing.Size(230, 23);
            this.txtClientMail.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label1.Location = new System.Drawing.Point(450, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "Telefono";
            // 
            // txtClientPhone
            // 
            this.txtClientPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtClientPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClientPhone.Enabled = false;
            this.txtClientPhone.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtClientPhone.Location = new System.Drawing.Point(509, 10);
            this.txtClientPhone.MaxLength = 100;
            this.txtClientPhone.Name = "txtClientPhone";
            this.txtClientPhone.NumbersOnly = false;
            this.txtClientPhone.Size = new System.Drawing.Size(230, 23);
            this.txtClientPhone.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label6.Location = new System.Drawing.Point(124, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 36;
            this.label6.Text = "Residencia";
            // 
            // txtClientResidence
            // 
            this.txtClientResidence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtClientResidence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClientResidence.Enabled = false;
            this.txtClientResidence.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientResidence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtClientResidence.Location = new System.Drawing.Point(197, 10);
            this.txtClientResidence.MaxLength = 100;
            this.txtClientResidence.Name = "txtClientResidence";
            this.txtClientResidence.NumbersOnly = false;
            this.txtClientResidence.Size = new System.Drawing.Size(247, 23);
            this.txtClientResidence.TabIndex = 35;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 33);
            this.panel1.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(991, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "Manejo de Asistencias";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnClose.Location = new System.Drawing.Point(991, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(33, 33);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlClientSelection
            // 
            this.pnlClientSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.pnlClientSelection.Controls.Add(this.label7);
            this.pnlClientSelection.Controls.Add(this.txtClientObservations);
            this.pnlClientSelection.Controls.Add(this.label4);
            this.pnlClientSelection.Controls.Add(this.txtClient);
            this.pnlClientSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlClientSelection.Location = new System.Drawing.Point(0, 33);
            this.pnlClientSelection.Name = "pnlClientSelection";
            this.pnlClientSelection.Size = new System.Drawing.Size(1024, 45);
            this.pnlClientSelection.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label7.Location = new System.Drawing.Point(450, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 19);
            this.label7.TabIndex = 38;
            this.label7.Text = "Observaciones";
            // 
            // txtClientObservations
            // 
            this.txtClientObservations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtClientObservations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClientObservations.Enabled = false;
            this.txtClientObservations.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtClientObservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtClientObservations.Location = new System.Drawing.Point(561, 9);
            this.txtClientObservations.MaxLength = 255;
            this.txtClientObservations.Name = "txtClientObservations";
            this.txtClientObservations.NumbersOnly = false;
            this.txtClientObservations.Size = new System.Drawing.Size(453, 27);
            this.txtClientObservations.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label4.Location = new System.Drawing.Point(8, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 36;
            this.label4.Text = "Cliente";
            // 
            // txtClient
            // 
            this.txtClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClient.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtClient.Location = new System.Drawing.Point(69, 9);
            this.txtClient.MaxLength = 255;
            this.txtClient.Name = "txtClient";
            this.txtClient.NumbersOnly = false;
            this.txtClient.Size = new System.Drawing.Size(375, 27);
            this.txtClient.TabIndex = 0;
            this.txtClient.TextChanged += new System.EventHandler(this.txtClient_TextChanged);
            this.txtClient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClient_KeyDown);
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.dgvAssistsClientList);
            this.pnlList.Controls.Add(this.panel4);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(0, 78);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(1024, 480);
            this.pnlList.TabIndex = 52;
            // 
            // dgvAssistsClientList
            // 
            this.dgvAssistsClientList.AllowUserToAddRows = false;
            this.dgvAssistsClientList.AllowUserToDeleteRows = false;
            this.dgvAssistsClientList.AllowUserToResizeColumns = false;
            this.dgvAssistsClientList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAssistsClientList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAssistsClientList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssistsClientList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.dgvAssistsClientList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAssistsClientList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAssistsClientList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAssistsClientList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAssistsClientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssistsClientList.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAssistsClientList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAssistsClientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssistsClientList.EnableHeadersVisualStyles = false;
            this.dgvAssistsClientList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.dgvAssistsClientList.Location = new System.Drawing.Point(0, 49);
            this.dgvAssistsClientList.MultiSelect = false;
            this.dgvAssistsClientList.Name = "dgvAssistsClientList";
            this.dgvAssistsClientList.ReadOnly = true;
            this.dgvAssistsClientList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAssistsClientList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAssistsClientList.RowHeadersWidth = 20;
            this.dgvAssistsClientList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAssistsClientList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAssistsClientList.RowTemplate.Height = 30;
            this.dgvAssistsClientList.RowTemplate.ReadOnly = true;
            this.dgvAssistsClientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssistsClientList.Size = new System.Drawing.Size(1024, 431);
            this.dgvAssistsClientList.TabIndex = 19;
            this.dgvAssistsClientList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssistsClientList_CellClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            this.panel4.Controls.Add(this.btnDelete);
            this.panel4.Controls.Add(this.dtpDate);
            this.panel4.Controls.Add(this.btnAdd);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1024, 49);
            this.panel4.TabIndex = 17;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnDelete.Location = new System.Drawing.Point(12, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 31);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "ELIMINAR";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd / MM / yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(719, 9);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(149, 31);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnAdd.Location = new System.Drawing.Point(874, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 31);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "AGREGAR";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmManagementAssists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(16)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlClientSelection);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManagementAssists";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManagementAssists";
            this.Load += new System.EventHandler(this.frmManagementAssists_Load);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlClientSelection.ResumeLayout(false);
            this.pnlClientSelection.PerformLayout();
            this.pnlList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssistsClientList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private PresentationLayer.Controls.GymCoreTextBox txtClientMail;
        private System.Windows.Forms.Label label1;
        private PresentationLayer.Controls.GymCoreTextBox txtClientPhone;
        private System.Windows.Forms.Label label6;
        private PresentationLayer.Controls.GymCoreTextBox txtClientResidence;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private PresentationLayer.Controls.GymCoreButton btnClose;
        private System.Windows.Forms.Panel pnlClientSelection;
        private System.Windows.Forms.Label label7;
        private PresentationLayer.Controls.GymCoreTextBox txtClientObservations;
        private System.Windows.Forms.Label label4;
        private PresentationLayer.Controls.GymCoreTextBox txtClient;
        private System.Windows.Forms.Panel pnlList;
        private PresentationLayer.Controls.GymCoreDataGridView dgvAssistsClientList;
        private System.Windows.Forms.Panel panel4;
        private PresentationLayer.Controls.GymCoreButton btnDelete;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private PresentationLayer.Controls.GymCoreButton btnAdd;
    }
}