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
using System.Security.Cryptography;
using System.Windows.Forms.VisualStyles;
// ReSharper disable All

namespace Memory_Game_Project
{
    public class Spel_Opslag
    {
        static private string temp_bestand = "temp";
        static private string autosave_bestand = "autosave.sav";
        static private string text_bestand_name = "savetext.txt";
        static private string plaatjes_extenstie = ".png";
        static private ImageFormat plaatjes_format = ImageFormat.Png;
        static private bool encyptie = true;

        public static void save_spel(PictureBox[] kaartjes, Image achterkant, int omgedraaide_box_index, string speler_1_naam_score,
                string speler_2_naam_score, bool speler1_aan_de_beurt, string filepath)

        {
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
            * todo (Jan) een spel opslaan als de saves map niet bestaad veroorzaakt een crash
            * */
            /*
             * de status van het spelbord worden in een textbestand opgeslagen.
             * in dat zelfde zip bestand
             */

            string save_bestand = resolve_path(filepath);
            int imgs_index = 1;//(Jan) de array index waar de plaatjes worden opgeslagen
            int omgedraait_index = 0;
            int no_kaartjes = kaartjes.Length;
            int plaatje_resolutie = 200;

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

                kaart_data[i, imgs_index] = Utils.ResizeImage((kaartjes[i].Tag as Image), plaatje_resolutie, plaatje_resolutie);
            }

            //achterkant is een argument en word door gepassed
            save_naar_zip(save_bestand, imgs_index, kaart_data, achterkant, omgedraaide_box_index, speler_1_naam_score, speler_2_naam_score, speler1_aan_de_beurt, no_kaartjes);
            Console.WriteLine("opgeslagen");
        }

        public static object[] load_spel(string zip_filepath)
        {
            /* deze methode laad een opgeslagen spel
         * de methode gebruikt de volgende args:
         *
         * filepath is het path naar het spel dat geladen moet worden
         * als dit leeg is word het autosave bestand geladen
         *
         * project_map: de root map van het project
         * als opslapath niet leeg is word dit genegeerd
         *
         * returns een list waarin
         * [0] is PictureBox[] kaartjes
         * [1] is een bool[] waarin staat of een plaatje is omgedraait
         * [2] is het plaatje voor de achterkant.
         * [3] is een string array met speler 1 en 2 naam_score als 0 en 1
         * [4] is een bool die true is als speler 1 aan de beurt is
         * [5] is een de index van de omgedraaide box als er 1 was anders <0
         * todo (Jan) een spel laden met een fout path veroorzaakt een crash
         */

            zip_filepath = resolve_path(zip_filepath);

            String[] save_tekst;
            try
            {
                save_tekst = get_save_tekst(zip_filepath);
            }
            catch
            {
                Console.WriteLine("kan bestand niet lezen. is het encrypted?");
                Encryption.decrypt_save(zip_filepath);
                save_tekst = get_save_tekst(zip_filepath);
            }
            //parses tekst
            Object[] temp = parse_save_tekst(save_tekst);
            int aantal_plaatjes = (int)temp[0];
            string[] spelers_naam_score = (string[])temp[1];
            bool[] kaart_omgedraait = (bool[])temp[2];
            bool speler1_aan_de_beurt = (bool)temp[3];
            int omgedraaide_box_index = (int)temp[4];

            //loads plaatjes
            Image[] temp_plaatjes = laad_plaatjes(aantal_plaatjes, zip_filepath);//het achterste plaatje is de achterkant
            Image[] plaatjes = new Image[temp_plaatjes.Length - 1];
            for (int i = 0; i < aantal_plaatjes; i++)
            {
                plaatjes[i] = temp_plaatjes[i];
            }
            Image achterkant = temp_plaatjes[temp_plaatjes.Length - 1];

            //maakt pictureboxes
            PictureBox[] picture_boxes = get_pictureboxes(plaatjes, achterkant, kaart_omgedraait);

            Object[] retrn = new object[6];
            retrn[0] = plaatjes;
            retrn[1] = kaart_omgedraait;
            retrn[2] = achterkant;
            retrn[3] = spelers_naam_score;
            retrn[4] = speler1_aan_de_beurt;
            retrn[5] = omgedraaide_box_index;

            return retrn;
        }


