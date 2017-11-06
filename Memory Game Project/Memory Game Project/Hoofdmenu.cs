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
using System.IO;
using System.Runtime.InteropServices;

namespace prototype
{
    public partial class Hoofdmenu : Form
    {
        string[] themas = new string[2] { "DC", "Marvel" };
        public static int themaIndex = 0;


        public Hoofdmenu()
        {
            InitializeComponent();
            huidige_thema_label.Text = themas[themaIndex];
            setup_combo_box();

        }        

        public void setup_combo_box()
        {
            themas_combobox.Items.Clear();
            themas_combobox.Items.Add("Marvel");
            themas_combobox.Items.Add("DC");
            string[] themas = Directory.GetDirectories(Utils.get_themas_dir());
            string base_path = Utils.get_themas_dir();

            for (int i = 0; i < themas.Length; i++)
            {
                themas_combobox.Items.Add(
                    themas[i].Replace(base_path, string.Empty)
                    );
            }
            themas_combobox.Text = "Marvel";
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void nieuw_spel_klik(object sender, EventArgs e)
        {
            //todo (Jan) moet eigenlijk wat eleganter met parents en children ofzo
            Spel_bord spel_bord = new Spel_bord(this, themas_combobox.Text);
            Hide();
        }

        private void multiplayer_klik(object sender, EventArgs e)
        {

        }

        private void verander_thema_klik(object sender, EventArgs e)
        {
            if (themaIndex == 0)
            {
                themaIndex++;
            }
            else
            {
                themaIndex--;
            }
            huidige_thema_label.Text = themas[themaIndex];
        }

        private void sluit_programma_klik(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void open_maak_thema(object sender, EventArgs e)
        {

            Thema_Ontwerper thema_ontwerper = new Thema_Ontwerper(this);
            Hide();
        }

        private void Hoofdmenu_Load(object sender, EventArgs e)
        {

        }

        private void themas_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}