using Proyecto.logica;
using Proyecto.persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.presentacion
{
    public partial class Blackjack : Form
    {
        BlackjackFunciones funciones = new BlackjackFunciones();
        Guest f = new Guest();
        Baraja b = new Baraja();
        CartaInglesa c1 = new CartaInglesa("","",0,""),
            c2 = new CartaInglesa("", "", 0,""),
            c3 = new CartaInglesa("", "", 0,""),
            c4 = new CartaInglesa("", "", 0,""),
            c5 = new CartaInglesa("", "", 0,""),
            c6 = new CartaInglesa("", "", 0, ""),
            c7 = new CartaInglesa("", "", 0, "");
        CartaInglesa co1 = new CartaInglesa("", "", 0,""), 
            co2 = new CartaInglesa("", "", 0,""), 
            co3 = new CartaInglesa("", "", 0,""),
            co4 = new CartaInglesa("", "", 0,""), 
            co5 = new CartaInglesa("", "", 0,""),
            co6 = new CartaInglesa("", "", 0,""),
            co7 = new CartaInglesa("", "", 0,"");
        //CartaInglesa cd1, cd2, cd3, cd4, cd5, cd6, cd7;
        int cantCartas;
        CartaInglesa[] cartas = new CartaInglesa[7];
        int apuesta = 1;
        int ganancia = 0;
        int presupuesto = 1000;
        string[] fichas = { "fichaAmarilla", "fichaCeleste", "fichaNaranja", "fichaNegra", "fichaRoja", "fichaVerde" };
        int posicionFicha = 0;
        public Blackjack() //true es guest, false es usuario
        {
            InitializeComponent();
            inicio();
            b.barajaInglesa();

            this.Closing += new CancelEventHandler(Register_Closing);
            void Register_Closing(object sender, CancelEventArgs e)
            {
                Conexion.Conectado(Usuario.usuarioActual.Username, 0);
                Application.Exit();
            }
            /*if(Usuario.usuarioActual.Username != "")
            {
                presupuesto = Usuario.usuarioActual.Presupuesto;
            }*/
            imagenJugador();
        }
        private void imagenJugador()
        {
            if (Usuario.usuarioActual.FotoPerfil.Equals("") == false)
            {
                picPerfil.BackgroundImage = null;
                picPerfil.Load(Usuario.usuarioActual.FotoPerfil);
                if (Usuario.usuarioActual.Rol == "sin rol" || Usuario.usuarioActual.Rol == "administrador")
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
        private void Blackjack_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
        }
        private void btnPresupuesto_Click(object sender, EventArgs e)
        {
        }
        private void btnDerecha_Click(object sender, EventArgs e)
        {
            if (posicionFicha <= 4)
            {
                posicionFicha++;
                apuesta = funciones.apuesta(posicionFicha, apuesta, presupuesto);
                btnFicha.Image = Image.FromFile(@"..\..\imagenes\blackjack\" + fichas[posicionFicha] + ".png");
            }
            else
            {
                MessageBoxButtons btn = MessageBoxButtons.OK;
                MessageBox.Show("No hay fichas de mayor valor", "Error", btn);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e) //Adaptar para usuario y guest
        {
            DialogResult d;
            d = MessageBox.Show("Si sales ahora perderás" +
                "\nlo que apostaste", "¡Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {
                if(Usuario.usuarioActual.Username != "")
                {
                    Main2 m = new Main2();
                    m.Show();
                    base.Hide();
                }
                else
                {
                    f.Show();
                    base.Hide();
                }
                
            }
        }

        private void btnCarta6_Click(object sender, EventArgs e)
        {

        }
        private void btnCartaO5_Click(object sender, EventArgs e)
        {

        }
        private void btnCartaO4_Click(object sender, EventArgs e)
        {

        }
        private void btnCartaO3_Click(object sender, EventArgs e)
        {

        }
        private void btnCartaO2_Click(object sender, EventArgs e)
        {

        }
        private void btnCartaO1_Click(object sender, EventArgs e)
        {

        }
        private void btnCartaO6_Click(object sender, EventArgs e)
        {

        }
        private void btnCarta5_Click(object sender, EventArgs e)
        {

        }
        private void btnCarta4_Click(object sender, EventArgs e)
        {

        }
        private void btnCarta3_Click(object sender, EventArgs e)
        {

        }
        private void btnCarta2_Click(object sender, EventArgs e)
        {

        }
        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            if (posicionFicha >= 0)
            {
                posicionFicha--;
                apuesta = funciones.apuesta(posicionFicha, apuesta, presupuesto);
                btnFicha.Image = Image.FromFile(@"..\..\imagenes\blackjack\" + fichas[posicionFicha] + ".png");
            }
            else
            {
                MessageBoxButtons btn = MessageBoxButtons.OK;
                MessageBox.Show("No hay fichas de menor valor", "Error", btn);
            }
        }
        private void btnPedir_Click(object sender, EventArgs e)
        {
            btnDoblar.Hide();
            btnDividir.Hide();

            switch (cantCartas)
            {
                case 2:
                    c3 = b.robarCartaInglesa();
                    btnCarta3.Show();
                    btnCarta3.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + c3.RutaImg + ".png");
                    cartas[2] = c3;
                    txtValores.Text = funciones.actualizaValores(cartas);
                    if (funciones.superaLimite(cartas))
                    {
                        pierde();
                        //return;
                    }
                    else
                    {
                        cantCartas++;
                    }
                    break;
                case 3:
                    c4 = b.robarCartaInglesa();
                    btnCarta4.Show();
                    btnCarta4.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + c4.RutaImg + ".png");
                    cartas[3] = c4;
                    txtValores.Text = funciones.actualizaValores(cartas);
                    if (funciones.superaLimite(cartas))
                    {
                        pierde();
                        //return;
                    }
                    else
                    {
                        cantCartas++;
                    }
                    break;
                case 4:
                    c5 = b.robarCartaInglesa();
                    btnCarta5.Show();
                    btnCarta5.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + c5.RutaImg + ".png");
                    cartas[4] = c5;
                    txtValores.Text = funciones.actualizaValores(cartas);
                    if (funciones.superaLimite(cartas))
                    {
                        pierde();
                        //return;
                    }
                    else
                    {
                        cantCartas++;
                    }
                    break;
                case 5:
                    c6 = b.robarCartaInglesa();
                    btnCarta6.Show();
                    btnCarta6.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + c6.RutaImg + ".png");
                    cartas[5] = c6;
                    txtValores.Text = funciones.actualizaValores(cartas);
                    if (funciones.superaLimite(cartas))
                    {
                        pierde();
                        //return;
                    }
                    else
                    {
                        cantCartas++;
                    }
                    break;
                case 6:
                    c7 = b.robarCartaInglesa();
                    btnCarta7.Show();
                    btnCarta3.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + c7.RutaImg + ".png");
                    cartas[6] = c7;
                    txtValores.Text = funciones.actualizaValores(cartas);
                    if (funciones.superaLimite(cartas))
                    {
                        pierde();
                        //return;
                    }
                    else
                    {
                        cpu();
                        //return;
                    }
                    break;
            }
            //cantCartas++;
        }
        private void button6_Click(object sender, EventArgs e)
        {
        }
        private void btnApostar_Click(object sender, EventArgs e)
        {
            if (presupuesto - apuesta <= 0)
            {
                MessageBox.Show("No cuentas con suficientes fichas para seguir jugando", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                btnApostar.Hide();
                btnFicha.Hide();
                btnIzquierda.Hide();
                btnDerecha.Hide();
                txtApuesta.Text = "Apuesta: " + apuesta;
                presupuesto -= apuesta;
                txtPresupuesto.Text = "Presupuesto: " + presupuesto;

                if (Usuario.usuarioActual.Username != "")
                {
                    Conexion.CrearPartidaBlackjack(apuesta);
                }

                c1 = b.robarCartaInglesa();
                cartas[0] = c1;
                btnCarta1.Show();
                btnCarta1.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + c1.RutaImg + ".png");
                co1 = b.robarCartaInglesa();
                btnCartaO1.Show();
                btnCartaO1.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + co1.RutaImg + ".png");
                c2 = b.robarCartaInglesa();
                cartas[1] = c2;
                btnCarta2.Show();
                btnCarta2.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + c2.RutaImg + ".png");
                co2 = b.robarCartaInglesa();
                btnCartaO2.Show();
                btnCartaO2.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\parteTrasera.png");
                txtValores.Text = funciones.actualizaValores(cartas);
                cantCartas = 2;

                if (funciones.blackJack(c1, c2) && funciones.blackJack(co1, co2))
                {
                    MessageBox.Show("Ninguno gana, ninguno pierde", "¡Doble Blackjack!");
                    inicio();
                }
                else if (co1.Numero == "A")
                {
                    DialogResult d;
                    d = MessageBox.Show("La casa tiene un as, ¿quieres comprar un seguro?", "¡Alerta!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (d == DialogResult.Yes)
                    {
                        presupuesto -= apuesta / 2;
                        if (funciones.blackJack(co1, co2))
                        {
                            MessageBox.Show("La casa hizo blackjack, por suerte tienes seguro", "Atencion",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            presupuesto += apuesta;
                            pierde();
                            return;
                        }
                    }
                }
                else if (funciones.blackJack(c1, c2))
                {
                    MessageBox.Show("¡Blackjack!", "¡Felicidades!");
                    gana();
                    return;
                }

                btnDoblar.Show();
                btnPedir.Show();
                btnPlantarse.Show();
                if (funciones.divide(c1, c2))
                {
                    btnDividir.Show();
                }
            }
            
        }
        private void btnNuevaApuesta_Click(object sender, EventArgs e)
        {
        }

        private void btnPlantarse_Click(object sender, EventArgs e)
        {
            cpu();
        }
        private void btnDoblar_Click(object sender, EventArgs e)
        {
            presupuesto -= apuesta;
            txtPresupuesto.Text = "Presupuesto: " + presupuesto;
            apuesta *= 2;
            txtApuesta.Text = "Apuesta: " + apuesta;
            c3 = b.robarCartaInglesa();
            btnCarta3.Show();
            btnCarta3.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + c3.RutaImg + ".png");
            Thread.Sleep(1);
            cartas[2] = c3;
            txtValores.Text = funciones.actualizaValores(cartas);
            if (funciones.superaLimite(cartas))
            {
                pierde();
                //return;
            }
            else
            {
                cpu();
                //return;
            }
        }
        private void btnDividir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta caracteristica todavía no está terminada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pierde() //Pregunta si quiere volver a jugar
        {
            if (Usuario.usuarioActual.Username != "")
            {
                int[] medallasAntiguas = Conexion.recibeMedallasProfile(Usuario.usuarioActual.Username);
                Conexion.CompletarPartidaBlackjack(false, 0);
                int[] medallasNuevas = Conexion.recibeMedallasProfile(Usuario.usuarioActual.Username);
                bool variaron = false;
                for(int x = 0; x < medallasAntiguas.Length; x++)
                {
                    if(medallasAntiguas[x] != medallasNuevas[x])
                    {
                        variaron = true;
                    }
                }
                if (variaron)
                {
                    MessageBox.Show("La cantidad de medallas que tenía aumentó" +
                        "\nVaya a su perfil a ver sus nuevas medallas", "Atención", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DialogResult d;
            d = MessageBox.Show("Quieres volver a jugar?", "¡Perdiste!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
            bool hizoBlackjack = false;
            if (funciones.blackJack(c1, c2))
            {
                ganancia = Convert.ToInt32(Convert.ToDouble(apuesta) * 2.5);
                presupuesto += ganancia;
                hizoBlackjack = true;
            }
            else
            {
                ganancia = apuesta * 2;
                presupuesto += ganancia;
            }
            txtPresupuesto.Text = "Presupusto: " + presupuesto;
            if (Usuario.usuarioActual.Username != "")
            {
                int[] medallasAntiguas = Conexion.recibeMedallasProfile(Usuario.usuarioActual.Username);
                Conexion.CompletarPartidaBlackjack(hizoBlackjack, ganancia);
                int[] medallasNuevas = Conexion.recibeMedallasProfile(Usuario.usuarioActual.Username);
                bool variaron = false;
                for (int x = 0; x < medallasAntiguas.Length; x++)
                {
                    if (medallasAntiguas[x] != medallasNuevas[x])
                    {
                        variaron = true;
                    }
                }
                if (variaron)
                {
                    MessageBox.Show("La cantidad de medallas que tenías aumentó" +
                        "\nVe a su perfil a ver tus nuevas medallas", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DialogResult d;
            d = MessageBox.Show("Quieres volver a jugar?", "¡Ganaste!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
            CartaInglesa[] cartasO = new CartaInglesa[7];
            cartasO[0] = co1;
            cartasO[1] = co2;
            int cartasTotal = co1.ValorCarta + co2.ValorCarta;
            int valorAGanar = funciones.valorAGanar(cartas);
            cantCartas = 2;
            btnCartaO2.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + co2.RutaImg + ".png");
            while (cantCartas <= 7 && (cartasTotal <= 17 || cartasTotal < valorAGanar))
            {
                switch (cantCartas)
                {
                    case 2:
                        co3 = b.robarCartaInglesa();
                        cartasTotal += co3.ValorCarta;
                        cartasO[2] = co3;
                        btnCartaO3.Show();
                        btnCartaO3.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + co3.RutaImg + ".png");
                        if (funciones.superaLimite(cartasO))
                        {
                            gana();
                            //return;
                        }
                        else
                        {
                            cantCartas++;
                        }
                        break;
                    case 3:
                        co4 = b.robarCartaInglesa();
                        cartasTotal += co4.ValorCarta;
                        cartasO[3] = co4;
                        btnCartaO4.Show();
                        btnCartaO4.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + co4.RutaImg + ".png");
                        if (funciones.superaLimite(cartasO))
                        {
                            gana();
                            //return;
                        }
                        else
                        {
                            cantCartas++;
                        }
                        break;
                    case 4:
                        co5 = b.robarCartaInglesa();
                        cartasTotal += co5.ValorCarta;
                        cartasO[4] = co5;
                        btnCartaO5.Show();
                        btnCartaO5.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + co5.RutaImg + ".png");
                        if (funciones.superaLimite(cartasO))
                        {
                            gana();
                            //return;
                        }
                        else
                        {
                            cantCartas++;
                        }
                        break;
                    case 5:
                        co6 = b.robarCartaInglesa();
                        cartasTotal += co6.ValorCarta;
                        cartasO[5] = co6;
                        btnCartaO6.Show();
                        btnCartaO6.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + co6.RutaImg + ".png");
                        if (funciones.superaLimite(cartasO))
                        {
                            gana();
                            //return;
                        }
                        else
                        {
                            cantCartas++;
                        }
                        break;
                    case 6:
                        co7 = b.robarCartaInglesa();
                        cartasTotal += co7.ValorCarta;
                        cartasO[6] = co7;
                        btnCartaO7.Show();
                        btnCartaO6.BackgroundImage = Image.FromFile(@"..\..\imagenes\blackjack\" + co7.RutaImg + ".png");
                        if (funciones.superaLimite(cartasO))
                        {
                            gana();
                            //return;
                        }
                        else
                        {
                            cantCartas++;
                        }
                        break;
                }
                //cantCartas++;
            }
            if (cartasTotal == valorAGanar)
            {
                MessageBox.Show("Ninguno gana, ninguno pierde", "¡Empate!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                inicio();
            }
            else if (cartasTotal < valorAGanar)
            {
                gana();
                //return;
            }
            else if (cartasTotal > valorAGanar && !funciones.superaLimite(cartasO))
            {
                pierde();
                //return;
            }
        }
        private void inicio() //Deja todos los objetos para el iniciar el juego
        {
            btnDividir.Hide();
            btnDoblar.Hide();
            btnPedir.Hide();
            btnPlantarse.Hide();

            btnCarta1.BackgroundImage = null;
            btnCarta2.BackgroundImage = null;
            btnCarta3.BackgroundImage = null;
            btnCarta4.BackgroundImage = null;
            btnCarta5.BackgroundImage = null;
            btnCarta6.BackgroundImage = null;
            btnCarta6.BackgroundImage = null;
            btnCartaO1.BackgroundImage = null;
            btnCartaO2.BackgroundImage = null;
            btnCartaO3.BackgroundImage = null;
            btnCartaO4.BackgroundImage = null;
            btnCartaO5.BackgroundImage = null;
            btnCartaO6.BackgroundImage = null;
            btnCartaO6.BackgroundImage = null;
            c1 = null;
            c2 = null;
            c3 = null;
            c4 = null;
            c5 = null;
            c6 = null;
            c7 = null;
            co1 = null;
            co2 = null;
            co3 = null;
            co4 = null;
            co5 = null;
            co6 = null;
            co7 = null;
            b.limpiarInglesas();
            for(int x = 0; x < cartas.Length; x++)
            {
                cartas[x] = null;
            }
            btnCarta1.Hide();
            btnCarta2.Hide();
            btnCarta3.Hide();
            btnCarta4.Hide();
            btnCarta5.Hide();
            btnCarta6.Hide();
            btnCarta7.Hide();
            btnCartaO1.Hide();
            btnCartaO2.Hide();
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
            txtValores.Text = "Valor de sus cartas: ";
            //apuesta = 0;
            txtApuesta.Text = "Apuesta: ";
        }
    }
}