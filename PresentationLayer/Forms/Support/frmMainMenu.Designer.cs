namespace PresentationLayer
{
    partial class frmMainMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblState = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRegisterClients = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPackages = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExercises = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSubscriptions = new System.Windows.Forms.ToolStripMenuItem();
            this.planesDeTrabajoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rutinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManagentAssits = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQueriesCurrentAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEndSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mstPPal = new System.Windows.Forms.MenuStrip();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.asistenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.mstPPal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.lblState);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 425);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 25);
            this.panel1.TabIndex = 1;
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.lblState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblState.Location = new System.Drawing.Point(0, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(808, 25);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "Sesion no iniciada !";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegisterClients,
            this.btnPackages,
            this.btnExercises});
            this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(48, 21);
            this.btnRegister.Text = "Altas";
            // 
            // btnRegisterClients
            // 
            this.btnRegisterClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnRegisterClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnRegisterClients.Name = "btnRegisterClients";
            this.btnRegisterClients.Size = new System.Drawing.Size(218, 22);
            this.btnRegisterClients.Text = "Clientes";
            this.btnRegisterClients.Click += new System.EventHandler(this.btnRegisterClients_Click);
            // 
            // btnPackages
            // 
            this.btnPackages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnPackages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnPackages.Name = "btnPackages";
            this.btnPackages.Size = new System.Drawing.Size(218, 22);
            this.btnPackages.Text = "Paquetes de Suscripcion";
            this.btnPackages.Click += new System.EventHandler(this.btnPackages_Click);
            // 
            // btnExercises
            // 
            this.btnExercises.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnExercises.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnExercises.Name = "btnExercises";
            this.btnExercises.Size = new System.Drawing.Size(218, 22);
            this.btnExercises.Text = "Ejercicios";
            this.btnExercises.Click += new System.EventHandler(this.btnExercises_Click);
            // 
            // btnManagement
            // 
            this.btnManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSubscriptions,
            this.planesDeTrabajoToolStripMenuItem,
            this.rutinasToolStripMenuItem,
            this.btnManagentAssits,
            this.btnPayments});
            this.btnManagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(64, 21);
            this.btnManagement.Text = "Manejo";
            // 
            // btnSubscriptions
            // 
            this.btnSubscriptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnSubscriptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnSubscriptions.Name = "btnSubscriptions";
            this.btnSubscriptions.Size = new System.Drawing.Size(180, 22);
            this.btnSubscriptions.Text = "Suscripciones";
            this.btnSubscriptions.Click += new System.EventHandler(this.btnSubscriptions_Click);
            // 
            // planesDeTrabajoToolStripMenuItem
            // 
            this.planesDeTrabajoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.planesDeTrabajoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.planesDeTrabajoToolStripMenuItem.Name = "planesDeTrabajoToolStripMenuItem";
            this.planesDeTrabajoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.planesDeTrabajoToolStripMenuItem.Text = "Planes de Trabajo";
            this.planesDeTrabajoToolStripMenuItem.Visible = false;
            // 
            // rutinasToolStripMenuItem
            // 
            this.rutinasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.rutinasToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.rutinasToolStripMenuItem.Name = "rutinasToolStripMenuItem";
            this.rutinasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rutinasToolStripMenuItem.Text = "Rutinas";
            this.rutinasToolStripMenuItem.Visible = false;
            // 
            // btnManagentAssits
            // 
            this.btnManagentAssits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnManagentAssits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnManagentAssits.Name = "btnManagentAssits";
            this.btnManagentAssits.Size = new System.Drawing.Size(180, 22);
            this.btnManagentAssits.Text = "Asistencia";
            this.btnManagentAssits.Click += new System.EventHandler(this.btnManagentAssits_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnPayments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(180, 22);
            this.btnPayments.Text = "Pagos";
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.asistenciasToolStripMenuItem,
            this.btnQueriesCurrentAccounts});
            this.btnQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(76, 21);
            this.btnQuery.Text = "Consultas";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.clientesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Visible = false;
            // 
            // btnQueriesCurrentAccounts
            // 
            this.btnQueriesCurrentAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnQueriesCurrentAccounts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnQueriesCurrentAccounts.Name = "btnQueriesCurrentAccounts";
            this.btnQueriesCurrentAccounts.Size = new System.Drawing.Size(186, 22);
            this.btnQueriesCurrentAccounts.Text = "Cuentas Corrientes";
            this.btnQueriesCurrentAccounts.Click += new System.EventHandler(this.btnQueriesCurrentAccounts_Click);
            // 
            // btnSystem
            // 
            this.btnSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUsers,
            this.btnEndSesion});
            this.btnSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Size = new System.Drawing.Size(65, 21);
            this.btnSystem.Text = "Sistema";
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(180, 22);
            this.btnUsers.Text = "Usuarios";
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnEndSesion
            // 
            this.btnEndSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnEndSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnEndSesion.Name = "btnEndSesion";
            this.btnEndSesion.Size = new System.Drawing.Size(180, 22);
            this.btnEndSesion.Text = "Cerrar Sesión";
            this.btnEndSesion.Click += new System.EventHandler(this.btnEndSesion_Click);
            // 
            // mstPPal
            // 
            this.mstPPal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.mstPPal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstPPal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegister,
            this.btnManagement,
            this.btnQuery,
            this.btnSystem,
            this.btnExit});
            this.mstPPal.Location = new System.Drawing.Point(0, 0);
            this.mstPPal.Name = "mstPPal";
            this.mstPPal.Size = new System.Drawing.Size(808, 25);
            this.mstPPal.TabIndex = 0;
            this.mstPPal.Text = "menuStrip1";
            // 
            // btnExit
            // 
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(45, 21);
            this.btnExit.Text = "Salir";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // asistenciasToolStripMenuItem
            // 
            this.asistenciasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.asistenciasToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.asistenciasToolStripMenuItem.Name = "asistenciasToolStripMenuItem";
            this.asistenciasToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.asistenciasToolStripMenuItem.Text = "Asistencias";
            this.asistenciasToolStripMenuItem.Visible = false;
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(3)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(808, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mstPPal);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mstPPal;
            this.Name = "frmMainMenu";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.panel1.ResumeLayout(false);
            this.mstPPal.ResumeLayout(false);
            this.mstPPal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ToolStripMenuItem btnRegister;
        private System.Windows.Forms.ToolStripMenuItem btnRegisterClients;
        private System.Windows.Forms.ToolStripMenuItem btnPackages;
        private System.Windows.Forms.ToolStripMenuItem btnExercises;
        private System.Windows.Forms.ToolStripMenuItem btnManagement;
        private System.Windows.Forms.ToolStripMenuItem btnQuery;
        private System.Windows.Forms.ToolStripMenuItem btnSystem;
        private System.Windows.Forms.ToolStripMenuItem btnEndSesion;
        private System.Windows.Forms.MenuStrip mstPPal;
        private System.Windows.Forms.ToolStripMenuItem btnSubscriptions;
        private System.Windows.Forms.ToolStripMenuItem planesDeTrabajoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rutinasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnManagentAssits;
        private System.Windows.Forms.ToolStripMenuItem btnPayments;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnQueriesCurrentAccounts;
        private System.Windows.Forms.ToolStripMenuItem btnUsers;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem asistenciasToolStripMenuItem;
    }
}

