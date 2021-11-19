using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.logica
{
    public class Usuario
    {
        public Usuario(string u, string p, string n, string a, string s, string m, string f, string f1, bool s1, bool a1, string f2, string r, int p1) //Constructor por defecto con todos los valores
        {
            username = u;
            password = p;
            nombre = n;
            apellido = a;
            sexo = s;
            mail = m;
            fechaNac = f;
            fechaIngreso = f1;
            fotoPerfil = f2;
            rol = r;
            presuesto = p1;
            consecutivasBlackjack = 0;
            consecutivasTruco = 0;
        }
        //Atributos
        private string username;
        private string password;
        private string nombre;
        private string apellido;
        private string sexo;
        private string mail;
        private string fechaNac;
        private string fechaIngreso;
        private string fotoPerfil;
        private string rol;
        private int presuesto;
        private int consecutivasBlackjack;
        private int consecutivasTruco;
        public static Usuario usuarioActual = new Usuario("", "", "", "", "", "", "", "", false, false, "", "", 0);
        public static ArrayList usuarios = new ArrayList();
        
        //Getters y Setters de los atributos
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        public string FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }
        public string FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }
        public string FotoPerfil
        {
            get { return fotoPerfil; }
            set { fotoPerfil = value; }
        }
        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }
        public int Presupuesto
        {
            get { return presuesto; }
            set { presuesto = value; }
        }
        public int ConsecutivasBlackjack
        {
            get { return consecutivasBlackjack; }
            set { consecutivasBlackjack = value; }
        }
        public int ConsecutivasTruco
        {
            get { return consecutivasTruco; }
            set { consecutivasTruco = value; }
        }
        public Usuario UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }
        public bool valida(string txtUsername, string txtPassword)
        {
            bool verifica = false;
            foreach (Usuario u in usuarios)
            {
                if (u.username == txtUsername)
                {
                    if (u.password == txtPassword)
                    {
                        verifica = true;
                        usuarioActual = u;
                    }
                }
            }
            return verifica;
        }
        public bool existeUsuario(string txtUsername, string txtMail)
        {
            bool existe = false;
            foreach(Usuario u in usuarios)
            {
                if (u.username == txtUsername || u.mail == txtMail)
                {
                    existe = true;
                }
            }
            
            return existe;
        }
        public static bool mailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}