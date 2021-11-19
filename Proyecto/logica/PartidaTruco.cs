﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.logica
{
    class PartidaTruco
    {
        public PartidaTruco(int id, string j1, string j2, bool t) //si tipo es false es contra la CPU, sino online
        {
            idPartida = id;
            jugador1 = j1;
            jugador2 = j2;
        }
        //Tanteador parcial que se va a ir actualizando
        private int idPartida;
        private string jugador1, jugador2, ganador;
        private bool tipo;

        public int IdPartida
        {
            get { return idPartida; }
            set { idPartida = value; }
        }
        public string Jugador1
        {
            get { return Jugador1; }
            set { jugador1 = value; }
        }
        public string Jugador2
        {
            get { return Jugador2; }
            set { jugador2 = value; }
        }
        public bool Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Ganador
        {
            get { return ganador; }
            set { ganador = value; }
        }
    }
}