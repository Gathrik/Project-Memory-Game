using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization; 
using prototype;

namespace Memory_Game_Project
{
    public partial class Highscores : Form
    {

        public Highscores()
        {
            InitializeComponent();
            var scores = ReadScoresFromFile("Highscores.txt");
            scores.ForEach(s => Console.WriteLine(s));
        }

        public class Highscore
        {
            public String naam { get; set; }
            public int positie { get; set; }
            public int score { get; set; }

            public Highscore(String data)
            {
                var d = data.Split(' ');

                if (String.IsNullOrEmpty(data) || d.Length < 2)
                    throw new ArgumentException("Ongeldige highscore string", "data");

                this.naam = d[0];

                int num;
                if (int.TryParse(d[1], out num))
                {
                    this.score = num;
                }
                else
                {
                    throw new ArgumentException("Ongeldige score", "data");
                }
            }

            public override string ToString()
            {
                return String.Format("{0}. {1}: {2}", this.positie, this.naam, this.score);
            }
        }

        static List<Highscore> ReadScoresFromFile(String path)
        {
            var scores = new List<Highscore>();
            File.AppendText(path).Close();
            using (StreamReader reader = new StreamReader(path))
            {
                String line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    try
                    {
                        scores.Add(new Highscore(line));
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine("Ongeldige score bij lijn \"{0}\": {1}", line, ex);
                    }
                }
            }

            return SorteerPosEnScore(scores);
        }

        static List<Highscore> SorteerPosEnScore(List<Highscore> scores)
        {
            scores = scores.OrderByDescending(s => s.score).ToList();

            int pos = 1;

            scores.ForEach(s => s.positie = pos++);

            return scores.ToList();
        }

        private void return_menu(object sender, EventArgs e)
        {
            Hoofdmenu hoofdmenu = new Hoofdmenu();
            hoofdmenu.Show();
            Hide();
            Dispose();
        }

        private void kruisje_klik(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
