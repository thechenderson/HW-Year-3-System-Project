namespace Maintenance_mode
{
    partial class MAINT_MODE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbDistance = new System.Windows.Forms.TextBox();
            this.pbColour = new System.Windows.Forms.PictureBox();
            this.btnReadColour = new System.Windows.Forms.Button();
            this.btnReadDistance = new System.Windows.Forms.Button();
            this.lblSensorOps = new System.Windows.Forms.Label();
            this.btnServoRead = new System.Windows.Forms.Button();
            this.lblReadPosition = new System.Windows.Forms.Label();
            this.btnServoMove = new System.Windows.Forms.Button();
            this.nudServoAngle = new System.Windows.Forms.NumericUpDown();
            this.lblServoMove2 = new System.Windows.Forms.Label();
            this.nudServoNo = new System.Windows.Forms.NumericUpDown();
            this.lblServoMove1 = new System.Windows.Forms.Label();
            this.lblServoOps = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.tbDisplay = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudServoAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudServoNo)).BeginInit();
            this.SuspendLayout();
            // 
            // tbDistance
            // 
            this.tbDistance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbDistance.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDistance.Location = new System.Drawing.Point(72, 500);
            this.tbDistance.Name = "tbDistance";
            this.tbDistance.ReadOnly = true;
            this.tbDistance.Size = new System.Drawing.Size(100, 50);
            this.tbDistance.TabIndex = 33;
            this.tbDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbColour
            // 
            this.pbColour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbColour.BackColor = System.Drawing.Color.Black;
            this.pbColour.Location = new System.Drawing.Point(316, 500);
            this.pbColour.Name = "pbColour";
            this.pbColour.Size = new System.Drawing.Size(100, 50);
            this.pbColour.TabIndex = 32;
            this.pbColour.TabStop = false;
            // 
            // btnReadColour
            // 
            this.btnReadColour.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReadColour.Location = new System.Drawing.Point(280, 425);
            this.btnReadColour.Name = "btnReadColour";
            this.btnReadColour.Size = new System.Drawing.Size(168, 52);
            this.btnReadColour.TabIndex = 31;
            this.btnReadColour.Text = "Get Colour";
            this.btnReadColour.UseVisualStyleBackColor = true;
            this.btnReadColour.Click += new System.EventHandler(this.btnReadColour_Click);
            // 
            // btnReadDistance
            // 
            this.btnReadDistance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReadDistance.Location = new System.Drawing.Point(39, 425);
            this.btnReadDistance.Name = "btnReadDistance";
            this.btnReadDistance.Size = new System.Drawing.Size(168, 52);
            this.btnReadDistance.TabIndex = 30;
            this.btnReadDistance.Text = "Get Distance";
            this.btnReadDistance.UseVisualStyleBackColor = true;
            this.btnReadDistance.Click += new System.EventHandler(this.btnReadDistance_Click);
            // 
            // lblSensorOps
            // 
            this.lblSensorOps.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSensorOps.AutoSize = true;
            this.lblSensorOps.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSensorOps.Location = new System.Drawing.Point(116, 357);
            this.lblSensorOps.Name = "lblSensorOps";
            this.lblSensorOps.Size = new System.Drawing.Size(257, 35);
            this.lblSensorOps.TabIndex = 29;
            this.lblSensorOps.Text = "Sensor Operations:";
            // 
            // btnServoRead
            // 
            this.btnServoRead.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnServoRead.Location = new System.Drawing.Point(190, 255);
            this.btnServoRead.Name = "btnServoRead";
            this.btnServoRead.Size = new System.Drawing.Size(93, 31);
            this.btnServoRead.TabIndex = 28;
            this.btnServoRead.Text = "Read";
            this.btnServoRead.UseVisualStyleBackColor = true;
            this.btnServoRead.Click += new System.EventHandler(this.btnServoRead_Click);
            // 
            // lblReadPosition
            // 
            this.lblReadPosition.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblReadPosition.AutoSize = true;
            this.lblReadPosition.Location = new System.Drawing.Point(76, 212);
            this.lblReadPosition.Name = "lblReadPosition";
            this.lblReadPosition.Size = new System.Drawing.Size(338, 17);
            this.lblReadPosition.TabIndex = 27;
            this.lblReadPosition.Text = "Read the position of the most recently moved Servo:";
            // 
            // btnServoMove
            // 
            this.btnServoMove.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnServoMove.Location = new System.Drawing.Point(336, 128);
            this.btnServoMove.Name = "btnServoMove";
            this.btnServoMove.Size = new System.Drawing.Size(124, 33);
            this.btnServoMove.TabIndex = 26;
            this.btnServoMove.Text = "Start Moving";
            this.btnServoMove.UseVisualStyleBackColor = true;
            this.btnServoMove.Click += new System.EventHandler(this.btnServoMove_Click);
            // 
            // nudServoAngle
            // 
            this.nudServoAngle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudServoAngle.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudServoAngle.Location = new System.Drawing.Point(255, 131);
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
            this.nudServoAngle.Size = new System.Drawing.Size(54, 22);
            this.nudServoAngle.TabIndex = 25;
            // 
            // lblServoMove2
            // 
            this.lblServoMove2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblServoMove2.AutoSize = true;
            this.lblServoMove2.Location = new System.Drawing.Point(207, 139);
            this.lblServoMove2.Name = "lblServoMove2";
            this.lblServoMove2.Size = new System.Drawing.Size(20, 17);
            this.lblServoMove2.TabIndex = 24;
            this.lblServoMove2.Text = "to";
            // 
            // nudServoNo
            // 
            this.nudServoNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudServoNo.Location = new System.Drawing.Point(133, 131);
            this.nudServoNo.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudServoNo.Name = "nudServoNo";
            this.nudServoNo.Size = new System.Drawing.Size(57, 22);
            this.nudServoNo.TabIndex = 23;
            // 
            // lblServoMove1
            // 
            this.lblServoMove1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblServoMove1.AutoSize = true;
            this.lblServoMove1.Location = new System.Drawing.Point(19, 139);
            this.lblServoMove1.Name = "lblServoMove1";
            this.lblServoMove1.Size = new System.Drawing.Size(83, 17);
            this.lblServoMove1.TabIndex = 22;
            this.lblServoMove1.Text = "Move Servo";
            // 
            // lblServoOps
            // 
            this.lblServoOps.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblServoOps.AutoSize = true;
            this.lblServoOps.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServoOps.Location = new System.Drawing.Point(116, 81);
            this.lblServoOps.Name = "lblServoOps";
            this.lblServoOps.Size = new System.Drawing.Size(244, 35);
            this.lblServoOps.TabIndex = 21;
            this.lblServoOps.Text = "Servo Operations:";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnConnect.Location = new System.Drawing.Point(330, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(133, 30);
            this.btnConnect.TabIndex = 20;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // cbPort
            // 
            this.cbPort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(178, 20);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(121, 24);
            this.cbPort.TabIndex = 19;
            // 
            // lblPort
            // 
            this.lblPort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 27);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(124, 17);
            this.lblPort.TabIndex = 18;
            this.lblPort.Text = "Select a COM Port";
            // 
            // tbDisplay
            // 
            this.tbDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDisplay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbDisplay.Location = new System.Drawing.Point(12, 658);
            this.tbDisplay.Multiline = true;
            this.tbDisplay.Name = "tbDisplay";
            this.tbDisplay.ReadOnly = true;
            this.tbDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDisplay.Size = new System.Drawing.Size(464, 175);
            this.tbDisplay.TabIndex = 17;
            this.tbDisplay.Text = "\r\n\r\n\r\n";
            // 
            // MAINT_MODE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 853);
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
            this.Name = "MAINT_MODE";
            this.Text = "Maintenance Mode";
            this.Load += new System.EventHandler(this.MaintainanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudServoAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudServoNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.TextBox tbDistance;
        private System.Windows.Forms.PictureBox pbColour;
        private System.Windows.Forms.Button btnReadColour;
        private System.Windows.Forms.Button btnReadDistance;
        private System.Windows.Forms.Label lblSensorOps;
        private System.Windows.Forms.Button btnServoRead;
        private System.Windows.Forms.Label lblReadPosition;
        private System.Windows.Forms.Button btnServoMove;
        private System.Windows.Forms.NumericUpDown nudServoAngle;
        private System.Windows.Forms.Label lblServoMove2;
        private System.Windows.Forms.NumericUpDown nudServoNo;
        private System.Windows.Forms.Label lblServoMove1;
        private System.Windows.Forms.Label lblServoOps;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox tbDisplay;
        private System.IO.Ports.SerialPort serialPort1;
    }
}