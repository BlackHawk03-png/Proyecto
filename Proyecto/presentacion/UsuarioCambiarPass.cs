using Proyecto.persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.presentacion
{
    public partial class UsuarioCambiarPass : Form
    {
        public UsuarioCambiarPass()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(Register_Closing);
            void Register_Closing(object sender, CancelEventArgs e)
            {
                Application.Exit();
            }
            label2.Hide();
            btnVerificarCodigo.Hide();
            label3.Hide();
            btnNuevaContraseña.Hide();
        }
        Random azar = new Random();
        int codigoVerificacion;
        string usuarioVerificando = "";
        private void UsuarioCambiarPass_Load(object sender, EventArgs e)
        {

        }

        private void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            string mail = Conexion.RecibirMail(txtUsername.Text);
            usuarioVerificando = txtUsername.Text;
            codigoVerificacion = azar.Next(9999);
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("cloudtech.soporte@gmail.com", "Cloud Tech", System.Text.Encoding.UTF8);//Correo de salida
            correo.To.Add(mail); //Correo destino?
            correo.Subject = "Password Reset"; //Asunto
            correo.Body = "Verification code: " + codigoVerificacion + "."; //Mensaje del correo
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com"; //Host del servidor de correo
            smtp.Port = 25; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential("cloudtech.soporte@gmail.com", "cablectpcat7");//Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;//True si el servidor de correo permite ssl
            
            try
            {
                smtp.Send(correo);
                MessageBox.Show("Mail enviado", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo enviar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            label2.Show();
            btnVerificarCodigo.Show();
        }

        private void btnVerificarCodigo_Click(object sender, EventArgs e)
        {
            if(int.Parse(txtCodigo.Text) == codigoVerificacion)
            {
                label3.Show();
                btnNuevaContraseña.Show();
            }
            else
            {
                MessageBox.Show("Codigo incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevaContraseña_Click(object sender, EventArgs e)
        {
            Conexion.NuevaContraseña(usuarioVerificando, txtNuevaContraseña.Text);
            MessageBox.Show("Contraseña cambiada", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            base.Hide();
        }
    }
}