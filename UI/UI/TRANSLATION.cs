using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class TRANSLATION : Form
    {
        /*creation of the sound player*/
        SoundPlayer player = new System.Media.SoundPlayer
               ("NULL");
        public TRANSLATION()
        {
            InitializeComponent();
            int h = Screen.PrimaryScreen.Bounds.Height;
            int w = Screen.PrimaryScreen.Bounds.Width;
            this.Size = new Size(w, h);
        }

        private void Translate_Click(object sender, EventArgs e)
        {
            switch(Texttotrans.Text)
            {
                case "Je suis un robot alien" :
                    Texttranslate.Text = "I am an alien robot";

                    player.SoundLocation = @"C:\Users\Patrick Geiger\source\repos\HW-Year-3-System-Project\UI\UI\Resources\I-am-an-alien-robot.wav";
                    player.Play();

                    break;

                case "I am an alien robot":
                    Texttranslate.Text = "Je suis un robot alien";

                    player.SoundLocation = @"C:\Users\Patrick Geiger\source\repos\HW-Year-3-System-Project\UI\UI\Resources\Je-suis-un-robot-alien.wav";
                    player.Play();

                    break;


                case "Viens jouer avec moi !":
                    Texttranslate.Text = "Come play with me!";

                    player.SoundLocation = @"C:\Users\Patrick Geiger\source\repos\HW-Year-3-System-Project\UI\UI\Resources\Come-play-with-me.wav";
                    player.Play();

                    break;

                case "Come play with me!":
                    Texttranslate.Text = "Viens jouer avec moi !";

                    player.SoundLocation = @"C:\Users\Patrick Geiger\source\repos\HW-Year-3-System-Project\UI\UI\Resources\Viens-jouer-avec-moi.wav";
                    player.Play();

                    break;

                 
                case "Je viens pour exterminer la planète Terre":
                    Texttranslate.Text = "I come to wipe out planet Earth";

                    player.SoundLocation = @"C:\Users\Patrick Geiger\source\repos\HW-Year-3-System-Project\UI\UI\Resources\I-come-to-wipe-out-planet-Earth.wav";
                    player.Play();

                    break;

                case "I come to wipe out planet Earth":
                    Texttranslate.Text = "Je viens pour exterminer la planète Terre";

                    player.SoundLocation = @"C:\Users\Patrick Geiger\source\repos\HW-Year-3-System-Project\UI\UI\Resources\Je-viens-pour-exterminer-la-planete-terre.wav";
                    player.Play();

                    break;


                case "J'ai été crée par Arbots":
                    Texttranslate.Text = "I was created by Arbots";

                    player.SoundLocation = @"C:\Users\Patrick Geiger\source\repos\HW-Year-3-System-Project\UI\UI\Resources\I-was-created-by-Artbots.wav";
                    player.Play();

                    break;

                case "I was created by Arbots":
                    Texttranslate.Text = "J'ai été crée par Arbots";

                    player.SoundLocation = @"C:\Users\Patrick Geiger\source\repos\HW-Year-3-System-Project\UI\UI\Resources\Jai-été-crée-par-Arbotes.wav";
                    player.Play();

                    break;


                case "J'aime les pizzas au Haggis":
                    Texttranslate.Text = "I like Haggis pizza";

                    player.SoundLocation = @"C:\Users\Patrick Geiger\source\repos\HW-Year-3-System-Project\UI\UI\Resources\I-like-Haggis-pizza.wav";
                    player.Play();

                    break;

                case "I like Haggis pizza":
                    Texttranslate.Text = "J'aime les pizzas au Haggis";

                    player.SoundLocation = @"C:\Users\Patrick Geiger\source\repos\HW-Year-3-System-Project\UI\UI\Resources\Jaime-les-pizza-au-Haggis.wav";
                    player.Play();

                    break;


                case "Que penses-tu de mes antennes ?":
                    Texttranslate.Text = "What do you think about my antennas?";

                    player.SoundLocation = @"C:\Users\Patrick Geiger\source\repos\HW-Year-3-System-Project\UI\UI\Resources\What-do-you-think-about-my-antenna.wav";
                    player.Play();

                    break;

                case "What do you think about my antennas?":
                    Texttranslate.Text = "Que penses-tu de mes antennes ?";

                    player.SoundLocation = @"C:\Users\Patrick Geiger\source\repos\HW-Year-3-System-Project\UI\UI\Resources\Que-penses-tu-de-mes-antennes.wav";
                    player.Play();

                    break;
            }
        }

        private void backtomm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
