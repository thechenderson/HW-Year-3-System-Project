﻿using System;
using System.IO.Ports;     // added to use serial port features

namespace Maintenance_mode
{
    public class Functions
    {
        //Constants for communication
        const int READ_TIMEOUT = 10000;
        const int ERROR = -1;
        const string STR_ERROR = "";

        public int CheckConnect(SerialPort serialPort)//Checking if there is a connection between the PC and an MBED
        {
            string Response;
            int Status;

            serialPort.DiscardInBuffer();//Clearing any existing data from the connection between the PC and MBED
            serialPort.ReadTimeout = READ_TIMEOUT;//Setting the length for a Time Out
            try
            {
                Response = serialPort.ReadLine();//Reading the data from the MBED
            }
            catch (TimeoutException)//If there is an error recieving data
            {
                return ERROR;
            }

            Status = Convert.ToInt32(Response);
           
            return Status;
        }

        public string ReadData(SerialPort serialPort)//Reading the values being passed from the MBED
        {
            string Response;//Setting a string to store the data that is read
            serialPort.DiscardInBuffer();//Removing all existing data from the connection
            serialPort.ReadTimeout = READ_TIMEOUT;//Setting the time out length

            try
            {
                Response = serialPort.ReadLine();//Reading the data from the MBED

            }
            catch (TimeoutException)//If there is an error reading the data
            {
                return STR_ERROR;//returns a blank string to stop the program from crashing
            }
            return Response;
        }

        public int ButtonRead(SerialPort serialPort)
        {
            string command = "B";
            serialPort.WriteLine(command);//Send the command to the MBED
            string button = ReadData(serialPort);
            return Convert.ToInt32(button);
        }

        public int ServoMove(string state, SerialPort serialPort)
        {
            string command = "F " + state;
            serialPort.WriteLine(command);//Send the command to the MBED
            int status = CheckConnect(serialPort);//Get the status from the MBED
            return status;
        }

        public void ServoEnable(string state, SerialPort serialPort)
        {
            string command = "E "+ state;
            serialPort.WriteLine(command);//Send the command to the MBED
        }

        public void LEDs(string state, SerialPort serialPort)
        {
            string command = "L " + state;
            serialPort.WriteLine(command);//Send the command to the MBED
        }

        public int MBEDConnect(string com_port, SerialPort serialPort)
        {
            try
            {
                serialPort.PortName = com_port;
                serialPort.Open();//Attempt to open up a connection on the selected COM port
            }
            catch //If no connection could be made
            {
                return ERROR;
            }
            return 0;
        }

        public string ServoRead(SerialPort serialPort)
        {
            //Sends the command 'r' to the MBED to get the last servo value
            String command = "r";
            serialPort.WriteLine(command);

            string Servo = ReadData(serialPort);//Getting the value from the MBED
            string Pos = ReadData(serialPort);//Getting the value from the MBED
            int status = 0;// CheckConnect(serialPort);//Getting the status from the MBED

            string data = "Servo " + Servo + " was moved to position " + Pos;
            if (status != 0)
            {
                return status.ToString();
            }
            return data;
        }

        public int GetDistance(SerialPort serialPort)
        {
            String command = "d";
            serialPort.WriteLine(command);
            string distance = ReadData(serialPort);
            int status = 0;// CheckConnect(serialPort);

            if (status != 0)
            {
                return ERROR;
            }

            return Convert.ToInt32(distance);
        }

        public Tuple<string, string, string, string> GetColour(SerialPort serialPort)
        {
            //Sending the command 'c' to the embed to initiate the colour sensor function
            String command = "c";
            serialPort.WriteLine(command);

            string clear, red, green, blue;

            string line = ReadData(serialPort);
            string[] values = line.Split('\t');

            clear = values[0];
            red = values[1];
            green = values[2];
            blue = values[3];
            
            return Tuple.Create(clear, red, green, blue);
        }

        public bool CardCheck(SerialPort serialPort)
        {
            String command = "i"; 
            serialPort.WriteLine(command);
            string cardinserted = ReadData(serialPort);

            return Convert.ToBoolean(Convert.ToInt32(cardinserted));
        }

        public int CardIDRead(SerialPort serialPort)
        {
            String command = "u";
            serialPort.WriteLine(command);
            string cardID = ReadData(serialPort);

            return Convert.ToInt32(cardID);
        }

        public Tuple<bool, int, int, int> GetAll(SerialPort serialPort)
        {
            String command = "A";
            serialPort.WriteLine(command);
            string states = ReadData(serialPort);

            string[] all = states.Split('\t');

            bool CardIn;
            int UserNo, Dist, Button;

            CardIn = Convert.ToBoolean(Convert.ToInt32(all[0]));
            UserNo = Convert.ToInt32(all[1]);
            Dist = Convert.ToInt32(all[2]);
            Button = Convert.ToInt32(all[3]);

            return Tuple.Create(CardIn, UserNo, Dist, Button);
        }
    }
}
