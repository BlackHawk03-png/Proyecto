using Proyecto.logica;
using Proyecto.persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Proyecto.presentacion
{
    public partial class Main2 : Form
    {
        public Main2()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(Register_Closing);
            void Register_Closing(object sender, CancelEventArgs e)
            {
                Conexion.Conectado(Usuario.usuarioActual.Username, 0);
                Application.Exit();
            }
            List<string> usuarios = Conexion.devuelveUsernames();
            foreach (string user in usuarios)
            {
                int n = gridUsernames.Rows.Add();
                gridUsernames.Rows[n].Cells[0].Value = user;
            }
        }

        private void Main2_Load(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (Usuario.usuarioActual.Rol == "administrador" || Usuario.usuarioActual.Rol == "ambos")
            {
                PanelAdministrador a = new PanelAdministrador();
                a.Show();
                base.Hide();
            }
            else
            {
                MessageBox.Show("You do not have administrator permissions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            PruebaPersistencia p = new PruebaPersistencia(true, "");
            p.Show();
            base.Hide();
        }

        private void btnBlackjack_Click(object sender, EventArgs e)
        {
            Blackjack b = new Blackjack();
            b.Show();
            base.Hide();
        }

        private void btnTruco_Click(object sender, EventArgs e)
        {
            Truco t = new Truco(false, Usuario.usuarioActual.Username, "CPU)");
            t.Show();
            base.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("¿Estás seguro que quieres salir?" +
                "\nPerderás tu foto de perfil actual", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                Conexion.Conectado(Usuario.usuarioActual.Username, 0);
                Main f = new Main();
                f.Show();
                base.Hide();
            }
        }

        private void btnAgregarAmigos_Click(object sender, EventArgs e)
        {
            List<string> amigos = Conexion.devuelveAmigos(Usuario.usuarioActual.Username);
            bool existente = false;
            foreach (string a in amigos)
            {
                if (a == gridUsernames.CurrentCell.Value.ToString())
                {
                    MessageBox.Show("Usted ya tiene agregado a este amigo", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    existente = true;
                }
            }
            if (!existente)
            {
                Conexion.agregarAmigo(gridUsernames.CurrentCell.Value.ToString());
                MessageBox.Show("Amigo agregado correctamente", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnVisitarPerfil_Click(object sender, EventArgs e)
        {
            if(txtVistaUsuario.Text != "" && Conexion.Existe(txtVistaUsuario.Text) == 1)
            {
                PruebaPersistencia p = new PruebaPersistencia(false, txtVistaUsuario.Text);
                p.Show();
                base.Hide();
            }
            else if(txtVistaUsuario.Text == "")
            {
                MessageBox.Show("Debe ingresar un nombre de usuario", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(Conexion.Existe(txtVistaUsuario.Text) == 0)
            {
                MessageBox.Show("Este usuario no existe", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}