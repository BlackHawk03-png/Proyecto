using Proyecto.logica;
using Proyecto.persistencia;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.presentacion
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(Register_Closing);
            void Register_Closing(object sender, CancelEventArgs e)
            {
                Conexion.Conectado(Usuario.usuarioActual.Username, 0);
                Application.Exit();
            }
            btnExtra.Hide();
            usuariosConectados = Conexion.cantUsuarios();
            txtUsuarios.Text = usuariosConectados[0].ToString();
            txtUsuarios.Text = "Usuarios totales: " + usuariosConectados[0].ToString() +
                "\nUsuarios conectados: " + usuariosConectados[1].ToString();
            List<string> usuarios = Conexion.devuelveUsernames();     
            foreach(string user in usuarios)
            {
                int n = gridUsernames.Rows.Add();
                gridUsernames.Rows[n].Cells[0].Value = user;
            }
        }
        int[] usuariosConectados;
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Main2 m = new Main2();
            m.Show();
            base.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Warning", "Are you sure you want to delete physically this user?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                int a = Conexion.Existe(txtUsername1.Text);
                if (a == 1)
                {
                    Conexion.EliminarCuenta(txtUsername1.Text);
                    MessageBox.Show("Done", "User successfully deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This user does not exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Warning", "Are you sure you want to convert this user into admin?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                int a = Conexion.Existe(txtUsername1.Text);
                if (a == 1)
                {
                    Conexion.hacerAdmin(txtUsername1.Text);
                    MessageBox.Show("Done", "User successfully converted into admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "This user does not exists.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Warning", "Are you sure you want to put this user's picture in default?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                int a = Conexion.Existe(txtUsername1.Text);
                if (a == 1)
                {
                    Conexion.fotoPerfilDefault(txtUsername1.Text);
                    MessageBox.Show("Done", "User successfully converted into admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "This user does not exists.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnReview_Click(object sender, EventArgs e)
        {
            int a = Conexion.Existe(txtUsername1.Text);
            if (a == 1)
            {
                MessageBox.Show(Conexion.infoUsuario(txtUsername1.Text), "Information of this user", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error", "This user does not exists.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            usuariosConectados = Conexion.cantUsuarios();
            txtUsuarios.Text = usuariosConectados[0].ToString();
            txtUsuarios.Text = "Usuarios totales: " + usuariosConectados[0].ToString() + 
                "\nUsuarios conectados: " + usuariosConectados[1].ToString();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }

        private void btnDeleteLogic_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Warning", "Are you sure you want to disable this user?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                int a = Conexion.Existe(txtUsername1.Text);
                if (a == 1)
                {
                    Conexion.EliminarCuentaLogica(txtUsername1.Text, 0);
                    MessageBox.Show("Done", "User successfully disabled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This user does not exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            EditProfile edit = new EditProfile(txtUsername1.Text, true);
            edit.Show();
            base.Hide();
        }

        private void btnAbleUser_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Warning", "Are you sure you want to able this user?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                int a = Conexion.Existe(txtUsername1.Text);
                if (a == 1)
                {
                    Conexion.EliminarCuentaLogica(txtUsername1.Text, 1);
                    MessageBox.Show("Done", "User successfully abled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("This user does not exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}