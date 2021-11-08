using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.logica
{
    class PartidaTruco
    {
        //Hacer esta clase como la CartaEspañola (tiene atributos con sus gettrs
        //y setters para guardarlos y pasarlos a la base de datos)
        public PartidaTruco(int id, Usuario j1, Usuario j2, bool t) //si tipo es false es contra la CPU, sino online
        {
            idPartida = id;
            jugador1 = j1;
            jugador2 = j2;
        }
        //Tanteador parcial que se va a ir actualizando
        private int idPartida;
        private Usuario jugador1, jugador2;
        private bool tipo;

        public int IdPartida
        {
            get { return idPartida; }
            set { idPartida = value; }
        }
        public Usuario Jugador1
        {
            get { return Jugador1; }
            set { jugador1 = value; }
        }
        public Usuario Jugador2
        {
            get { return Jugador2; }
            set { jugador2 = value; }
        }
        public bool Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}