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

namespace Proyecto.presentacion
{
    public partial class EditProfile : Form
    {
        public EditProfile(string u, bool a)
        {
            InitializeComponent();
            admin = a;
            username = u;
            usuario = Conexion.recibeDatos(username);
            this.Closing += new CancelEventHandler(Register_Closing);
            void Register_Closing(object sender, CancelEventArgs e)
            {
                Conexion.Conectado(Usuario.usuarioActual.Username, 0);
                Application.Exit();
            }
            if (admin)
            {
                txtPassword.Text = usuario.Password;
                txtNombre.Text = usuario.Nombre;
                txtMail.Text = usuario.Mail;
                if (usuario.Sexo == "F") { checkBoxFemale.Checked = true; }
                else { checkBoxMale.Checked = true; }
            }
            else
            {
                txtPassword.Text = Usuario.usuarioActual.Password;
                txtNombre.Text = Usuario.usuarioActual.Nombre;
                txtMail.Text = Usuario.usuarioActual.Mail;
                if (Usuario.usuarioActual.Sexo == "F") { checkBoxFemale.Checked = true; }
                else { checkBoxMale.Checked = true; }
            }
            
        }
        bool admin;
        string username;
        Usuario usuario;
        private void EditProfile_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (admin)
            {
                AdminPanel a = new AdminPanel(); 
                a.Show(); 
                base.Hide();
            }
            if (!admin)
            {
                PruebaPersistencia p = new PruebaPersistencia(true, "");
                p.Show();
                base.Hide();
            }
        }
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            string password = "";
            string nombre = "";
            string mail = "";
            string sexo = "";

            password = txtPassword.Text;
            nombre = txtNombre.Text;
            mail = txtMail.Text;
            if (checkBoxFemale.Checked) { sexo = "F"; }
            if (checkBoxMale.Checked) { sexo = "M"; }

            if (Usuario.mailValido(txtMail.Text))
            {
                if (!admin)
                {
                    if (txtPassword.Text == "") { password = Usuario.usuarioActual.Password; }
                    if (txtNombre.Text == "") { nombre = Usuario.usuarioActual.Nombre; }
                    if (txtMail.Text == "") { mail = Usuario.usuarioActual.Mail; }
                    if (!checkBoxFemale.Checked && !checkBoxMale.Checked) { sexo = Usuario.usuarioActual.Sexo; }
                    Conexion.ActualizarUsuario(Usuario.usuarioActual.Username, password, nombre, mail, sexo);
                }
                if (admin)
                {
                    if (txtPassword.Text == "") { password = usuario.Password; }
                    if (txtNombre.Text == "") { nombre = usuario.Nombre; }
                    if (txtMail.Text == "") { mail = usuario.Mail; }
                    if (!checkBoxFemale.Checked && !checkBoxMale.Checked) { sexo = usuario.Sexo; }
                    Conexion.ActualizarUsuario(username, password, nombre, mail, sexo);
                    Conexion.Actual(username);
                }
                MessageBox.Show("Usuario correctamente editado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("El mail que ingresó es inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void checkBoxMale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMale.Checked)
            {
                checkBoxFemale.Checked = false;
                return;
            }
            checkBoxMale.Checked = !checkBoxFemale.Checked;
        }

        private void checkBoxFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFemale.Checked)
            {
                checkBoxMale.Checked = false;
                return;
            }
            checkBoxFemale.Checked = !checkBoxMale.Checked;
        }
    }
}