using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool maintenance_mode = false;
            OFF off = new OFF();
            MAIN_MENU main_M = new MAIN_MENU();
            ADVERTISE advertising = new ADVERTISE();
            WARNING warning = new WARNING();
            CTRL_PANEL control_panel = new CTRL_PANEL(maintenance_mode, off, main_M, warning, advertising);
            AUTO_CTRL auto_ctrl = new AUTO_CTRL(control_panel, off, main_M, warning, advertising);

            if (maintenance_mode)
            {
                auto_ctrl.timer_stop();
                off.Show();
                Application.Run(control_panel);
            }
            else
            {
                auto_ctrl.timer_initialise();
                auto_ctrl.timer_start();
                off.Show();
                Application.Run(control_panel);
            }
        }
    }
}
