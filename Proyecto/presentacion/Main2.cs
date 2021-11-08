﻿using Proyecto.logica;
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
using Microsoft.VisualBasic;

namespace Proyecto.presentacion
{
    public partial class Main2 : Form
    {
        public Main2()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(Register_Closing);
            void Register_Closing(object sender, CancelEventArgs e)
            {
                Conexion.Conectado(Usuario.usuarioActual.Username, 0);
                Application.Exit();
            }
            List<string> usuarios = Conexion.devuelveUsernames();
            foreach (string user in usuarios)
            {
                int n = gridUsernames.Rows.Add();
                gridUsernames.Rows[n].Cells[0].Value = user;
            }
        }

        private void Main2_Load(object sender, EventArgs e)
        {

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (Usuario.usuarioActual.Administrador)
            {
                AdminPanel a = new AdminPanel();
                a.Show();
                base.Hide();
            }
            else
            {
                MessageBox.Show("You do not have administrator permissions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            PruebaPersistencia p = new PruebaPersistencia();
            p.Show();
            base.Hide();
        }

        private void btnBlackjack_Click(object sender, EventArgs e)
        {
            Blackjack b = new Blackjack(false);
            b.Show();
            base.Hide();
        }

        private void btnTruco_Click(object sender, EventArgs e)
        {
            Truco t = new Truco(false, Usuario.usuarioActual, null);
            t.Show();
            base.Hide();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Are you sure you want leave? " +
                "\nYou're gonna lose your profile pic", "Wait", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                Main f = new Main();
                f.Show();
                base.Hide();
            }
        }

        private void btnAgregarAmigos_Click(object sender, EventArgs e)
        {
            Conexion.agregarAmigo(gridUsernames.CurrentCell.Value.ToString());
        }
    }
}