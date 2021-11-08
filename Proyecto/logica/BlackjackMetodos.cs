using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.logica
{
    class BlackjackMetodos
    {
        public BlackjackMetodos() //Constructor por defecto con todos los valores
        {

        }

        private bool blackJack(CartaInglesa c1, CartaInglesa c2) //Verifica si las cartas forman blackjack
        {
            bool devuelve = false;
            int valor1 = c1.ValorCarta;
            int valor2 = c2.ValorCarta;
            if (valor1 == 1)
            {
                valor1 = 11;
            }
            if (valor2 == 1)
            {
                valor2 = 11;
            }
            if (valor1 == 11 && valor2 == 11)
            {
                valor1 = 1;
                valor2 = 2;
            }
            if (c1.ValorCarta + c2.ValorCarta == 21)
            {
                devuelve = true;
            }
            return devuelve;
        }
        private bool divide(CartaInglesa c1, CartaInglesa c2) //Verifica si las cartas dan posibilidad a dividir
        {
            bool devuelve = false;
            if (c1.Numero == c2.Numero)
            {
                devuelve = true;
            }
            return devuelve;
        }
        private bool superaLimite(CartaInglesa[] cartas) //Verifica si superó el limite de 21
        {
            bool devuelve = false;
            int contador = 0;

            for (int c = 0; c < cartas.Length; c++)
            {
                contador += cartas[c].ValorCarta;
            }
            if (contador > 22)
            {
                devuelve = true;
            }
            return devuelve;
        }
        private void actualizaValores(CartaInglesa[] cartas) //Actualiza el panel que muestra la suma de tus cartas
        {
            int val1 = 0;
            int val2;
            bool tieneAs = false;

            for (int c = 0; c < cartas.Length; c++)
            {
                val1 += cartas[c].ValorCarta;
                if (cartas[c].Numero == "A")
                {
                    tieneAs = true;
                }
            }
            if (tieneAs && (val1 + 10) < 22)
            {
                val2 = val1 + 10;
                btnValores.Text = val1 + "/" + val2;
            }
            else
            {
                btnValores.Text = val1.ToString();
            }
        }
        private void pierde() //Pregunta si quiere volver a jugar
        {
            DialogResult d;
            d = MessageBox.Show("¡Perdiste!", "Quieres volver a jugar?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                inicio();
            }
            else
            {
                f.Show();
                base.Hide();
            }
        } 
        private void gana() //Devuelve el dinero que debe y pregunta si quiere volver a jugar
        {
            if (blackJack(c1, c2))
            {
                presupuesto += Convert.ToInt32(Convert.ToDouble(apuesta) * 2.5);
            }
            else
            {
                presupuesto += apuesta * 2;
            }
            btnPresupuesto.Text = "Presupusto: " + presupuesto;
            DialogResult d;
            d = MessageBox.Show("¡Perdiste!", "Quieres volver a jugar?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                inicio();
            }
            else
            {
                f.Show();
                base.Hide();
            }
        }
        private void cpu() //Saca cartas hasta superar al usuario
        {
            CartaInglesa[] cartas = { co1, co2 };
            int cartasTotal = co1.ValorCarta + co2.ValorCarta;
            string temp = btnValores.Text;
            string[] str = new string[temp.Length];
            int valorAGanar = 0;
            cantCartas = 2;
            if (str[1] == "/")
            {
                temp = str[2] + str[3];
                valorAGanar = int.Parse(temp);
            }
            else
            {
                valorAGanar = int.Parse(temp);
            }
            while (cantCartas < 8 || cartasTotal < 17) { 
                switch (cantCartas)
                {
                    case 2:
                        co3 = b.robarCartaInglesa();
                        cartasTotal += co3.ValorCarta;
                        cartas[2] = co3;
                        btnCartaO3.Image = Image.FromFile(@"F:\Liceo\3ºEMTI\Proyecto fin de año\Programacion\Proyecto\Proyecto\imagenes\blackjack\" + co3.RutaImg + ".png");
                        if (superaLimite(cartas))
                        {
                            gana();
                        }
                        break;
                    case 3:
                        co4 = b.robarCartaInglesa();
                        cartasTotal += co4.ValorCarta;
                        cartas[3] = co4;
                        btnCartaO4.Image = Image.FromFile(@"F:\Liceo\3ºEMTI\Proyecto fin de año\Programacion\Proyecto\Proyecto\imagenes\blackjack\" + co4.RutaImg + ".png");
                        if (superaLimite(cartas))
                        {
                            gana();
                        }
                        break;
                    case 4:
                        co5 = b.robarCartaInglesa();
                        cartasTotal += co5.ValorCarta;
                        cartas[4] = co5;
                        btnCartaO5.Image = Image.FromFile(@"F:\Liceo\3ºEMTI\Proyecto fin de año\Programacion\Proyecto\Proyecto\imagenes\blackjack\" + co5.RutaImg + ".png");
                        if (superaLimite(cartas))
                        {
                            gana();
                        }
                        break;
                    case 5:
                        co6 = b.robarCartaInglesa();
                        cartasTotal += co6.ValorCarta;
                        cartas[5] = co6;
                        btnCartaO6.Image = Image.FromFile(@"F:\Liceo\3ºEMTI\Proyecto fin de año\Programacion\Proyecto\Proyecto\imagenes\blackjack\" + co6.RutaImg + ".png");
                        if (superaLimite(cartas))
                        {
                            gana();
                        }
                        break;
                    case 6:
                        co7 = b.robarCartaInglesa();
                        cartasTotal += co3.ValorCarta;
                        cartas[6] = co7;
                        btnCartaO7.Image = Image.FromFile(@"F:\Liceo\3ºEMTI\Proyecto fin de año\Programacion\Proyecto\Proyecto\imagenes\blackjack\" + co7.RutaImg + ".png");
                        if (superaLimite(cartas))
                        {
                            gana();
                        }
                        break;
                }
                cantCartas++;
            }
            if (cartasTotal > valorAGanar)
            {
                pierde();
            }else if(cartasTotal == valorAGanar)
            {
                inicio();
            } else if (cartasTotal < valorAGanar)
            {
                gana();
            }
        }
        private void inicio() //Deja todos los objetos para el iniciar el juego
        {
            btnDividir.Hide();
            btnDoblar.Hide();
            btnPedir.Hide();
            btnPlantarse.Hide();
            btnCarta1.Image = null;
            btnCarta2.Image = null;
            btnCarta3.Hide();
            btnCarta4.Hide();
            btnCarta5.Hide();
            btnCarta6.Hide();
            btnCarta7.Hide();
            btnCartaO1.Image = null;
            btnCartaO2.Image = null;
            btnCartaO3.Hide();
            btnCartaO4.Hide();
            btnCartaO5.Hide();
            btnCartaO6.Hide();
            btnCartaO7.Hide();
            btnIzquierda.Show();
            btnDerecha.Show();
            btnFicha.Show();
            btnApostar.Show();
            btnFicha.BackColor = Color.Transparent;
        }
        private void rellenarApuesta() //Sobreescribe la informacion del btnApuesta
        {
            switch (posicionFicha)
            {
                case 0:
                    apuesta = 1;
                    btnApuesta.Text = "Apuesta: 1";
                    break;
                case 1:
                    apuesta = 5;
                    btnApuesta.Text = "Apuesta: 5";
                    break;
                case 2:
                    apuesta = 10;
                    btnApuesta.Text = "Apuesta: 10";
                    break;
                case 3:
                    apuesta = 25;
                    btnApuesta.Text = "Apuesta: 25";
                    break;
                case 4:
                    apuesta = 50;
                    btnApuesta.Text = "Apuesta: 50";
                    break;
                case 5:
                    apuesta = 100;
                    btnApuesta.Text = "Apuesta: 100";
                    break;
            }
            presupuesto -= apuesta;
            btnPresupuesto.Text = "Presupuesto: " + presupuesto;
        }
    }
}        