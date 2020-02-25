using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class SIM_SENSORS : Form
    { 
        /*Declaration of the magic numbers*/
        const int NO_COLOR = -1;
        const int GREEN = 0;
        const int RED = 1;
        const int PURPLE = 2;
        const int BLUE = 3;

        /*Sensors states*/
        bool card_reader = false;
        bool presence_detected = false;
        bool maintenance = false;

        public SIM_SENSORS()
        {
            InitializeComponent();
        }

        private void cb_cardread_CheckedChanged_1(object sender, EventArgs e)
        {
            card_reader = cb_cardread.Checked;
            if (cb_cardread.Checked) maint_card.Show();
            else maint_card.Hide();
        }

        private void cb_presence_CheckedChanged(object sender, EventArgs e)
        {
            presence_detected = cb_presence.Checked;
        }

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
            if (green.Checked) return GREEN;
            if (blue.Checked) return BLUE;
            if (purple.Checked) return PURPLE;
            if (red.Checked) return RED;
            else return NO_COLOR;
        }

        private void maint_card_CheckedChanged_1(object sender, EventArgs e)
        {
            if (maint_card.Checked) maintenance = true;
            else maintenance = false;
        }

        public bool get_maintenance()
        {
            return maintenance;
        }

        private void SIM_SENSORS_Load(object sender, EventArgs e)
        {
        }
    }
}
