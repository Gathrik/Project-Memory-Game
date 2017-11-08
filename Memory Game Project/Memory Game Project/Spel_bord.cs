using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.Versioning;
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
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;
using Memory_Game_Project;

// ReSharper disable All


namespace Memory_Game_Project
{
    public partial class Spel_bord : Form
    {
        bool allowClick = true;
        string themaExtensie;
        PictureBox firstGuess;
        Random random = new Random();
        private Image[] plaatjes;
        private Image plaatje_achterkant;
        private Hoofdmenu hoofdmenu;
        PictureBox vorig_kaartje = null;
        bool omgedraait = false;
        bool speler1_aan_de_beurt = true;
       
        
        
        // (Jan)volgens mij werkt dit niet in gecompileerde code omdat je dan de Directory.GetCurrentDirectory() en niet de parent ervan
        String project_map = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName;


        public Spel_bord(Hoofdmenu hoofdmenu_arg, string naam_speler1_arg, string naam_speler2_arg)
        {
            InitializeComponent();
            naamspeler1.Text = naam_speler1_arg;
            naamspeler2.Text = naam_speler2_arg;
            checkThema();
            plaatjes = get_plaatjes();
            //plaatje_achterkant = get_achterkant();
            hoofdmenu = hoofdmenu_arg;
            RandomizePictures();
            hideImages();
            geef_events();
            speleraandebeurttext();
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
            Spel_bord nieuw_spel_bord = new Spel_bord(hoofdmenu, naamspeler1.Text, naamspeler2.Text);
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
            PictureBox huidig_plaatje = (sender as PictureBox);
            // bug je kan plaatjes meerdere keren omdraaien
            // todo beide spelers krijgen steeds een punt
            // todo als steeds op een plaatje klikt krijgt je punten

            if (huidig_plaatje.Image != huidig_plaatje.Tag )
            {
                draaiplaatjeom(huidig_plaatje);
                if (vorig_kaartje == null)
                {
                    vorig_kaartje = huidig_plaatje;
                }
                else
                {
                    if (vorig_kaartje.Tag == huidig_plaatje.Tag)
                    {
                        if (speler1_aan_de_beurt)
                        {
                            geef_speler1_punt();
                        }
                        else
                        {
                            geef_speler2_punt();
                        }
                        bool spel_klaar = true;
                        foreach(PictureBox box in pictureBoxes)
                        {
                            if (box.Image != box.Tag)
                            {
                                spel_klaar = false;
                                break;
                            }
                        }
                        if (spel_klaar)
                        {
                            einde_spel();
                        }
                        vorig_kaartje = null;
                    }
                    else
                    {
                        if (speler1_aan_de_beurt)
                        {
                            speler1_aan_de_beurt = false;
                        }
                        else
                        {
                            speler1_aan_de_beurt = true;
                        }
                        draai_kaartjes_weer_om(huidig_plaatje, vorig_kaartje, 5);
                        speleraandebeurttext();
                    }
                }
            }
        }

        private void speleraandebeurttext()
        {
            if (speler1_aan_de_beurt)
            {
                aan_de_beurt_label.Text = naamspeler1.Text + " is aan de beurt";

            }
            else
            {
                aan_de_beurt_label.Text = naamspeler2.Text + " is aan de beurt";

            }
        }

       
        private async void draai_kaartjes_weer_om(PictureBox kaartje1, PictureBox kaartje2, int seconden_wachtijd)
        {
            
            await Task.Delay(seconden_wachtijd * 100);
            draaiplaatjeom(kaartje1);
            draaiplaatjeom(kaartje2);
            vorig_kaartje = null;
        }

        private void geef_speler1_punt()
        {
            double score = double.Parse(Scorespeler1.Text);
            score = ( score + 2);
            score = (score - 1);

          
            
            Scorespeler1.Text = score.ToString();
            
        }

        private void geef_speler2_punt()
        {


            int score2 = int.Parse(Scorespeler2.Text);
            score2++;
            
            Scorespeler2.Text = score2.ToString();


        }
        private void draaiplaatjeom(PictureBox box)
        {

            if ((box as PictureBox).Image == plaatje_achterkant)
            {
                (box as PictureBox).Image = (Image)(box as PictureBox).Tag;
            }
            else
            {
                (box as PictureBox).Image = plaatje_achterkant;
            }
        }

        private void einde_spel()
        {
            Console.WriteLine("einde spel");
        }

        private Image[] get_plaatjes()
        {
            // get eerst de map voor het project en dan voor de plaatjes
            // (Jan)volgens mij werkt dit niet in gecompileerde code omdat je dan de Directory.GetCurrentDirectory() en niet de parent ervan
            String project_map = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName;
            String map_met_plaatjes = "\\Resources\\";

            // maakt een list met de filepath van de plaatjes
            String[] bestanden_in_map = Directory.GetFiles(project_map + map_met_plaatjes);
            List<string> plaatjes_filepaths = new List<string> { };
            foreach (String bestand in bestanden_in_map)
            {
                if (bestand.Contains(themaExtensie))
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

        private void checkThema() // (Garik) Weet niet wat beter is, een if statement of gewoon switches
        {
            /* if (Hoofdmenu.themaIndex == 0)
             {
                 themaExtensie = "_dc.png";
             } else
             {
                 themaExtensie = "_marvel.png";
             } */

            int themaSwitch = Hoofdmenu.themaIndex;

            switch (themaSwitch)
            {
                case 0:
                    plaatje_achterkant = Resources.dc_icon;
                    themaExtensie = "_dc.png";
                    break;
                case 1:
                    plaatje_achterkant = Resources.marvel_icon;
                    themaExtensie = "_marvel.png";
                    break;
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

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void aan_de_beurt_label_Click(object sender, EventArgs e)
        {

        }
    }
}