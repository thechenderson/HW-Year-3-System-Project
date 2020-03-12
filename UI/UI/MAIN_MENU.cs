using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AlienSays;
using Maintenance_mode;

namespace UI
{
    public partial class MAIN_MENU : Form
    {
        /*Declaration of constants*/
        const int FR = 3;
        const int ENG = 4;
        const int TRANSLATE = 1;
        const int AL_SAYS = 2;

        /*Variable for the language selection*/
        bool french = false;
        bool maintenance = true;
        int selected_button = 1;

        TRANSLATION translation;
        alienSaysForm aliensays;
        MAINT_MODE maint_mode;

        public MAIN_MENU(MAINT_MODE maint_mode, alienSaysForm aliensays, TRANSLATION translation, int Scr)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            this.Location = Screen.AllScreens[Scr].WorkingArea.Location;
            int h = Screen.AllScreens[Scr].Bounds.Height;
            int w = Screen.AllScreens[Scr].Bounds.Width;
            this.Size = new Size(w, h);
            this.translation = translation;
            this.aliensays = aliensays;
            this.maint_mode = maint_mode;
            translate_button.FlatAppearance.BorderSize = 10;
        }

        private void fr_button_Click(object sender, EventArgs e)
        {
            french = true;
            button_game1.Text = "ALIEN A DIT";
            button_maintMode.Text = "ENTRETIEN";
            translate_button.Text = "TRADUCTION";
        }

        private void eng_buttton_Click(object sender, EventArgs e)
        {
            french = false;
            button_game1.Text = "ALIEN SAYS";
            button_maintMode.Text = "MAINTENANCE";
            translate_button.Text = "TRANSLATE";
        }

        public void set_maintenance(bool maintenance)
        {
            this.maintenance = maintenance;
            if (maintenance) button_maintMode.Show();
            else button_maintMode.Hide();
        }

        private void translate_button_Click(object sender, EventArgs e)
        {
            translation.Show();
            translation.set_inTranslation(true);
        }

        private void button_game1_Click(object sender, EventArgs e)
        {
            aliensays.Show();
            aliensays.set_inGame(true);
            translation.set_inTranslation(false);
        }

        private void button_maintMode_Click(object sender, EventArgs e)
        {
            maint_mode.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void blue_click()
        {

        }
        public void green_click()
        {

        }
        public void white_click()
        {
            switch (selected_button)
            {
                case TRANSLATE:
                    translate_button.PerformClick();
                    break;
                case AL_SAYS:
                    button_game1.PerformClick();
                    break;
                case FR:
                    fr_button.PerformClick();
                    break;
                case ENG:
                    eng_buttton.PerformClick();
                    Console.WriteLine("yep");
                    break;

            }
        }
        public void black_click()
        {
            selected_button += 1;
            switch (selected_button)
            {
                case TRANSLATE:
                    eng_buttton.FlatAppearance.BorderSize = 0;
                    translate_button.FlatAppearance.BorderSize = 10;
                    break;
                case AL_SAYS:
                    translate_button.FlatAppearance.BorderSize = 0;
                    button_game1.FlatAppearance.BorderSize = 10;
                    break;
                case FR:
                    button_game1.FlatAppearance.BorderSize = 0;
                    fr_button.FlatAppearance.BorderSize = 10;
                    break;
                case ENG:
                    fr_button.FlatAppearance.BorderSize = 0;
                    eng_buttton.FlatAppearance.BorderSize = 10;
                    break;
                case 5:
                    eng_buttton.FlatAppearance.BorderSize = 0;
                    translate_button.FlatAppearance.BorderSize = 10;
                    selected_button = TRANSLATE;
                    break;
            }
          
        }
        public void yellow_click()
        {

        }
        public void red_click()
        {

        }

        private void set_selected(Button button)
        {
            button.BackColor = Color.Black;
        }
        private void unset_selected(Button button)
        {
            button.BackColor = Color.DeepSkyBlue;
        }

        public void set_french(bool french)
        {
            if (french) fr_button.PerformClick();
            else eng_buttton.PerformClick();
        }

        public bool get_french()
        {
            return french;
        }
    }
}
