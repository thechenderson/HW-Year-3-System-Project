﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;

using Maintenance_mode;
using AlienSays;
using UI;

using System.IO.Ports;     // added to use serial port features
using System.Threading;    // added to use sleep feature
using System.Timers;

namespace UI
{
    public class AUTO_CTRL
    {
        /*Declaration of the magic numbers*/
        const int NO_COLOR = -1;
        const int GREEN = 0;
        const int RED = 1;
        const int PURPLE = 2;
        const int BLUE = 3; 
        const int RGB_CONST = 256;
        const int BLACK_BUTTON = 1;
        const int WHITE_BUTTON = 2;
        const int BLUE_BUTTON = 3;
        const int YELLOW_BUTTON = 4;
        const int RED_BUTTON = 5;
        const int GREEN_BUTTON = 6;
        const int NO_BUTTON = 0;
        string currentUser;

        /*Declaration Timer*/
        static System.Windows.Forms.Timer timer =
                                        new System.Windows.Forms.Timer();
        
        /*Declaration bits of the FSM*/
        static bool card_reader = false;
        static bool presence_detected = false;
        static int color = NO_COLOR;
        static bool maintenance = true;
        static int active_window = 0;
        static int dist = -1;
        static int user_id = 15;
        static int button = 0;
        static int R = 0, G = 0, B = 0;
        static int[] minmaxR = new int[] { 130, 170, 40, 85, 30, 60 }; 
                        //For RED {minR, maxR, minG, maxG, minB, maxB}
        static int[] minmaxG = new int[] { 80, 120, 150, 255, 0, 40 };
                        //For GREEN {minR, maxR, minG, maxG, minB, maxB}
        static int[] minmaxB = new int[] { 60, 100, 80, 110, 70, 100 }; 
                        //For BLUE {minR, maxR, minG, maxG, minB, maxB}
        static int[] minmaxP = new int[] { 120, 160, 30, 60, 150, 255 };
                        //For PURPLE {minR, maxR, minG, maxG, minB, maxB}
        List<string> cardIDNames = new List<string>();
        int long_tick = 0; //for having the color sensor values each 2s 
        bool twice = false; //for the unduplicate the timer tick 

        /*Declaration of the attached class for the control*/
        static WLC wlc;
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
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        public AUTO_CTRL(SIM_SENSORS sensor, WLC off_given, 
                            MAIN_MENU main_men, WARNING warn, 
                            ADVERTISE advertise, CTRL_PANEL ctrl_pan,
                            MAINT_MODE maint, Functions func,
                            alienSaysForm game, TRANSLATION translate)
        {
            //Set the timer
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = 125;
            timer.Start();

            //Locally assigns variables as arguments
            ctrl_panel = ctrl_pan;
            wlc = off_given;
            main_menu = main_men;
            warning = warn;
            advertising = advertise;
            sensors = sensor;
            maint_mode = maint;
            function = func;
            translation = translate;
            aliensays = game;

            //List of all known users
            cardIDNames.Add("Soosin");
            cardIDNames.Add("La-a");
            cardIDNames.Add("Kevin");
            cardIDNames.Add("Pierre");
            cardIDNames.Add("Patrick");
            cardIDNames.Add("Max");
            cardIDNames.Add("Alex");
            cardIDNames.Add("Jordan");
            cardIDNames.Add("Chris");
            cardIDNames.Add("Tilly");
            cardIDNames.Add("Candy");
            cardIDNames.Add("Richard");
            cardIDNames.Add("Jurgen");
            cardIDNames.Add("Boris");
            cardIDNames.Add("Covid");
            cardIDNames.Add("Maintenance");
        }

