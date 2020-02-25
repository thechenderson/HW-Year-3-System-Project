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
            this.SuspendLayout();
            // 
            // backToGameButton
            // 
            this.backToGameButton.BackColor = System.Drawing.Color.SlateGray;
            this.backToGameButton.Location = new System.Drawing.Point(12, 12);
            this.backToGameButton.Name = "backToGameButton";
            this.backToGameButton.Size = new System.Drawing.Size(124, 394);
            this.backToGameButton.TabIndex = 7;
            this.backToGameButton.Text = "<---BACK TO GAME";
            this.backToGameButton.UseVisualStyleBackColor = false;
            this.backToGameButton.Click += new System.EventHandler(this.backToGameButton_Click);
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.AutoSize = true;
            this.highScoreLabel.Font = new System.Drawing.Font("Stencil", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.Location = new System.Drawing.Point(142, 12);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(916, 42);
            this.highScoreLabel.TabIndex = 8;
            this.highScoreLabel.Text = "Rank                              Score                             Name";
            // 
            // Leaderboards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 418);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.backToGameButton);
            this.Name = "Leaderboards";
            this.Text = "Leaderboard";
            this.Load += new System.EventHandler(this.Leaderboards_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backToGameButton;
        private System.Windows.Forms.Label highScoreLabel;
    }
}