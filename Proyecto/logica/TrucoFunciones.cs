using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.logica
{
    class TrucoFunciones
    {
        public TrucoFunciones()
        {

        }
        public int valorEnvido(CartaEspañola[] c, CartaEspañola muestra) //Devuelve el valor de envido
        {
            int[] valores = { 0, 0, 0 };
            int valorTotal = 0;
            /*for (int i = 0; i < 3; i++)
            {
                valores[i] = c[i].Numero;
                if (c[i].Palo == muestra.Palo)
                {
                    switch (c[i].Numero)
                    {
                        case 2:
                            valores[i] = 30;
                            break;
                        case 4:
                            valores[i] = 29;
                            break;
                        case 5:
                            valores[i] = 28;
                            break;
                        case 11:
                            valores[i] = 27;
                            break;
                        case 10:
                            valores[i] = 27;
                            break;
                    }
                }
                if (c[i].Palo != muestra.Palo && c[i].Numero > 9 && c[i].Numero < 13)
                {
                    valores[i] = 0;
                }
            }*/
            if(esPieza(c[0], muestra) || esPieza(c[1], muestra) || esPieza(c[2], muestra))
            {
                if (esPieza(c[0], muestra))
                {
                    if (c[1].Puntos > c[2].Puntos) { valorTotal = c[0].Puntos + c[1].Puntos; }
                    if (c[1].Puntos < c[2].Puntos) { valorTotal = c[0].Puntos + c[2].Puntos; }
                }
                else if (esPieza(c[1], muestra))
                {
                    if (c[0].Puntos > c[2].Puntos) { valorTotal = c[1].Puntos + c[0].Puntos; }
                    if (c[0].Puntos < c[2].Puntos) { valorTotal = c[1].Puntos + c[2].Puntos; }
                }
                else if (esPieza(c[2], muestra))
                {
                    if (c[0].Puntos > c[1].Puntos) { valorTotal = c[2].Puntos + c[0].Puntos; }
                    if (c[0].Puntos < c[1].Puntos) { valorTotal = c[2].Puntos + c[1].Puntos; }
                }
            }
            else
            {
                valorTotal = valores[0] + valores[1] + valores[2];
                if (c[0].Palo == c[1].Palo)
                {
                    valorTotal = valores[0] + valores[1] + 20;
                }
                else if (c[0].Palo == c[2].Palo)
                {
                    valorTotal = valores[0] + valores[2] + 20;
                }
                else if (c[1].Palo == c[2].Palo)
                {
                    valorTotal = valores[1] + valores[2] + 20;
                }
            }
            
            return valorTotal;
        }
        public void valorCarta(CartaEspañola c, CartaEspañola muestra) //Devuelve el valor de la mano
        {
            if (esPieza(c, muestra))
            {
                switch (c.Numero)
                {
                    case 2:
                        c.Valor = 19;
                        c.Puntos = 30;
                        break;
                    case 4:
                        c.Valor = 18;
                        c.Puntos = 29;
                        break;
                    case 5:
                        c.Valor = 17;
                        c.Puntos = 28;
                        break;
                    case 11:
                        c.Valor = 16;
                        c.Puntos = 27;
                        break;
                    case 10:
                        c.Valor = 15;
                        c.Puntos = 27;
                        break;
                }
            }
            else if (esMata(c))
            {
                switch (c.Palo)
                {
                    case "Espada":
                        if (c.Numero == 1) { c.Valor = 14; c.Puntos = 1; }
                        if (c.Numero == 7) { c.Valor = 12; c.Puntos = 7; }
                        break;
                    case "Basto":
                        if (c.Numero == 1) { c.Valor = 13; c.Puntos = 1; }
                        break;
                    case "Oro":
                        if (c.Numero == 7) { c.Valor = 11; c.Puntos = 7; }
                        break;
                }
            }
            else
            {
                if (c.Numero == 3) { c.Valor = 10; c.Puntos = 3; }
                else if (c.Numero == 2) { c.Valor = 9; c.Puntos = 2; }
                else if (c.Numero == 1) { c.Valor = 8; c.Puntos = 1; }
                else if (c.Numero == 12) { c.Valor = 7; c.Puntos = 0; }
                else if (c.Numero == 11) { c.Valor = 6; c.Puntos = 0; }
                else if (c.Numero == 10) { c.Valor = 5; c.Puntos = 0; }
                else if (c.Numero == 7) { c.Valor = 4; c.Puntos = 7; }
                else if (c.Numero == 6) { c.Valor = 3; c.Puntos = 6; }
                else if (c.Numero == 5) { c.Valor = 2; c.Puntos = 5; }
                else if (c.Numero == 4) { c.Valor = 1; c.Puntos = 4; }
            }
        }
        public bool esMata(CartaEspañola c)
        {
            bool devuelve = false;
            switch (c.Palo)
            {
                case "Espada":
                    if (c.Numero == 1) { devuelve = true; }
                    else if (c.Numero == 7) { devuelve = true; }
                    break;
                case "Basto":
                    if (c.Numero == 1) { devuelve = true; }
                    break;
                case "Oro":
                    if (c.Numero == 7) { devuelve = true; }
                    break;
            }
            return devuelve;
        }
        public bool esPieza(CartaEspañola c, CartaEspañola muestra)
        {
            bool devuelve = false;
            if (c.Palo == muestra.Palo && (c.Numero == 2 || c.Numero == 4 || c.Numero == 5 || c.Numero == 10 || c.Numero == 11))
            { 
                devuelve = true;
            }
            else if(c.Numero == 12 && c.Palo == muestra.Palo)
            {
                if(muestra.Numero == 2 || muestra.Numero == 4 || muestra.Numero == 5 || muestra.Numero == 10 || muestra.Numero == 11)
                {
                    devuelve = true;
                }
            }
            return devuelve;
        }
        public int cartaGanadora(CartaEspañola c1, CartaEspañola c2, CartaEspañola muestra)
        {
            int ganador = 0; //Emparda
            
            if(c1.Valor > c2.Valor)
            {
                ganador = 1;
            }
            else if(c1.Valor < c2.Valor)
            {
                ganador = 2;
            }
            return ganador;
        }
        public bool verificaFlor(CartaEspañola[] c, CartaEspañola muestra) //Devuelve un valor verdadero en caso de tener Flor
        {
            bool verifica = false;
            if (c[0].Palo == c[1].Palo && c[1].Palo == c[2].Palo)
            {
                verifica = true;
            }
            else if ((esPieza(c[0], muestra) && esPieza(c[1], muestra)) || (esPieza(c[1], muestra) && esPieza(c[2], muestra)) || (esPieza(c[0], muestra) && esPieza(c[2], muestra)))
            {
                verifica = true;
            }
            else if ((esPieza(c[0], muestra) && c[1].Palo == c[2].Palo) || (esPieza(c[1], muestra) && c[0].Palo == c[2].Palo) || (esPieza(c[2], muestra) && c[1].Palo == c[0].Palo))
            {

            }
            return verifica;
        }
        public CartaEspañola[] repartirCartas()
        {
            Random azar = new Random();
            CartaEspañola c = new CartaEspañola(0, "");
            CartaEspañola[] cartas = { c, c, c, c, c, c, c};
            int num = 0;
            string palo = "";
            string[] palos = { "Pica", "Corazones", "Diamantes", "Treboles" };
            for (int x = 0; x < cartas.Length; x++)
            {
                num = azar.Next(12);
                palo = palos[azar.Next(3)];

            }
            return cartas;
        }
    }
}