
namespace Brain_Rush
{
    partial class Form1
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
            this.PanelLogin = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelPrincipal = new System.Windows.Forms.Panel();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.progressTiempo = new System.Windows.Forms.ProgressBar();
            this.lblPuntaje = new System.Windows.Forms.Label();
            this.lblTiempoLimite = new System.Windows.Forms.Label();
            this.rbOpcion4 = new System.Windows.Forms.RadioButton();
            this.rbOpcion3 = new System.Windows.Forms.RadioButton();
            this.rbOpcion2 = new System.Windows.Forms.RadioButton();
            this.rbOpcion1 = new System.Windows.Forms.RadioButton();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.panelGameInit = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numTiempo = new System.Windows.Forms.NumericUpDown();
            this.cmbModo = new System.Windows.Forms.ComboBox();
            this.btnComenzar = new System.Windows.Forms.Button();
            this.PanelLogin.SuspendLayout();
            this.PanelPrincipal.SuspendLayout();
            this.panelGameInit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTiempo)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelLogin
            // 
            this.PanelLogin.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.PanelLogin.Controls.Add(this.btnLogin);
            this.PanelLogin.Controls.Add(this.txtUsuario);
            this.PanelLogin.Controls.Add(this.txtPassword);
            this.PanelLogin.Controls.Add(this.label2);
            this.PanelLogin.Controls.Add(this.label1);
            this.PanelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelLogin.Location = new System.Drawing.Point(0, 0);
            this.PanelLogin.Name = "PanelLogin";
            this.PanelLogin.Size = new System.Drawing.Size(800, 450);
            this.PanelLogin.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(353, 289);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Entrar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(322, 197);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(148, 20);
            this.txtUsuario.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(322, 263);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(148, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Usuario\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contraseña";
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelPrincipal.Controls.Add(this.btnSiguiente);
            this.PanelPrincipal.Controls.Add(this.progressTiempo);
            this.PanelPrincipal.Controls.Add(this.lblPuntaje);
            this.PanelPrincipal.Controls.Add(this.lblTiempoLimite);
            this.PanelPrincipal.Controls.Add(this.rbOpcion4);
            this.PanelPrincipal.Controls.Add(this.rbOpcion3);
            this.PanelPrincipal.Controls.Add(this.rbOpcion2);
            this.PanelPrincipal.Controls.Add(this.rbOpcion1);
            this.PanelPrincipal.Controls.Add(this.lblPregunta);
            this.PanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Size = new System.Drawing.Size(800, 450);
            this.PanelPrincipal.TabIndex = 1;
            this.PanelPrincipal.Visible = false;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(344, 318);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
            this.btnSiguiente.TabIndex = 10;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // progressTiempo
            // 
            this.progressTiempo.Location = new System.Drawing.Point(12, 10);
            this.progressTiempo.Name = "progressTiempo";
            this.progressTiempo.Size = new System.Drawing.Size(100, 23);
            this.progressTiempo.TabIndex = 9;
            // 
            // lblPuntaje
            // 
            this.lblPuntaje.AutoSize = true;
            this.lblPuntaje.Location = new System.Drawing.Point(563, 13);
            this.lblPuntaje.Name = "lblPuntaje";
            this.lblPuntaje.Size = new System.Drawing.Size(35, 13);
            this.lblPuntaje.TabIndex = 8;
            this.lblPuntaje.Text = "label5";
            // 
            // lblTiempoLimite
            // 
            this.lblTiempoLimite.AutoSize = true;
            this.lblTiempoLimite.Location = new System.Drawing.Point(667, 13);
            this.lblTiempoLimite.Name = "lblTiempoLimite";
            this.lblTiempoLimite.Size = new System.Drawing.Size(35, 13);
            this.lblTiempoLimite.TabIndex = 7;
            this.lblTiempoLimite.Text = "label4";
            // 
            // rbOpcion4
            // 
            this.rbOpcion4.AutoSize = true;
            this.rbOpcion4.Location = new System.Drawing.Point(471, 289);
            this.rbOpcion4.Name = "rbOpcion4";
            this.rbOpcion4.Size = new System.Drawing.Size(85, 17);
            this.rbOpcion4.TabIndex = 6;
            this.rbOpcion4.TabStop = true;
            this.rbOpcion4.Text = "radioButton4";
            this.rbOpcion4.UseVisualStyleBackColor = true;
            // 
            // rbOpcion3
            // 
            this.rbOpcion3.AutoSize = true;
            this.rbOpcion3.Location = new System.Drawing.Point(210, 289);
            this.rbOpcion3.Name = "rbOpcion3";
            this.rbOpcion3.Size = new System.Drawing.Size(85, 17);
            this.rbOpcion3.TabIndex = 5;
            this.rbOpcion3.TabStop = true;
            this.rbOpcion3.Text = "radioButton3";
            this.rbOpcion3.UseVisualStyleBackColor = true;
            // 
            // rbOpcion2
            // 
            this.rbOpcion2.AutoSize = true;
            this.rbOpcion2.Location = new System.Drawing.Point(471, 227);
            this.rbOpcion2.Name = "rbOpcion2";
            this.rbOpcion2.Size = new System.Drawing.Size(85, 17);
            this.rbOpcion2.TabIndex = 4;
            this.rbOpcion2.TabStop = true;
            this.rbOpcion2.Text = "radioButton2";
            this.rbOpcion2.UseVisualStyleBackColor = true;
            // 
            // rbOpcion1
            // 
            this.rbOpcion1.AutoSize = true;
            this.rbOpcion1.Location = new System.Drawing.Point(210, 227);
            this.rbOpcion1.Name = "rbOpcion1";
            this.rbOpcion1.Size = new System.Drawing.Size(85, 17);
            this.rbOpcion1.TabIndex = 3;
            this.rbOpcion1.TabStop = true;
            this.rbOpcion1.Text = "radioButton1";
            this.rbOpcion1.UseVisualStyleBackColor = true;
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Location = new System.Drawing.Point(350, 137);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(35, 13);
            this.lblPregunta.TabIndex = 2;
            this.lblPregunta.Text = "label3";
            // 
            // panelGameInit
            // 
            this.panelGameInit.BackColor = System.Drawing.SystemColors.Highlight;
            this.panelGameInit.Controls.Add(this.label4);
            this.panelGameInit.Controls.Add(this.label3);
            this.panelGameInit.Controls.Add(this.numTiempo);
            this.panelGameInit.Controls.Add(this.cmbModo);
            this.panelGameInit.Controls.Add(this.btnComenzar);
            this.panelGameInit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGameInit.Location = new System.Drawing.Point(0, 0);
            this.panelGameInit.Name = "panelGameInit";
            this.panelGameInit.Size = new System.Drawing.Size(800, 450);
            this.panelGameInit.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tiempo por pregunta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(418, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Dificultad";
            // 
            // numTiempo
            // 
            this.numTiempo.Location = new System.Drawing.Point(242, 170);
            this.numTiempo.Name = "numTiempo";
            this.numTiempo.Size = new System.Drawing.Size(120, 20);
            this.numTiempo.TabIndex = 2;
            // 
            // cmbModo
            // 
            this.cmbModo.FormattingEnabled = true;
            this.cmbModo.Location = new System.Drawing.Point(421, 170);
            this.cmbModo.Name = "cmbModo";
            this.cmbModo.Size = new System.Drawing.Size(121, 21);
            this.cmbModo.TabIndex = 1;
            // 
            // btnComenzar
            // 
            this.btnComenzar.Location = new System.Drawing.Point(344, 227);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(75, 23);
            this.btnComenzar.TabIndex = 0;
            this.btnComenzar.Text = "Comenzar";
            this.btnComenzar.UseVisualStyleBackColor = true;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelPrincipal);
            this.Controls.Add(this.panelGameInit);
            this.Controls.Add(this.PanelLogin);
            this.Name = "Form1";
            this.Text = "Form1";
            this.PanelLogin.ResumeLayout(false);
            this.PanelLogin.PerformLayout();
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelPrincipal.PerformLayout();
            this.panelGameInit.ResumeLayout(false);
            this.panelGameInit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTiempo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelLogin;
        private System.Windows.Forms.Panel PanelPrincipal;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.ProgressBar progressTiempo;
        private System.Windows.Forms.Label lblPuntaje;
        private System.Windows.Forms.Label lblTiempoLimite;
        private System.Windows.Forms.RadioButton rbOpcion4;
        private System.Windows.Forms.RadioButton rbOpcion3;
        private System.Windows.Forms.RadioButton rbOpcion2;
        private System.Windows.Forms.RadioButton rbOpcion1;
        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.Panel panelGameInit;
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.ComboBox cmbModo;
        private System.Windows.Forms.NumericUpDown numTiempo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

