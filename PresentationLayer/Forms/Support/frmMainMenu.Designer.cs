namespace Presentation
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
            this.btnRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paquetesDeSuscripcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ejerciciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.btnQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.mstPPal = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblState = new System.Windows.Forms.Label();
            this.btnEndSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mstPPal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.Control;
            this.btnRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.paquetesDeSuscripcionToolStripMenuItem,
            this.ejerciciosToolStripMenuItem});
            this.btnRegister.ForeColor = System.Drawing.Color.Black;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(48, 21);
            this.btnRegister.Text = "Altas";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            // 
            // paquetesDeSuscripcionToolStripMenuItem
            // 
            this.paquetesDeSuscripcionToolStripMenuItem.Name = "paquetesDeSuscripcionToolStripMenuItem";
            this.paquetesDeSuscripcionToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.paquetesDeSuscripcionToolStripMenuItem.Text = "Paquetes de Suscripcion";
            // 
            // ejerciciosToolStripMenuItem
            // 
            this.ejerciciosToolStripMenuItem.Name = "ejerciciosToolStripMenuItem";
            this.ejerciciosToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.ejerciciosToolStripMenuItem.Text = "Ejercicios";
            // 
            // btnManagement
            // 
            this.btnManagement.BackColor = System.Drawing.SystemColors.Control;
            this.btnManagement.ForeColor = System.Drawing.Color.Black;
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(64, 21);
            this.btnManagement.Text = "Manejo";
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.SystemColors.Control;
            this.btnQuery.ForeColor = System.Drawing.Color.Black;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(76, 21);
            this.btnQuery.Text = "Consultas";
            // 
            // btnSystem
            // 
            this.btnSystem.BackColor = System.Drawing.SystemColors.Control;
            this.btnSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEndSesion,
            this.btnExit});
            this.btnSystem.ForeColor = System.Drawing.Color.Black;
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Size = new System.Drawing.Size(65, 21);
            this.btnSystem.Text = "Sistema";
            // 
            // mstPPal
            // 
            this.mstPPal.BackColor = System.Drawing.SystemColors.Control;
            this.mstPPal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mstPPal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRegister,
            this.btnManagement,
            this.btnQuery,
            this.btnSystem});
            this.mstPPal.Location = new System.Drawing.Point(0, 0);
            this.mstPPal.Name = "mstPPal";
            this.mstPPal.Size = new System.Drawing.Size(808, 25);
            this.mstPPal.TabIndex = 0;
            this.mstPPal.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblState);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 425);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 25);
            this.panel1.TabIndex = 1;
            // 
            // lblState
            // 
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblState.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblState.Location = new System.Drawing.Point(0, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(808, 25);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "Sesion no iniciada !";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEndSesion
            // 
            this.btnEndSesion.Name = "btnEndSesion";
            this.btnEndSesion.Size = new System.Drawing.Size(180, 22);
            this.btnEndSesion.Text = "Cerrar Sesión";
            this.btnEndSesion.Click += new System.EventHandler(this.btnEndSesion_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 22);
            this.btnExit.Text = "Salir";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(808, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mstPPal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mstPPal;
            this.Name = "frmMainMenu";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.mstPPal.ResumeLayout(false);
            this.mstPPal.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem btnRegister;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paquetesDeSuscripcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ejerciciosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnManagement;
        private System.Windows.Forms.ToolStripMenuItem btnQuery;
        private System.Windows.Forms.ToolStripMenuItem btnSystem;
        private System.Windows.Forms.MenuStrip mstPPal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ToolStripMenuItem btnEndSesion;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
    }
}

