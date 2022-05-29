namespace PresentationLayer.Forms.Register
{
    partial class frmRegisterClients
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
            this.txtName = new PresentationLayer.Controls.GymCoreTextBox();
            this.pnlData = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMail = new PresentationLayer.Controls.GymCoreTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPhone = new PresentationLayer.Controls.GymCoreTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAddress = new PresentationLayer.Controls.GymCoreTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLocality = new PresentationLayer.Controls.GymCoreTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSurname = new PresentationLayer.Controls.GymCoreTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservations = new PresentationLayer.Controls.GymCoreTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearch = new PresentationLayer.Controls.GymCoreTextBox();
            this.dgvClientsList = new PresentationLayer.Controls.GymCoreDataGridView();
            this.pnlList = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnNew = new PresentationLayer.Controls.GymCoreButton();
            this.btnUpdate = new PresentationLayer.Controls.GymCoreButton();
            this.btnDelete = new PresentationLayer.Controls.GymCoreButton();
            this.btnCancel = new PresentationLayer.Controls.GymCoreButton();
            this.btnSave = new PresentationLayer.Controls.GymCoreButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new PresentationLayer.Controls.GymCoreButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlData.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientsList)).BeginInit();
            this.pnlList.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtName.Location = new System.Drawing.Point(117, 14);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(439, 27);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.label11);
            this.pnlData.Controls.Add(this.label10);
            this.pnlData.Controls.Add(this.txtMail);
            this.pnlData.Controls.Add(this.label9);
            this.pnlData.Controls.Add(this.txtPhone);
            this.pnlData.Controls.Add(this.label8);
            this.pnlData.Controls.Add(this.txtAddress);
            this.pnlData.Controls.Add(this.label7);
            this.pnlData.Controls.Add(this.txtLocality);
            this.pnlData.Controls.Add(this.label5);
            this.pnlData.Controls.Add(this.txtSurname);
            this.pnlData.Controls.Add(this.label1);
            this.pnlData.Controls.Add(this.txtName);
            this.pnlData.Controls.Add(this.txtObservations);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(456, 33);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(568, 316);
            this.pnlData.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label11.Location = new System.Drawing.Point(6, 247);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 19);
            this.label11.TabIndex = 37;
            this.label11.Text = "Observaciones";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label10.Location = new System.Drawing.Point(6, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 19);
            this.label10.TabIndex = 35;
            this.label10.Text = "Mail";
            // 
            // txtMail
            // 
            this.txtMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMail.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtMail.Location = new System.Drawing.Point(117, 207);
            this.txtMail.MaxLength = 100;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(439, 27);
            this.txtMail.TabIndex = 5;
            this.txtMail.TextChanged += new System.EventHandler(this.txtMail_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label9.Location = new System.Drawing.Point(6, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 19);
            this.label9.TabIndex = 33;
            this.label9.Text = "Telefono";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtPhone.Location = new System.Drawing.Point(117, 168);
            this.txtPhone.MaxLength = 45;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(439, 27);
            this.txtPhone.TabIndex = 4;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label8.Location = new System.Drawing.Point(6, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 19);
            this.label8.TabIndex = 31;
            this.label8.Text = "Direccion";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtAddress.Location = new System.Drawing.Point(117, 129);
            this.txtAddress.MaxLength = 255;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(439, 27);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label7.Location = new System.Drawing.Point(6, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 19);
            this.label7.TabIndex = 29;
            this.label7.Text = "Localidad";
            // 
            // txtLocality
            // 
            this.txtLocality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtLocality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocality.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtLocality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtLocality.Location = new System.Drawing.Point(117, 91);
            this.txtLocality.MaxLength = 255;
            this.txtLocality.Name = "txtLocality";
            this.txtLocality.Size = new System.Drawing.Size(439, 27);
            this.txtLocality.TabIndex = 2;
            this.txtLocality.TextChanged += new System.EventHandler(this.txtLocality_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 19);
            this.label5.TabIndex = 27;
            this.label5.Text = "Apellido";
            // 
            // txtSurname
            // 
            this.txtSurname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSurname.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtSurname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtSurname.Location = new System.Drawing.Point(117, 52);
            this.txtSurname.MaxLength = 100;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(439, 27);
            this.txtSurname.TabIndex = 1;
            this.txtSurname.TextChanged += new System.EventHandler(this.txtSurname_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nombre";
            // 
            // txtObservations
            // 
            this.txtObservations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtObservations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObservations.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtObservations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtObservations.Location = new System.Drawing.Point(117, 245);
            this.txtObservations.MaxLength = 255;
            this.txtObservations.Multiline = true;
            this.txtObservations.Name = "txtObservations";
            this.txtObservations.Size = new System.Drawing.Size(439, 60);
            this.txtObservations.TabIndex = 6;
            this.txtObservations.TextChanged += new System.EventHandler(this.txtObservations_TextChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(456, 35);
            this.label2.TabIndex = 5;
            this.label2.Text = "Clientes Cargados en el Sistema";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(21)))), ((int)(((byte)(28)))));
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(456, 35);
            this.panel4.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.label4.Location = new System.Drawing.Point(8, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 20;
            this.label4.Text = "Filtrar";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.txtSearch.Location = new System.Drawing.Point(61, 9);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(383, 27);
            this.txtSearch.TabIndex = 20;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvClientsList
            // 
            this.dgvClientsList.AllowUserToAddRows = false;
            this.dgvClientsList.AllowUserToDeleteRows = false;
            this.dgvClientsList.AllowUserToResizeColumns = false;
            this.dgvClientsList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvClientsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvClientsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientsList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.dgvClientsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvClientsList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvClientsList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClientsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientsList.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientsList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvClientsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClientsList.EnableHeadersVisualStyles = false;
            this.dgvClientsList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.dgvClientsList.Location = new System.Drawing.Point(0, 35);
            this.dgvClientsList.MultiSelect = false;
            this.dgvClientsList.Name = "dgvClientsList";
            this.dgvClientsList.ReadOnly = true;
            this.dgvClientsList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClientsList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvClientsList.RowHeadersWidth = 20;
            this.dgvClientsList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvClientsList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvClientsList.RowTemplate.Height = 30;
            this.dgvClientsList.RowTemplate.ReadOnly = true;
            this.dgvClientsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientsList.Size = new System.Drawing.Size(456, 435);
            this.dgvClientsList.TabIndex = 19;
            this.dgvClientsList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientsList_CellClick);
            this.dgvClientsList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvClientsList_MouseUp);
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.dgvClientsList);
            this.pnlList.Controls.Add(this.panel5);
            this.pnlList.Controls.Add(this.panel4);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlList.Location = new System.Drawing.Point(0, 33);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(456, 516);
            this.pnlList.TabIndex = 34;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(18)))));
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.txtSearch);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 470);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(456, 46);
            this.panel5.TabIndex = 18;
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
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnUpdate.Location = new System.Drawing.Point(158, 10);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(140, 31);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "MODIFICAR";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 549);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 51);
            this.panel2.TabIndex = 33;
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
            this.label3.Text = "Altas de Clientes";
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 33);
            this.panel1.TabIndex = 32;
            // 
            // frmRegisterClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(16)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(1024, 600);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRegisterClients";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRegisterClients";
            this.Load += new System.EventHandler(this.frmRegisterClients_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientsList)).EndInit();
            this.pnlList.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.GymCoreTextBox txtName;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private Controls.GymCoreTextBox txtSearch;
        private Controls.GymCoreDataGridView dgvClientsList;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Panel panel5;
        private Controls.GymCoreButton btnNew;
        private Controls.GymCoreButton btnUpdate;
        private Controls.GymCoreButton btnDelete;
        private Controls.GymCoreButton btnCancel;
        private Controls.GymCoreButton btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private Controls.GymCoreButton btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private Controls.GymCoreTextBox txtSurname;
        private System.Windows.Forms.Label label8;
        private Controls.GymCoreTextBox txtAddress;
        private System.Windows.Forms.Label label7;
        private Controls.GymCoreTextBox txtLocality;
        private System.Windows.Forms.Label label10;
        private Controls.GymCoreTextBox txtMail;
        private System.Windows.Forms.Label label9;
        private Controls.GymCoreTextBox txtPhone;
        private System.Windows.Forms.Label label11;
        private Controls.GymCoreTextBox txtObservations;
    }
}