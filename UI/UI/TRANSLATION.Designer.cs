namespace UI
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
            this.backtomm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backtomm.Location = new System.Drawing.Point(192, 879);
            this.backtomm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.backtomm.Name = "backtomm";
            this.backtomm.Size = new System.Drawing.Size(156, 58);
            this.backtomm.TabIndex = 3;
            this.backtomm.Text = "Back to main menu";
            this.backtomm.UseVisualStyleBackColor = true;
            this.backtomm.Click += new System.EventHandler(this.backtomm_Click);
            // 
            // sentence1
            // 
            this.sentence1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sentence1.Location = new System.Drawing.Point(20, 113);
            this.sentence1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sentence1.Name = "sentence1";
            this.sentence1.Size = new System.Drawing.Size(196, 276);
            this.sentence1.TabIndex = 4;
            this.sentence1.Text = "I am an alien robot";
            this.sentence1.UseVisualStyleBackColor = true;
            this.sentence1.Click += new System.EventHandler(this.sentence1_Click);
            // 
            // sentence2
            // 
            this.sentence2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sentence2.Location = new System.Drawing.Point(317, 113);
            this.sentence2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sentence2.Name = "sentence2";
            this.sentence2.Size = new System.Drawing.Size(196, 276);
            this.sentence2.TabIndex = 6;
            this.sentence2.Text = "I like Haggis pizza";
            this.sentence2.UseVisualStyleBackColor = true;
            this.sentence2.Click += new System.EventHandler(this.sentence2_Click);
            // 
            // sentence4
            // 
            this.sentence4.Location = new System.Drawing.Point(317, 579);
            this.sentence4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sentence4.Name = "sentence4";
            this.sentence4.Size = new System.Drawing.Size(196, 276);
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
            this.fr_button.Location = new System.Drawing.Point(339, 11);
            this.fr_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fr_button.Name = "fr_button";
            this.fr_button.Size = new System.Drawing.Size(93, 62);
            this.fr_button.TabIndex = 9;
            this.fr_button.UseVisualStyleBackColor = true;
            this.fr_button.Click += new System.EventHandler(this.fr_button_Click);
            // 
            // eng_buttton
            // 
            this.eng_buttton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eng_buttton.BackgroundImage = global::UI.Properties.Resources.ENG;
            this.eng_buttton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eng_buttton.Location = new System.Drawing.Point(436, 11);
            this.eng_buttton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.eng_buttton.Name = "eng_buttton";
            this.eng_buttton.Size = new System.Drawing.Size(93, 62);
            this.eng_buttton.TabIndex = 8;
            this.eng_buttton.UseVisualStyleBackColor = true;
            this.eng_buttton.Click += new System.EventHandler(this.eng_buttton_Click);
            // 
            // sentence3
            // 
            this.sentence3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sentence3.Location = new System.Drawing.Point(20, 579);
            this.sentence3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sentence3.Name = "sentence3";
            this.sentence3.Size = new System.Drawing.Size(196, 276);
            this.sentence3.TabIndex = 10;
            this.sentence3.Text = "I was created by ArBots";
            this.sentence3.UseVisualStyleBackColor = true;
            this.sentence3.Click += new System.EventHandler(this.sentence3_Click);
            // 
            // TRANSLATION
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(540, 960);
            this.Controls.Add(this.sentence3);
            this.Controls.Add(this.fr_button);
            this.Controls.Add(this.eng_buttton);
            this.Controls.Add(this.sentence4);
            this.Controls.Add(this.sentence2);
            this.Controls.Add(this.sentence1);
            this.Controls.Add(this.backtomm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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