
namespace Proyecto.presentacion
{
    partial class UsuarioCambiarPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuarioCambiarPass));
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnEnviarCodigo = new System.Windows.Forms.Button();
            this.btnVerificarCodigo = new System.Windows.Forms.Button();
            this.btnNuevaContraseña = new System.Windows.Forms.Button();
            this.txtNuevaContraseña = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Transparent;
            this.btnVolver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVolver.BackgroundImage")));
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(0, 613);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(151, 64);
            this.btnVolver.TabIndex = 14;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(600, 260);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(117, 35);
            this.txtUsername.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(351, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ingrese su username:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(600, 330);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(117, 35);
            this.txtCodigo.TabIndex = 17;
            // 
            // btnEnviarCodigo
            // 
            this.btnEnviarCodigo.Location = new System.Drawing.Point(732, 260);
            this.btnEnviarCodigo.Name = "btnEnviarCodigo";
            this.btnEnviarCodigo.Size = new System.Drawing.Size(105, 35);
            this.btnEnviarCodigo.TabIndex = 18;
            this.btnEnviarCodigo.Text = "Enviar codigo\r\nde verificacion";
            this.btnEnviarCodigo.UseVisualStyleBackColor = true;
            this.btnEnviarCodigo.Click += new System.EventHandler(this.btnEnviarCodigo_Click);
            // 
            // btnVerificarCodigo
            // 
            this.btnVerificarCodigo.Location = new System.Drawing.Point(732, 330);
            this.btnVerificarCodigo.Name = "btnVerificarCodigo";
            this.btnVerificarCodigo.Size = new System.Drawing.Size(105, 35);
            this.btnVerificarCodigo.TabIndex = 19;
            this.btnVerificarCodigo.Text = "Verificar codigo";
            this.btnVerificarCodigo.UseVisualStyleBackColor = true;
            this.btnVerificarCodigo.Click += new System.EventHandler(this.btnVerificarCodigo_Click);
            // 
            // btnNuevaContraseña
            // 
            this.btnNuevaContraseña.Location = new System.Drawing.Point(732, 403);
            this.btnNuevaContraseña.Name = "btnNuevaContraseña";
            this.btnNuevaContraseña.Size = new System.Drawing.Size(105, 35);
            this.btnNuevaContraseña.TabIndex = 21;
            this.btnNuevaContraseña.Text = "Establecer\r\nnueva contraseña";
            this.btnNuevaContraseña.UseVisualStyleBackColor = true;
            this.btnNuevaContraseña.Click += new System.EventHandler(this.btnNuevaContraseña_Click);
            // 
            // txtNuevaContraseña
            // 
            this.txtNuevaContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevaContraseña.Location = new System.Drawing.Point(600, 403);
            this.txtNuevaContraseña.Name = "txtNuevaContraseña";
            this.txtNuevaContraseña.Size = new System.Drawing.Size(117, 35);
            this.txtNuevaContraseña.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(394, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 58);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ingrese el codigo\r\nde verificacion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(393, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 58);
            this.label3.TabIndex = 23;
            this.label3.Text = "Ingrese su nueva\r\ncontraseña:";
            // 
            // UsuarioCambiarPass
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1260, 677);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNuevaContraseña);
            this.Controls.Add(this.txtNuevaContraseña);
            this.Controls.Add(this.btnVerificarCodigo);
            this.Controls.Add(this.btnEnviarCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnVolver);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "UsuarioCambiarPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsuarioCambiarPass";
            this.Load += new System.EventHandler(this.UsuarioCambiarPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnEnviarCodigo;
        private System.Windows.Forms.Button btnVerificarCodigo;
        private System.Windows.Forms.Button btnNuevaContraseña;
        private System.Windows.Forms.TextBox txtNuevaContraseña;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}