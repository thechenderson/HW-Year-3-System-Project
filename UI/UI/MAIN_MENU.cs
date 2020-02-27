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
        /*Variable for the language selection*/
        bool french = false;
        bool maintenance = false;

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
        }

        private void fr_button_Click(object sender, EventArgs e)
        {
            french = true;
            button_game1.Text = "Jeu 1";
            button_maintMode.Text = "Jeu 2";
            translate_button.Text = "Traduction";
        }

        private void eng_buttton_Click(object sender, EventArgs e)
        {
            french = false;
            button_game1.Text = "Game 1";
            button_maintMode.Text = "Game 2";
            translate_button.Text = "Translate";
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
    }
}