        private static void save_naar_zip(string save_bestand, int imgs_index, Object[,] kaart_data, Image achterkant,
            int omgedraaide_box_index, string speler_1_naam_score, string speler_2_naam_score, bool speler1_aan_de_beurt, int no_kaartjes)
        {
            //saves het spel
            using (var memoryStream = new MemoryStream())
            {
                //creates the archive
                using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    //slaat de tekst op
                    var tekst_bestand = zip.CreateEntry(text_bestand_name);

                    using (var entryStream = tekst_bestand.Open())
                    {
                        using (var streamWriter = new StreamWriter(entryStream))
                        {
                            List<string> save_tekst = create_save_text(kaart_data,  omgedraaide_box_index, speler_1_naam_score,
                                speler_2_naam_score, speler1_aan_de_beurt, no_kaartjes);
                            foreach (string line in save_tekst)
                            {
                                streamWriter.Write(line + Environment.NewLine);
                            }
                        }
                    }

                    //slaat de plaatjes op
                    //slaat de voorkant op
                    for (int i = 0; i < kaart_data.GetLength(0); i++)
                    {
                        Image img = kaart_data[i, imgs_index] as Image;
                        Byte[] bytes = img_naar_bytes(img);

                        var bestand = zip.CreateEntry(i + plaatjes_extenstie);
                        using (var entryStream = bestand.Open())
                        {
                            entryStream.Write(bytes, 0, bytes.Length);
                        }
                    }
                    //slaat de achterkant op
                    Byte[] bytes2 = img_naar_bytes(achterkant);

                    var bestand2 = zip.CreateEntry("ACHTERKANT" + plaatjes_extenstie);
                    using (var entryStream = bestand2.Open())
                    {
                        entryStream.Write(bytes2, 0, bytes2.Length);
                    }
                }

                //saves the archief
                using (var fileStream = new FileStream(save_bestand, FileMode.Create))
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.CopyTo(fileStream);
                }
            }
            if (encyptie)
            {
                Encryption.encrypt_save(save_bestand);
            }
        }

        private static Byte[] img_naar_bytes(Image img)
        {
            Byte[] bytes;
            using (var stream = new MemoryStream())
            {
                img.Save(stream, plaatjes_format);
                bytes = stream.ToArray(); //to keep it as image better to have it as bytes
            }
            return bytes;
        }

        private static List<string> create_save_text(Object[,] kaart_data, int omgedraaide_box_index, string speler_1_naam_score,
            string speler_2_naam_score, bool speler1_aan_de_beurt, int no_kaartjes)
        { /* een regel met een / aan het begin is een comment*/
            string eindtext = "#END";

            List<string> save_text = new List<string>();

            save_text.Add("#SPELER1_AAN_BEURT");
            save_text.Add(speler1_aan_de_beurt.ToString());
            save_text.Add(eindtext);

            save_text.Add("#OMGEDRAAIDE_BOX_INDEX");
            save_text.Add(omgedraaide_box_index.ToString());
            save_text.Add(eindtext);

            save_text.Add("#NO_KAARTJES");
            save_text.Add(no_kaartjes.ToString());
            save_text.Add(eindtext);

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

        private static PictureBox[] get_pictureboxes(Image[] plaatjes, Image achterkant, bool[] kaart_omgedraait)
        {//(Jan) deprecated niet meer in gebruik
            List<PictureBox> picture_boxes = new List<PictureBox>();

            for (int i = 0; i < kaart_omgedraait.Length; i++)
            {
                PictureBox temp_box = new PictureBox();
                temp_box.Tag = plaatjes[i];
                if (kaart_omgedraait[i])//als het plaatje naar boven ligt
                {
                    temp_box.Image = (Image)temp_box.Tag;
                }
                else
                {
                    temp_box.Image = achterkant;
                }
                picture_boxes.Add(temp_box);
            }
            return picture_boxes.ToArray();
        }

        private static Object[] parse_save_tekst(String[] save_tekst)
        {
            // parst het tekst bestand naar game data
            // returnt een List<Object> met het volgende
            // 0 = een int met het aantal plaatjes in het bestand
            // 1 = een string[] met speler 1 en 2 naam en score
            // 2 = een bool[] of een kaartje op die index is omgedraait of niet

            int aantal_plaatjes = new int();
            string[] spelers_naam_score = new string[] { "", "" };
            List<bool> kaart_omgedraait_list = new List<bool>();
            bool speler1_aan_de_beurt = new bool();
            int omgedraaide_box_index = new int();

            bool reading_no_kaartjes = false;
            bool reading_namen_en_scores = false;
            bool reading_kaart_omgedraait = false;
            bool reading_speler1_aan_de_beurt = false;
            bool reading_omgedraaide_box_index = false;

            foreach (string line in save_tekst)
            {
                if (line[0] == '#')
                {
                    if (line.Contains("END"))
                    {
                        reading_no_kaartjes = false;
                        reading_namen_en_scores = false;
                        reading_kaart_omgedraait = false;
                        reading_speler1_aan_de_beurt = false;
                    }
                    else if (line.Contains("NO_KAARTJES"))
                    {
                        reading_no_kaartjes = true;
                    }
                    else if (line.Contains("NAMEN+SCORES"))
                    {
                        reading_namen_en_scores = true;
                    }
                    else if(line.Contains("SPELER1_AAN_BEURT"))
                    {
                        reading_speler1_aan_de_beurt = true;
                    }
                    else if (line.Contains("OMGEDRAAIT"))
                    {
                        reading_kaart_omgedraait = true;
                    }
                    else if (line.Contains("OMGEDRAAIDE_BOX_INDEX"))
                    {
                        reading_omgedraaide_box_index = true;
                    }
                }
                else if (reading_no_kaartjes)
                {
                    aantal_plaatjes = int.Parse(line);
                }
                else if (reading_namen_en_scores)
                {
                    if (spelers_naam_score[0].Length == 0)
                    {
                        spelers_naam_score[0] = line;
                    }
                    else
                    {
                        spelers_naam_score[1] = line;
                    }
                }
                else if (reading_speler1_aan_de_beurt)
                {
                    speler1_aan_de_beurt = bool.Parse(line);
                }
                else if (reading_kaart_omgedraait)
                {
                    kaart_omgedraait_list.Add(bool.Parse(line));
                }
                else if (reading_omgedraaide_box_index)
                {
                    omgedraaide_box_index = int.Parse(line);
                }
                else
                {
                    if (line[0] != '/')
                    {// als een regel met een / begint is het een comment
                        throw new ArgumentException("niet geldige savetext.");
                    }
                }
            }
            Object[] temp = new object[5];
            temp[0] = aantal_plaatjes;
            temp[1] = spelers_naam_score;
            temp[2] = kaart_omgedraait_list.ToArray();
            temp[3] = speler1_aan_de_beurt;
            temp[4] = omgedraaide_box_index;
            return temp;
        }

        private static Image[] laad_plaatjes(int aantal_plaatjes, string zip_filepath)
        {// returnt de plaatjes voor de pixtureboxes in volgorde
         // de laatste index is het plaatje voor de achterkant
            Image[] plaatjes = new Image[aantal_plaatjes + 1];
            using (var file = File.OpenRead(zip_filepath))
            {
                using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
                {
                    for (int i = 0; i < aantal_plaatjes; i++)
                    {
                        string bestandsnaam = i + plaatjes_extenstie;
                        // deze regel opent de enty met de bestandsnaam en zet het om naar een image
                        plaatjes[i] = Bitmap.FromStream(zip.GetEntry(bestandsnaam).Open());
                    }
                    plaatjes[plaatjes.Length - 1] = Bitmap.FromStream(zip.GetEntry("ACHTERKANT" + plaatjes_extenstie).Open());
                }
            }
            return plaatjes;
        }

        private static String[] get_save_tekst(string filepath)
        {
            List<string> save_text = new List<string>();
            using (var file = File.OpenRead(filepath))
            {
                using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
                {
                    foreach (var entry in zip.Entries)
                    {
                        if (entry.Name == text_bestand_name)
                        {
                            using (StreamReader sr = new StreamReader(entry.Open()))
                            {
                                while (!sr.EndOfStream)
                                {
                                    save_text.Add(sr.ReadLine());
                                }
                            }
                        }
                    }
                }
            }
            return save_text.ToArray();
        }

        private static string resolve_path(string path)
        // als het path leeg is returnt dit het autosave path
        {
            if (path == "")
            {
                Directory.CreateDirectory(Utils.get_saves_dir());
                return Utils.get_saves_dir() + autosave_bestand;
            }
            Console.WriteLine(path);
            return path;
        }
        private static class Encryption
        {
            //todo gebruik een temp bestand als outfile 
            private static string password = @"byd6hg9l";

            public static void encrypt_save(string input_bestand)
            {
                string temp_bestand_path = Utils.get_saves_dir() + temp_bestand;

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = temp_bestand_path;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(input_bestand, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();

                kopieer_en_verwijder_temp(input_bestand, temp_bestand_path);

            }

            public static void decrypt_save(string input_bestand)
            {
                string temp_bestand_path = Utils.get_saves_dir() + temp_bestand;
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(input_bestand, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(temp_bestand_path, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();

                kopieer_en_verwijder_temp(input_bestand, temp_bestand_path);
            }

            private static void kopieer_en_verwijder_temp(string output_bestand, string temp_bestand_path)
            {
                if (File.Exists(output_bestand))
                {
                    File.Delete(output_bestand);
                }
                File.Copy(temp_bestand_path, output_bestand);
                File.Delete(temp_bestand_path);
            }
        }
    }
}

