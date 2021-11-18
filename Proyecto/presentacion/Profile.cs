using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.persistencia;
using Proyecto.logica;
using System.Collections;

namespace Proyecto.presentacion
{
    public partial class PruebaPersistencia : Form
    {
        public PruebaPersistencia()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(Register_Closing);
            void Register_Closing(object sender, CancelEventArgs e)
            {
                Conexion.Conectado(Usuario.usuarioActual.Username, 0);
                Application.Exit();
            }
            txtUsername.Text = Usuario.usuarioActual.Username;
            List<string> amigos = Conexion.devuelveAmigos(Usuario.usuarioActual.Username);
            foreach(string a in amigos)
            {
                gridUsernames.Rows.Add(a);
            }

            if (!Usuario.usuarioActual.Suscrito)
            {
                panelMarcoDiferencial.Hide();
            }
            if (Usuario.usuarioActual.FotoPerfil.Equals("") == false)
            {
                picPerfil.BackgroundImage = null;
                picPerfil.Load(Usuario.usuarioActual.FotoPerfil);
            }
            rellenarMedallas();
            
        }
        private void rellenarMedallas()
        {
            int[] medallas = Conexion.recibeMedallasProfile(Usuario.usuarioActual.Username);
            if(medallas[0] == 0)
            {
                pictureBox20.Hide();
                label20.Hide();
            }
            else
            {
                label20.Text = "x" + medallas[0];
            }
            if (medallas[1] == 0)
            {
                pictureBox19.Hide();
                label19.Hide();
            }
            else
            {
                label19.Text = "x" + medallas[1];
            }
            if (medallas[2] == 0)
            {
                pictureBox18.Hide();
                label18.Hide();
            }
            else
            {
                label18.Text = "x" + medallas[2];
            }
            if (medallas[3] == 0)
            {
                pictureBox17.Hide();
                label17.Hide();
            }
            else
            {
                label17.Text = "x" + medallas[3];
            }
            if (medallas[4] == 0)
            {
                pictureBox16.Hide();
                label16.Hide();
            }
            else
            {
                label16.Text = "x" + medallas[4];
            }
            if (medallas[5] == 0)
            {
                pictureBox15.Hide();
                label15.Hide();
            }
            else
            {
                label15.Text = "x" + medallas[5];
            }
            if (medallas[6] == 0)
            {
                pictureBox14.Hide();
                label14.Hide();
            }
            else
            {
                label14.Text = "x" + medallas[6];
            }
            if (medallas[7] == 0)
            {
                pictureBox13.Hide();
                label13.Hide();
            }
            else
            {
                label13.Text = "x" + medallas[7];
            }
            if (medallas[8] == 0)
            {
                pictureBox12.Hide();
                label12.Hide();
            }
            else
            {
                label12.Text = "x" + medallas[8];
            }
            if (medallas[9] == 0)
            {
                pictureBox11.Hide();
                label11.Hide();
            }
            else
            {
                label11.Text = "x" + medallas[9];
            }
            if (medallas[10] == 0)
            {
                pictureBox10.Hide();
                label10.Hide();
            }
            else
            {
                label10.Text = "x" + medallas[10];
            }
            if (medallas[11] == 0)
            {
                pictureBox9.Hide();
                label9.Hide();
            }
            else
            {
                label9.Text = "x" + medallas[11];
            }
            if (medallas[12] == 0)
            {
                pictureBox8.Hide();
                label8.Hide();
            }
            else
            {
                label8.Text = "x" + medallas[12];
            }
            if (medallas[13] == 0)
            {
                pictureBox7.Hide();
                label7.Hide();
            }
            else
            {
                label7.Text = "x" + medallas[13];
            }
            if (medallas[14] == 0)
            {
                pictureBox6.Hide();
                label6.Hide();
            }
            else
            {
                label6.Text = "x" + medallas[14];
            }
            if (medallas[15] == 0)
            {
                pictureBox5.Hide();
                label5.Hide();
            }
            else
            {
                label5.Text = "x" + medallas[15];
            }
            if (medallas[16] == 0)
            {
                pictureBox4.Hide();
                label4.Hide();
            }
            else
            {
                label4.Text = "x" + medallas[16];
            }
            if (medallas[17] == 0)
            {
                pictureBox3.Hide();
                label3.Hide();
            }
            else
            {
                label3.Text = "x" + medallas[17];
            }
            if (medallas[18] == 0)
            {
                pictureBox2.Hide();
                label2.Hide();
            }
            else
            {
                label2.Text = "x" + medallas[18];
            }
            if (medallas[19] == 0)
            {
                pictureBox1.Hide();
                label1.Hide();
            }
            else
            {
                label1.Text = "x" + medallas[19];
            }
        }
        private void PruebaPersistencia_Load(object sender, EventArgs e)
        {

        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox1, "Truco prodigio III");
        }
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox2, "Truco prodigio II");
        }
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox3, "Truco prodigio I");
        }
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox4, "Truco pro II");
        }
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox5, "Truco pro I");
        }
        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox6, "Ganar tu primera partida de Truco");
        }
        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox7, "Truco profesional");
        }
        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox8, "Truco entusiasta");
        }
        private void pictureBox9_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox9, "Truco principiante");
        }
        private void pictureBox10_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox10, "Tu primera partida en Truco");
        }
        private void pictureBox11_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox11, "Blackjack prodigio III");
        }
        private void pictureBox12_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox12, "Blackjack prodigio II");
        }
        private void pictureBox13_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox13, "Blackjack prodigio I");
        }
        private void pictureBox14_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox14, "Blackjack pro II");
        }
        private void pictureBox15_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox15, "Blackjack pro I");
        }
        private void pictureBox16_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox16, "Ganar tu primera partida de Blackjack");
        }
        private void pictureBox17_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox17, "Blackjack profesional");
        }
        private void pictureBox18_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox18, "Blackjack entusiasta");
        }
        private void pictureBox19_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox19, "Blackjack principiante");
        }
        private void pictureBox20_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBox20, "Tu primera partida en Blackjack");
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Main2 m = new Main2();
            m.Show();
            base.Hide();
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            EditProfile edit = new EditProfile("", false);
            edit.Show();
            base.Hide();
        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "Imagenes|*.jpg;*.png;*.gif;*.jfif";
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName.Equals("") == false)
                {
                    picPerfil.BackgroundImage = null;
                    picPerfil.Load(openFileDialog1.FileName);
                    Usuario.usuarioActual.FotoPerfil = openFileDialog1.FileName;

                    Conexion.NuevaImagen();
                }

            } catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la imagen: " + e.ToString());
                throw ex;
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }
    }
}
