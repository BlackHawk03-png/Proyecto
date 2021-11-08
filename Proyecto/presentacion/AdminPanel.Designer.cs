
namespace Proyecto.presentacion
{
    partial class AdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExtra = new System.Windows.Forms.Button();
            this.btnReview = new System.Windows.Forms.Button();
            this.txtUsername1 = new System.Windows.Forms.TextBox();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtUsuarios = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnDeleteLogic = new System.Windows.Forms.Button();
            this.btnEditProfile = new System.Windows.Forms.Button();
            this.gridUsernames = new System.Windows.Forms.DataGridView();
            this.Usuarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAbleUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsernames)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Transparent;
            this.btnVolver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVolver.BackgroundImage")));
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(0, 617);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(151, 64);
            this.btnVolver.TabIndex = 38;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(21, 181);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(143, 50);
            this.btnDelete.TabIndex = 36;
            this.btnDelete.Text = "Delete User Physically";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExtra
            // 
            this.btnExtra.Location = new System.Drawing.Point(185, 461);
            this.btnExtra.Name = "btnExtra";
            this.btnExtra.Size = new System.Drawing.Size(91, 27);
            this.btnExtra.TabIndex = 35;
            this.btnExtra.Text = "Send Extra";
            this.btnExtra.UseVisualStyleBackColor = true;
            // 
            // btnReview
            // 
            this.btnReview.Location = new System.Drawing.Point(21, 125);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(143, 50);
            this.btnReview.TabIndex = 34;
            this.btnReview.Text = "Review User";
            this.btnReview.UseVisualStyleBackColor = true;
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // txtUsername1
            // 
            this.txtUsername1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername1.Location = new System.Drawing.Point(41, 461);
            this.txtUsername1.Name = "txtUsername1";
            this.txtUsername1.Size = new System.Drawing.Size(100, 26);
            this.txtUsername1.TabIndex = 39;
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(21, 293);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(143, 50);
            this.btnAdmin.TabIndex = 40;
            this.btnAdmin.Text = "Convert into Admin";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(21, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 50);
            this.button1.TabIndex = 41;
            this.button1.Text = "Put default picture";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtUsuarios
            // 
            this.txtUsuarios.AutoSize = true;
            this.txtUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.txtUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarios.Location = new System.Drawing.Point(16, 514);
            this.txtUsuarios.Name = "txtUsuarios";
            this.txtUsuarios.Size = new System.Drawing.Size(220, 50);
            this.txtUsuarios.TabIndex = 42;
            this.txtUsuarios.Text = "Usuarios totales:\r\nUsuarios conectados:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(21, 567);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(91, 27);
            this.btnActualizar.TabIndex = 43;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnDeleteLogic
            // 
            this.btnDeleteLogic.Location = new System.Drawing.Point(21, 237);
            this.btnDeleteLogic.Name = "btnDeleteLogic";
            this.btnDeleteLogic.Size = new System.Drawing.Size(143, 50);
            this.btnDeleteLogic.TabIndex = 44;
            this.btnDeleteLogic.Text = "Disable user";
            this.btnDeleteLogic.UseVisualStyleBackColor = true;
            this.btnDeleteLogic.Click += new System.EventHandler(this.btnDeleteLogic_Click);
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditProfile.Location = new System.Drawing.Point(21, 405);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.Size = new System.Drawing.Size(143, 50);
            this.btnEditProfile.TabIndex = 45;
            this.btnEditProfile.Text = "Edit user profile";
            this.btnEditProfile.UseVisualStyleBackColor = false;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // gridUsernames
            // 
            this.gridUsernames.AllowUserToAddRows = false;
            this.gridUsernames.AllowUserToDeleteRows = false;
            this.gridUsernames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsernames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Usuarios});
            this.gridUsernames.Location = new System.Drawing.Point(1080, 125);
            this.gridUsernames.Name = "gridUsernames";
            this.gridUsernames.ReadOnly = true;
            this.gridUsernames.RowHeadersWidth = 51;
            this.gridUsernames.Size = new System.Drawing.Size(172, 287);
            this.gridUsernames.TabIndex = 46;
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
            // btnAbleUser
            // 
            this.btnAbleUser.Location = new System.Drawing.Point(170, 237);
            this.btnAbleUser.Name = "btnAbleUser";
            this.btnAbleUser.Size = new System.Drawing.Size(143, 50);
            this.btnAbleUser.TabIndex = 48;
            this.btnAbleUser.Text = "Able user";
            this.btnAbleUser.UseVisualStyleBackColor = true;
            this.btnAbleUser.Click += new System.EventHandler(this.btnAbleUser_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnAbleUser);
            this.Controls.Add(this.gridUsernames);
            this.Controls.Add(this.btnEditProfile);
            this.Controls.Add(this.btnDeleteLogic);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtUsuarios);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.txtUsername1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExtra);
            this.Controls.Add(this.btnReview);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPanel";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsernames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExtra;
        private System.Windows.Forms.Button btnReview;
        private System.Windows.Forms.TextBox txtUsername1;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txtUsuarios;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnDeleteLogic;
        private System.Windows.Forms.Button btnEditProfile;
        private System.Windows.Forms.DataGridView gridUsernames;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuarios;
        private System.Windows.Forms.Button btnAbleUser;
    }
}