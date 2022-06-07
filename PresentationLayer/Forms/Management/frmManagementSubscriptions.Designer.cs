namespace PresentationLayer.Forms.Management
{
    partial class frmManagementSubscriptions
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new PresentationLayer.Controls.GymCoreButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNew = new PresentationLayer.Controls.GymCoreButton();
            this.btnInvalidate = new PresentationLayer.Controls.GymCoreButton();
            this.btnDelete = new PresentationLayer.Controls.GymCoreButton();
            this.btnCancel = new PresentationLayer.Controls.GymCoreButton();
            this.btnSave = new PresentationLayer.Controls.GymCoreButton();
            this.pnlClientSelection = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClientObservations = new PresentationLayer.Controls.GymCoreTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClient = new PresentationLayer.Controls.GymCoreTextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClientMail = new PresentationLayer.Controls.GymCoreTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClientPhone = new PresentationLayer.Controls.GymCoreTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClientResidence = new PresentationLayer.Controls.GymCoreTextBox();
            this.pnlList = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.dgvSubcriptionsClientList = new PresentationLayer.Controls.GymCoreDataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlData = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTicketCode = new PresentationLayer.Controls.GymCoreTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExpireDate = new PresentationLayer.Controls.GymCoreTextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPrice = new PresentationLayer.Controls.GymCoreTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAvailableDays = new PresentationLayer.Controls.GymCoreTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtNumberSessions = new PresentationLayer.Controls.GymCoreTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPackage = new PresentationLayer.Controls.GymCoreTextBox();
            this.txtObservations = new PresentationLayer.Controls.GymCoreTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlClientSelection.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnlList.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubcriptionsClientList)).BeginInit();
            this.panel4.SuspendLayout();
            this.pnlData.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.TabIndex = 3;
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
            this.label3.Text = "Manejo de Subscripciones";
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnInvalidate);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 549);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 51);
            this.panel2.TabIndex = 2;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnNew.Location = new System.Drawing.Point(12, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(140, 31);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "NUEVO";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnInvalidate
            // 
            this.btnInvalidate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnInvalidate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnInvalidate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvalidate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnInvalidate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnInvalidate.Location = new System.Drawing.Point(158, 10);
            this.btnInvalidate.Name = "btnInvalidate";
            this.btnInvalidate.Size = new System.Drawing.Size(140, 31);
            this.btnInvalidate.TabIndex = 1;
            this.btnInvalidate.Text = "ANULAR";
            this.btnInvalidate.UseVisualStyleBackColor = false;
            this.btnInvalidate.Click += new System.EventHandler(this.btnInvalidate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnDelete.Location = new System.Drawing.Point(304, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 31);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "ELIMINAR";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnCancel.Location = new System.Drawing.Point(873, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 31);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "CANCELAR";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnSave.Location = new System.Drawing.Point(727, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 31);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "GUARDAR";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.pnlClientSelection.TabIndex = 0;
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
            this.panel6.Location = new System.Drawing.Point(0, 507);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1024, 42);
            this.panel6.TabIndex = 41;
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
            // pnlList
            // 
            this.pnlList.Controls.Add(this.panel7);
            this.pnlList.Controls.Add(this.dgvSubcriptionsClientList);
            this.pnlList.Controls.Add(this.panel4);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlList.Location = new System.Drawing.Point(0, 78);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(456, 429);
            this.pnlList.TabIndex = 42;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            this.panel7.Controls.Add(this.label12);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 409);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(456, 20);
            this.panel7.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label12.Location = new System.Drawing.Point(28, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(403, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "[*] Anular una subscripcion no genera el descuento en la cuenta corriente del cli" +
    "ente";
            // 
            // dgvSubcriptionsClientList
            // 
            this.dgvSubcriptionsClientList.AllowUserToAddRows = false;
            this.dgvSubcriptionsClientList.AllowUserToDeleteRows = false;
            this.dgvSubcriptionsClientList.AllowUserToResizeColumns = false;
            this.dgvSubcriptionsClientList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvSubcriptionsClientList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSubcriptionsClientList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSubcriptionsClientList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.dgvSubcriptionsClientList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSubcriptionsClientList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSubcriptionsClientList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubcriptionsClientList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSubcriptionsClientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubcriptionsClientList.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubcriptionsClientList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSubcriptionsClientList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubcriptionsClientList.EnableHeadersVisualStyles = false;
            this.dgvSubcriptionsClientList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.dgvSubcriptionsClientList.Location = new System.Drawing.Point(0, 35);
            this.dgvSubcriptionsClientList.MultiSelect = false;
            this.dgvSubcriptionsClientList.Name = "dgvSubcriptionsClientList";
            this.dgvSubcriptionsClientList.ReadOnly = true;
            this.dgvSubcriptionsClientList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubcriptionsClientList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSubcriptionsClientList.RowHeadersWidth = 20;
            this.dgvSubcriptionsClientList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvSubcriptionsClientList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSubcriptionsClientList.RowTemplate.Height = 30;
            this.dgvSubcriptionsClientList.RowTemplate.ReadOnly = true;
            this.dgvSubcriptionsClientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSubcriptionsClientList.Size = new System.Drawing.Size(456, 394);
            this.dgvSubcriptionsClientList.TabIndex = 19;
            this.dgvSubcriptionsClientList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubcriptionsClientList_CellClick);
            this.dgvSubcriptionsClientList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvSubcriptionsClientList_MouseUp);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.panel4.Controls.Add(this.label9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(456, 35);
            this.panel4.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(456, 35);
            this.label9.TabIndex = 5;
            this.label9.Text = "Subscripciones Activas del Cliente";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.label13);
            this.pnlData.Controls.Add(this.txtTicketCode);
            this.pnlData.Controls.Add(this.label8);
            this.pnlData.Controls.Add(this.txtExpireDate);
            this.pnlData.Controls.Add(this.dtpStartDate);
            this.pnlData.Controls.Add(this.label10);
            this.pnlData.Controls.Add(this.label16);
            this.pnlData.Controls.Add(this.label17);
            this.pnlData.Controls.Add(this.txtPrice);
            this.pnlData.Controls.Add(this.label18);
            this.pnlData.Controls.Add(this.txtAvailableDays);
            this.pnlData.Controls.Add(this.label19);
            this.pnlData.Controls.Add(this.txtNumberSessions);
            this.pnlData.Controls.Add(this.label11);
            this.pnlData.Controls.Add(this.label14);
            this.pnlData.Controls.Add(this.txtPackage);
            this.pnlData.Controls.Add(this.txtObservations);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(456, 78);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(568, 355);
            this.pnlData.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label13.Location = new System.Drawing.Point(7, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 19);
            this.label13.TabIndex = 50;
            this.label13.Text = "Codigo de Op.";
            // 
            // txtTicketCode
            // 
            this.txtTicketCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtTicketCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTicketCode.Enabled = false;
            this.txtTicketCode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTicketCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtTicketCode.Location = new System.Drawing.Point(154, 11);
            this.txtTicketCode.MaxLength = 11;
            this.txtTicketCode.Name = "txtTicketCode";
            this.txtTicketCode.NumbersOnly = false;
            this.txtTicketCode.Size = new System.Drawing.Size(211, 27);
            this.txtTicketCode.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label8.Location = new System.Drawing.Point(7, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 19);
            this.label8.TabIndex = 48;
            this.label8.Text = "Fecha de Inicio";
            // 
            // txtExpireDate
            // 
            this.txtExpireDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtExpireDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpireDate.Enabled = false;
            this.txtExpireDate.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtExpireDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtExpireDate.Location = new System.Drawing.Point(154, 203);
            this.txtExpireDate.MaxLength = 11;
            this.txtExpireDate.Name = "txtExpireDate";
            this.txtExpireDate.NumbersOnly = true;
            this.txtExpireDate.Size = new System.Drawing.Size(167, 27);
            this.txtExpireDate.TabIndex = 5;
            this.txtExpireDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExpireDate.TextChanged += new System.EventHandler(this.txtExpireDate_TextChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.dtpStartDate.Location = new System.Drawing.Point(154, 49);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(237, 23);
            this.dtpStartDate.TabIndex = 1;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label10.Location = new System.Drawing.Point(7, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 19);
            this.label10.TabIndex = 46;
            this.label10.Text = "Fecha de Vto.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label16.Location = new System.Drawing.Point(327, 166);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 19);
            this.label16.TabIndex = 45;
            this.label16.Text = "Dias";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label17.Location = new System.Drawing.Point(7, 242);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 19);
            this.label17.TabIndex = 44;
            this.label17.Text = "Precio";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Enabled = false;
            this.txtPrice.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtPrice.Location = new System.Drawing.Point(154, 243);
            this.txtPrice.MaxLength = 11;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.NumbersOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(167, 27);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label18.Location = new System.Drawing.Point(7, 166);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(135, 19);
            this.label18.TabIndex = 43;
            this.label18.Text = "Tiempo de vigencia";
            // 
            // txtAvailableDays
            // 
            this.txtAvailableDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtAvailableDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAvailableDays.Enabled = false;
            this.txtAvailableDays.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtAvailableDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtAvailableDays.Location = new System.Drawing.Point(154, 164);
            this.txtAvailableDays.MaxLength = 11;
            this.txtAvailableDays.Name = "txtAvailableDays";
            this.txtAvailableDays.NumbersOnly = true;
            this.txtAvailableDays.Size = new System.Drawing.Size(167, 27);
            this.txtAvailableDays.TabIndex = 4;
            this.txtAvailableDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAvailableDays.TextChanged += new System.EventHandler(this.txtAvailableDays_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label19.Location = new System.Drawing.Point(7, 127);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(141, 19);
            this.label19.TabIndex = 42;
            this.label19.Text = "Numero de sesiones";
            // 
            // txtNumberSessions
            // 
            this.txtNumberSessions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtNumberSessions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumberSessions.Enabled = false;
            this.txtNumberSessions.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtNumberSessions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtNumberSessions.Location = new System.Drawing.Point(154, 125);
            this.txtNumberSessions.MaxLength = 11;
            this.txtNumberSessions.Name = "txtNumberSessions";
            this.txtNumberSessions.NumbersOnly = true;
            this.txtNumberSessions.Size = new System.Drawing.Size(167, 27);
            this.txtNumberSessions.TabIndex = 3;
            this.txtNumberSessions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNumberSessions.TextChanged += new System.EventHandler(this.txtNumberSessions_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label11.Location = new System.Drawing.Point(7, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 19);
            this.label11.TabIndex = 37;
            this.label11.Text = "Observaciones";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label14.Location = new System.Drawing.Point(7, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 19);
            this.label14.TabIndex = 27;
            this.label14.Text = "Paquete";
            // 
            // txtPackage
            // 
            this.txtPackage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPackage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPackage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPackage.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtPackage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtPackage.Location = new System.Drawing.Point(154, 84);
            this.txtPackage.MaxLength = 100;
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.NumbersOnly = false;
            this.txtPackage.Size = new System.Drawing.Size(403, 27);
            this.txtPackage.TabIndex = 2;
            this.txtPackage.TextChanged += new System.EventHandler(this.txtPackage_TextChanged);
            this.txtPackage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPackage_KeyDown);
            // 
            // txtObservations
            // 
            this.txtObservations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtObservations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservations.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtObservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtObservations.Location = new System.Drawing.Point(154, 283);
            this.txtObservations.MaxLength = 255;
            this.txtObservations.Multiline = true;
            this.txtObservations.Name = "txtObservations";
            this.txtObservations.NumbersOnly = false;
            this.txtObservations.Size = new System.Drawing.Size(403, 60);
            this.txtObservations.TabIndex = 7;
            this.txtObservations.TextChanged += new System.EventHandler(this.txtObservations_TextChanged);
            // 
            // frmManagementSubscriptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(16)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.pnlClientSelection);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmManagementSubscriptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManagementSubscriptions";
            this.Load += new System.EventHandler(this.frmManagementSubscriptions_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlClientSelection.ResumeLayout(false);
            this.pnlClientSelection.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.pnlList.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubcriptionsClientList)).EndInit();
            this.panel4.ResumeLayout(false);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private PresentationLayer.Controls.GymCoreButton btnClose;
        private PresentationLayer.Controls.GymCoreTextBox txtClient;
        private System.Windows.Forms.Panel panel2;
        private PresentationLayer.Controls.GymCoreButton btnNew;
        private PresentationLayer.Controls.GymCoreButton btnInvalidate;
        private PresentationLayer.Controls.GymCoreButton btnDelete;
        private PresentationLayer.Controls.GymCoreButton btnCancel;
        private PresentationLayer.Controls.GymCoreButton btnSave;
        private System.Windows.Forms.Panel pnlClientSelection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private PresentationLayer.Controls.GymCoreTextBox txtClientObservations;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private PresentationLayer.Controls.GymCoreTextBox txtClientMail;
        private System.Windows.Forms.Label label1;
        private PresentationLayer.Controls.GymCoreTextBox txtClientPhone;
        private System.Windows.Forms.Label label6;
        private PresentationLayer.Controls.GymCoreTextBox txtClientResidence;
        private System.Windows.Forms.Panel pnlList;
        private PresentationLayer.Controls.GymCoreDataGridView dgvSubcriptionsClientList;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private PresentationLayer.Controls.GymCoreTextBox txtPackage;
        private PresentationLayer.Controls.GymCoreTextBox txtObservations;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private PresentationLayer.Controls.GymCoreTextBox txtPrice;
        private System.Windows.Forms.Label label18;
        private PresentationLayer.Controls.GymCoreTextBox txtAvailableDays;
        private System.Windows.Forms.Label label19;
        private PresentationLayer.Controls.GymCoreTextBox txtNumberSessions;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private PresentationLayer.Controls.GymCoreTextBox txtExpireDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private PresentationLayer.Controls.GymCoreTextBox txtTicketCode;
    }
}