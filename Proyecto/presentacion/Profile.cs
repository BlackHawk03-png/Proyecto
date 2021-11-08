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
            List<string> amigos = Conexion.devuelveAmigos();
            //gridUsernames.Columns.Add("Amigos");
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
        }

        private void PruebaPersistencia_Load(object sender, EventArgs e)
        {

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
    }
}
