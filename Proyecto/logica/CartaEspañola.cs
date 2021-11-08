using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    class CartaEspañola
    {
        //Atributos
        private int numero;
        private string palo;
        private int valor;
        private int puntos;
        private bool fueJugada;
        private bool fueEnvido;
        private string rutaImg;

        public CartaEspañola(int n, string p) //Constructor especifico para 2 atributos
        {
            numero = n;
            palo = p;
            rutaImg = n + p; //Nombre del archivo en Cloudinary
            fueJugada = false;
            fueEnvido = false;
        }

        //Getters y Setters de los atributos
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string Palo
        {
            get { return palo; }
            set { palo = value; }
        }
        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        public int Puntos
        {
            get { return puntos; }
            set { puntos = value; }
        }
        public string RutaImg
        {
            get { return rutaImg; }
            set { rutaImg = value; }
        }
        public bool FueJugada
        {
            get { return fueJugada; }
            set { fueJugada = value; }
        }
        public bool FueEnvido
        {
            get { return fueEnvido; }
            set { fueEnvido = value; }
        }
    }
}