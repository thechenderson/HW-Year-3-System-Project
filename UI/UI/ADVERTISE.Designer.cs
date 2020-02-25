namespace UI
{
    partial class ADVERTISE
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
            this.pictureRed = new System.Windows.Forms.PictureBox();
            this.pictureGreen = new System.Windows.Forms.PictureBox();
            this.pictureBlue = new System.Windows.Forms.PictureBox();
            this.picturePurple = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.advertise_name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePurple)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureRed
            // 
            this.pictureRed.BackgroundImage = global::UI.Properties.Resources.RED;
            this.pictureRed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureRed.Location = new System.Drawing.Point(52, 236);
            this.pictureRed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureRed.Name = "pictureRed";
            this.pictureRed.Size = new System.Drawing.Size(929, 862);
            this.pictureRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureRed.TabIndex = 1;
            this.pictureRed.TabStop = false;
            this.pictureRed.Visible = false;
            // 
            // pictureGreen
            // 
            this.pictureGreen.BackgroundImage = global::UI.Properties.Resources.GREEN;
            this.pictureGreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureGreen.Location = new System.Drawing.Point(69, 247);
            this.pictureGreen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureGreen.Name = "pictureGreen";
            this.pictureGreen.Size = new System.Drawing.Size(912, 862);
            this.pictureGreen.TabIndex = 0;
            this.pictureGreen.TabStop = false;
            this.pictureGreen.Visible = false;
            // 
            // pictureBlue
            // 
            this.pictureBlue.BackgroundImage = global::UI.Properties.Resources.BLUE;
            this.pictureBlue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBlue.Location = new System.Drawing.Point(52, 236);
            this.pictureBlue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBlue.Name = "pictureBlue";
            this.pictureBlue.Size = new System.Drawing.Size(912, 862);
            this.pictureBlue.TabIndex = 3;
            this.pictureBlue.TabStop = false;
            this.pictureBlue.Visible = false;
            // 
            // picturePurple
            // 
            this.picturePurple.BackgroundImage = global::UI.Properties.Resources.PURPLE;
            this.picturePurple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picturePurple.Location = new System.Drawing.Point(52, 379);
            this.picturePurple.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picturePurple.Name = "picturePurple";
            this.picturePurple.Size = new System.Drawing.Size(929, 567);
            this.picturePurple.TabIndex = 2;
            this.picturePurple.TabStop = false;
            this.picturePurple.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(651, 97);
            this.label1.TabIndex = 4;
            this.label1.Text = "A bit of advertising...";
            // 
            // advertise_name
            // 
            this.advertise_name.AutoEllipsis = true;
            this.advertise_name.AutoSize = true;
            this.advertise_name.Font = new System.Drawing.Font("Monotype Corsiva", 54.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advertise_name.Location = new System.Drawing.Point(89, 1242);
            this.advertise_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.advertise_name.Name = "advertise_name";
            this.advertise_name.Size = new System.Drawing.Size(238, 111);
            this.advertise_name.TabIndex = 5;
            this.advertise_name.Text = "Name";
            this.advertise_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ADVERTISE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.ClientSize = new System.Drawing.Size(768, 1366);
            this.Controls.Add(this.advertise_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picturePurple);
            this.Controls.Add(this.pictureRed);
            this.Controls.Add(this.pictureGreen);
            this.Controls.Add(this.pictureBlue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ADVERTISE";
            this.Text = "Advertising";
            this.Load += new System.EventHandler(this.ADVERTISE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePurple)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureGreen;
        private System.Windows.Forms.PictureBox pictureRed;
        private System.Windows.Forms.PictureBox picturePurple;
        private System.Windows.Forms.PictureBox pictureBlue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label advertise_name;
    }
}