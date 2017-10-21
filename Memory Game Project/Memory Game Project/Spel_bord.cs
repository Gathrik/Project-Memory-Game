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

        // (Jan)volgens mij werkt dit niet in gecompileerde code omdat je dan de Directory.GetCurrentDirectory() en niet de parent ervan
        String project_map = Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.FullName;


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

        private Image[] get_plaatjes()
        {
            // get eerst de map voor het project en dan voor de plaatjes
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

        private Image get_achterkant()
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

        private void opslaan_test(object sender, EventArgs e)
        {
            Spel_Opslag.save_spel(pictureBoxes, plaatje_achterkant, "speler 1 test",
                "speler 2 test", "", project_map);
        }

        private class Spel_Opslag
        {
            //TODO (Jan) kan dit static?
            public static void save_spel(PictureBox[] kaartjes, Image achterkant, string speler_1_naam_score,
                    string speler_2_naam_score, string filepath,  string project_map)
            /* (Jan) door deze methode to callen sla je het spel op.
             * de methode gebruikt de volgende args:
             *
             * achterkant is het plaatje dat gebruikt is voor de achterkant
             *
             * filepath: het filepath waar het bestand opgeslagen zal worden.
             * als opslapath leeg is word het spel op de autosave locatie opgeslagen.
             *
             * kaartjes: een 1d array van de pictureboxes
             *
             * speler 1 en 2 naam en score: een string met de naam en de score van elke speler
             * bijvoorbeeld: "Anna score: 15"
             *
             * project_map: de root map van het project
             * als opslapath niet leeg is word dit genegeerd
             *
             * TODO (Jan) ondersteuning voor themas?
             */
            {
                /* todo maak het .sav bestand een zip,
                 * de status van het spelbord worden in een textbestand opgeslagen.
                 * in dat zelfde zip bestand
                 * todo moeten de plaatjes worden geresized om opslaan/laden sneller te maken?
                 */

                string save_bestand = resolve_path(filepath, project_map);

                int imgs_index = 1;
                int omgedraait_index = 0;

                Object[,] kaart_data = new Object[kaartjes.Length, 2];
                // de eerste collom is de plaatjes de tweede collom is een bool of het omgedraait is
                for (int i = 0; i < kaartjes.Length; i++)
                {
                    if (kaartjes[i].Image == (Image)kaartjes[i].Tag)
                    {
                        kaart_data[i, omgedraait_index] = true;
                    }
                    else
                    {
                        kaart_data[i, omgedraait_index] = false;
                    }

                    kaart_data[i, imgs_index] = kaartjes[i].Tag as Image;
                }

                //save the data
                using (var memoryStream = new MemoryStream())
                {
                    //creates the archive
                    using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        //slaat de tekst op
                        var tekst_bestand = zip.CreateEntry("savetext.txt");

                        using (var entryStream = tekst_bestand.Open())
                        {
                            using (var streamWriter = new StreamWriter(entryStream))
                            {
                                List<string> save_tekst = create_save_text(kaart_data, speler_1_naam_score, speler_2_naam_score);
                                foreach (string line in save_tekst)
                                {
                                    streamWriter.Write(line + Environment.NewLine);
                                }
                            }
                        }



                        //slaat de plaatjes op
                        //todo(Jan) dit kan vast beter
                        for (int i = 0; i < kaart_data.GetLength(0); i++)
                        {
                            Image img = kaart_data[i, imgs_index] as Image;

                            var bestand = zip.CreateEntry(i + ".bmp");

                            using (var stream = new MemoryStream())
                            {
                                img.Save(stream, ImageFormat.Bmp);
                                using (var entryStream = bestand.Open())
                                {
                                    //todo werkt nog niet
                                    stream.CopyTo(entryStream);
                                }

                            }

                            /*using (var entryStream = bestand.Open())
                            {
                                using (var streamWriter = new StreamWriter(entryStream))
                                {
                                    using (var stream = new MemoryStream())
                                    {
                                        img.Save(stream, img.RawFormat);
                                        streamWriter.Write(stream);
                                    }

                                }
                            }*/
/*                            using (MemoryStream tempstream = new MemoryStream())
                            {
                                img.Save(tempstream, ImageFormat.Png);
                                tempstream.Seek(0, SeekOrigin.Begin);
                                byte[] imageData = new byte[tempstream.Length];
                                tempstream.Read(imageData, 0, imageData.Length);

                            }*/
                        }
                    }

                    //saves the archive to disk
                    using (var fileStream = new FileStream(@"C:\Temp\test.zip", FileMode.Create))
                    {
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        memoryStream.CopyTo(fileStream);
                    }
                }
            }

            private static MemoryStream img_naar_bytes(Image img)
            {

                using (MemoryStream tempstream = new MemoryStream())
                {
                    img.Save(tempstream, ImageFormat.Png);
                    tempstream.Seek(0, SeekOrigin.Begin);
                    byte[] imageData = new byte[tempstream.Length];
                    tempstream.Read(imageData, 0, imageData.Length);
                    return tempstream;
                }
            }

            private static List<string> create_save_text(Object[,] kaart_data, string speler_1_naam_score,
                        string speler_2_naam_score)
            {
                string eindtext = "#END";

                List<string> save_text = new List<string>();

                save_text.Add("#NAMEN+SCORES");
                save_text.Add(speler_1_naam_score);
                save_text.Add(speler_2_naam_score);
                save_text.Add(eindtext);
                save_text.Add("#OMGEDRAAIT");

                for (int i = 0; i < kaart_data.GetLength(0); i++)
                {
                    save_text.Add(kaart_data[i, 0].ToString());
                }
                save_text.Add(eindtext);
                return save_text;
            }

            public static List<object> load_spel(string filepath, string project_map)
            /* deze methode laad een opgeslagen spel
             * de methode gebruikt de volgende args:
             *
             * filepath is het path naar het spel dat geladen moet worden
             * als dit leeg is word het autosave bestand geladen
             *
             * project_map: de root map van het project
             * als opslapath niet leeg is word dit genegeerd
             *
             * returns een list waarin [0] is PictureBox[] kaartjes
             * [1] is string speler_1_naam_score,
             * en [2] is string speler_2_naam_score
             */
            {

                filepath = resolve_path(filepath, project_map);
                return new List<object>(1);//todo placeholder
            }

            private static string resolve_path(string path, string project_map)
            // als het path leeg is returnt dit het autosave path
            {
                if (path == "")
                {
                    return project_map + "\\saves\\autosave.sav";
                }
                return path;
            }
        }
    }
}


