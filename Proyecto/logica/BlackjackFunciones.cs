using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.presentacion;

namespace Proyecto.logica
{
    class BlackjackFunciones
    {
        //Blackjack b = new Blackjack();
        public BlackjackFunciones()
        {

        }
        public bool blackJack(CartaInglesa c1, CartaInglesa c2) //Verifica si las cartas forman blackjack
        {
            bool devuelve = false;

            if(c1.Numero == "A" && c2.ValorCarta == 10)
            {
                devuelve = true;
            }
            else if (c1.ValorCarta == 10 && c2.Numero == "A")
            {
                devuelve = true;
            }

            return devuelve;
        }
        public bool divide(CartaInglesa c1, CartaInglesa c2) //Verifica si las cartas dan posibilidad a dividir
        {
            bool devuelve = false;
            if (c1.Numero == c2.Numero)
            {
                devuelve = true;
            }
            return devuelve;
        }
        public bool superaLimite(CartaInglesa[] cartas) //Verifica si superó el limite de 21
        {
            bool devuelve = false;
            int contador = 0;

            int i = 0;
            while (cartas[i] != null)
            {
                contador += cartas[i].ValorCarta;
                i++;
            }

            if (contador >= 22)
            {
                devuelve = true;
            }
            return devuelve;
        }
        public string actualizaValores(CartaInglesa[] cartas) //Actualiza el panel que muestra la suma de tus cartas
        {
            int val1 = 0;
            int val2;
            string devuelve = "";
            bool tieneAs = false;

            for (int c = 0; c < cartas.Length; c++)
            {
                if (cartas[c] != null)
                {
                    val1 += cartas[c].ValorCarta;
                    if (cartas[c].Numero == "A")
                    {
                        tieneAs = true;
                    }
                } 
            }
            if (tieneAs && (val1 + 10) < 22)
            {
                val2 = val1 + 10;
                devuelve = "Valor de sus cartas: " + val1.ToString() + "/" + val2.ToString();
            }
            else
            {
                devuelve = "Valor de sus cartas:" + val1.ToString();
            }
            return devuelve;
        }
        public int valorAGanar(CartaInglesa[] cartas) //Actualiza el panel que muestra la suma de tus cartas
        {
            int val1 = 0;
            int val2;
            int devuelve;
            bool tieneAs = false;

            for (int c = 0; c < cartas.Length; c++)
            {
                if (cartas[c] != null)
                {
                    val1 += cartas[c].ValorCarta;
                    if (cartas[c].Numero == "A")
                    {
                        tieneAs = true;
                    }
                }
            }
            if (tieneAs && (val1 + 10) < 22)
            {
                val2 = val1 + 10;
                devuelve = val2;
            }
            else
            {
                devuelve = val1;
            }
            return devuelve;
        }
        public string[] rellenarApuesta(int posicionFicha, int apuesta, int presupuesto) //Sobreescribe la informacion del btnApuesta
        {
            string[] devuelve = { "", ""};
            switch (posicionFicha)
            {
                case 0:
                    apuesta = 1;
                    devuelve[0] = "Apuesta: 1";
                    break;
                case 1:
                    apuesta = 5;
                    devuelve[0] = "Apuesta: 5";
                    break;
                case 2:
                    apuesta = 10;
                    devuelve[0] = "Apuesta: 10";
                    break;
                case 3:
                    apuesta = 25;
                    devuelve[0] = "Apuesta: 25";
                    break;
                case 4:
                    apuesta = 50;
                    devuelve[0] = "Apuesta: 50";
                    break;
                case 5:
                    apuesta = 100;
                    devuelve[0] = "Apuesta: 100";
                    break;
            }
            presupuesto -= apuesta;
            devuelve[1] = "Presupuesto: " + presupuesto;
            return devuelve;
        }
        public int apuesta(int posicionFicha, int apuesta, int presupuesto) //Sobreescribe la informacion del btnApuesta
        {
            switch (posicionFicha)
            {
                case 0:
                    apuesta = 1;
                    break;
                case 1:
                    apuesta = 5;
                    break;
                case 2:
                    apuesta = 10;
                    break;
                case 3:
                    apuesta = 25;
                    break;
                case 4:
                    apuesta = 50;
                    break;
                case 5:
                    apuesta = 100;
                    break;
            }
            presupuesto -= apuesta;
            return apuesta;
        }
    }
}
