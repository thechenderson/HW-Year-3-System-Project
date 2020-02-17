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
            this.SuspendLayout();
            // 
            // redButton
            // 
            this.redButton.BackColor = System.Drawing.Color.Maroon;
            this.redButton.Location = new System.Drawing.Point(12, 12);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(367, 176);
            this.redButton.TabIndex = 0;
            this.redButton.Text = "RED";
            this.redButton.UseVisualStyleBackColor = false;
            this.redButton.Click += new System.EventHandler(this.redButton_Click);
            // 
            // yellowButton
            // 
            this.yellowButton.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.yellowButton.Location = new System.Drawing.Point(385, 12);
            this.yellowButton.Name = "yellowButton";
            this.yellowButton.Size = new System.Drawing.Size(367, 176);
            this.yellowButton.TabIndex = 1;
            this.yellowButton.Text = "YELLOW";
            this.yellowButton.UseVisualStyleBackColor = false;
            this.yellowButton.Click += new System.EventHandler(this.yellowButton_Click);
            // 
            // greenButton
            // 
            this.greenButton.BackColor = System.Drawing.Color.DarkGreen;
            this.greenButton.Location = new System.Drawing.Point(12, 194);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(367, 176);
            this.greenButton.TabIndex = 2;
            this.greenButton.Text = "GREEN";
            this.greenButton.UseVisualStyleBackColor = false;
            this.greenButton.Click += new System.EventHandler(this.greenButton_Click);
            // 
            // blueButton
            // 
            this.blueButton.BackColor = System.Drawing.Color.MidnightBlue;
            this.blueButton.Location = new System.Drawing.Point(385, 194);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(367, 176);
            this.blueButton.TabIndex = 3;
            this.blueButton.Text = "BLUE";
            this.blueButton.UseVisualStyleBackColor = false;
            this.blueButton.Click += new System.EventHandler(this.blueButton_Click);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Stencil", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(12, 377);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(173, 42);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "Score: 0";
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.AutoSize = true;
            this.highScoreLabel.Font = new System.Drawing.Font("Stencil", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.Location = new System.Drawing.Point(487, 377);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(265, 42);
            this.highScoreLabel.TabIndex = 5;
            this.highScoreLabel.Text = "Highscore: 0";
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.SlateGray;
            this.startButton.Location = new System.Drawing.Point(12, 422);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(740, 87);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "START";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // alienSaysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 517);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.blueButton);
            this.Controls.Add(this.greenButton);
            this.Controls.Add(this.yellowButton);
            this.Controls.Add(this.redButton);
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
    }
}

