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
    public partial class Guest : Form
    {
        public Guest()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(Register_Closing);
            void Register_Closing(object sender, CancelEventArgs e)
            {
                Application.Exit();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Main f = new Main();
            f.Show();
            base.Hide();
        }

        private void btnBlackjack_Click(object sender, EventArgs e)
        {
            Blackjack b = new Blackjack(true);
            b.Show();
            base.Hide();
        }

        private void btnTruco_Click(object sender, EventArgs e)
        {
            Truco t = new Truco(true, null, null);
            t.Show();
            base.Hide();
        }
    }
}
