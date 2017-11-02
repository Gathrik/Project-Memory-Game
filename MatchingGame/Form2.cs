using MatchingGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        public int[] CardIndex = new int[16];

        private void Form2_Load(object sender, EventArgs e)
        {
         
            // We bewaren de gebruikte nummers in een string zodat we String.Contains kunnen gebruiken
            string usedNumbers = "/";

            bool breaking = false;

            //doe dit ... keer
            for (int i = 0; i < 16; i++)
            {
                Random rnd = new Random();

                int randomNumber = rnd.Next(1, 15);
                int old = randomNumber;

                //dubbel
                while (usedNumbers.Contains("/" + randomNumber.ToString() + "/"))
                {

                    randomNumber = rnd.Next(1, 15);

                    //niet het zelfde nummer 2x achter elkaar
                    if (randomNumber == old)
                    {
                        breaking = true;
                        break;
                    }
                    //new
                    else
                    {
                        //old
                        if (usedNumbers.Contains("/" + randomNumber.ToString() + "/"))
                        {
                            randomNumber = rnd.Next(1, 15);
                            breaking = true;
                            break;
                        }
                        //new
                        else
                        {
                            breaking = false;
                            break;
                        }
                    }
                }
                if (breaking == false)
                {

                    usedNumbers += randomNumber.ToString() + "/";
                    CardIndex[i] = randomNumber;
                }

                else
                {
                    //Debug.Log("else");
                    while (usedNumbers.Contains("/" + randomNumber.ToString() + "/"))
                    {

                        randomNumber = rnd.Next(1, 15);

                        if (usedNumbers.Contains("/" + randomNumber.ToString() + "/"))
                        {

                            randomNumber = rnd.Next(1, 15);
                            break;
                        }
                        else
                        {
                            randomNumber = rnd.Next(1, 15);
                            //Debug.Log("break else");
                            break;
                        }
                    }

                    //geen dubbel
                    usedNumbers += randomNumber.ToString() + "/";
                    CardIndex[i] = randomNumber;
                    //Debug.Log("Uniek: " + randomNumber);
                    breaking = false;
                    continue;
                }

            }
            SpawnCards();
            
        }

        public void SpawnCards()
        {
            double square;

            int pointx = 0;
            int pointy = 0;
            int total = 16;

            string[] imgs = new string[] {"Image1", "Image2", "Image3", "Image4", "Image5", "Image6", "Image7", "Image8", "Image1", "Image2", "Image3", "Image4", "Image5", "Image6", "Image7", "Image8" };

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
    }
}
