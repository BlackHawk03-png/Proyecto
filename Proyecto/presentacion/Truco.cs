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
        }

        private void btnCarta2_Click(object sender, EventArgs e)
        {
            btnCarta2.Enabled = false;
            var x = btnCarta2.Location;
            x.Y -= 40;
            btnCarta2.Location = x;
        }

        private void btnCarta1_Click(object sender, EventArgs e)
        {
            btnCarta1.Enabled = false;
            var x = btnCarta1.Location;
            x.Y -= 40;
            btnCarta1.Location = x;
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
            /*if (Usuario.usuarioActual.Username != "")
            {
                Conexion.CrearPartidaTruco(jugador1, jugador2, tipo);
                id = Conexion.RecibirIdPartida(true);
            }*/
            PartidaTruco p = new PartidaTruco(id, jugador1, jugador2, tipo);



            while (!finalizaPartida(p))
            {
                inicioRonda();
            }
            //Conexion con la base de datos, persistir la partida
            //Mensaje al ganador
        }
        private bool finalizaPartida(PartidaTruco p)
        {
            bool finaliza = false;
            if (puntosJugador1 == 40)
            {
                p.Ganador = jugador1;
                finaliza = true;
            }
            else if (puntosJugador2 == 40)
            {
                p.Ganador = jugador2;
                finaliza = true;
            }
            return finaliza;
        }
        private void btnEnvido_Click(object sender, EventArgs e)
        {
            cantoEnvido = true;
            int a = azar.Next(2);
            if (a == 0)
            {
                CartaEspañola[] cartas = { c1, c2, c3 };
                int envido1 = tf.valorEnvido(cartas, muestra);
                cartas[0] = co1;
                cartas[1] = co2;
                cartas[2] = co3;
                int envido2 = tf.valorEnvido(cartas, muestra);
                if(envido1 > envido2)
                {
                    MessageBox.Show("¡Wow!", "Son buenas, ganaste el envido");
                    puntosJugador1++;
                }
                else if(envido2 > envido1)
                {
                    MessageBox.Show("Son buenas", envido2.ToString() + "son mejores, perdiste el envido");
                    puntosJugador2++;
                }
                envido = true;
            }
            else
            {
                puntosJugador1++;
                labelPuntajeUser.Text = puntosJugador1.ToString();
                labelPuntajeCPU.Text = puntosJugador1.ToString();
            }
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
                puntosEnJuego = 4;
                vale4 = true;
            }
            else
            {
                puntosJugador1 += 2;
                labelPuntajeUser.Text = puntosJugador1.ToString();
                repartir();
            }
        }

        private void btnReTruco_Click(object sender, EventArgs e)
        {
            int a = azar.Next(2); //Si es 0 el cpu quiere, sino no quiere
            cantoReTruco = true;
            if (a == 0)
            {
                puntosEnJuego = 3;
                retruco = true;
                btnVale4.Show();
                btnReTruco.Hide();
            }
            else
            {
                puntosJugador1++;
                labelPuntajeUser.Text = puntosJugador1.ToString();
            }
                
        }

        private void btnTruco_Click(object sender, EventArgs e)
        {
            cantoTruco = true;
            int a = azar.Next(2); //Si es 0 el cpu quiere, sino no quiere
            if (a == 0)
            {
                puntosEnJuego = 2;
                truco = true;
                btnReTruco.Show();
                btnTruco.Hide();
            }
            else
            {
                puntosJugador1++;
                labelPuntajeUser.Text = puntosJugador1.ToString();
            }


        }

        private void btnFlor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tenés flor. ganas 3 puntos", "Felicidades");
            puntosJugador1 += 3;
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
            c1 = new CartaEspañola(12, "Basto");
            //c1 = b.robarCartaEspañola();
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
            muestra = new CartaEspañola(5, "Basto");
            //muestra = b.robarCartaEspañola();
            pictureMuestra.BackgroundImage = Image.FromFile(@"..\..\imagenes\truco\" + muestra.RutaImg + ".png");

            btnCarta1.Enabled = true;
            btnCarta2.Enabled = true;
            btnCarta3.Enabled = true;

            picCartaO1.Show();
            picCartaO2.Show();
            picCartaO3.Show();
            btnCarta1.Show();
            btnCarta2.Show();
            btnCarta3.Show();
            btnTruco.Show();
            btnReTruco.Hide();
            btnVale4.Hide();
            btnQuiero.Hide();
            btnNoQuiero.Hide();
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
        private void cpuMano()
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

            if (mano) 
            { 
                mano = false;
            }
            else
            { 
                mano = true;
            }
            repartir();
            btnReTruco.Hide();
            btnVale4.Hide();
            btnQuiero.Hide();
            btnNoQuiero.Hide();
            //btnIniciarJuego.Hide();
            do
            {
                jugarMano();
            }
            while (!finalizaRonda);
            
        }
        private void jugarMano()
        {


            //Conexion a la base de datos, persistir mano
        }
    }
}