        void timer_tick(object sender, EventArgs e)
        {
            if (twice) twice = false;
            else twice = true;

            if (twice)
            {
                //Check if the maintenace mode is on
                maintenance = ctrl_panel.get_maintenance();

                if (!maintenance)
                {
                    //Check if we've initialised the robot (connection w/
                        //MBED)
                    if (maint_mode.get_initialised())
                    {
                        //Get from the MBED all the values of the sensors
                        get_sensors_values();
                    }

                    // Set all the bool as card_reader,
                    //presence_detected ...
                    set_bool();

                    ctrl_panel.Hide();
                    maint_mode.Hide();

                    /*Set the colors of the advertising mode*/
                    set_color_advertising();

                    /*FSM for the UI in auto mode*/
                    auto_fsm();
                    button_press();
                }
                else
                {
                    ctrl_panel.Show();
                }
            }  
        }

        private void auto_fsm() //Display Forms on the screen and make
                                //the servos move w.r.t. the robot state
        {
            if (!card_reader && presence_detected) //Welcome window
            {
                wlc.Show();
                advertising.Hide();
                main_menu.Hide();
                warning.Hide();
                active_window = 0;
                function.ServoEnable("0", maint_mode.serialPort1);
                function.LEDs("1", maint_mode.serialPort1);
            }
            else if (!card_reader && !presence_detected) //Advert window
            {
                advertising.Show();
                main_menu.Hide();
                warning.Hide();
                wlc.Hide();
                active_window = 0;
                function.ServoEnable("0", maint_mode.serialPort1);
                function.LEDs("1", maint_mode.serialPort1);
            }
            else if (card_reader && !presence_detected) //Warning window
            {
                warning.Show();
                wlc.Hide();
                main_menu.Hide();
                advertising.Hide();
                active_window = 0;
                function.ServoEnable("0", maint_mode.serialPort1);
                function.LEDs("1", maint_mode.serialPort1);
            }
            else //Main menu window
            {
                if (aliensays.get_inGame()) //Game window
                {
                    Console.WriteLine(aliensays.get_french());
                    main_menu.set_french(aliensays.get_french());
                    translation.set_french(aliensays.get_french());
                    aliensays.setUserID(currentUser);
                    aliensays.Show();
                }
                else if (translation.get_inTranslation()) //Trans window
                {
                    main_menu.set_french(translation.get_french());
                    aliensays.set_french(translation.get_french());
                    translation.Show();
                }
                else if (!aliensays.get_inGame() && 
                         !translation.get_inTranslation()) //Main menu window
                {
                    aliensays.set_french(main_menu.get_french());
                    translation.set_french(main_menu.get_french());
                    main_menu.set_userid(currentUser);
                    main_menu.Show();
                }

                advertising.Hide();
                wlc.Hide();
                warning.Hide();
                function.ServoEnable("1", maint_mode.serialPort1);
                function.LEDs("2", maint_mode.serialPort1);
            }
        }
        private void set_color_advertising() //Change the advertising color
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
                        //Main function for read sensors values
        {
            //Store all states sensors (exept color sensor) in one variables
            var States = function.GetAll(maint_mode.serialPort1); 

            card_reader = States.Item1;
            user_id = States.Item2;
            dist = States.Item3;
            button = States.Item4;

            if (user_id != -1)
            {
                currentUser = cardIDNames[user_id];
            }
            else 
            {
                currentUser = "";
            }

            long_tick++;

            if (long_tick % 16 == 0) // ask the color each 2s
            {
                // get color sensor values
                var Colours = function.GetColour(maint_mode.serialPort1);

                int C = Convert.ToInt32(Colours.Item1);

                if (C != 0) //Convert Colours sensor values to RGB values
                {
                    R = Convert.ToInt32(Colours.Item2) * RGB_CONST / C;
                    G = Convert.ToInt32(Colours.Item3) * RGB_CONST / C;
                    B = Convert.ToInt32(Colours.Item4) * RGB_CONST / C;
                }
            }

            if (long_tick == 17) //raz of long_tick
            {
                long_tick = 1;
            }
        }
        private void set_bool()//Set local variables w.r.t sensors states
        {
            //------------------------------Distance---------------------
            if (0 < dist && dist < 200) presence_detected = true;
            else presence_detected = false;
            //-----------------------------------------------------------

            //----------------------------------Colors-------------------
            if (minmaxR[0] < R && R < minmaxR[1] && 
                minmaxR[2] < G && G < minmaxR[3] && 
                minmaxR[4] < B && B < minmaxR[5])
            {
                color = RED;
            }
            else
            if (minmaxG[0] < R && R < minmaxG[1] && 
                minmaxG[2] < G && G < minmaxG[3] && 
                minmaxG[4] < B && B < minmaxG[5])
            {
                color = GREEN;
            }
            else
            if (minmaxB[0] < R && R < minmaxB[1] &&
                minmaxB[2] < G && G < minmaxB[3] && 
                minmaxB[4] < B && B < minmaxB[5])
            {
                color = BLUE;
            }
            else
            if (minmaxP[0] < R && R < minmaxP[1] &&
                minmaxP[2] < G && G < minmaxP[3] && 
                minmaxP[4] < B && B < minmaxP[5])
            {
                color = PURPLE;
            }
            else
            {
                color = GREEN;
            }
            //-------------------------------------------------------------

            //-----------------Card User ID--------------------------------
            if (user_id == 15)
            {
                maintenance = true;
            }
            else
            {
                maintenance = false; 
            }

            ctrl_panel.set_maintenance(maintenance);
            main_menu.set_maintenance(maintenance);
            //------------------------------------------------------------
        }

