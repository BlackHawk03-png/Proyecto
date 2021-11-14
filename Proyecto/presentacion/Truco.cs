using Proyecto.logica;
using Proyecto.persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.presentacion
{
    public partial class Truco : Form
    {
        string jugador1, jugador2, ganadorEnvido; //jugador2 es el CPU
        string[] ganadoresManos = { "", "", "" };
        bool tipo;
        int id;

        Baraja b = new Baraja();
        TrucoFunciones tf = new TrucoFunciones();
        CartaEspañola c1 = new CartaEspañola(0, ""),
            c2 = new CartaEspañola(0, ""),
            c3 = new CartaEspañola(0, ""),
            co1 = new CartaEspañola(0, ""),
            co2 = new CartaEspañola(0, ""),
            co3 = new CartaEspañola(0, ""),
            muestra = new CartaEspañola(0, "");

        bool mano = false, //Si es true mano es el jugador1, si es false mano es el jugador2
            finalizaRonda = false,
            truco = false,
            cantoTruco = false,
            retruco = false,
            cantoReTruco = false,
            vale4 = false,
            cantoVal4 = false,
            envido = false,
            cantoEnvido = false,
            flor = false,
            gana = false,
            buenasj1 = false,
            buenasj2 = false;
        int puntosJugador1 = 0,
            puntosJugador2 = 0,
            puntosEnJuego = 0,
            ronda = 1,
            nroMano = 1;

        Random azar = new Random();

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if(Usuario.usuarioActual.Username != "")
            {
                Main2 m = new Main2();
                m.Show();
                base.Hide();
            }
            else
            {
                Guest g = new Guest();
                g.Show();
                base.Hide();
            }
        }

        private void btnIniciarJuego_Click(object sender, EventArgs e)
        {
            iniciarJuego();
        }

        private void btnCarta3_Click(object sender, EventArgs e)
        {
            btnCarta3.Enabled = false;
            var x = btnCarta3.Location;
            x.Y -= 40;
            btnCarta3.Location = x;

            CartaEspañola[] cartasO = { co1, co2, co3 };

            int numCartaO = azar.Next(3);
            while (cartasO[numCartaO].FueJugada)
            {
                numCartaO = azar.Next(3);
            }
            var y = picCartaO1.Location;
            switch (numCartaO)
            {
                case 0:
                    y = picCartaO1.Location;
                    y.Y += 40;
                    picCartaO1.Location = x;
                    break;
                case 1:
                    y = picCartaO2.Location;
                    y.Y += 40;
                    picCartaO2.Location = x;
                    break;
                case 2:
                    y = picCartaO3.Location;
                    y.Y += 40;
                    picCartaO3.Location = x;
                    break;
            }
            if (tf.cartaGanadora(c3, cartasO[numCartaO], muestra) == 1)
            {
                ganadoresManos[nroMano - 1] = jugador1;
                MessageBox.Show("Ganaste esta mano", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (tf.cartaGanadora(c3, cartasO[numCartaO], muestra) == 2)
            {
                ganadoresManos[nroMano - 1] = jugador2;
                MessageBox.Show("Perdiste esta mano", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ganadoresManos[nroMano - 1] = "Emparde";
                MessageBox.Show("Emparde", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (comparaManos() == 1)
            {
                terminaRonda(true);
                return;
            }
            else if (comparaManos() == 2)
            {
                terminaRonda(false);
                return;
            }
            nroMano++;
        }

        private void btnCarta2_Click(object sender, EventArgs e)
        {
            btnCarta2.Enabled = false;
            var x = btnCarta2.Location;
            x.Y -= 40;
            btnCarta2.Location = x;

            CartaEspañola[] cartasO = { co1, co2, co3 };

            int numCartaO = azar.Next(3);
            while (cartasO[numCartaO].FueJugada)
            {
                numCartaO = azar.Next(3);
            }
            var y = picCartaO1.Location;
            switch (numCartaO)
            {
                case 0:
                    y = picCartaO1.Location;
                    y.Y += 40;
                    picCartaO1.Location = x;
                    break;
                case 1:
                    y = picCartaO2.Location;
                    y.Y += 40;
                    picCartaO2.Location = x;
                    break;
                case 2:
                    y = picCartaO3.Location;
                    y.Y += 40;
                    picCartaO3.Location = x;
                    break;
            }
            if (tf.cartaGanadora(c2, cartasO[numCartaO], muestra) == 1)
            {
                ganadoresManos[nroMano - 1] = jugador1;
                MessageBox.Show("Ganaste esta mano", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (tf.cartaGanadora(c2, cartasO[numCartaO], muestra) == 2)
            {
                ganadoresManos[nroMano - 1] = jugador2;
                MessageBox.Show("Perdiste esta mano", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ganadoresManos[nroMano - 1] = "Emparde";
                MessageBox.Show("Emparde", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (comparaManos() == 1)
            {
                terminaRonda(true);
                return;
            }
            else if (comparaManos() == 2)
            {
                terminaRonda(false);
                return;
            }
            nroMano++;
        }

        private void btnCarta1_Click(object sender, EventArgs e)
        {
            btnCarta1.Enabled = false;
            var x = btnCarta1.Location;
            x.Y -= 40;
            btnCarta1.Location = x;

            CartaEspañola[] cartasO = { co1, co2, co3 };

            int numCartaO = azar.Next(3);
            while (cartasO[numCartaO].FueJugada)
            {
                numCartaO = azar.Next(3);
            }
            var y = picCartaO1.Location;
            switch (numCartaO)
            {
                case 0:
                    y = picCartaO1.Location;
                    y.Y += 40;
                    picCartaO1.Location = x;
                    co1.FueJugada = true;
                    break;
                case 1:
                    y = picCartaO2.Location;
                    y.Y += 40;
                    picCartaO2.Location = x;
                    co2.FueJugada = true;
                    break;
                case 2:
                    y = picCartaO3.Location;
                    y.Y += 40;
                    picCartaO3.Location = x;
                    co3.FueJugada = true;
                    break;
            }
            if (tf.cartaGanadora(c1, cartasO[numCartaO], muestra) == 1)
            {
                ganadoresManos[nroMano - 1] = jugador1;
                MessageBox.Show("Ganaste esta mano", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (tf.cartaGanadora(c1, cartasO[numCartaO], muestra) == 2)
            {
                ganadoresManos[nroMano - 1] = jugador2;
                MessageBox.Show("Perdiste esta mano", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ganadoresManos[nroMano - 1] = "Emparde";
                MessageBox.Show("Emparde", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (comparaManos() == 1)
            {
                terminaRonda(true);
                return;
            }
            else if (comparaManos() == 2)
            {
                terminaRonda(false);
                return;
            }
            nroMano++;
        }

        private int comparaManos() //Si gana el jugador1, devuelve 1, si gana el jugador2 devuelve 2, sino 3
        {
            int devuelve = 0;

            if (ganadoresManos[0] == jugador1)
            {
                if (ganadoresManos[1] == jugador1)
                {
                    devuelve = 1;
                }
                else if (ganadoresManos[2] == jugador1)
                {
                        devuelve = 1;
                }
                else if (ganadoresManos[1] == jugador2 && ganadoresManos[2] == "Emparde")
                {
                    devuelve = 1;
                }
                else if (ganadoresManos[1] == "Emparde")
                {
                    devuelve = 1;
                }
            }
            else if(ganadoresManos[0] == jugador2)
            {
                if (ganadoresManos[1] == jugador2)
                {
                    devuelve = 2;
                }
                else if (ganadoresManos[2] == jugador2)
                {
                    devuelve = 2;
                }
                else if (ganadoresManos[1] == jugador1 && ganadoresManos[2] == "Emparde")
                {
                    devuelve = 2;
                }
                else if (ganadoresManos[1] == "Emparde")
                {
                    devuelve = 2;
                }
            }
            else if(ganadoresManos[0] == "Emparde")
            {
                if (ganadoresManos[1] == jugador1)
                {
                    devuelve = 1;
                }
                else if (ganadoresManos[1] == jugador2)
                {
                    devuelve = 2;
                }
                else if (ganadoresManos[1] == "Emparde" && ganadoresManos[2] == jugador1)
                {
                    devuelve = 1;
                }
                else if (ganadoresManos[1] == "Emparde" && ganadoresManos[2] == jugador2)
                {
                    devuelve = 2;
                }
                else if (ganadoresManos[1] == "Emparde" && ganadoresManos[2] == "Emparde")
                {
                    if (mano)
                    {
                        devuelve = 1;
                    }
                    else
                    {
                        devuelve = 2;
                    }
                }
            }
  
            if (ganadoresManos[1] == jugador1 && ganadoresManos[2] == jugador1)
            {
                devuelve = 1;
            }
            else if (ganadoresManos[1] == jugador2 && ganadoresManos[2] == jugador2)
            {
                devuelve = 2;
            }

            return devuelve;
        }

        public Truco(bool t, string j1, string j2)
        {
            InitializeComponent();
            tipo = t;
            jugador1 = j1;
            jugador2 = j2;
            
            this.Closing += new CancelEventHandler(Register_Closing);
            void Register_Closing(object sender, CancelEventArgs e)
            {
                Conexion.Conectado(Usuario.usuarioActual.Username, 0);
                Application.Exit();
            }
            imagenJugador();
            inicio();
            b.barajaEspañola();
        }
        private void imagenJugador()
        {
            if (Usuario.usuarioActual.FotoPerfil.Equals("") == false)
            {
                picPerfil.BackgroundImage = null;
                picPerfil.Load(Usuario.usuarioActual.FotoPerfil);
                if (!Usuario.usuarioActual.Suscrito)
                {
                    panelMarcoDiferencial.Hide();
                }
            }
            else
            {
                panelMarcoDiferencial.Hide();
                picPerfil.Hide();
            }
        }
        private void iniciarJuego()
        {
            if (Usuario.usuarioActual.Username != "")
            {
                Conexion.CrearPartidaTruco(jugador1, jugador2, tipo);
                id = Conexion.RecibirIdPartida(true);
            }
            PartidaTruco p = new PartidaTruco(id, jugador1, jugador2, tipo);

            inicioRonda();
            
            //Conexion con la base de datos, persistir la partida
            //Mensaje al ganador
        }
        private void finalizaPartida()
        {
            if (Usuario.usuarioActual.Username != "")
            {
                Main2 m = new Main2();
                m.Show();
                base.Hide();
                //Conexion con la base de datos para actualizar la partida
            }
            else
            {
                Guest g = new Guest();
                g.Show();
                base.Hide();
            }
        }
        private void btnEnvido_Click(object sender, EventArgs e)
        {
            cantoEnvido = true;
            int a = 0;
            //int a = azar.Next(2);
            if (a == 0)
            {
                CartaEspañola[] cartas = { c1, c2, c3 };
                int envido1 = tf.valorEnvido(cartas, muestra);
                cartas[0] = co1;
                cartas[1] = co2;
                cartas[2] = co3;

                if (!tf.verificaFlor(cartas, muestra))
                {
                    int envido2 = tf.valorEnvido(cartas, muestra);
                    if (envido1 > envido2)
                    {
                        MessageBox.Show("Son buenas, ganaste el envido", "Atención");
                        puntosJugador1++;
                        labelPuntajeUser.Text = puntosJugador1.ToString();
                    }
                    else if (envido2 > envido1)
                    {
                        MessageBox.Show(envido2.ToString() + " son mejores, perdiste el envido", "Son buenas");
                        puntosJugador2++;
                        labelPuntajeCPU.Text = puntosJugador2.ToString();
                    }
                    else
                    {
                        if (mano)
                        {
                            MessageBox.Show("Empate, ganas por mano", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntosJugador1++;
                            labelPuntajeUser.Text = puntosJugador1.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Empate, tu oponente gana por mano", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            puntosJugador2++;
                            labelPuntajeCPU.Text = puntosJugador2.ToString();
                        }

                    }
                    envido = true;
                }
                else
                {
                    MessageBox.Show("Tu oponente tiene flor, gana 3 puntos", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    puntosJugador2 += 3;
                    labelPuntajeCPU.Text = puntosJugador2.ToString();
                }
            }
            else
            {
                puntosJugador1++;
                labelPuntajeUser.Text = puntosJugador1.ToString();
                labelPuntajeCPU.Text = puntosJugador2.ToString();
            }
            //btnEnvido.Hide();
        }

        private void btnQuiero_Click(object sender, EventArgs e)
        {

        }

        private void btnVale4_Click(object sender, EventArgs e)
        {
            cantoVal4 = true;
            int a = azar.Next(2); //Si es 0 el cpu quiere, sino no quiere
            if (a == 0)
            {
                MessageBox.Show("Tu oponente quiere vale 4", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                puntosEnJuego = 4;
                vale4 = true;
            }
            else
            {
                MessageBox.Show("Tu oponente no quiere vale 4", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                puntosEnJuego = 3;
                labelPuntajeUser.Text = puntosJugador1.ToString();
                terminaRonda(true);
            }
        }

        private void btnReTruco_Click(object sender, EventArgs e)
        {
            int a = azar.Next(2); //Si es 0 el cpu quiere, sino no quiere
            cantoReTruco = true;
            if (a == 0)
            {
                MessageBox.Show("Tu oponente quiere retruco", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                puntosEnJuego = 3;
                retruco = true;
                btnVale4.Show();
                btnReTruco.Hide();
            }
            else
            {
                MessageBox.Show("Tu oponente no quiere retruco", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                puntosEnJuego = 2;
                labelPuntajeUser.Text = puntosJugador1.ToString();
                terminaRonda(true);
            }
                
        }

        private void btnTruco_Click(object sender, EventArgs e)
        {
            cantoTruco = true;
            int a = azar.Next(2); //Si es 0 el cpu quiere, sino no quiere
            if (a == 0)
            {
                MessageBox.Show("Tu oponente quiere truco", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                puntosEnJuego = 2;
                truco = true;
                btnReTruco.Show();
                btnTruco.Hide();
            }
            else
            {
                MessageBox.Show("Tu oponente  no quiere truco", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                puntosEnJuego = 1;
                labelPuntajeUser.Text = puntosJugador1.ToString();
                terminaRonda(true);
            }


        }

        private void btnFlor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tenés flor, ganas 3 puntos", "Felicidades");
            puntosJugador1 += 3;
            labelPuntajeUser.Text = puntosJugador1.ToString();
            btnFlor.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Truco_Load(object sender, EventArgs e)
        {

        }
        private void repartir()
        {
            c1 = b.robarCartaEspañola();
            btnCarta1.BackgroundImage = Image.FromFile(@"..\..\imagenes\truco\" + c1.RutaImg + ".png");
            co1 = b.robarCartaEspañola();
            picCartaO1.BackgroundImage = Image.FromFile(@"..\..\imagenes\truco\" + co1.RutaImg + ".png");
            c2 = b.robarCartaEspañola();
            btnCarta2.BackgroundImage = Image.FromFile(@"..\..\imagenes\truco\" + c2.RutaImg + ".png");
            co2 = b.robarCartaEspañola();
            picCartaO2.BackgroundImage = Image.FromFile(@"..\..\imagenes\truco\" + co2.RutaImg + ".png");
            c3 = b.robarCartaEspañola();
            btnCarta3.BackgroundImage = Image.FromFile(@"..\..\imagenes\truco\" + c3.RutaImg + ".png");
            co3 = b.robarCartaEspañola();
            picCartaO3.BackgroundImage = Image.FromFile(@"..\..\imagenes\truco\" + co3.RutaImg + ".png");
            muestra = b.robarCartaEspañola();
            pictureMuestra.BackgroundImage = Image.FromFile(@"..\..\imagenes\truco\" + muestra.RutaImg + ".png");

            btnCarta1.Enabled = true;
            btnCarta2.Enabled = true;
            btnCarta3.Enabled = true;

            picCartaO1.Show();
            picCartaO1.Location = new Point(340, 25);
            picCartaO2.Show();
            picCartaO2.Location = new Point(520, 25);
            picCartaO3.Show();
            picCartaO3.Location = new Point(700, 25);
            btnCarta1.Show();
            btnCarta1.Location = new Point(340, 464);
            btnCarta2.Show();
            btnCarta2.Location = new Point(520, 464);
            btnCarta3.Show();
            btnCarta3.Location = new Point(700, 464);
            btnTruco.Show();
            btnReTruco.Hide();
            btnVale4.Hide();
            btnQuiero.Hide();
            btnNoQuiero.Hide();

            nroMano = 1;
            ganadoresManos[0] = "!";
            ganadoresManos[1] = "·";
            ganadoresManos[2] = "$";

            CartaEspañola[] cartas = { c1, c2, c3 };
            if (tf.verificaFlor(cartas, muestra))
            {
                btnFlor.Show();
                btnEnvido.Hide();
            }
            else
            {
                btnFlor.Hide();
                btnEnvido.Show();
            }


        }
        private void primeraMano()
        {
            
        }

        private void pierde()
        {

        }
        private void inicio()
        {
            picCartaO1.Hide();
            picCartaO2.Hide();
            picCartaO3.Hide();
            btnCarta1.Hide();
            btnCarta2.Hide();
            btnCarta3.Hide();


            btnEnvido.Hide();
            btnFlor.Hide();
            btnQuiero.Hide();
            btnNoQuiero.Hide();
            btnTruco.Hide();
            btnReTruco.Hide();
            btnVale4.Hide();

            c1 = null;
            co1 = null;
            c2 = null;
            co2 = null;
            c3 = null;
            co3 = null;

            mano = false;
            finalizaRonda = false;
            truco = false;
            cantoTruco = false;
            retruco = false;
            cantoReTruco = false;
            vale4 = false;
            cantoVal4 = false;
            envido = false;
            cantoEnvido = false;
            flor = false;
            gana = false;
            buenasj1 = false;
            buenasj2 = false;
            puntosJugador1 = 0;
            puntosJugador2 = 0;
            puntosEnJuego = 1;
            ronda = 1;
            nroMano = 1;
            ganadoresManos[0] = "!";
            ganadoresManos[1] = "·";
            ganadoresManos[2] = "$";

            labelPuntajeCPU.Text = "";
            labelPuntajeUser.Text = "";
        }
        private void inicioRonda()
        {
            if(puntosJugador1 >= 20 && !buenasj1)
            {
                MessageBox.Show("Entraste en buenas", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                buenasj1 = true;
            }
            else if(puntosJugador2 >= 20 && !buenasj2)
            {
                MessageBox.Show("Tu oponente entró en buenas", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                buenasj2 = true;
            }
            if (puntosJugador1 >= 40)
            {
                MessageBox.Show("Felicidades, ganaste la partida", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                finalizaPartida();
            }
            else if (puntosJugador2 >= 40)
            {
                MessageBox.Show("Perdiste la partida", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                finalizaPartida();
            }


            if (mano) 
            { 
                mano = false;
            }
            else
            { 
                mano = true;
            }
            repartir();
            nroMano = 1;
            truco = false;
            cantoTruco = false;
            retruco = false;
            cantoReTruco = false;
            vale4 = false;
            cantoVal4 = false;
            envido = false;
            cantoEnvido = false;
            flor = false;

            //btnIniciarJuego.Hide();
            jugarMano();

            
        }
        private void jugarMano()
        {


            //Conexion a la base de datos, persistir mano
        }
        private void terminaRonda(bool ganador) //si es true el ganador es el usuario
        {
            if (ganador)
            {
                MessageBox.Show("Ganaste la ronda, ganas " + puntosEnJuego + " puntos", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                puntosJugador1 += puntosEnJuego;
                labelPuntajeUser.Text = puntosJugador1.ToString();
            }
            if (!ganador)
            {
                MessageBox.Show("Perdiste la ronda, tu oponente gana " + puntosEnJuego + " puntos", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                puntosJugador2 += puntosEnJuego;
                labelPuntajeCPU.Text = puntosJugador2.ToString();
            }
            inicioRonda();
        }
    }
}