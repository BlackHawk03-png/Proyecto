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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(Register_Closing);
            void Register_Closing(object sender, CancelEventArgs e)
            {
                Application.Exit();
            }
            btnFechaNac.MaxDate = DateTime.Now.AddYears(-18);
            btnFechaNac.MinDate = DateTime.Now.AddYears(-100);
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (Conexion.Existe(txtUsername.Text) == 0)
            {
                if (checkBoxMale.Checked || checkBoxFemale.Checked)
                {
                    string sexo = "";
                    string fecha = "";
                    fecha = btnFechaNac.Value.ToString("yyyy-MM-dd");

                    if (checkBoxFemale.Checked)
                        sexo = "F";
                    else sexo = "M";

                    if (txtUsername.Text.Equals("") == false && txtPassword.Text.Equals("") == false && txtNombre.Text.Equals("") == false && txtApellido.Text.Equals("") == false)
                    {
                        if (Usuario.mailValido(txtMail.Text))
                        {
                            Conexion.insertarUsuario(txtUsername.Text, txtPassword.Text, txtNombre.Text, txtApellido.Text, sexo, txtMail.Text, fecha);
                            MessageBox.Show("Usuario correctamente creado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            txtNombre.Text = "";
                            txtApellido.Text = "";
                            txtMail.Text = "";
                            checkBoxFemale.Checked = false;
                            checkBoxMale.Checked = false;
                        }
                        else
                        {
                            MessageBox.Show("El mail que ingresó es inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hay campos sin rellenar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tienes que elegir tu sexo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El nombre de usuario y/o el mail que ingresaste ya están en uso" +
                    "\nPrueba poner otro nombre de usuario u otro mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Main f = new Main();
            f.Show();
            base.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void checkTerms_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkPoP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}