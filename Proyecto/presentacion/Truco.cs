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
        Usuario jugador1, jugador2;
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
        
        bool truco = false,
            cantoTruco = false,
            retruco = false,
            cantoReTruco = false,
            vale4 = false,
            cantoVal4 = false,
            envido = false,
            cantoEnvido = false,
            flor = false,
            gana = false;
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

        int puntosJugador = 0,
            puntosCPU = 0,
            puntosEnJuego = 0,
            ronda = 1;

        private void btnIniciarJuego_Click(object sender, EventArgs e)
        {
            iniciarJuego();
        }

        private void btnCarta3_Click(object sender, EventArgs e)
        {
            btnCarta3.Enabled = false;
        }

        private void btnCarta2_Click(object sender, EventArgs e)
        {
            btnCarta2.Enabled = false;
        }

        private void btnCarta1_Click(object sender, EventArgs e)
        {
            btnCarta1.Enabled = false;
        }

        public Truco(bool t, Usuario j1, Usuario j2)
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
            
            b.barajaEspañola();
        }
        private void iniciarJuego()
        {
            if (Usuario.usuarioActual.Username != "")
            {
                Conexion.CrearPartidaTruco(jugador1.Username, jugador2.Username, tipo);
                id = Conexion.RecibirIdPartida(true);
            }
            PartidaTruco p = new PartidaTruco(id, jugador1, jugador2, tipo);
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
                    puntosJugador++;
                }
                else if(envido2 > envido1)
                {
                    MessageBox.Show("Son buenas", envido2.ToString() + "son mejores, perdiste el envido");
                    puntosCPU++;
                }
            }
            else
            {
                puntosJugador++;
                labelPuntajeUser.Text = puntosJugador.ToString();
                labelPuntajeCPU.Text = puntosJugador.ToString();
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
                puntosJugador += 2;
                labelPuntajeUser.Text = puntosJugador.ToString();
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
                puntosJugador++;
                labelPuntajeUser.Text = puntosJugador.ToString();
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
                puntosJugador++;
                labelPuntajeUser.Text = puntosJugador.ToString();
            }


        }

        private void btnFlor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tenés flor. ganas 3 puntos", "Felicidades");
            puntosJugador += 3;
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
            primeraRonda();
        }
        private void primeraRonda()
        {
            btnReTruco.Hide();
            btnVale4.Hide();
            btnQuiero.Hide();
            btnNoQuiero.Hide();
            btnEnvido.Show();
            CartaEspañola[] cartas = { c1, c2, c3 };
            if (tf.verificaFlor(cartas, muestra))
            {
                btnFlor.Show();
                btnEnvido.Hide();
            }
        }
        private void cpuMano()
        {

        }
        private void pierde()
        {

        }
        private void inicio()
        {
            
        }
        private void inicioMano()
        {
            btnReTruco.Hide();
            btnVale4.Hide();
            btnQuiero.Hide();
            btnNoQuiero.Hide();
            

            repartir();

            btnIniciarJuego.Hide();
        }
    }
}