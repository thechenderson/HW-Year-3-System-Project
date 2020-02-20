using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class TRANSLATION : Form
    {
        /*creation of the speech synthesizer*/
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        /*Select fr/en*/
        bool fr = false;
        bool en = true;

        public TRANSLATION(int Scr)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            this.Location = Screen.AllScreens[Scr].WorkingArea.Location;
            int h = Screen.AllScreens[Scr].Bounds.Height;
            int w = Screen.AllScreens[Scr].Bounds.Width;
            this.Size = new Size(w, h);
            Console.WriteLine(w);
            Console.WriteLine(h);
        }

       

        private void backtomm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void sentence1_Click(object sender, EventArgs e)
        {
            if(en)
            {
                Translate_sentence.Text = "Je suis un robot alien";
            }else if(fr)
            {
                Translate_sentence.Text = "I am an alien robot";
            }
            synthesizer.Speak(Translate_sentence.Text);       
        }

        private void sentence2_Click(object sender, EventArgs e)
        {
            if (en)
            {
                Translate_sentence.Text = "J'aime les pizzas au Haggis";
            }
            else if (fr)
            {
                Translate_sentence.Text = "I like Haggis pizza";
            }
            synthesizer.Speak(Translate_sentence.Text);      
        }

        private void sentence3_Click(object sender, EventArgs e)
        {
            if (en)
            {
                Translate_sentence.Text = "J'ai été crée par ArBots";
            }
            else if (fr)
            {
                Translate_sentence.Text = "I was created by ArBots";
            }
            synthesizer.Speak(Translate_sentence.Text);      
        }

        private void sentence4_Click(object sender, EventArgs e)
        {
            if (en)
            {
                Translate_sentence.Text = "Viens jouer avec moi !";
            }
            else if (fr)
            {
                Translate_sentence.Text = "Come play with me!";
            }
            synthesizer.Speak(Translate_sentence.Text);
        }

        private void eng_buttton_Click(object sender, EventArgs e)
        {
            fr = false;
            en = true;
            sentence1.Text = "I am an alien robot";
            sentence2.Text = "I like Haggis pizza";
            sentence3.Text = "I was created by ArBots";
            sentence4.Text = "Come play with me!";
        }

        private void fr_button_Click(object sender, EventArgs e)
        {
            fr = true;
            en = false;
            sentence1.Text = "Je suis un robot alien";
            sentence2.Text = "J'aime les pizzas au Haggis";
            sentence3.Text = "J'ai été crée par ArBots";
            sentence4.Text = "Viens jouer avec moi !";
        }

 
    }
}
