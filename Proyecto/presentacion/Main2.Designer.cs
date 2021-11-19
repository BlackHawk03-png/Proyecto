
namespace Proyecto.presentacion
{
    partial class Main2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main2));
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTruco = new System.Windows.Forms.Button();
            this.btnBlackjack = new System.Windows.Forms.Button();
            this.gridUsernames = new System.Windows.Forms.DataGridView();
            this.Usuarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarAmigos = new System.Windows.Forms.Button();
            this.btnVisitarPerfil = new System.Windows.Forms.Button();
            this.txtVistaUsuario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsernames)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.Transparent;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.Location = new System.Drawing.Point(1098, 122);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(154, 71);
            this.btnAdmin.TabIndex = 3;
            this.btnAdmin.Text = "Panel de\r\nadministrador\r\n";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
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
            this.btnVolver.TabIndex = 5;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1098, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 71);
            this.button1.TabIndex = 4;
            this.button1.Text = "Perfil";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTruco
            // 
            this.btnTruco.BackColor = System.Drawing.Color.Transparent;
            this.btnTruco.FlatAppearance.BorderSize = 2;
            this.btnTruco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTruco.Font = new System.Drawing.Font("White Storm", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTruco.Location = new System.Drawing.Point(326, 354);
            this.btnTruco.Name = "btnTruco";
            this.btnTruco.Size = new System.Drawing.Size(615, 136);
            this.btnTruco.TabIndex = 2;
            this.btnTruco.Text = "Truco";
            this.btnTruco.UseVisualStyleBackColor = false;
            this.btnTruco.Click += new System.EventHandler(this.btnTruco_Click);
            // 
            // btnBlackjack
            // 
            this.btnBlackjack.BackColor = System.Drawing.Color.Transparent;
            this.btnBlackjack.FlatAppearance.BorderSize = 2;
            this.btnBlackjack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlackjack.Font = new System.Drawing.Font("White Storm", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlackjack.Location = new System.Drawing.Point(326, 161);
            this.btnBlackjack.Name = "btnBlackjack";
            this.btnBlackjack.Size = new System.Drawing.Size(615, 136);
            this.btnBlackjack.TabIndex = 1;
            this.btnBlackjack.Text = "Blackjack";
            this.btnBlackjack.UseVisualStyleBackColor = false;
            this.btnBlackjack.Click += new System.EventHandler(this.btnBlackjack_Click);
            // 
            // gridUsernames
            // 
            this.gridUsernames.AllowUserToAddRows = false;
            this.gridUsernames.AllowUserToDeleteRows = false;
            this.gridUsernames.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.gridUsernames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsernames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Usuarios});
            this.gridUsernames.Location = new System.Drawing.Point(12, 122);
            this.gridUsernames.Name = "gridUsernames";
            this.gridUsernames.ReadOnly = true;
            this.gridUsernames.RowHeadersWidth = 51;
            this.gridUsernames.Size = new System.Drawing.Size(180, 368);
            this.gridUsernames.TabIndex = 6;
            // 
            // Usuarios
            // 
            this.Usuarios.HeaderText = "Usuarios";
            this.Usuarios.MinimumWidth = 6;
            this.Usuarios.Name = "Usuarios";
            this.Usuarios.ReadOnly = true;
            this.Usuarios.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Usuarios.Width = 125;
            // 
            // btnAgregarAmigos
            // 
            this.btnAgregarAmigos.Location = new System.Drawing.Point(12, 501);
            this.btnAgregarAmigos.Name = "btnAgregarAmigos";
            this.btnAgregarAmigos.Size = new System.Drawing.Size(180, 35);
            this.btnAgregarAmigos.TabIndex = 7;
            this.btnAgregarAmigos.Text = "Agregar amigo";
            this.btnAgregarAmigos.UseVisualStyleBackColor = true;
            this.btnAgregarAmigos.Click += new System.EventHandler(this.btnAgregarAmigos_Click);
            // 
            // btnVisitarPerfil
            // 
            this.btnVisitarPerfil.BackColor = System.Drawing.Color.Transparent;
            this.btnVisitarPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisitarPerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisitarPerfil.Location = new System.Drawing.Point(1098, 276);
            this.btnVisitarPerfil.Name = "btnVisitarPerfil";
            this.btnVisitarPerfil.Size = new System.Drawing.Size(154, 71);
            this.btnVisitarPerfil.TabIndex = 8;
            this.btnVisitarPerfil.Text = "Perfil de otro usuario";
            this.btnVisitarPerfil.UseVisualStyleBackColor = false;
            this.btnVisitarPerfil.Click += new System.EventHandler(this.btnVisitarPerfil_Click);
            // 
            // txtVistaUsuario
            // 
            this.txtVistaUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVistaUsuario.Location = new System.Drawing.Point(1098, 353);
            this.txtVistaUsuario.Name = "txtVistaUsuario";
            this.txtVistaUsuario.Size = new System.Drawing.Size(154, 31);
            this.txtVistaUsuario.TabIndex = 9;
            // 
            // Main2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1260, 677);
            this.Controls.Add(this.txtVistaUsuario);
            this.Controls.Add(this.btnVisitarPerfil);
            this.Controls.Add(this.btnAgregarAmigos);
            this.Controls.Add(this.gridUsernames);
            this.Controls.Add(this.btnTruco);
            this.Controls.Add(this.btnBlackjack);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAdmin);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Main2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main2";
            this.Load += new System.EventHandler(this.Main2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsernames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTruco;
        private System.Windows.Forms.Button btnBlackjack;
        private System.Windows.Forms.DataGridView gridUsernames;
        private System.Windows.Forms.Button btnAgregarAmigos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuarios;
        private System.Windows.Forms.Button btnVisitarPerfil;
        private System.Windows.Forms.TextBox txtVistaUsuario;
    }
}