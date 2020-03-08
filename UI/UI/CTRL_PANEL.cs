using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maintenance_mode; 

namespace UI
{
    public partial class CTRL_PANEL : Form
    {
        /*Declaration of the magic numbers*/
        const int NO_COLOR = -1;
        const int GREEN = 0;
        const int RED = 1;
        const int PURPLE = 2;
        const int BLUE = 3;

        /*Variables for transmission of the forms 
         * done in the constructor*/

        WLC off;
        MAIN_MENU main_menu;
        WARNING warning;
        ADVERTISE advertising;

        /*Boolean for the detectors state*/
        bool card_reader = false;
        bool presence_detected = false;
        bool maintenance = true;

        public CTRL_PANEL(WLC off, MAIN_MENU main_menu, WARNING warning, ADVERTISE advertising, int Scr)
        {
            InitializeComponent();
            this.off = off;
            this.main_menu = main_menu;
            this.warning = warning;
            this.advertising = advertising;
            this.TopMost = true;

            StartPosition = FormStartPosition.Manual;
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
        }

        private void cb_cardread_CheckedChanged(object sender, EventArgs e)
        {
            card_reader = cb_cardread.Checked;

            if (maintenance)
            {
                if (!card_reader && !presence_detected)
                {
                    advertising.Show();
                    main_menu.Hide();
                    warning.Hide();
                    off.Hide();

           
                }
                else if (card_reader && !presence_detected)
                {
                    off.Show();
                    advertising.Hide();
                    main_menu.Hide();
                    warning.Hide();
                }
                else if (card_reader && !presence_detected)
                {
                    warning.Show();
                    off.Hide();
                    main_menu.Hide();
                    advertising.Hide();
                }
                else
                {
                    main_menu.Show();
                    advertising.Hide();
                    off.Hide();
                    warning.Hide();
                }
            }
        }

        private void cb_presence_CheckedChanged(object sender, EventArgs e)
        {
            presence_detected = cb_presence.Checked;

            if (maintenance)
            {
                if (!card_reader && presence_detected)
                {
                    off.Show();
                    advertising.Hide();
                    main_menu.Hide();
                    warning.Hide();
                }
                else if (!card_reader && !presence_detected)
                {
                    advertising.Show();
                    main_menu.Hide();
                    warning.Hide();
                    off.Hide();
                }
                else if (card_reader && !presence_detected)
                {
                    warning.Show();
                    off.Hide();
                    main_menu.Hide();
                    advertising.Hide();
                }
                else
                {
                    main_menu.Show();
                    advertising.Hide();
                    off.Hide();
                    warning.Hide();
                }
            }
        }

        private void green_CheckedChanged(object sender, EventArgs e)
        {
            if (green.Checked == true)
            {
                advertising.set_color(GREEN);
            }
        }

        private void red_CheckedChanged(object sender, EventArgs e)
        {
            if (red.Checked == true)
            {
                advertising.set_color(RED);
            }
        }

        private void purple_CheckedChanged(object sender, EventArgs e)
        {
            if (purple.Checked)
            {
                advertising.set_color(PURPLE);
            }
        }

        private void blue_CheckedChanged(object sender, EventArgs e)
        {
            if (blue.Checked)
            { 
                advertising.set_color(BLUE);
            }
        }

        private void color_sensor_Enter(object sender, EventArgs e) {}

        public bool get_cardreader()
        {
            return card_reader;
        }

        public bool get_presence()
        {
            return presence_detected;
        }

        public int get_color()
        {
            if (green.Checked)  return GREEN;
            if (blue.Checked)   return BLUE;
            if (purple.Checked) return PURPLE;
            if (red.Checked)    return RED;
            else return NO_COLOR;
        }

        public void set_maintenance(bool maintenance)
        {
            this.maintenance = maintenance;
        }

        public bool get_maintenance()
        {
            return maintenance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            maintenance = false;
            main_menu.set_maintenance(maintenance);
        }
    }
}
