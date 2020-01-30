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

        //Variables
        int global_error;

        public MaintainanceForm()
        {
            InitializeComponent();
        }


        public int CheckConnect()//Checking if there is a connection between the PC and an MBED
        {
            string Response;
            int Status;

            serialPort1.DiscardInBuffer();
            serialPort1.ReadTimeout = READ_TIMEOUT;
            try
            {
                Response = serialPort1.ReadLine();
            }
            catch (TimeoutException)
            {
                tbDisplay.AppendText("Readline timeout fail" + Environment.NewLine);
                return -1;
            }
            Status = Convert.ToInt32(Response);
            tbDisplay.AppendText("Status = " + Response + Environment.NewLine);
            return Status;
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
            ((System.ComponentModel.ISupportInitialize)(this.nudServoNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudServoAngle)).BeginInit();
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
            this.lblServoOps.AutoSize = true;
            this.lblServoOps.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServoOps.Location = new System.Drawing.Point(16, 75);
            this.lblServoOps.Name = "lblServoOps";
            this.lblServoOps.Size = new System.Drawing.Size(244, 35);
            this.lblServoOps.TabIndex = 4;
            this.lblServoOps.Text = "Servo Operations:";
            // 
            // lblServoMove1
            // 
            this.lblServoMove1.AutoSize = true;
            this.lblServoMove1.Location = new System.Drawing.Point(22, 141);
            this.lblServoMove1.Name = "lblServoMove1";
            this.lblServoMove1.Size = new System.Drawing.Size(108, 22);
            this.lblServoMove1.TabIndex = 5;
            this.lblServoMove1.Text = "Move Servo";
            // 
            // nudServoNo
            // 
            this.nudServoNo.Location = new System.Drawing.Point(136, 133);
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
            this.lblServoMove2.AutoSize = true;
            this.lblServoMove2.Location = new System.Drawing.Point(210, 141);
            this.lblServoMove2.Name = "lblServoMove2";
            this.lblServoMove2.Size = new System.Drawing.Size(29, 22);
            this.lblServoMove2.TabIndex = 7;
            this.lblServoMove2.Text = "by";
            // 
            // nudServoAngle
            // 
            this.nudServoAngle.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudServoAngle.Location = new System.Drawing.Point(258, 133);
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
            this.btnServoMove.Location = new System.Drawing.Point(339, 130);
            this.btnServoMove.Name = "btnServoMove";
            this.btnServoMove.Size = new System.Drawing.Size(124, 33);
            this.btnServoMove.TabIndex = 9;
            this.btnServoMove.Text = "Start Moving";
            this.btnServoMove.UseVisualStyleBackColor = true;
            this.btnServoMove.Click += new System.EventHandler(this.btnServoMove_Click);
            // 
            // MaintainanceForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(488, 853);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MaintainanceForm());
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
            string com_port = cbPort.SelectedItem.ToString();
            tbDisplay.AppendText("Selected COM Port = " + com_port + Environment.NewLine);
            try
            {
                tbDisplay.AppendText("Trying to open " + com_port + Environment.NewLine);
                serialPort1.PortName = com_port;
                serialPort1.Open();
            }
            catch
            {
                tbDisplay.AppendText("Cannot open " + com_port + Environment.NewLine);
                return;
            }
            tbDisplay.AppendText(com_port + " now open" + Environment.NewLine);
        }

        private void btnServoMove_Click(object sender, EventArgs e)
        {
            string command = "s "
                           + Convert.ToString(nudServoNo.Value)
                           + " "
                           + Convert.ToString(nudServoAngle.Value);
            tbDisplay.AppendText(command + Environment.NewLine);
            serialPort1.WriteLine(command);
            tbDisplay.AppendText("Reading reply" + Environment.NewLine);
            int status = CheckConnect();
        }


    }

}