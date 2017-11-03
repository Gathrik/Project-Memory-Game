using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

// ReSharper disable All

namespace Memory_Game_Project
{
    public partial class Thema_Ontwerper : Form
    {
        static private string plaatjes_extenstie = ".png";
        static private ImageFormat plaatjes_format = ImageFormat.Png;

        public Thema_Ontwerper()
        {
            InitializeComponent();
            Show();
        }

        private void kies_plaatje(object sender, EventArgs e)
        {
            PictureBox box = sender as PictureBox;
            OpenFileDialog dialog_1 = new OpenFileDialog();
            dialog_1.Filter = @"Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            DialogResult result = dialog_1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = dialog_1.FileName;
                try
                {
                    box.Image = Image.FromFile(file);
                }
                catch (IOException)
                {
                }
            }


        }

        private PictureBox[] pictureBoxes
        {
            get
            {
                return Controls.OfType<PictureBox>().ToArray();
            }
        }

        private void kruisje_klik(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Thema_Ontwerper_Load(object sender, EventArgs e)
        {

        }

        private int string_naar_int(string a)
        {
            string b = "";
            int val = -1;
            for (int i=0; i< a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }

            if (b.Length>0)
                val = int.Parse(b);
            return val;
        }

        private void maak_thema(object sender, EventArgs e)
        {
            foreach (var box in pictureBoxes)
            {
                if (box.Image == null)
                {
                    MessageBox.Show("ERROR: niet alle plaatjes zijn geselecteerd. selecteer overige plaatjes en probeer opnieuw.");
                    return;
                }
            }
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("ERROR: geen naam voor dit thema opgegeven.");
                return;
            }//todo(Jan) resize de plaatjes voor opslaan

            string themamap = Utils.get_themas_dir() + textBox1.Text + @"\";
            System.IO.Directory.CreateDirectory(themamap );

                foreach (PictureBox box in pictureBoxes)
                {
                    box.Image = Utils.ResizeImage(box.Image, 200, 200);
                    if (box.Name != "plaatje_achterkant")
                    {
                        box.Image.Save(themamap + string_naar_int(box.Name).ToString() + plaatjes_extenstie, plaatjes_format);
                    }
                    else
                    {
                        box.Image.Save(themamap + "achterkant" + plaatjes_extenstie, plaatjes_format);
                    }
                }
            Console.WriteLine("thema gemaakt");
        }

    }
}
