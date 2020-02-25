namespace AlienSays
{
    partial class alienSaysForm
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
            this.redButton = new System.Windows.Forms.Button();
            this.yellowButton = new System.Windows.Forms.Button();
            this.greenButton = new System.Windows.Forms.Button();
            this.blueButton = new System.Windows.Forms.Button();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.leaderboardsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // redButton
            // 
            this.redButton.BackColor = System.Drawing.Color.Transparent;
            this.redButton.BackgroundImage = global::AlienSays.Properties.Resources.redButtonOff;
            this.redButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.redButton.FlatAppearance.BorderSize = 0;
            this.redButton.Location = new System.Drawing.Point(13, 167);
            this.redButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(361, 434);
            this.redButton.TabIndex = 0;
            this.redButton.Text = "RED";
            this.redButton.UseVisualStyleBackColor = false;
            this.redButton.Click += new System.EventHandler(this.redButton_Click);
            // 
            // yellowButton
            // 
            this.yellowButton.BackColor = System.Drawing.Color.Transparent;
            this.yellowButton.BackgroundImage = global::AlienSays.Properties.Resources.yellowButtonOff;
            this.yellowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.yellowButton.Location = new System.Drawing.Point(376, 167);
            this.yellowButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.yellowButton.Name = "yellowButton";
            this.yellowButton.Size = new System.Drawing.Size(361, 434);
            this.yellowButton.TabIndex = 1;
            this.yellowButton.Text = "YELLOW";
            this.yellowButton.UseVisualStyleBackColor = false;
            this.yellowButton.Click += new System.EventHandler(this.yellowButton_Click);
            // 
            // greenButton
            // 
            this.greenButton.BackColor = System.Drawing.Color.Transparent;
            this.greenButton.BackgroundImage = global::AlienSays.Properties.Resources.greenButtonOff;
            this.greenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.greenButton.FlatAppearance.BorderSize = 0;
            this.greenButton.Location = new System.Drawing.Point(14, 609);
            this.greenButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(361, 434);
            this.greenButton.TabIndex = 2;
            this.greenButton.Text = "GREEN";
            this.greenButton.UseVisualStyleBackColor = false;
            this.greenButton.Click += new System.EventHandler(this.greenButton_Click);
            // 
            // blueButton
            // 
            this.blueButton.BackColor = System.Drawing.Color.Transparent;
            this.blueButton.BackgroundImage = global::AlienSays.Properties.Resources.blueButtonOff;
            this.blueButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.blueButton.Location = new System.Drawing.Point(377, 609);
            this.blueButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(361, 434);
            this.blueButton.TabIndex = 3;
            this.blueButton.Text = "BLUE";
            this.blueButton.UseVisualStyleBackColor = false;
            this.blueButton.Click += new System.EventHandler(this.blueButton_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(7, 1132);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(193, 52);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "Score: 0";
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.AutoSize = true;
            this.highScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.Location = new System.Drawing.Point(1049, 548);
            this.highScoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(280, 52);
            this.highScoreLabel.TabIndex = 5;
            this.highScoreLabel.Text = "Highscore: 0";
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.OliveDrab;
            this.startButton.Location = new System.Drawing.Point(5, 1188);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(362, 107);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // leaderboardsButton
            // 
            this.leaderboardsButton.BackColor = System.Drawing.Color.OliveDrab;
            this.leaderboardsButton.FlatAppearance.BorderSize = 0;
            this.leaderboardsButton.Location = new System.Drawing.Point(375, 1188);
            this.leaderboardsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.leaderboardsButton.Name = "leaderboardsButton";
            this.leaderboardsButton.Size = new System.Drawing.Size(362, 107);
            this.leaderboardsButton.TabIndex = 7;
            this.leaderboardsButton.Text = "LEADERBOARDS";
            this.leaderboardsButton.UseVisualStyleBackColor = false;
            this.leaderboardsButton.Click += new System.EventHandler(this.leaderboardsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 60F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 122);
            this.label1.TabIndex = 8;
            this.label1.Text = "Alien says...";
            // 
            // alienSaysForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(768, 1366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.leaderboardsButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.blueButton);
            this.Controls.Add(this.greenButton);
            this.Controls.Add(this.yellowButton);
            this.Controls.Add(this.redButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "alienSaysForm";
            this.Text = "Alien Says...";
            this.Load += new System.EventHandler(this.alienSaysForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Button yellowButton;
        private System.Windows.Forms.Button greenButton;
        private System.Windows.Forms.Button blueButton;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label highScoreLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button leaderboardsButton;
        private System.Windows.Forms.Label label1;
    }
}

