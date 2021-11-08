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
    public partial class Register : Form
    {
        public Register()
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
                    fecha = btnFechaNac.Value.ToString("yyyy-MM-dd"); //Year.SelectedItem.ToString() + "-" + Month.SelectedItem.ToString() + "-" + Day.SelectedItem.ToString();
                    if (checkBoxMale.Checked)
                    {
                        sexo = "M";
                    }
                    if (checkBoxFemale.Checked)
                    {
                        sexo = "F";
                    }

                    /*if (checkBoxFemale.Checked)
                        sexo = "F";
                    else sexo = "M";*/

                    if (Usuario.mailValido(txtMail.Text))
                    {
                        Conexion.insertarUsuario(txtUsername.Text, txtPassword.Text, txtNombre.Text, txtApellido.Text, sexo, txtMail.Text, fecha);
                        MessageBox.Show("User correctly created", "Great!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("The mail is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You have to choose your sex", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The username or the mail you entered is already in use" +
                    "\nTry to put other username or mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}