using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace AlienSays
{
    public partial class Leaderboards : Form
    {
        public Leaderboards()
        {
            InitializeComponent();
        }

        Thread th;

        private void Leaderboards_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            this.Text = String.Empty;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            (new alienSaysForm()).Show();
        }

        private void openForm(object obj)
        {
            Application.Run(new alienSaysForm());
        }

    }
}
