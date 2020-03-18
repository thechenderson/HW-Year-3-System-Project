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
<<<<<<< HEAD
            string username ="";
=======
>>>>>>> parent of bfdb6ed... Sys files

            Functions functions = new Functions();
            SIM_SENSORS sensors = new SIM_SENSORS();
            MAINT_MODE maint_mode = new MAINT_MODE(functions);
            TRANSLATION translation = new TRANSLATION(Scr);
            HELP help = new HELP(Scr);
            WLC off = new WLC(Scr);
            alienSaysForm aliensays_game = new alienSaysForm(Scr);
            MAIN_MENU main_M = new MAIN_MENU(maint_mode, aliensays_game ,translation,help, Scr);
            ADVERTISE advertising = new ADVERTISE(Scr);
            WARNING warning = new WARNING(Scr);
            CTRL_PANEL control_panel = new CTRL_PANEL(off, main_M, warning, advertising, Scr);
            AUTO_CTRL auto_ctrl = new AUTO_CTRL(sensors, off, main_M, warning, advertising, control_panel,
<<<<<<< HEAD
                                                maint_mode, functions, aliensays_game, translation, username);


                

            //auto_ctrl.timer_initialise();
            // auto_ctrl.timer_start();
=======
                                                maint_mode, functions, aliensays_game, translation);

           //auto_ctrl.timer_initialise();
           // auto_ctrl.timer_start();
>>>>>>> parent of bfdb6ed... Sys files
            off.Show();
            Application.Run(sensors);
          
        }
    }
}
