using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.logica;
using MySql.Data.MySqlClient;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Collections;

namespace Proyecto.persistencia
{
    class Conexion
    {
       public Conexion()
       {
            cloudinary.Api.Secure = true;
       }
        private static string connectionString = "Datasource=127.0.0.1;port=3306;username=root;password=;database=proyecto;SSL Mode=None";
        private static MySqlConnection databaseConnection = new MySqlConnection(connectionString);

        private static Account account = new Account("cloud-tech00", "181871794848263", "E-CFF2yrPqOuUDhcPxVHrd2oe9I");
        private static Cloudinary cloudinary = new Cloudinary(account);
        
        public static MySqlConnection ObtenerConexion()
        {
            try
            {
                databaseConnection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
            return databaseConnection;
        }
        public static MySqlConnection CerrarConexion()
        {
            try
            {
                databaseConnection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            return databaseConnection;
        }

        public static void insertarUsuario(string username, string password, string nombre, string apellido, string sexo, string mail, string fechaNac)
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "INSERT INTO usuario " +
                    "(username, passwd, nombre, apellido, sexo, mail, fecha_nac, fecha_ingreso, suscrito, administrador, foto_perfil) " +
                    "VALUES (" +
                    "'" + username +
                    "', '" + password +
                    "', '" + nombre +
                    "', '" + apellido +
                    "', '" + sexo +
                    "', '" + mail +
                    "', '" + fechaNac +
                    "', CURDATE(), FALSE, FALSE, 'default');";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static Usuario recibeDatos(string username)
        {
            Usuario devuelve = new Usuario("","","", "", "","","","",false,false,"");
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT * FROM usuario WHERE username = '{0}';", username), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    devuelve.Username = _reader.GetString(0);
                    devuelve.Password = _reader.GetString(1);
                    devuelve.Nombre = _reader.GetString(2);
                    devuelve.Apellido = _reader.GetString(3);
                    devuelve.Sexo = _reader.GetString(4);
                    devuelve.Mail = _reader.GetString(5);
                    devuelve.FechaNac = _reader.GetString(6);
                    devuelve.FechaIngreso = _reader.GetString(7);
                    devuelve.Suscrito = _reader.GetBoolean(8);
                    devuelve.Administrador = _reader.GetBoolean(9);
                    devuelve.FotoPerfil = _reader.GetString(10);
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
            return devuelve;
        }
        public static string login(string username)
        {
            string devuelve = "";
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT passwd FROM usuario WHERE username = '{0}';", username), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    devuelve = _reader.GetString(0);
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
            return devuelve;
        }
        public static void Actual(string username)
        {
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT * FROM usuario WHERE username = '{0}';", username), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    Usuario.usuarioActual.Username = _reader.GetString(0);
                    Usuario.usuarioActual.Password = _reader.GetString(1);
                    Usuario.usuarioActual.Nombre = _reader.GetString(2);
                    Usuario.usuarioActual.Apellido = _reader.GetString(3);
                    Usuario.usuarioActual.Sexo = _reader.GetString(4);
                    Usuario.usuarioActual.Mail = _reader.GetString(5);
                    Usuario.usuarioActual.FechaNac = _reader.GetString(6);
                    Usuario.usuarioActual.FechaIngreso = _reader.GetString(7);
                    Usuario.usuarioActual.Suscrito = _reader.GetBoolean(8);
                    Usuario.usuarioActual.Administrador = _reader.GetBoolean(9);
                    Usuario.usuarioActual.FotoPerfil = "";
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int Existe(string username)
        {
            int devuelve = 0;
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT COUNT(username) FROM usuario WHERE username = '{0}';", username), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    devuelve = _reader.GetInt32(0);
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
            return devuelve;
        }
        public static void EliminarCuenta(string username)
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "DELETE FROM usuario WHERE username = '" + username + "';";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void hacerAdmin(string username)
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "UPDATE usuario SET administrador = TRUE WHERE username = '" + username + "';";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void fotoPerfilDefault(string username)
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "UPDATE usuario SET foto_perfil = 'default' WHERE username = '" + username + "';";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static string infoUsuario(string username)
        {
            string devuelve = "";
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT * FROM usuario WHERE username = '{0}';", username), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    devuelve = "Username: " + _reader.GetString(0) +
                        "\nPassword: " + _reader.GetString(1) +
                        "\nNombre: " + _reader.GetString(2) +
                        "\nSexo: " + _reader.GetString(3) +
                        "\nMail: " + _reader.GetString(4) +
                        "\nFecha de nacimiento: " + _reader.GetString(5) +
                        "\nFecha de ingreso: " + _reader.GetString(6) +
                        "\nSuscrito: " + _reader.GetString(7) +
                        "\nAdministrador: " + _reader.GetString(8);
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
            return devuelve;
        }
        public static int[] cantUsuarios()
        {
            int[] devuelve = { 0, 0 };
            int usuariosTotales = 0;
            int usuariosConectados = 0;
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
                  "SELECT COUNT(username) FROM usuario;"), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    usuariosTotales = _reader.GetInt32(0);
                }
                CerrarConexion();
                _comando = new MySqlCommand(String.Format(
                      "SELECT COUNT(username) FROM conectado WHERE conectado = TRUE;"), ObtenerConexion());
                _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    usuariosConectados = _reader.GetInt32(0);
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
            devuelve[0] = usuariosTotales;
            devuelve[1] = usuariosConectados;
            return devuelve;
        }
        public static void EliminarCuentaLogica(string username, int estado)
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "UPDATE usuario SET activo = " + estado +" WHERE username = '" + username + "';";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void CrearPartidaBlackjack(int apuesta)
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "INSERT INTO blackjack " +
                    "(fecha, jugador, apuesta) VALUES (CURDATE(), '" +
                    Usuario.usuarioActual.Username + "', " + apuesta + ");";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void CrearPartidaTruco(string jugador1, string jugador2, bool tipo) //Sin terminar, falta actualizar
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "INSERT INTO truco " +
                    "(tipo, jugador1, jugador2, fecha, puntos_j1, puntos_j2, ganador) VALUES (" +
                    "'" + tipo + "', " +
                    "'" + jugador1 + "', " +
                    "'" + jugador2 + "', " + 
                    "CURDATE()," + 
                    "0, 0, ''"
                    + ");";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int RecibirIdPartida(bool j) //true -> truco ; false -> blackjack
        {
            int devuelve = 0;
            string juego = "";
            if (j)
            {
                juego = "partida_truco";
            }
            else
            {
                juego = "blackjack";
            }
            try
            { 
                MySqlCommand _comando = new MySqlCommand(String.Format(
                  "SELECT MAX(id_partida) FROM " + juego +
                  " WHERE jugador = '" + Usuario.usuarioActual.Username + "';"), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    devuelve = _reader.GetInt32(0);
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
            return devuelve;
        }
        public static int RecibirIdPartidaTruco()
        {
            int devuelve = 0;
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
                  "SELECT MAX(id_partida) FROM truco;"), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    devuelve = _reader.GetInt32(0);
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
            return devuelve;
        }
        public static void InsertarMano(int contMano, int nroMano, string ganador, bool cantoJ1, bool cantoJ2, bool envido, int puntosJ1, int puntosJ2, string jugador, string jugadorMano, int cartaJ1Numero, string cartaJ1Palo, int cartaJ2Numero, string cartaJ2Palo)
        {

        }
        public static void CompletarPartidaBlackjack(bool blackjack, int ganancia)
        {
            int id_partida = RecibirIdPartida(false);
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "UPDATE blackjack " +
                    "SET blackjack = " + blackjack +
                    ", ganancia = " + ganancia + " WHERE jugador = '" + Usuario.usuarioActual.Username + "' " +
                    "AND id_partida = " + id_partida + ";";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static string RecibirMail(string username)
        {
            string devuelve = "";
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT mail FROM usuario WHERE username = '{0}';", username), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    devuelve = _reader.GetString(0);
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
            return devuelve;
        }
        public static void NuevaContraseña(string username, string pass)
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "UPDATE usuario " +
                    "SET passwd = '" + pass + "' WHERE username = '" + username + "';";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void Conectado(string username, int conectado)
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "UPDATE conectado " +
                    "SET conectado = '" + conectado + "' WHERE username = '" + username + "';";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void ActualizarUsuario(string username, string password, string nombre, string mail, string sexo)
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "UPDATE usuario " +
                    "SET passwd = '" + password +
                    "', nombre = '" + nombre +
                    "', mail = '" + mail +
                    "', sexo = '" + sexo +
                    "' WHERE username = '" + username + "';";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<string> devuelveUsernames()
        {
            List<string> usuarios = new List<string>();
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT username FROM usuario WHERE username != 'CPU';"), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    usuarios.Add(_reader.GetString(0));
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
            return usuarios;
        }
        public static List<string> devuelveAmigos(string username)
        {
            List<string> amigos = new List<string>();

            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT amigo FROM amigos " +
              "WHERE username = '" + username + "';"), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    amigos.Add(_reader.GetString(0));
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
            return amigos;
        }
        public static void NuevaImagen()
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(Usuario.usuarioActual.FotoPerfil)
            };
            var uploadResult = cloudinary.Upload(uploadParams);
        }
        public static void DevuelveImagen()
        {
            
        }
        public static void agregarAmigo(string username)
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "INSERT INTO amigos " +
                    "(username, amigo) VALUES ('" + Usuario.usuarioActual.Username + "', " +
                    "'" + username + "');";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static int[] estadisticasUsuario(string username) //Sin terminar, faltan consultas
        {
            int[] estadisticas = { 0, 0, 0, 0 }; // [0] = jugadasBlackjack / [1] = ganadasBlackjack / [2] = jugadasTruco / [3] = ganadasTruco
            //Consultas SQL para recibir partidas jugadas y ganadas de ambos juegos para un jugador
            return estadisticas;
        }
        public static string nombreMedalla(int idMedalla) //Sin terminar, faltan consultas
        {
            string nombreMedalla = "";
            //Consulta SQL para recibir el nombre de una medalla segun un id
            return nombreMedalla;
        }
        public static ArrayList actualizarMedallas(string username) //Sin terminar
        {
            ArrayList medallasGanadas = new ArrayList();
            int[] estadisticas = estadisticasUsuario(username);

            if(estadisticas[0] == 1)
            {
                medallasGanadas.Add(nombreMedalla(1));
            }
            if (estadisticas[0] == 5)
            {
                medallasGanadas.Add(nombreMedalla(2));
            }
            return medallasGanadas;
        }
        public static int[] recibeMedallasProfile(string username)
        {
            //int[] medallas = { 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };
            int[] medallas = new int[20];
            int c = 0;
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT cantidad FROM gano " +
              "WHERE username = '" + username + "' " +
              "ORDER BY(id_medalla);"), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    medallas[c] = _reader.GetInt32(0);
                    c++;
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }


            return medallas;
        }

    }
}