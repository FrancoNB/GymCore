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
            this.paquetesDeSuscripcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejerciciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.suscripcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesDeTrabajoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rutinasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asistenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asistenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentasCorrientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEndSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.mstPPal = new System.Windows.Forms.MenuStrip();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
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
            this.paquetesDeSuscripcionToolStripMenuItem,
            this.ejerciciosToolStripMenuItem});
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
            this.btnRegisterClients.Text = "Cliente";
            this.btnRegisterClients.Click += new System.EventHandler(this.btnRegisterClients_Click);
            // 
            // paquetesDeSuscripcionToolStripMenuItem
            // 
            this.paquetesDeSuscripcionToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.paquetesDeSuscripcionToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.paquetesDeSuscripcionToolStripMenuItem.Name = "paquetesDeSuscripcionToolStripMenuItem";
            this.paquetesDeSuscripcionToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.paquetesDeSuscripcionToolStripMenuItem.Text = "Paquetes de Suscripcion";
            // 
            // ejerciciosToolStripMenuItem
            // 
            this.ejerciciosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.ejerciciosToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.ejerciciosToolStripMenuItem.Name = "ejerciciosToolStripMenuItem";
            this.ejerciciosToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ejerciciosToolStripMenuItem.Text = "Ejercicios";
            // 
            // btnManagement
            // 
            this.btnManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.suscripcionesToolStripMenuItem,
            this.planesDeTrabajoToolStripMenuItem,
            this.rutinasToolStripMenuItem,
            this.asistenciaToolStripMenuItem,
            this.pagosToolStripMenuItem});
            this.btnManagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(64, 21);
            this.btnManagement.Text = "Manejo";
            // 
            // suscripcionesToolStripMenuItem
            // 
            this.suscripcionesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.suscripcionesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.suscripcionesToolStripMenuItem.Name = "suscripcionesToolStripMenuItem";
            this.suscripcionesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.suscripcionesToolStripMenuItem.Text = "Suscripciones";
            // 
            // planesDeTrabajoToolStripMenuItem
            // 
            this.planesDeTrabajoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.planesDeTrabajoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.planesDeTrabajoToolStripMenuItem.Name = "planesDeTrabajoToolStripMenuItem";
            this.planesDeTrabajoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.planesDeTrabajoToolStripMenuItem.Text = "Planes de Trabajo";
            // 
            // rutinasToolStripMenuItem
            // 
            this.rutinasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.rutinasToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.rutinasToolStripMenuItem.Name = "rutinasToolStripMenuItem";
            this.rutinasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rutinasToolStripMenuItem.Text = "Rutinas";
            // 
            // asistenciaToolStripMenuItem
            // 
            this.asistenciaToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.asistenciaToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.asistenciaToolStripMenuItem.Name = "asistenciaToolStripMenuItem";
            this.asistenciaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asistenciaToolStripMenuItem.Text = "Asistencia";
            // 
            // pagosToolStripMenuItem
            // 
            this.pagosToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.pagosToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            this.pagosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pagosToolStripMenuItem.Text = "Pagos";
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnQuery.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem,
            this.asistenciasToolStripMenuItem,
            this.cuentasCorrientesToolStripMenuItem});
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
            // 
            // asistenciasToolStripMenuItem
            // 
            this.asistenciasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.asistenciasToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.asistenciasToolStripMenuItem.Name = "asistenciasToolStripMenuItem";
            this.asistenciasToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.asistenciasToolStripMenuItem.Text = "Asistencias";
            // 
            // cuentasCorrientesToolStripMenuItem
            // 
            this.cuentasCorrientesToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.cuentasCorrientesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.cuentasCorrientesToolStripMenuItem.Name = "cuentasCorrientesToolStripMenuItem";
            this.cuentasCorrientesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cuentasCorrientesToolStripMenuItem.Text = "Cuentas Corrientes";
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
            this.btnUsers.Size = new System.Drawing.Size(155, 22);
            this.btnUsers.Text = "Usuarios";
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnEndSesion
            // 
            this.btnEndSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(19)))), ((int)(((byte)(46)))));
            this.btnEndSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(166)))), ((int)(((byte)(145)))));
            this.btnEndSesion.Name = "btnEndSesion";
            this.btnEndSesion.Size = new System.Drawing.Size(155, 22);
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
        private System.Windows.Forms.ToolStripMenuItem paquetesDeSuscripcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejerciciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnManagement;
        private System.Windows.Forms.ToolStripMenuItem btnQuery;
        private System.Windows.Forms.ToolStripMenuItem btnSystem;
        private System.Windows.Forms.ToolStripMenuItem btnEndSesion;
        private System.Windows.Forms.MenuStrip mstPPal;
        private System.Windows.Forms.ToolStripMenuItem suscripcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesDeTrabajoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rutinasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asistenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asistenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuentasCorrientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnUsers;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
    }
}

