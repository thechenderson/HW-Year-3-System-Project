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


namespace MaintainanceMode{
    public partial class MaintainanceForm : Form
    {
        //Constants
        const int OK = 0;
        const int FORMAT_ERROR = -1;
        const int COM_BAUD = 115200;
        const int READ_TIMEOUT = 10000;
        private SerialPort serialPort1;
        private IContainer components;
        private TextBox tbDisplay;
        private Label lblPort;
        private ComboBox cbPort;
        private Button btnConnect;
        private Label lblServoOps;
        private Label lblServoMove1;
        private NumericUpDown nudServoNo;
        private Label lblServoMove2;
        private NumericUpDown nudServoAngle;
        private Button btnServoMove;
        private Label lblReadPosition;
        private Button btnServoRead;
        private Label lblSensorOps;
        private Button btnReadDistance;
        private Button btnReadColour;
        private PictureBox pbColour;
        private TextBox tbDistance;
        private System.Windows.Forms.Button checkCard;
        private System.Windows.Forms.Button btnCardRead;

        //Variables
        int global_error;

        public MaintainanceForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblServoOps = new System.Windows.Forms.Label();
            this.lblServoMove1 = new System.Windows.Forms.Label();
            this.nudServoNo = new System.Windows.Forms.NumericUpDown();
            this.lblServoMove2 = new System.Windows.Forms.Label();
            this.nudServoAngle = new System.Windows.Forms.NumericUpDown();
            this.btnServoMove = new System.Windows.Forms.Button();
            this.lblReadPosition = new System.Windows.Forms.Label();
            this.btnServoRead = new System.Windows.Forms.Button();
            this.lblSensorOps = new System.Windows.Forms.Label();
            this.btnReadDistance = new System.Windows.Forms.Button();
            this.btnReadColour = new System.Windows.Forms.Button();
            this.pbColour = new System.Windows.Forms.PictureBox();
            this.tbDistance = new System.Windows.Forms.TextBox();
            this.checkCard = new System.Windows.Forms.Button();
            this.btnCardRead = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudServoNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudServoAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColour)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDisplay
            // 
            this.tbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisplay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDisplay.Location = new System.Drawing.Point(12, 650);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.ReadOnly = true;
            this.tbDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDisplay.Size = new System.Drawing.Size(464, 175);
            this.tbDisplay.TabIndex = 0;
            this.tbDisplay.Text = "\r\n\r\n\r\n";
            // 
            // lblPort
            // 
            this.lblPort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 19);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(160, 22);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Select a COM Port";
            // 
            // cbPort
            // 
            this.cbPort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(178, 12);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(121, 30);
            this.cbPort.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConnect.Location = new System.Drawing.Point(330, 11);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(133, 30);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblServoOps
            // 
            this.lblServoOps.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblServoOps.AutoSize = true;
            this.lblServoOps.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServoOps.Location = new System.Drawing.Point(116, 73);
            this.lblServoOps.Name = "lblServoOps";
            this.lblServoOps.Size = new System.Drawing.Size(244, 35);
            this.lblServoOps.TabIndex = 4;
            this.lblServoOps.Text = "Servo Operations:";
            // 
            // lblServoMove1
            // 
            this.lblServoMove1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblServoMove1.AutoSize = true;
            this.lblServoMove1.Location = new System.Drawing.Point(19, 131);
            this.lblServoMove1.Name = "lblServoMove1";
            this.lblServoMove1.Size = new System.Drawing.Size(108, 22);
            this.lblServoMove1.TabIndex = 5;
            this.lblServoMove1.Text = "Move Servo";
            // 
            // nudServoNo
            // 
            this.nudServoNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudServoNo.Location = new System.Drawing.Point(133, 123);
            this.nudServoNo.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudServoNo.Name = "nudServoNo";
            this.nudServoNo.Size = new System.Drawing.Size(57, 30);
            this.nudServoNo.TabIndex = 6;
            // 
            // lblServoMove2
            // 
            this.lblServoMove2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblServoMove2.AutoSize = true;
            this.lblServoMove2.Location = new System.Drawing.Point(207, 131);
            this.lblServoMove2.Name = "lblServoMove2";
            this.lblServoMove2.Size = new System.Drawing.Size(25, 22);
            this.lblServoMove2.TabIndex = 7;
            this.lblServoMove2.Text = "to";
            // 
            // nudServoAngle
            // 
            this.nudServoAngle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudServoAngle.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudServoAngle.Location = new System.Drawing.Point(255, 123);
            this.nudServoAngle.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudServoAngle.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.nudServoAngle.Name = "nudServoAngle";
            this.nudServoAngle.Size = new System.Drawing.Size(54, 30);
            this.nudServoAngle.TabIndex = 8;
            // 
            // btnServoMove
            // 
            this.btnServoMove.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnServoMove.Location = new System.Drawing.Point(336, 120);
            this.btnServoMove.Name = "btnServoMove";
            this.btnServoMove.Size = new System.Drawing.Size(124, 33);
            this.btnServoMove.TabIndex = 9;
            this.btnServoMove.Text = "Start Moving";
            this.btnServoMove.UseVisualStyleBackColor = true;
            this.btnServoMove.Click += new System.EventHandler(this.btnServoMove_Click);
            // 
            // lblReadPosition
            // 
            this.lblReadPosition.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblReadPosition.AutoSize = true;
            this.lblReadPosition.Location = new System.Drawing.Point(76, 204);
            this.lblReadPosition.Name = "lblReadPosition";
            this.lblReadPosition.Size = new System.Drawing.Size(423, 22);
            this.lblReadPosition.TabIndex = 10;
            this.lblReadPosition.Text = "Read the position of the most recently moved Servo:";
            // 
            // btnServoRead
            // 
            this.btnServoRead.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnServoRead.Location = new System.Drawing.Point(190, 247);
            this.btnServoRead.Name = "btnServoRead";
            this.btnServoRead.Size = new System.Drawing.Size(93, 31);
            this.btnServoRead.TabIndex = 11;
            this.btnServoRead.Text = "Read";
            this.btnServoRead.UseVisualStyleBackColor = true;
            this.btnServoRead.Click += new System.EventHandler(this.btnServoRead_Click);
            // 
            // lblSensorOps
            // 
            this.lblSensorOps.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSensorOps.AutoSize = true;
            this.lblSensorOps.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSensorOps.Location = new System.Drawing.Point(116, 349);
            this.lblSensorOps.Name = "lblSensorOps";
            this.lblSensorOps.Size = new System.Drawing.Size(257, 35);
            this.lblSensorOps.TabIndex = 12;
            this.lblSensorOps.Text = "Sensor Operations:";
            // 
            // btnReadDistance
            // 
            this.btnReadDistance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReadDistance.Location = new System.Drawing.Point(39, 417);
            this.btnReadDistance.Name = "btnReadDistance";
            this.btnReadDistance.Size = new System.Drawing.Size(168, 52);
            this.btnReadDistance.TabIndex = 13;
            this.btnReadDistance.Text = "Get Distance";
            this.btnReadDistance.UseVisualStyleBackColor = true;
            this.btnReadDistance.Click += new System.EventHandler(this.btnReadDistance_Click);
            // 
            // btnReadColour
            // 
            this.btnReadColour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReadColour.Location = new System.Drawing.Point(280, 417);
            this.btnReadColour.Name = "btnReadColour";
            this.btnReadColour.Size = new System.Drawing.Size(168, 52);
            this.btnReadColour.TabIndex = 14;
            this.btnReadColour.Text = "Get Colour";
            this.btnReadColour.UseVisualStyleBackColor = true;
            this.btnReadColour.Click += new System.EventHandler(this.btnReadColour_Click);
            // 
            // pbColour
            // 
            this.pbColour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbColour.BackColor = System.Drawing.Color.Black;
            this.pbColour.Location = new System.Drawing.Point(316, 492);
            this.pbColour.Name = "pbColour";
            this.pbColour.Size = new System.Drawing.Size(100, 50);
            this.pbColour.TabIndex = 15;
            this.pbColour.TabStop = false;
            // 
            // tbDistance
            // 
            this.tbDistance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbDistance.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDistance.Location = new System.Drawing.Point(72, 492);
            this.tbDistance.Name = "tbDistance";
            this.tbDistance.ReadOnly = true;
            this.tbDistance.Size = new System.Drawing.Size(100, 50);
            this.tbDistance.TabIndex = 16;
            this.tbDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkCard
            // 
            this.checkCard.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkCard.Location = new System.Drawing.Point(29, 437);
            this.checkCard.Margin = new System.Windows.Forms.Padding(2);
            this.checkCard.Name = "checkCard";
            this.checkCard.Size = new System.Drawing.Size(126, 42);
            this.checkCard.TabIndex = 34;
            this.checkCard.Text = "Check Card";
            this.checkCard.UseVisualStyleBackColor = true;
            this.checkCard.Click += new System.EventHandler(this.btnCheckCard_Click);
            // 
            // btnCardRead
            // 
            this.btnCardRead.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCardRead.Location = new System.Drawing.Point(210, 437);
            this.btnCardRead.Margin = new System.Windows.Forms.Padding(2);
            this.btnCardRead.Name = "btnCardRead";
            this.btnCardRead.Size = new System.Drawing.Size(126, 42);
            this.btnCardRead.TabIndex = 35;
            this.btnCardRead.Text = "Read Card ID";
            this.btnCardRead.UseVisualStyleBackColor = true;
            this.btnCardRead.Click += new System.EventHandler(this.btnCardRead_Click);
            // 
            // MaintainanceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(488, 853);
            this.Controls.Add(this.btnCardRead);
            this.Controls.Add(this.checkCard);
            this.Controls.Add(this.tbDistance);
            this.Controls.Add(this.pbColour);
            this.Controls.Add(this.btnReadColour);
            this.Controls.Add(this.btnReadDistance);
            this.Controls.Add(this.lblSensorOps);
            this.Controls.Add(this.btnServoRead);
            this.Controls.Add(this.lblReadPosition);
            this.Controls.Add(this.btnServoMove);
            this.Controls.Add(this.nudServoAngle);
            this.Controls.Add(this.lblServoMove2);
            this.Controls.Add(this.nudServoNo);
            this.Controls.Add(this.lblServoMove1);
            this.Controls.Add(this.lblServoOps);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.tbDisplay);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(1080, 1920);
            this.MinimumSize = new System.Drawing.Size(506, 900);
            this.Name = "MaintainanceForm";
            this.Text = "Maintainance Mode";
            this.Load += new System.EventHandler(this.MaintainanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudServoNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudServoAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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

        private void btnConnect_Click(object sender, EventArgs e)//When the connect button is pressed
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

        private void btnServoMove_Click(object sender, EventArgs e)//When the Move Servo button is pressed
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

        private void btnServoRead_Click(object sender, EventArgs e)//When the Read Servo button is pressed
        {
            //Sends the command 'r' to the MBED to get the last servo value
            String command = "r";
            tbDisplay.AppendText(command + Environment.NewLine);
            serialPort1.WriteLine(command);

            tbDisplay.AppendText("Reading reply: " + Environment.NewLine);

            string servo = ReadData();//Getting the value from the MBED
            string pos = ReadData();
            int status = CheckConnect();//Getting the status from the MBED

            if (status == 0)//Running if the MBED program ran correctly
            {
                tbDisplay.AppendText("reading data" + Environment.NewLine);
                tbDisplay.AppendText("Servo = " + servo + Environment.NewLine);
                tbDisplay.AppendText("Position = " + pos + Environment.NewLine);
            }
            else //Displaying if there was an error when the MBED operated
            {
                tbDisplay.AppendText("Error when reading the data");
            }
        }

        private void btnReadDistance_Click(object sender, EventArgs e)//When the Read Distance button is pressed
        {

            String command = "d";
            tbDisplay.AppendText(command + Environment.NewLine);
            serialPort1.WriteLine(command);
            tbDisplay.AppendText("Reading reply: " + Environment.NewLine);
            string distance = ReadData();
            int status = CheckConnect();

            tbDistance.Text = distance + " mm";
        }



        private void btnReadColour_Click(object sender, EventArgs e)
        {

            //Sending the command 'c' to the embed to initiate the colour sensor function
            String command = "c";
            tbDisplay.AppendText(command + Environment.NewLine);
            serialPort1.WriteLine(command);

            tbDisplay.AppendText("Reading reply: " + Environment.NewLine);

            string clear = ReadData();//Calling the ReadData function to get the response from the MBED which will be the clear value
            tbDisplay.AppendText("Clear Value: "+ clear + Environment.NewLine);//Printing the clear value on the display
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

        private void btnCheckCard_Click(object sender, EventArgs e)
        {

            tbDisplay.AppendText("Checking card is inserted..." + Environment.NewLine);

            String command = "i";
            serialPort1.WriteLine(command);
            string CheckCard = ReadData();

            int status = CheckConnect();//Getting the status


            if (status == 0)//If there was no errors
            {
                tbDisplay.AppendText("Card Check Result: " + CheckCard + Environment.NewLine);
            }
            else
            {
                tbDisplay.AppendText("Error reading the card");
            }


        }

        private void btnCardRead_Click(object sender, EventArgs e)
        {

            tbDisplay.AppendText("Reading card value..." + Environment.NewLine);

            String command = "u";
            serialPort1.WriteLine(command);
            string cardValue = ReadData();

            int status = CheckConnect();//Getting the status


            if (status == 0)//If there was no errors
            {
                tbDisplay.AppendText("Card ID: " + cardValue + Environment.NewLine);
            }
            else
            {
                tbDisplay.AppendText("Error reading the card ID");
            }

        }

        static void Main()//Starts the program and sets up the form
        {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MaintainanceForm());
         }

    }
}
  