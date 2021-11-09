using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.logica
{
    class Baraja
    {
        public Baraja() //Constructor sin atributos
        {
        }
        Random azar = new Random();

        private CartaInglesa[] barajaInglesas1 = new CartaInglesa[52];
        private CartaEspañola[] barajaEspañolas1 = new CartaEspañola[40];

        private ArrayList usadasEspañolas = new ArrayList();
        private ArrayList usadasInglesas = new ArrayList();

        public void limpiarEspañolas() //cupala Pose jaja
        {
            usadasEspañolas.Clear();
        }
        public void limpiarInglesas()
        {
            usadasInglesas.Clear();
        }
        public void barajaEspañola() //Crea la baraja española
        {
            int nC = 0;
            int n = 0;
            string[] palos = { "Oro", "Copa", "Basto", "Espada" };
            for (int x = 0; x < 4; x++)
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (i != 8 && i != 9)
                    {
                        n = i;
                        CartaEspañola c = new CartaEspañola(n, palos[x]);
                        barajaEspañolas1[nC] = c;
                        nC++;
                    }
                }
            }
        }
        public void barajaInglesa() //Crea la baraja inglesa
        {
            int nC = 0;
            string n = "";
            string[] palos = { "Pica", "Corazones", "Diamantes", "Treboles" };
            for (int x = 0; x < 4; x++)
            {
                CartaInglesa c = new CartaInglesa("A", palos[x], 1, "A" + palos[x]);
                barajaInglesas1[nC] = c;
                nC++;
                for (int i = 2; i <= 10; i++)
                {
                    n = i.ToString();
                    CartaInglesa c1 = new CartaInglesa(n, palos[x], i, i + palos[x]);
                    barajaInglesas1[nC] = c1;
                    nC++;
                }
                CartaInglesa c2 = new CartaInglesa("J", palos[x], 10, "J" + palos[x]);
                barajaInglesas1[nC] = c2;
                nC++;

                CartaInglesa c3 = new CartaInglesa("Q", palos[x], 10, "Q" + palos[x]);
                barajaInglesas1[nC] = c3;
                nC++;

                CartaInglesa c4 = new CartaInglesa("K", palos[x], 10, "K" + palos[x]);
                barajaInglesas1[nC] = c4;
                nC++;
            }
        }
        public CartaEspañola robarCartaEspañola() //Roba una carta española
        {
            Random azar = new Random();
            CartaEspañola devuelve = null;
            int a = azar.Next(40);

            while (usadasEspañolas.Contains(a))
            {
                a = azar.Next(40);
            }
            devuelve = barajaEspañolas1[a];
            usadasEspañolas.Add(a);

            return devuelve;
        }
        public CartaInglesa robarCartaInglesa() //Roba una carta inglesa
        {
            Random azar = new Random();
            CartaInglesa devuelve = null;
            int a = azar.Next(52);

            while (usadasInglesas.Contains(a))
            {
                a = azar.Next(52);
            }
            devuelve = barajaInglesas1[a];
            usadasInglesas.Add(a);

            return devuelve;
        }
    }
}
