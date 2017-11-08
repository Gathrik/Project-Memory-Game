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
using Memory_Game_Project.Properties;

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

        public void SpawnCards()
        {
            double square;

            int pointx = 0;
            int pointy = 0;
            int total = 16;

            string[] imgs = new string[] { "Image1", "Image2", "Image3", "Image4", "Image5", "Image6", "Image7", "Image8", "Image1", "Image2", "Image3", "Image4", "Image5", "Image6", "Image7", "Image8" };

            int picsize = 75;

            square = Math.Sqrt(total);

            for (int j = 0; j < 16; j++)
            {
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Location = new System.Drawing.Point(pointx, pointy);
                pictureBox1.Name = "pictureBox";
                pictureBox1.Size = new System.Drawing.Size(picsize, picsize);
                pictureBox1.BackColor = Color.Black;

                //pictureBox1.Image = global::MatchingGame.Properties.Resources.Image1;

                //object O = Resources.ResourceManager.GetObject(imgs[CardIndex[j]]);
                object O = Resources.ResourceManager.GetObject(imgs[j]);
                pictureBox1.Image = (Image)O;



                Controls.Add(pictureBox1);

                if (pointx == ((square * picsize) - picsize))
                {
                    pointx = 0;
                    pointy += picsize;
                }
                else
                {
                    pointx += picsize;
                }
            }
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
            string naamspeler1 = textBox1.Text;
            string naamspeler2 = textBox2.Text;
            //todo (Jan) moet eigenlijk wat eleganter met parents en children ofzo

            //Spel_bord spel_bord = new Spel_bord(this, textBox1.Text, textBox2.Text);

            SpawnCards();
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
        private void highscores_klik(object sender, EventArgs e)
        {
            Highscores highscores = new Highscores();
            Hide();
            highscores.Show();
        }
    }
}