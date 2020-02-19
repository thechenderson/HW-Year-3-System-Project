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
    public partial class ADVERTISE : Form
    {
        /*Declaration of the magic numbers*/
        int GREEN = 0;
        int RED = 1;
        int PURPLE = 2;
        int BLUE = 3;

        int color_num;

        public ADVERTISE(int Scr)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            this.Location = Screen.AllScreens[Scr].WorkingArea.Location;
            int h = Screen.AllScreens[Scr].Bounds.Height;
            int w = Screen.AllScreens[Scr].Bounds.Width;
            this.Size = new Size(w, h);
        }

        public void set_color(int color_num)
        {
            this.color_num = color_num;

            /*Hide and make visible pictures with respect to color_num*/

            if (color_num == GREEN)
            {
                pictureGreen.Visible = true;
                pictureBlue.Visible = false;
                picturePurple.Visible = false;
                pictureRed.Visible = false;       
            }

            if (color_num == RED)
            {
                pictureRed.Visible = true;
                pictureGreen.Visible = false;
                pictureBlue.Visible = false;
                picturePurple.Visible = false;
            }

            if (color_num == PURPLE)
            {
                picturePurple.Visible = true;
                pictureGreen.Visible = false;
                pictureBlue.Visible = false;
                pictureRed.Visible = false;
            }

            if (color_num == BLUE)
            {
                pictureBlue.Visible = true;
                pictureGreen.Visible = false;
                picturePurple.Visible = false;
                pictureRed.Visible = false;
            }
        }
    }
}
