using Proyecto.presentacion;
using Proyecto.logica;
using System;
using System.Windows.Forms;
using Proyecto.persistencia;
using System.ComponentModel;

namespace Proyecto.presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(Register_Closing);
            void Register_Closing(object sender, CancelEventArgs e)
            {
                Application.Exit();
            }
            panel4.Hide();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Main f = new Main();
            f.Show();
            base.Hide();
        }
        private void btnPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (Conexion.login(txtUsername.Text) != "" && Conexion.login(txtUsername.Text)  == txtPassword.Text)
            {
                Main2 m = new Main2();
                m.Show();
                Conexion.Actual(txtUsername.Text);
                Conexion.Conectado(txtUsername.Text, 1);
                base.Hide();
            }
            else
            {
                MessageBox.Show("El nombre de usuario o contraseña es incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPassword_Click_1(object sender, EventArgs e)
        {
            UsuarioCambiarPass ucp = new UsuarioCambiarPass();
            ucp.Show();
            base.Hide();
        }
        private void btnImprime_Click(object sender, EventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //Conexion.insertarDatos();
            MessageBox.Show("Listo");
        }
    }
}