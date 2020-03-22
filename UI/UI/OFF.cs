using System;
using System.Activities;
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
    public partial class WLC : Form
    {
        public WLC(int Scr)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            this.Location = Screen.AllScreens[Scr].WorkingArea.Location;
            int h = Screen.AllScreens[Scr].Bounds.Height;
            int w = Screen.AllScreens[Scr].Bounds.Width;
            this.Size = new Size(w, h);
          
        }
        
        private void Form1_Load(object sender, EventArgs e){}
    }
}
