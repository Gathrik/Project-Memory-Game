﻿using System;
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
        Random random = new Random();
        private Image[] plaatjes;
        private Image plaatje_achterkant;
        private Hoofdmenu hoofdmenu;
        PictureBox vorig_kaartje = null;
        bool speler1_aan_de_beurt = true;
        string thema;


        public Spel_bord(Hoofdmenu hoofdmenu_arg, string naam_speler1_arg, string naam_speler2_arg, string thema_arg)
        {
            thema = thema_arg;
            InitializeComponent();
            naamspeler1.Text = naam_speler1_arg;
            naamspeler2.Text = naam_speler2_arg;
            checkThema();
            //plaatjes = get_plaatjes();
            //plaatje_achterkant = get_achterkant();
            hoofdmenu = hoofdmenu_arg;
            RandomizePictures();

            hideImages();
            geef_events();
            speleraandebeurttext();
            Show();

            einde_spel();
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
            Spel_bord nieuw_spel_bord = new Spel_bord(hoofdmenu, naamspeler1.Text, naamspeler2.Text, thema);
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
            string highscore_bestand = Utils.get_highscores_file();
            //naamspeler1 en 2


            File.AppendText(highscore_bestand).Close();
            System.IO.File.AppendAllText(highscore_bestand, get_winnaar_tekst());
            //speler1_aan_de_beurt is true als speler 1 aan de beurt is else false
           
        }

        private string get_winnaar_tekst()
        {
            int defScore1 = int.Parse(Scorespeler1.Text);
            int defScore2 = int.Parse(Scorespeler2.Text);

            int highscore;
            string winnaar;

            if (defScore1 > defScore2)
            {
                highscore = defScore1;
                winnaar = naamspeler1.Text;

            }
            else if (defScore1 < defScore2)
            {
                highscore = defScore2;
                winnaar = naamspeler2.Text;
            }
            else
            {
                highscore = defScore2;
                winnaar = naamspeler2.Text;
            }
            return string.Format("{0},{1}{2}", winnaar, highscore, Environment.NewLine);
        }
/* (JAN)DEPRECATED
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
        }*/

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
                ret_plaatjes[i] = Image.FromFile(thema_map + (i + 1).ToString() + plaatjes_exstentsie);
            }
            plaatje_achterkant = Image.FromFile(thema_map + "ACHTERKANT" + plaatjes_exstentsie);

            plaatjes = ret_plaatjes;
        }

/* (JAN)DEPRECATED
        private Image get_test_achterkant()
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
        }*/

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