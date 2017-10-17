using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory_Game_Project.Properties;
using prototype;

namespace Memory_Game_Project
{
    public partial class Spel_bord : Form
    {
        bool allowClick = true;
        PictureBox firstGuess;
        Random random = new Random();
        private Image[] plaatjes;
        private Image plaatje_achterkant;
        private Hoofdmenu hoofdmenu;


        public Spel_bord(Hoofdmenu hoofdmenu_arg)
        {
            InitializeComponent();
            plaatjes = get_plaatjes();
            plaatje_achterkant = get_achterkant();
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
            Spel_bord nieuw_spel_bord = new Spel_bord(hoofdmenu);
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

        // deze twee methods uit het spelobject gehaald omdat ze static moeten zijn?
        private Image[] get_plaatjes()
        {
            // get eerst de map voor het project en dan voor de plaatjes
            // (Jan)volgens mij werkt dit niet in gecompileerde code omdat je dan de Directory.GetCurrentDirectory() en niet de parent ervan
            String project_map = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName;
            String map_met_plaatjes = "\\Resources\\";

            // maakt een list met de filepath van de plaatjes
            String[] bestanden_in_map = Directory.GetFiles(project_map + map_met_plaatjes);
            string plaatjes_extenstie = ".png";
            List<string> plaatjes_filepaths = new List<string> { };
            foreach (String bestand in bestanden_in_map)
            {
                if (bestand.Contains(plaatjes_extenstie))
                {
                    plaatjes_filepaths.Add(bestand);
                }
            }

            // laad alle plaatjes in een array en returnt de array
            Image[] plaatjes = new Image[plaatjes_filepaths.Count];
            for (int i = 0; i < plaatjes_filepaths.Count; i++)
            {
                plaatjes[i] = Image.FromFile(plaatjes_filepaths[i]);
            }
            return plaatjes;
        }

        private Image get_achterkant()//todo (Jan) volgens mij genereert dit een leeg plaatje (niet zwart dus)
        {
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
    }
}


