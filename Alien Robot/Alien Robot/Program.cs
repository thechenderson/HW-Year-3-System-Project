using AlienSays;
using Maintenance_mode;
using System;
using System.Windows.Forms;
using UI;
namespace Alien_Robot
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

            bool maintenance = true;

            /* Set the screen
             * Working on the PC only : 
             * Scr = 0 OR working on the PC + Robot's screen : Scr = 1*/
            int Scr = 1;

            MAINT_MODE maint_mode = new MAINT_MODE();
            TRANSLATION translation = new TRANSLATION(Scr);
            OFF off = new OFF(Scr);
            Leaderboards leaderboardsScreen = new Leaderboards(Scr);
            alienSaysForm aliensays_game = new alienSaysForm(leaderboardsScreen, Scr);
            MAIN_MENU main_M = new MAIN_MENU(maint_mode, aliensays_game ,translation, Scr);
            ADVERTISE advertising = new ADVERTISE(Scr);
            WARNING warning = new WARNING(Scr);
            CTRL_PANEL control_panel = new CTRL_PANEL(maintenance, off, main_M, warning, advertising);
            AUTO_CTRL auto_ctrl = new AUTO_CTRL(control_panel, off, main_M, warning, advertising);


            if (maintenance)
            {
                main_M.set_maintenance(maintenance);
                auto_ctrl.timer_stop();
                off.Show();
                Application.Run(control_panel);
            }
            else
            {
                main_M.set_maintenance(maintenance);
                auto_ctrl.timer_initialise();
                auto_ctrl.timer_start();
                off.Show();
                Application.Run(control_panel);
            }
        }
    }
}
