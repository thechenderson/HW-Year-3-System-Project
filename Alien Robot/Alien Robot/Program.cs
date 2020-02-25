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

            /* Set the screen
             * Working on the PC only : 
             * Scr = 0 OR working on the PC + Robot's screen : Scr = 1*/
            int Scr = 1;

            SIM_SENSORS sensors = new SIM_SENSORS();
            MAINT_MODE maint_mode = new MAINT_MODE();
            TRANSLATION translation = new TRANSLATION(Scr);
            OFF off = new OFF(Scr);
            Leaderboards leaderboardsScreen = new Leaderboards();
            alienSaysForm aliensays_game = new alienSaysForm(leaderboardsScreen);
            MAIN_MENU main_M = new MAIN_MENU(maint_mode, aliensays_game ,translation, Scr);
            ADVERTISE advertising = new ADVERTISE(Scr);
            WARNING warning = new WARNING(Scr);
            CTRL_PANEL control_panel = new CTRL_PANEL(off, main_M, warning, advertising, Scr);
            AUTO_CTRL auto_ctrl = new AUTO_CTRL(sensors, off, main_M, warning, advertising, control_panel, maint_mode);

            auto_ctrl.timer_initialise();
            auto_ctrl.timer_start();
            off.Show();
            Application.Run(sensors);
          
        }
    }
}
