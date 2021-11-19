﻿using System;
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
        
        public static MySqlConnection ObtenerConexion() //Abre la conexion con la base de datos
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
        public static MySqlConnection CerrarConexion() //Cierra la conexion con la base de datos
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

        public static void insertarUsuario(string username, string password, string nombre, string apellido, string sexo, string mail, string fechaNac) //Inserta un usuario en la base de datos
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "INSERT INTO usuario " +
                    "(username, passwd, nombre, apellido, sexo, mail, fecha_nac, fecha_registro, " +
                    "foto_perfil, conectado, activo, rol, presupuesto) " +
                    "VALUES (" +
                    "'" + username +
                    "', '" + password +
                    "', '" + nombre +
                    "', '" + apellido +
                    "', '" + sexo +
                    "', '" + mail +
                    "', '" + fechaNac +
                    "', CURDATE(), 'default', 0, 1, 'sin rol', 1000);";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static Usuario recibeDatos(string username) //Devuelve toda la informacion de un usuario especifico
        {
            Usuario devuelve = new Usuario("", "", "", "", "", "", "", "", false, false, "", "", 0);
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
                    devuelve.FotoPerfil = _reader.GetString(10);
                    devuelve.Rol = _reader.GetString(11);
                    devuelve.Presupuesto = _reader.GetInt32(12);
                }
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
            return devuelve;
        }
        public static string login(string username) //Recibe la informacion necesaria para el logueo de un usuario
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
        public static void Actual(string username) //Guarda los datos del usuario logueado en un usuario estatico
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
                    Usuario.usuarioActual.FotoPerfil = "";
                    Usuario.usuarioActual.Rol = _reader.GetString(11);
                    Usuario.usuarioActual.Presupuesto = _reader.GetInt32(12);
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
            Usuario u = Conexion.recibeDatos(username);
            string rol = "administrador";
            if(u.Rol == "suscrito")
            {
                rol = "ambos";
            }
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "UPDATE usuario SET " + rol + "=  WHERE username = '" + username + "';";
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
                      "SELECT COUNT(username) FROM usuario WHERE conectado = TRUE;"), ObtenerConexion());
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
                    "(fecha, username, apuesta) VALUES (CURDATE(), '" +
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
                myCommand.CommandText = "INSERT INTO juega_truco " +
                    "(jugador1, jugador2) VALUES (" +
                    "'" + jugador1 + "', " +
                    "'" + jugador2 + "');";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void CompletarPartidaTruco(string ganador)
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "UPDATE partida_truco SET " +
                    "ganador = '" + ganador + "' WHERE id_partida = " + RecibirIdPartida(true) + "; ";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void insertarRonda(int contRonda, int id_partida, string ganador, bool cantoJ1, bool cantoJ2, bool tocaron, int puntosJ1, int puntosJ2, string jugador, string jugadorMano, int cartaJ1N1Numero, string cartaJ1N1Palo, int cartaJ2N1Numero, string cartaJ2N1Palo, int cartaJ1N2Numero, string cartaJ1N2Palo, int cartaJ2N2Numero, string cartaJ2N2Palo, int cartaJ1N3Numero, string cartaJ1N3Palo, int cartaJ2N3Numero, string cartaJ2N3Palo, int muestraNumero, string muestraPalo)
        {
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "INSERT INTO ronda_truco(cont_ronda, id_partida, ganador, canto_j1, canto_j2, tocaron, puntos_j1, puntos_j2, jugador, jugador_mano, carta_j1_1numero, carta_j1_1palo, carta_j1_2numero, carta_j1_2palo, carta_j1_3numero, carta_j1_3palo, carta_j2_1numero, carta_j2_1palo, carta_j2_2numero, carta_j2_2palo, carta_j2_3numero, carta_j2_3palo, carta_muestra_numero,  carta_muestra_palo) VALUES " +
                    "("+ contRonda + ", " + id_partida + ", '" + ganador + "', " + cantoJ1 + ", " + cantoJ2 + ", " + tocaron + ", " + puntosJ1 + ", " + puntosJ2 + ", '" + jugador + "', '" + jugadorMano + "', " + cartaJ1N1Numero + ", '" + cartaJ1N1Palo +"', " + cartaJ2N1Numero + ", '" + cartaJ2N1Palo + "', " + cartaJ1N2Numero + ", '" + cartaJ1N2Palo + "', " + cartaJ2N2Numero + ", '" + cartaJ2N2Palo + "', " + cartaJ1N3Numero + ", '" + cartaJ1N3Palo + "', " + cartaJ2N3Numero + ", '" + cartaJ2N3Palo + "', " +muestraNumero + ", '" + muestraPalo + "',); ";
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
                  "SELECT MAX(id_partida) FROM partida_truco;"), ObtenerConexion());
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
        public static void InsertarRonda(int contMano, int nroMano, string ganador, bool cantoJ1, bool cantoJ2, bool envido, int puntosJ1, int puntosJ2, string jugador, string jugadorMano, int cartaJ1Numero, string cartaJ1Palo, int cartaJ2Numero, string cartaJ2Palo)
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
                myCommand.CommandText = "UPDATE usuario " +
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
              "SELECT amigo FROM amistad " +
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
        public static int[] recibeMedallasProfile(string username)
        {
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
        public static List<string>[] estadistica1Username()
        {
            List<string>[] estadisticas = new List<string>[2];
            List<string> a = new List<string>();
            try
            {
                MySqlCommand _comando = new MySqlCommand(String.Format(
              "SELECT ganador, COUNT(id_partida) AS cantidad " +
              "FROM partida_truco " +
              "WHERE ganador != 'CPU' " +
              "GROUP BY(ganador) " +
              "ORDER BY(cantidad)DESC " +
              "LIMIT 10; "), ObtenerConexion());
                MySqlDataReader _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    a.Add(_reader.GetString(0));
                }
                CerrarConexion();
                estadisticas[0] = a;
                a.Clear();
                ObtenerConexion();
                _reader = _comando.ExecuteReader();
                while (_reader.Read())
                {
                    a.Add(_reader.GetString(1));
                }
                CerrarConexion();
                estadisticas[1] = a;
            }
            catch (Exception e)
            {
                throw e;
            }
            return estadisticas;
        } 
        public static void darMedalla(int id_medalla)
        {
            int[] a = Conexion.recibeMedallasProfile(Usuario.usuarioActual.Username);
            try
            {
                ObtenerConexion();
                MySqlCommand myCommand = databaseConnection.CreateCommand();
                myCommand.CommandText = "UPDATE usuario " +
                    "SET cantidad = " + (a[id_medalla-1] + 1) +
                    "WHERE username = '" + Usuario.usuarioActual.Username + "' AND id_medalla = " + id_medalla + ";";
                myCommand.ExecuteNonQuery();
                CerrarConexion();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}