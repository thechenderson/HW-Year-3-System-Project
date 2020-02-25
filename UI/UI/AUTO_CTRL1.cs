using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Maintenance_mode;

namespace UI
{
    public class AUTO_CTRL
    {
        /*Declaration of the magic numbers*/
        const int NO_COLOR = -1;
        const int GREEN = 0;
        const int RED = 1;
        const int PURPLE = 2;
        const int BLUE = 3; //test git

        /*Declaration Timer*/
        static Timer timer = new Timer();
        

        /*Declaration bits of the FSM*/
        static bool card_reader = false;
        static bool presence_detected = false;
        static int color = NO_COLOR;
        static bool maintenance = false;

        /*Declaration of the attached class for the control*/
        static OFF off;
        static MAIN_MENU main_menu;
        static WARNING warning;
        static ADVERTISE advertising;
        static CTRL_PANEL ctrl_panel;
        static SIM_SENSORS sensors;
        static MAINT_MODE maint_mode;

        public AUTO_CTRL(SIM_SENSORS sensor, OFF off_given, MAIN_MENU main_men, 
                         WARNING warn, ADVERTISE advertise, CTRL_PANEL ctrl_pan, MAINT_MODE maint)
        {
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = 25;
            timer.Start();
            ctrl_panel = ctrl_pan;
            off = off_given;
            main_menu = main_men;
            warning = warn;
            advertising = advertise;
            sensors = sensor;
            maint_mode = maint;
        }

        static void timer_tick(object sender, EventArgs e)
        {
            /*Here we uses the get of ctrl_panel because we simulate the MBED with it
             but in the near futur we have to get them from the MBED with its method*/

            card_reader = sensors.get_cardreader();
            presence_detected = sensors.get_presence();
            color = sensors.get_color();
            maintenance = sensors.get_maintenance();
            ctrl_panel.set_maintenance(maintenance);
            main_menu.set_maintenance(maintenance);

            if (!maintenance)
            {
                ctrl_panel.Hide();
                advertising.set_color(sensors.get_color());
                maint_mode.Hide();

                /*Set the colors of the advertising mode*/
                switch (color)
                {
                    case NO_COLOR:
                        advertising.set_color(GREEN);
                        break;
                    case GREEN:
                        advertising.set_color(GREEN);
                        break;
                    case RED:
                        advertising.set_color(RED);
                        break;
                    case PURPLE:
                        advertising.set_color(PURPLE);
                        break;
                    case BLUE:
                        advertising.set_color(BLUE);
                        break;
                    default:
                        advertising.set_color(GREEN);
                        break;
                }

                /*FSM for the UI in auto mode*/

                if (!card_reader && !presence_detected)
                {
                    off.Show();
                    //ctrl_panel.Activate();

                    advertising.Hide();
                    main_menu.Hide();
                    warning.Hide();
                    //get_maintenance() MBED
                }
                else if (!card_reader && presence_detected)
                {
                    advertising.Show();
                    // ctrl_panel.Activate();

                    main_menu.Hide();
                    warning.Hide();
                    off.Hide();
                    //get_maintenance() MBED
                }
                else if (card_reader && !presence_detected)
                {
                    warning.Show();
                    //ctrl_panel.Activate();
                    off.Hide();
                    main_menu.Hide();
                    advertising.Hide();
                }
                else
                {
                    main_menu.Show();
                    //ctrl_panel.Activate();
                    advertising.Hide();
                    off.Hide();
                    warning.Hide();
                }
            }
            else
            {
                ctrl_panel.Show();
            }
        }
        public void timer_initialise()
        {
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = 25;
        }
        public void timer_start()
        {
            timer.Start();
        }
        public void timer_stop()
        {
            timer.Stop();
        }
    }
}
