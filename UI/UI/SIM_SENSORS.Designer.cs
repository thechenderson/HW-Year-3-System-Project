namespace UI
{
    partial class SIM_SENSORS
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
            this.color_sensor = new System.Windows.Forms.GroupBox();
            this.blue = new System.Windows.Forms.RadioButton();
            this.purple = new System.Windows.Forms.RadioButton();
            this.red = new System.Windows.Forms.RadioButton();
            this.green = new System.Windows.Forms.RadioButton();
            this.maint_card = new System.Windows.Forms.CheckBox();
            this.cb_presence = new System.Windows.Forms.CheckBox();
            this.cb_cardread = new System.Windows.Forms.CheckBox();
            this.color_sensor.SuspendLayout();
            this.SuspendLayout();
            // 
            // color_sensor
            // 
            this.color_sensor.Controls.Add(this.blue);
            this.color_sensor.Controls.Add(this.purple);
            this.color_sensor.Controls.Add(this.red);
            this.color_sensor.Controls.Add(this.green);
            this.color_sensor.Location = new System.Drawing.Point(497, 73);
            this.color_sensor.Name = "color_sensor";
            this.color_sensor.Size = new System.Drawing.Size(200, 304);
            this.color_sensor.TabIndex = 4;
            this.color_sensor.TabStop = false;
            this.color_sensor.Text = "Color Sensor";
            // 
            // blue
            // 
            this.blue.AutoSize = true;
            this.blue.Location = new System.Drawing.Point(62, 240);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(57, 21);
            this.blue.TabIndex = 3;
            this.blue.TabStop = true;
            this.blue.Text = "Blue";
            this.blue.UseVisualStyleBackColor = true;
            // 
            // purple
            // 
            this.purple.AutoSize = true;
            this.purple.Location = new System.Drawing.Point(62, 181);
            this.purple.Name = "purple";
            this.purple.Size = new System.Drawing.Size(70, 21);
            this.purple.TabIndex = 2;
            this.purple.TabStop = true;
            this.purple.Text = "Purple";
            this.purple.UseVisualStyleBackColor = true;
            // 
            // red
            // 
            this.red.AutoSize = true;
            this.red.Location = new System.Drawing.Point(62, 122);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(55, 21);
            this.red.TabIndex = 1;
            this.red.TabStop = true;
            this.red.Text = "Red";
            this.red.UseVisualStyleBackColor = true;
            // 
            // green
            // 
            this.green.AutoSize = true;
            this.green.Location = new System.Drawing.Point(62, 59);
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(69, 21);
            this.green.TabIndex = 0;
            this.green.TabStop = true;
            this.green.Text = "Green";
            this.green.UseVisualStyleBackColor = true;
            // 
            // maint_card
            // 
            this.maint_card.AutoSize = true;
            this.maint_card.Location = new System.Drawing.Point(139, 181);
            this.maint_card.Name = "maint_card";
            this.maint_card.Size = new System.Drawing.Size(145, 21);
            this.maint_card.TabIndex = 7;
            this.maint_card.Text = "Maintenance Card";
            this.maint_card.UseVisualStyleBackColor = true;
            this.maint_card.Visible = false;
            this.maint_card.CheckedChanged += new System.EventHandler(this.maint_card_CheckedChanged_1);
            // 
            // cb_presence
            // 
            this.cb_presence.AutoSize = true;
            this.cb_presence.Location = new System.Drawing.Point(104, 221);
            this.cb_presence.Name = "cb_presence";
            this.cb_presence.Size = new System.Drawing.Size(148, 21);
            this.cb_presence.TabIndex = 6;
            this.cb_presence.Text = "Presence Detector";
            this.cb_presence.UseVisualStyleBackColor = true;
            this.cb_presence.CheckedChanged += new System.EventHandler(this.cb_presence_CheckedChanged);
            // 
            // cb_cardread
            // 
            this.cb_cardread.AutoSize = true;
            this.cb_cardread.Location = new System.Drawing.Point(104, 154);
            this.cb_cardread.Name = "cb_cardread";
            this.cb_cardread.Size = new System.Drawing.Size(111, 21);
            this.cb_cardread.TabIndex = 5;
            this.cb_cardread.Text = "Card Reader";
            this.cb_cardread.UseVisualStyleBackColor = true;
            this.cb_cardread.CheckedChanged += new System.EventHandler(this.cb_cardread_CheckedChanged_1);
            // 
            // SIM_SENSORS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.color_sensor);
            this.Controls.Add(this.maint_card);
            this.Controls.Add(this.cb_presence);
            this.Controls.Add(this.cb_cardread);
            this.Name = "SIM_SENSORS";
            this.Text = "Sensors";
            this.Load += new System.EventHandler(this.SIM_SENSORS_Load);
            this.color_sensor.ResumeLayout(false);
            this.color_sensor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox color_sensor;
        private System.Windows.Forms.RadioButton blue;
        private System.Windows.Forms.RadioButton purple;
        private System.Windows.Forms.RadioButton red;
        private System.Windows.Forms.RadioButton green;
        private System.Windows.Forms.CheckBox maint_card;
        private System.Windows.Forms.CheckBox cb_presence;
        private System.Windows.Forms.CheckBox cb_cardread;
    }
}