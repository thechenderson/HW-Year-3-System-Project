﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;     // added to use serial port features
using System.Threading;    // added to use sleep feature

namespace Maintenance_mode
{
    public partial class MAINT_MODE : Form
    {
        //Constants
        const int OK = 0;
        const int FORMAT_ERROR = -1;
        const int COM_BAUD = 115200;
        const int READ_TIMEOUT = 10000;
        Functions function = new Functions();

        //Variables
        int global_error;

        public MAINT_MODE()
        {
  
            InitializeComponent();
        }

        private void MaintainanceForm_Load(object sender, EventArgs e)
        {
            cbPort.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                cbPort.Items.Add(s);
            }
            //cbPort.SelectedIndex = 0;
            serialPort1.BaudRate = COM_BAUD;
            global_error = OK;
            Thread.Sleep(2000);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string com_port = cbPort.SelectedItem.ToString();//Reading in the selected port from the drop down box
            tbDisplay.AppendText("Selected COM Port = " + com_port + Environment.NewLine);
            int status = function.MBEDConnect(com_port, serialPort1);
            if (status == 0)
            {
                tbDisplay.AppendText("MBED Connected" + Environment.NewLine);
            }
            else
            {
                tbDisplay.AppendText("Could Not Connect to the MBED" + Environment.NewLine);
            }
        }

        private void btnServoMove_Click(object sender, EventArgs e)
        {
            string Servo = Convert.ToString(nudServoNo.Value);
            string Pos = Convert.ToString(nudServoAngle.Value);

            tbDisplay.AppendText("Moving Servo " + Servo + " to position " + Pos + Environment.NewLine);

            int status = function.ServoMove(Servo, Pos, serialPort1);

            if (status == 0)
            {
                tbDisplay.AppendText("Servo Moved Successfully" + Environment.NewLine);
            }
            else 
            {
                tbDisplay.AppendText("Error: Check the Servo" + Environment.NewLine);
            }
        }

        private void btnServoRead_Click(object sender, EventArgs e)
        {

            tbDisplay.AppendText("Reading reply: " + Environment.NewLine);

            string data = function.ServoRead(serialPort1);//Getting the status from the MBED

            tbDisplay.AppendText(data + Environment.NewLine);
        }

        private void btnReadDistance_Click(object sender, EventArgs e)
        {
            int distance = function.GetDistance(serialPort1);//Getting the distance using the GetDistance function

            if (distance != -1)
            {
                tbDistance.Text = distance.ToString();
            }
            else 
            {
                tbDistance.Text = "Error reading the distance";
            }
        }

        private void btnReadColour_Click(object sender, EventArgs e)
        {

            tbDisplay.AppendText("Getting Colours" + Environment.NewLine);

            var Colours = function.GetColour(serialPort1);//Using the GetColour function to get the colours in a Tuple from the MBED

            string clear = Colours.Item1;//Assigning the first value in Colours as clear
            string red = Colours.Item2;//Assigning the second value in Colours as red
            string green = Colours.Item3;//Assigning the third value in Colours as green
            string blue = Colours.Item4;//Assigning the fourth value in Colours as blue

            int status = function.CheckConnect(serialPort1);//Getting the status

            if (status == 0)//If there was no errors
            {

                tbDisplay.AppendText("Clear Value: " + clear + Environment.NewLine);//Printing the clear value on the display
                tbDisplay.AppendText("Red Value: " + red + Environment.NewLine);//Printing the red value on the display
                tbDisplay.AppendText("Green Value: " + green + Environment.NewLine);//Printing the green value on the display
                tbDisplay.AppendText("Blue Value: " + blue + Environment.NewLine);//Printing the blue value on the display

                //Changing the colour box on the form to the colour from the sensor using the values obtained
                pbColour.BackColor = Color.FromArgb(((int)(((byte)(Convert.ToInt32(clear))))), ((int)(((byte)(Convert.ToInt32(red))))), ((int)(((byte)(Convert.ToInt32(green))))), ((int)(((byte)(Convert.ToInt32(blue))))));
            }
            else
            {
                tbDisplay.AppendText("Error reading the colours");
            }
        }
    }
}
