using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory_Game_Project;

namespace prototype
{
    public partial class Hoofdmenu : Form
    {


        public Hoofdmenu()
        {
            InitializeComponent();

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nieuw_spel_klik(object sender, EventArgs e)
        {
            //todo (Jan) moet eigenlijk wat eleganter met parents en children ofzo
            Spel_bord spel_bord = new Spel_bord(this);
            Hide();
        }

        private void multiplayer_klik(object sender, EventArgs e)
        {

        }

        private void sluit_programma_klik(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
