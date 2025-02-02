﻿using System;
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

        int selected_button = 1;

        const int EXIT = 1;
        const int FR = 2;
        const int ENG = 3;

        /*Select fr/en*/
        bool fr = false;
        bool inTranslation = false;

        public TRANSLATION(int Scr)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            this.Location = Screen.AllScreens[Scr].WorkingArea.Location;
            int h = Screen.AllScreens[Scr].Bounds.Height;
            int w = Screen.AllScreens[Scr].Bounds.Width;
            this.Size = new Size(w, h);
        }

        private void backtomm_Click(object sender, EventArgs e) //Back to main menu
        {
            this.Hide();
            inTranslation = false;
        }

        private void sentence1_Click(object sender, EventArgs e)//play sentence 1 w.r.t. the language
        {
            if(!fr)
            {
                Translate_sentence.Text = "Je suis un robot alien";
            }else
            {
                Translate_sentence.Text = "I am an alien robot";
            }
            synthesizer.Speak(Translate_sentence.Text);       
        }

        private void sentence2_Click(object sender, EventArgs e)//play sentence 2 w.r.t. the language
        {
            if (!fr)
            {
                Translate_sentence.Text = "J'aime les pizzas au Haggis";
            }
            else
            {
                Translate_sentence.Text = "I like Haggis pizza";
            }
            synthesizer.Speak(Translate_sentence.Text);      
        }

        private void sentence3_Click(object sender, EventArgs e)//play sentence 3 w.r.t. the language
        {
            if (!fr)
            {
                Translate_sentence.Text = "J'ai été crée par ArBots";
            }
            else
            {
                Translate_sentence.Text = "I was created by ArBots";
            }
            synthesizer.Speak(Translate_sentence.Text);      
        }

        private void sentence4_Click(object sender, EventArgs e)//play sentence 4 w.r.t. the language
        {
            if (!fr)
            {
                Translate_sentence.Text = "Viens jouer avec moi !";
            }
            else
            {
                Translate_sentence.Text = "Come play with me!";
            }
            synthesizer.Speak(Translate_sentence.Text);
        }

        private void eng_buttton_Click(object sender, EventArgs e)
        {
            fr = false;
            sentence1.Text = "I am an alien robot";
            sentence2.Text = "I like Haggis pizza";
            sentence3.Text = "I was created by ArBots";
            sentence4.Text = "Come play with me!";
            label1.Text = "Je parle Anglais !";
            label2.Text = "Trop facile :";
            backtomm.Text = "Menu Principal";
        }

        private void fr_button_Click(object sender, EventArgs e)
        {
            fr = true;
            sentence1.Text = "Je suis un robot alien";
            sentence2.Text = "J'aime les pizzas au Haggis";
            sentence3.Text = "J'ai été crée par ArBots";
            sentence4.Text = "Viens jouer avec moi !";
            label1.Text = "I can speak any language";
            label2.Text = "Too easy :";
            backtomm.Text = "Main Menu";
        }

        public bool get_inTranslation()
        {
            return inTranslation;
        }

        public void set_inTranslation(bool inTranslation)
        {
            this.inTranslation = inTranslation;
        }

        public void white_click() //perform white click w.r.t the actual selected item
        {
            switch (selected_button)
            {
                case EXIT:
                    backtomm.PerformClick();
                    break;
                case FR:
                    fr_button.PerformClick();
                    break;
                case ENG:
                    eng_buttton.PerformClick();
                    break;
            }
        }

        public void black_click()//perform black click w.r.t the actual selected item
        {
            selected_button += 1;
            switch (selected_button)
            {
                case EXIT:
                    eng_buttton.FlatStyle = FlatStyle.Flat;
                    backtomm.FlatAppearance.BorderSize = 5;
                    break;
                case FR:
                    backtomm.FlatAppearance.BorderSize = 0;
                    fr_button.FlatStyle = FlatStyle.Standard;
                    break;
                case ENG:
                    fr_button.FlatStyle = FlatStyle.Flat;
                    eng_buttton.FlatStyle = FlatStyle.Standard;
                    break;
                case 4:
                    eng_buttton.FlatStyle = FlatStyle.Flat;
                    backtomm.FlatAppearance.BorderSize = 5; 
                    selected_button = EXIT;
                    break;
            }
        }
        public void blue_click()
        {
            sentence4.PerformClick();
        }
        public void green_click()
        {
            sentence3.PerformClick();
        }
        public void yellow_click()
        {
            sentence2.PerformClick();
        }
        public void red_click()
        {
            sentence1.PerformClick();
        }
        public void set_french(bool french) //change the language of the Translation mode
        {
            fr = french;
            if (fr)
            {
                sentence1.Text = "Je suis un robot alien";
                sentence2.Text = "J'aime les pizzas au Haggis";
                sentence3.Text = "J'ai été crée par ArBots";
                sentence4.Text = "Viens jouer avec moi !";
                label1.Text = "Je parle Anglais !";
                label2.Text = "Trop facile :";
                backtomm.Text = "Menu Principal";
            }
            else
            {
                sentence1.Text = "I am an alien robot";
                sentence2.Text = "I like Haggis pizza";
                sentence3.Text = "I was created by ArBots";
                sentence4.Text = "Come play with me!";
                label1.Text = "I can speak any language";
                label2.Text = "Too easy :";
                backtomm.Text = "Main Menu";
            }
        }

        public bool get_french()
        {
            return fr;
        }
    }
}
