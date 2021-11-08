using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.logica
{
    class CartaInglesa
    {
        public CartaInglesa(string n, string p, int v, string r) //Constructor especifico para todos los atributos
        {
            numero = n;
            palo = p;
            rutaImg = r;
            valorCarta = v;
        }

        //Atributos
        private string numero;
        private string palo;
        private string rutaImg;
        private int valorCarta;
        

        //Getters y Setters de los atributos
        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        public string Palo
        {
            get { return palo; }
            set { palo = value; }
        }
        public string RutaImg
        {
            get { return rutaImg; }
            set { rutaImg = value; }
        }
        public int ValorCarta
        {
            get { return valorCarta; }
            set { valorCarta = value; }
        }
    }
}
