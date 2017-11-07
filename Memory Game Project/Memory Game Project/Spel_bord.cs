using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory_Game_Project.Properties;
using prototype;
using System.IO.Compression;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;

// ReSharper disable All


namespace Memory_Game_Project
{
    public partial class Spel_bord : Form
    {
        bool allowClick = true;
        string thema;
        PictureBox firstGuess;
        Random random = new Random();
        private Image[] plaatjes;
        private Image plaatje_achterkant;
        private Hoofdmenu hoofdmenu;

        // (Jan)volgens mij werkt dit niet in gecompileerde code omdat je dan de Directory.GetCurrentDirectory() en niet de parent ervan
        String project_map = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName;


        public Spel_bord(Hoofdmenu hoofdmenu_arg, string thema_arg)
        {
            InitializeComponent();
            thema = thema_arg;
            Console.WriteLine(thema_arg);
            checkThema();
            //plaatjes = get_plaatjes();
            //plaatje_achterkant = get_achterkant();
            hoofdmenu = hoofdmenu_arg;
            RandomizePictures();
            hideImages();
            geef_events();
            Show();
        }

        private void geef_events()
        {
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                pictureBoxes[i].Click += new EventHandler(picturebox_klik);
            }
        }


        private PictureBox[] pictureBoxes
        {
            get
            {
                return Controls.OfType<PictureBox>().ToArray();
            }
        }

        private void hideImages() // (Jan) draai de kaartjes om
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Image = plaatje_achterkant;
            }
        }

        private PictureBox plaatsen()
        {// (Jan) plaatsen() en RandomizePictures geven elke picturebox een random plaatje ALS DE TAG EIGENSCHAP
            int nummerIndex;
            do
            {
                nummerIndex = random.Next(0, pictureBoxes.Length);
            }
            while (pictureBoxes[nummerIndex].Tag != null);
            return pictureBoxes[nummerIndex];
        }

        private void RandomizePictures()
        {// (Jan) plaatsen() en RandomizePictures geven elke picturebox een random plaatje ALS DE TAG EIGENSCHAP
            foreach (var image in plaatjes)
            {
                plaatsen().Tag = image;
                plaatsen().Tag = image;
            }
        }


        private void restart_click(object sender, EventArgs e)
        {// (Jan) deze methode herstart het spel door een nieuw spelbord  te instantieren
            Spel_bord nieuw_spel_bord = new Spel_bord(hoofdmenu, thema);
            Hide();
            Dispose();
        }

        private void terug_naar_hoofdmenu_clik(object sender, EventArgs e)
        {
            hoofdmenu.Show();
            Hide();
            Dispose();
        }

        private void kruisje_klik(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void picturebox_klik(object sender, EventArgs e)
        {// (Jan) draait de kaartjes om
            if ((sender as PictureBox).Image == plaatje_achterkant)
            {
                (sender as PictureBox).Image = (Image)(sender as PictureBox).Tag;
            }
            else
            {
                (sender as PictureBox).Image = plaatje_achterkant;
            }
        }

        private void get_standaard_thema()
        {
            Image[] ret_plaatjes = new Image[8];
            switch (thema)
            {
                case "DC":
                {
                    ret_plaatjes = new Image[]{
                        Resources.aquaman_dc,
                        Resources.batman_dc,
                        Resources.cyborg_dc,
                        Resources.flash_dc,
                        Resources.lantern_dc,
                        Resources.martian_dc,
                        Resources.superman_dc,
                        Resources.wonder_woman_dc
                    };
                    break;
                }

                case "Marvel":
                {
                    ret_plaatjes = new Image[]
                    {
                        Resources.black_panther_marvel,
                        Resources.captain_america_marvel,
                        Resources.dr_strange_marvel,
                        Resources.hulk_marvel,
                        Resources.ironman_marvel,
                        Resources.spiderman_marvel,
                        Resources.thor_marvel,
                        Resources.marvelicon_marvel
                    };
                    break;
                }
            }
            plaatjes = ret_plaatjes;
        }

        private void load_custom_thema()
        {
            string thema_map = Utils.get_themas_dir() + thema + @"\";
            int plaatjes_op_bord = 8;
            string plaatjes_exstentsie = ".png";
            Image[] ret_plaatjes = new Image[plaatjes_op_bord];

            for (int i = 0; i < plaatjes_op_bord; i++)
            {
                ret_plaatjes[i] = Image.FromFile(thema_map + (i+1).ToString() + plaatjes_exstentsie);
            }
            plaatje_achterkant = Image.FromFile(thema_map + "ACHTERKANT" + plaatjes_exstentsie);

            plaatjes = ret_plaatjes;
        }

        private void checkThema()
        {

            if (thema == "DC")
            {
                plaatje_achterkant = Resources.dc_icon;
                get_standaard_thema();
            }
            else if (thema == "Marvel")
            {
                plaatje_achterkant = Resources.marvel_icon;
                get_standaard_thema();
            }
            else
            {
                load_custom_thema();
            }
        }

        private Image get_test_achterkant()
        {//momenteel niet in gebruik
            // genereert een geheel zwart plaatje voor de achterkant van de kaartjes
            int hoogte_en_breete = 150;// de groote van het plaatje
            Image achterkant = new Bitmap(hoogte_en_breete, hoogte_en_breete, PixelFormat.Format24bppRgb);

            using (Graphics gfx = Graphics.FromImage(achterkant))
            {
                gfx.FillRectangle(
                    Brushes.Black, 0, 0, hoogte_en_breete, hoogte_en_breete);
            }
            return achterkant;
        }

        private void opslaan_test(object sender, EventArgs e)
        {
            
            Spel_Opslag.save_spel(pictureBoxes, plaatje_achterkant, "speler 1 test",
                "speler 2 test", "");
        }

        private void load_test(object sender, EventArgs e)
        {
            Object[] temp = Spel_Opslag.load_spel("");
            Image[] plaatjes = (Image[])temp[0];
            bool[] omgedraait = (bool[])temp[1];
            Image achterkant = (Image)temp[2];
            string[] spelers_naam_score = (string[]) temp[3];

            for (int i = 0; i < plaatjes.Length; i++)
            {
                pictureBoxes[i].Tag = plaatjes[i];
                if (omgedraait[i])
                {
                    pictureBoxes[i].Image = plaatjes[i];
                }
                else
                {
                    pictureBoxes[i].Image = achterkant;
                }
            }

            plaatje_achterkant = achterkant;
            Console.WriteLine("spel geladen");
        }

    }
}