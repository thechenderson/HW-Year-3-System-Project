﻿namespace UI
{
    partial class TRANSLATION
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
            this.backtomm = new System.Windows.Forms.Button();
            this.sentence1 = new System.Windows.Forms.Button();
            this.sentence2 = new System.Windows.Forms.Button();
            this.sentence4 = new System.Windows.Forms.Button();
            this.fr_button = new System.Windows.Forms.Button();
            this.eng_buttton = new System.Windows.Forms.Button();
            this.sentence3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backtomm
            // 
            this.backtomm.Location = new System.Drawing.Point(831, 1276);
            this.backtomm.Name = "backtomm";
            this.backtomm.Size = new System.Drawing.Size(208, 71);
            this.backtomm.TabIndex = 3;
            this.backtomm.Text = "Back to main menu";
            this.backtomm.UseVisualStyleBackColor = true;
            this.backtomm.Click += new System.EventHandler(this.backtomm_Click);
            // 
            // sentence1
            // 
            this.sentence1.Location = new System.Drawing.Point(48, 115);
            this.sentence1.Name = "sentence1";
            this.sentence1.Size = new System.Drawing.Size(311, 364);
            this.sentence1.TabIndex = 4;
            this.sentence1.Text = "I am an alien robot";
            this.sentence1.UseVisualStyleBackColor = true;
            this.sentence1.Click += new System.EventHandler(this.sentence1_Click);
            // 
            // sentence2
            // 
            this.sentence2.Location = new System.Drawing.Point(491, 115);
            this.sentence2.Name = "sentence2";
            this.sentence2.Size = new System.Drawing.Size(311, 364);
            this.sentence2.TabIndex = 6;
            this.sentence2.Text = "I like Haggis pizza";
            this.sentence2.UseVisualStyleBackColor = true;
            this.sentence2.Click += new System.EventHandler(this.sentence2_Click);
            // 
            // sentence4
            // 
            this.sentence4.Location = new System.Drawing.Point(491, 603);
            this.sentence4.Name = "sentence4";
            this.sentence4.Size = new System.Drawing.Size(311, 364);
            this.sentence4.TabIndex = 7;
            this.sentence4.Text = "Come play with me!";
            this.sentence4.UseVisualStyleBackColor = true;
            this.sentence4.Click += new System.EventHandler(this.sentence4_Click);
            // 
            // fr_button
            // 
            this.fr_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fr_button.BackgroundImage = global::UI.Properties.Resources.FR;
            this.fr_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fr_button.Location = new System.Drawing.Point(813, 12);
            this.fr_button.Name = "fr_button";
            this.fr_button.Size = new System.Drawing.Size(124, 76);
            this.fr_button.TabIndex = 9;
            this.fr_button.UseVisualStyleBackColor = true;
            this.fr_button.Click += new System.EventHandler(this.fr_button_Click);
            // 
            // eng_buttton
            // 
            this.eng_buttton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eng_buttton.BackgroundImage = global::UI.Properties.Resources.ENG;
            this.eng_buttton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eng_buttton.Location = new System.Drawing.Point(943, 12);
            this.eng_buttton.Name = "eng_buttton";
            this.eng_buttton.Size = new System.Drawing.Size(124, 76);
            this.eng_buttton.TabIndex = 8;
            this.eng_buttton.UseVisualStyleBackColor = true;
            this.eng_buttton.Click += new System.EventHandler(this.eng_buttton_Click);
            // 
            // sentence3
            // 
            this.sentence3.Location = new System.Drawing.Point(48, 603);
            this.sentence3.Name = "sentence3";
            this.sentence3.Size = new System.Drawing.Size(311, 364);
            this.sentence3.TabIndex = 10;
            this.sentence3.Text = "I was created by ArBots";
            this.sentence3.UseVisualStyleBackColor = true;
            this.sentence3.Click += new System.EventHandler(this.sentence3_Click);
            // 
            // TRANSLATION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 1388);
            this.Controls.Add(this.sentence3);
            this.Controls.Add(this.fr_button);
            this.Controls.Add(this.eng_buttton);
            this.Controls.Add(this.sentence4);
            this.Controls.Add(this.sentence2);
            this.Controls.Add(this.sentence1);
            this.Controls.Add(this.backtomm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TRANSLATION";
            this.Text = "TRANSLATION";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button backtomm;
        private System.Windows.Forms.Button sentence1;
        private System.Windows.Forms.Button sentence2;
        private System.Windows.Forms.Button sentence4;
        private System.Windows.Forms.Button fr_button;
        private System.Windows.Forms.Button eng_buttton;
        private System.Windows.Forms.Button sentence3;
    }
}