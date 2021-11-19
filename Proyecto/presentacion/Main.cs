using Proyecto.presentacion;
using Proyecto.logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.persistencia;

namespace Proyecto
{
    public partial class Main : Form
    {
        
        public Main()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(Register_Closing);
            void Register_Closing(object sender, CancelEventArgs e)
            {
                Application.Exit();
            }
            dataGridView1.Hide();
            dataGridView2.Hide();
            /*List<string>[] usuarios = Conexion.estadistica1Username();
            foreach (string user in usuarios[0])
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = user;
            }
            foreach (string user in usuarios[1])
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[1].Value = user;
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            base.Hide();
        }

        private void btnEN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon...","",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnES_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            Guest g = new Guest();
            g.Show();
            base.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Registro r = new Registro();
            r.Show();
            base.Hide();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}