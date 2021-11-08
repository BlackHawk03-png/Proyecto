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
        public Usuario(string u, string p, string n, string a, string s, string m, string f, string f1, bool s1, bool a1, string f2) //Constructor por defecto con todos los valores
        {
            username = u;
            password = p;
            nombre = n;
            apellido = a;
            sexo = s;
            mail = m;
            fechaNac = f;
            fechaIngreso = f1;
            suscrito = s1;
            administrador = a1;
            fotoPerfil = f2;
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
        private bool suscrito;
        private bool administrador;
        private string fotoPerfil;
        public static Usuario usuarioActual = new Usuario("", "", "", "", "", "", "", "", false, false, "");
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
        public bool Suscrito
        {
            get { return suscrito; }
            set { suscrito = value; }
        }
        public bool Administrador
        {
            get { return administrador; }
            set { administrador = value; }
        }
        public string FotoPerfil
        {
            get { return fotoPerfil; }
            set { fotoPerfil = value; }
        }
        public Usuario UsuarioActual
        {
            get { return usuarioActual; }
            set { usuarioActual = value; }
        }

        public void insertarUsuario(Usuario u)
        {
            usuarios.Add(u);
        }
        public void removerUsuario(Usuario user)
        {
            foreach (Usuario u in usuarios)
            {
                if (user.username == u.username)
                {
                    usuarios.Remove(u);
                }
            }
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