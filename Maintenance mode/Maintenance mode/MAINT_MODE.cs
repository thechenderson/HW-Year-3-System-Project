using System;
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

        //Variables
        int global_error;

        public MAINT_MODE()
        {
            InitializeComponent();
        }

        public int CheckConnect()//Checking if there is a connection between the PC and an MBED
        {
            string Response;
            int Status;

            serialPort1.DiscardInBuffer();//Clearing any existing data from the connection between the PC and MBED
            serialPort1.ReadTimeout = READ_TIMEOUT;//Setting the length for a Time Out
            try
            {
                Response = serialPort1.ReadLine();//Reading the data from the MBED
            }
            catch (TimeoutException)//If there is an error recieving data
            {
                tbDisplay.AppendText("Readline timeout fail" + Environment.NewLine);
                return -1;
            }
            Status = Convert.ToInt32(Response);
            tbDisplay.AppendText("Status = " + Response + Environment.NewLine);//Displaying the MBED status
            return Status;
        }

        public string ReadData()//Reading the values being passed from the MBED
        {
            string Response;//Setting a string to store the data that is read
            serialPort1.DiscardInBuffer();//Removing all existing data from the connection
            serialPort1.ReadTimeout = READ_TIMEOUT;//Setting the time out length
            try
            {
                Response = serialPort1.ReadLine();//Reading the data from the MBED

            }
            catch (TimeoutException)//If there is an error reading the data
            {
                tbDisplay.AppendText("Readline timeout fail" + Environment.NewLine);
                return "";//returns a blank string to stop the program from crashing
            }
            return Response;
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
            try
            {
                tbDisplay.AppendText("Trying to open " + com_port + Environment.NewLine);
                serialPort1.PortName = com_port;
                serialPort1.Open();//Attempt to open up a connection on the selected COM port
            }
            catch //If no connection could be made
            {
                tbDisplay.AppendText("Cannot open " + com_port + Environment.NewLine);
                return;
            }
            tbDisplay.AppendText(com_port + " now open" + Environment.NewLine);
        }

        private void btnServoMove_Click(object sender, EventArgs e)
        {
            //Setting the command to have 's' so the MBED knows to move the servo, the servo number and the position to move the servo to
            string command = "s "
                           + Convert.ToString(nudServoNo.Value)
                           + " "
                           + Convert.ToString(nudServoAngle.Value);

            tbDisplay.AppendText(command + Environment.NewLine);
            serialPort1.WriteLine(command);//Send the command to the MBED
            tbDisplay.AppendText("Reading reply" + Environment.NewLine);
            int status = CheckConnect();//Get the status from the MBED
        }

        private void btnServoRead_Click(object sender, EventArgs e)
        {
            //Sends the command 'r' to the MBED to get the last servo value
            String command = "r";
            tbDisplay.AppendText(command + Environment.NewLine);
            serialPort1.WriteLine(command);

            tbDisplay.AppendText("Reading reply: " + Environment.NewLine);

            string data = ReadData();//Getting the value from the MBED
            int status = CheckConnect();//Getting the status from the MBED

            if (status == 0)//Running if the MBED program ran correctly
            {
                tbDisplay.AppendText("reading data" + Environment.NewLine);
                tbDisplay.AppendText("Data = " + data + Environment.NewLine);
            }
            else //Displaying if there was an error when the MBED operated
            {
                tbDisplay.AppendText("Error when reading the data");
            }
        }

        private void btnReadDistance_Click(object sender, EventArgs e)
        {
            String command = "d";
            tbDisplay.AppendText(command + Environment.NewLine);
            serialPort1.WriteLine(command);
            tbDisplay.AppendText("Reading reply: " + Environment.NewLine);
            string distance = ReadData();
            int status = CheckConnect();

            /*
                Only check for reply if status = 0 (was successful)
            */

            /*
            if (status == 0)
            {
                tbDisplay.AppendText("Reading data: " + Environment.NewLine);
                string data = serialPort1.ReadLine();
                tbDisplay.AppendText("Data received: " + data + Environment.NewLine);
            }
            */
            tbDistance.Text = distance;
        }

        private void btnReadColour_Click(object sender, EventArgs e)
        {
            //Sending the command 'c' to the embed to initiate the colour sensor function
            String command = "c";
            tbDisplay.AppendText(command + Environment.NewLine);
            serialPort1.WriteLine(command);

            tbDisplay.AppendText("Reading reply: " + Environment.NewLine);

            string clear = ReadData();//Calling the ReadData function to get the response from the MBED which will be the clear value
            tbDisplay.AppendText("Clear Value: " + clear + Environment.NewLine);//Printing the clear value on the display
            string red = ReadData();//Calling the ReadData function to get the response from the MBED which will be the red value
            tbDisplay.AppendText("Red Value: " + red + Environment.NewLine);//Printing the red value on the display
            string green = ReadData();//Calling the ReadData function to get the response from the MBED which will be the green value
            tbDisplay.AppendText("Green Value: " + green + Environment.NewLine);//Printing the green value on the display
            string blue = ReadData();//Calling the ReadData function to get the response from the MBED which will be the blue value
            tbDisplay.AppendText("Blue Value: " + blue + Environment.NewLine);//Printing the blue value on the display

            //Changing the colour box on the form to the colour from the sensor using the values obtained
            pbColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(Convert.ToInt32(red))))), ((int)(((byte)(Convert.ToInt32(green))))), ((int)(((byte)(Convert.ToInt32(blue))))));

            //Getting the status from the MBED to ensure the procedure ran correctly
            int status = CheckConnect();
        }
    }
}