        private void button_press() //Detect witch button is pressed 
                                    //and the action to do w.r.t 
                                    //the active window
        {                           
            switch (button)
            {
                case NO_BUTTON: 
                    break;
                case BLACK_BUTTON:
                    if (aliensays.get_inGame()) 
                        aliensays.black_click();
                    else if (translation.get_inTranslation()) 
                        translation.black_click();
                    else if (!aliensays.get_inGame() && 
                             !translation.get_inTranslation())
                    {
                        main_menu.black_click();
                    }
                    break;
                case WHITE_BUTTON:
                    if (aliensays.get_inGame()) 
                        aliensays.white_click();
                    else if (translation.get_inTranslation()) 
                        translation.white_click();
                    else if (!aliensays.get_inGame() && 
                             !translation.get_inTranslation()) 
                        main_menu.white_click();
                    break;
                case BLUE_BUTTON:
                    if (aliensays.get_inGame()) 
                        aliensays.blue_click();
                    else if (translation.get_inTranslation())
                    {
                        timer.Stop();
                        translation.blue_click();
                        timer.Start();
                    }
                    else if (!aliensays.get_inGame() &&
                             !translation.get_inTranslation()) ;
                    break;
                case YELLOW_BUTTON:
                    if (aliensays.get_inGame())
                    {
                        if (aliensays.gameInProgress == false)
                        {
                            timer.Stop();
                            if (!aliensays.get_french())
                            {
                                synthesizer.Speak("Press start to begin the game. The on screen shapes will then flash in a sequence, use the buttons to repeat this sequence");
                            }
                            else
                            {
                                synthesizer.Speak("Appuyer sur start pour commencer. Appuyer sur les boutons de couleurs pour reproduire les sequence qui apparaitront a l'ecran");
                            }
                            timer.Start();
                        }
                        else
                        {
                            aliensays.yellow_click();
                        }
                    }
                    else if (translation.get_inTranslation())
                    {
                        timer.Stop();
                        translation.yellow_click();
                        timer.Start();
                    }
                    else if (!aliensays.get_inGame() && !translation.get_inTranslation())
                    {
                        main_menu.yellow_click();
                    }
                    break;
                case RED_BUTTON:
                    if (aliensays.get_inGame()) aliensays.red_click();
                    else if (translation.get_inTranslation())
                    {
                        timer.Stop();
                        translation.red_click();
                        timer.Start();
                    }
                    else if (!aliensays.get_inGame() && !translation.get_inTranslation());
                    break;
                case GREEN_BUTTON:
                    if (aliensays.get_inGame()) aliensays.green_click();
                    else if (translation.get_inTranslation())
                    {
                        timer.Stop();
                        translation.green_click();
                        timer.Start();
                    }
                    else if (!aliensays.get_inGame() && !translation.get_inTranslation());
                    break;
                default: break;
            }                 
        }
    }
}
