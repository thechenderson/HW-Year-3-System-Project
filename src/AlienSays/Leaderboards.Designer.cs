namespace AlienSays
{
    partial class Leaderboards
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
            this.backToGameButton = new System.Windows.Forms.Button();
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backToGameButton
            // 
            this.backToGameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backToGameButton.BackColor = System.Drawing.Color.OliveDrab;
            this.backToGameButton.Location = new System.Drawing.Point(13, 1159);
            this.backToGameButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backToGameButton.Name = "backToGameButton";
            this.backToGameButton.Size = new System.Drawing.Size(724, 147);
            this.backToGameButton.TabIndex = 7;
            this.backToGameButton.Text = "<---BACK TO GAME";
            this.backToGameButton.UseVisualStyleBackColor = false;
            this.backToGameButton.Click += new System.EventHandler(this.backToGameButton_Click);
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.AutoSize = true;
            this.highScoreLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.Location = new System.Drawing.Point(98, 238);
            this.highScoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(639, 72);
            this.highScoreLabel.TabIndex = 8;
            this.highScoreLabel.Text = "Rank          Score          Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 72F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(131, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(590, 147);
            this.label1.TabIndex = 9;
            this.label1.Text = "Leaderboard";
            // 
            // Leaderboards
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(768, 1366);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.backToGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Leaderboards";
            this.Text = "Leaderboard";
            this.Load += new System.EventHandler(this.Leaderboards_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backToGameButton;
        private System.Windows.Forms.Label highScoreLabel;
        private System.Windows.Forms.Label label1;
    }
}