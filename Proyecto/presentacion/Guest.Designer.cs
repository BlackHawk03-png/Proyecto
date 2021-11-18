
namespace Proyecto.presentacion
{
    partial class Guest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Guest));
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnBlackjack = new System.Windows.Forms.Button();
            this.btnTruco = new System.Windows.Forms.Button();
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
            this.btnVolver.TabIndex = 15;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnBlackjack
            // 
            this.btnBlackjack.BackColor = System.Drawing.Color.Transparent;
            this.btnBlackjack.FlatAppearance.BorderSize = 2;
            this.btnBlackjack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlackjack.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlackjack.Location = new System.Drawing.Point(332, 185);
            this.btnBlackjack.Margin = new System.Windows.Forms.Padding(5);
            this.btnBlackjack.Name = "btnBlackjack";
            this.btnBlackjack.Size = new System.Drawing.Size(615, 136);
            this.btnBlackjack.TabIndex = 16;
            this.btnBlackjack.Text = "Blackjack";
            this.btnBlackjack.UseVisualStyleBackColor = false;
            this.btnBlackjack.Click += new System.EventHandler(this.btnBlackjack_Click);
            // 
            // btnTruco
            // 
            this.btnTruco.BackColor = System.Drawing.Color.Transparent;
            this.btnTruco.FlatAppearance.BorderSize = 2;
            this.btnTruco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTruco.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTruco.Location = new System.Drawing.Point(332, 412);
            this.btnTruco.Name = "btnTruco";
            this.btnTruco.Size = new System.Drawing.Size(615, 136);
            this.btnTruco.TabIndex = 17;
            this.btnTruco.Text = "Truco";
            this.btnTruco.UseVisualStyleBackColor = false;
            this.btnTruco.Click += new System.EventHandler(this.btnTruco_Click);
            // 
            // Guest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1260, 677);
            this.Controls.Add(this.btnTruco);
            this.Controls.Add(this.btnBlackjack);
            this.Controls.Add(this.btnVolver);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Guest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guest";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnBlackjack;
        private System.Windows.Forms.Button btnTruco;
    }
}