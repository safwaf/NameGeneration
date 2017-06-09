using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NameGeneration
{

    public partial class Form1 : Form
    {
        Generator g = new Generator();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = g.NewName();
            textBox2.Text = g.NewName();
            textBox3.Text = g.NewName();
            textBox4.Text = g.NewName();
            textBox5.Text = g.NewName();
            textBox6.Text = g.NewName();
            textBox7.Text = g.NewName();
            textBox8.Text = g.NewName();
        }
    }
    public class Generator
    {
        Random r = new Random();
        string[] Medial = new string[11] { "b", "d", "f", "g", "j", "r", "s", "sh", "th", "x", "z" };   //
        string[] sMedial = new string[11] { "c", "ch", "h", "k", "l", "m", "n", "p", "t", "w", "v" };
        string[] vowel = new string[6] { "a", "e", "i", "o", "u", "y"};

        public string NewName()
        {
            string name = "";
            int sLength = r.Next(2) + 1; //names are one, two or 3 syllables
             for (int i = 0; i<sLength; i++)
            {
                name = name + NewSyllable();
            }
            return name;
        }

        string NewVowel()
        {
            return vowel[r.Next(6)];
        }

        string NewSyllable()
        {

            //syllables always contain a vowel, and usually contain an onset and coda
            string syllable = "";
            if (r.Next(4) != 0) syllable = syllable + NewOnset();
            syllable = syllable + NewVowel();
            if (r.Next(4) != 0) syllable = syllable + NewCoda();
            return syllable;
        }

        string NewOnset()
        {
            string medial = "";
            string initial = "";
            string final = "";
            //an onset consists of a medial consonant, that might be proceeded by an s or followed by a liquid consonant
            //the double-if structure leads the algorithm to favour 2-consonant clusters. This is easy to change
            if (r.Next(5) == 1)
            {
                initial = "s";
                medial = sMedial[r.Next(11)];
            }
            else if (r.Next(2) == 1) medial = sMedial[r.Next(11)];
            else medial = Medial[r.Next(11)];

            if (r.Next(2) == 1)
            {
                switch (medial)
                {
                    case "h": break;
                    case "j": break;
                    case "l": break;
                    case "m": break;
                    case "n": break;
                    case "q": break;
                    case "r": break;
                    case "x": break;
                    case "z": break;
                    default:
                        if (r.Next(2) == 1) final = "l";
                        else final = "r";
                        break;
                }
            }
                return initial + medial + final;
        }

        string NewCoda()
        {
            string medial = "";
            string initial = "";
            string liquid = "";

            if (r.Next(5) == 1)
            {
                initial = "s";
                medial = sMedial[r.Next(11)];
            }
            else if (r.Next(2) == 1) medial = sMedial[r.Next(11)];
            else medial = Medial[r.Next(11)];

            if (r.Next(2) == 1)
            {
            if (r.Next(2) == 1) liquid = "l";
            else liquid = "r";
            }
            return liquid + initial + medial;
        }

    }
}
