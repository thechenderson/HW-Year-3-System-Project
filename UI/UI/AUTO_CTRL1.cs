﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Maintenance_mode;
using AlienSays;
using UI;

using System.IO.Ports;     // added to use serial port features
using System.Threading;    // added to use sleep feature

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
        const int RGB_CONST = 256;

        /*Declaration Timer*/
        static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        

        /*Declaration bits of the FSM*/
        static bool card_reader = false;
        static bool presence_detected = false;
        static int color = NO_COLOR;
        static bool maintenance = false;
        static int dist = -1;
        static int R = 0, G = 0, B = 0;
        static int[] minmaxR = new int[] { 150, 255, 0, 40, 40, 80 }; //For RED {minR, maxR, minG, maxG, minB, maxB}
        static int[] minmaxG = new int[] { 80, 120, 150, 255, 0, 40 }; //For GREEN {minR, maxR, minG, maxG, minB, maxB}
        static int[] minmaxB = new int[] { 40, 80, 80, 140, 170, 255 }; //For BLUE {minR, maxR, minG, maxG, minB, maxB}
        static int[] minmaxP = new int[] { 120, 160, 30, 60, 150, 255 }; //For PURPLE {minR, maxR, minG, maxG, minB, maxB}

        int long_tick = 0; //for having the color sensor values each 2s 



        /*Declaration of the attached class for the control*/
        static OFF off;
        static MAIN_MENU main_menu;
        static WARNING warning;
        static ADVERTISE advertising;
        static CTRL_PANEL ctrl_panel;
        static SIM_SENSORS sensors;
        static MAINT_MODE maint_mode;
        static Functions function;
        static alienSaysForm aliensays;
        static TRANSLATION translation;
        static SerialPort SerialPort;

        public AUTO_CTRL(SIM_SENSORS sensor, OFF off_given, MAIN_MENU main_men,
                         WARNING warn, ADVERTISE advertise, CTRL_PANEL ctrl_pan,
                         MAINT_MODE maint, Functions func, alienSaysForm game, 
                         TRANSLATION translate)
        {
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = 500;
            timer.Start();
            ctrl_panel = ctrl_pan;
            off = off_given;
            main_menu = main_men;
            warning = warn;
            advertising = advertise;
            sensors = sensor;
            maint_mode = maint;
            function = func;
            translation = translate;
            aliensays = game;
        }

        void timer_tick(object sender, EventArgs e)
        {
            /*Here we uses the get of sensors because we simulate the MBED with it
             *but in the near futur we have to get them from the MBED with its method*/
            maintenance = sensors.get_maintenance();
            card_reader = sensors.get_cardreader();
            presence_detected = sensors.get_presence();
            color = sensors.get_color();
            ctrl_panel.set_maintenance(maintenance);
            main_menu.set_maintenance(maintenance);

            if (!maintenance)
            {
                //Check if we've initialised the robot (connection w/ MBED)
                if (maint_mode.get_initialised() || true)
                {
                    //Get from the MBED all the values of the sensors
                    get_sensors_values();
                }

                // Set all the bool as card_reader, presence_detected ...
                set_bool();



                ctrl_panel.Hide();
                maint_mode.Hide();

                /*Set the colors of the advertising mode*/
                set_color_advertising();

                /*FSM for the UI in auto mode*/
                auto_fsm();
            }
            else
            {
                ctrl_panel.Show();
            }
            
        }
        public void timer_initialise()
        {
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = 500;
        }
        public void timer_start()
        {
            timer.Start();
        }
        public void timer_stop()
        {
            timer.Stop();
        }

        private void auto_fsm()
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
                if (aliensays.get_inGame()) aliensays.Show();
                if (translation.get_inTranslation()) translation.Show();
                if (!aliensays.get_inGame() && !translation.get_inTranslation()) main_menu.Show();

                advertising.Hide();
                off.Hide();
                warning.Hide();
            }
        }
        private void set_color_advertising()
        {
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
        }
        private void get_sensors_values()
        {
            //------------------------------Distance-------------------------------------------------
            //dist = function.GetDistance(maint_mode.serialPort1);
            //Console.WriteLine(dist);
            //---------------------------------------------------------------------------------------



            //----------------------------------Colors-----------------------------------------------
            long_tick++;
           
            if (long_tick % 4 == 0) // ask the color each 2s
            {
                //var Colours = function.GetColour(maint_mode.serialPort1);// get color sensor values

                //int C = Convert.ToInt32(Colours.Item1);

                //if (C != 0)
                //{
                //    R = Convert.ToInt32(Colours.Item2) * RGB_CONST / C;
                //    G = Convert.ToInt32(Colours.Item3) * RGB_CONST / C;
                //    B = Convert.ToInt32(Colours.Item4) * RGB_CONST / C;
                //}

                //int status = function.CheckConnect(maint_mode.serialPort1);//Getting the status

                //if (status != 0)//If there was errors
                //{
                //    Console.WriteLine("Error reading the colours" + Environment.NewLine);
                //}
            }

            if (long_tick == 5) //raz of long_tick
            {
                long_tick = 1 ;
            }
            
            //if(minmaxR[0] < R && R < minmaxR[1] && minmaxR[2] < G && G < minmaxR[3] && minmaxR[4] < B && B < minmaxR[5])
            //{
            //    color = RED;
            //}
            //else
            //if(minmaxG[0] < R && R < minmaxG[1] && minmaxG[2] < G && G < minmaxG[3] && minmaxG[4] < B && B < minmaxG[5])
            //{
            //    color = GREEN;
            //}
            //else
            //if (minmaxB[0] < R && R < minmaxB[1] && minmaxB[2] < G && G < minmaxB[3] && minmaxB[4] < B && B < minmaxB[5])
            //{
            //    color = BLUE;
            //}
            //else
            //if (minmaxP[0] < R && R < minmaxP[1] && minmaxP[2] < G && G < minmaxP[3] && minmaxP[4] < B && B < minmaxP[5])
            //{
            //    color = PURPLE;
            //}
            //else
            //{
            //    color = GREEN;
            //}

            //---------------------------------------------------------------------------------------
        }
        private void set_bool()
        {
            if (0 < dist && dist < 200) presence_detected = true;
            else presence_detected = false;
        }
    }
}
