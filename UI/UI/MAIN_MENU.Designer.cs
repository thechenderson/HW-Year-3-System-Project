namespace UI
{
    partial class MAIN_MENU
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
            this.fr_button = new System.Windows.Forms.Button();
            this.eng_buttton = new System.Windows.Forms.Button();
            this.button_game1 = new System.Windows.Forms.Button();
            this.translate_button = new System.Windows.Forms.Button();
            this.button_maintMode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fr_button
            // 
            this.fr_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fr_button.BackgroundImage = global::UI.Properties.Resources.FR;
            this.fr_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fr_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fr_button.Location = new System.Drawing.Point(441, 11);
            this.fr_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fr_button.Name = "fr_button";
            this.fr_button.Size = new System.Drawing.Size(58, 34);
            this.fr_button.TabIndex = 2;
            this.fr_button.UseVisualStyleBackColor = true;
            this.fr_button.Click += new System.EventHandler(this.fr_button_Click);
            // 
            // eng_buttton
            // 
            this.eng_buttton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.eng_buttton.BackgroundImage = global::UI.Properties.Resources.ENG;
            this.eng_buttton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eng_buttton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eng_buttton.Location = new System.Drawing.Point(503, 11);
            this.eng_buttton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.eng_buttton.Name = "eng_buttton";
            this.eng_buttton.Size = new System.Drawing.Size(58, 34);
            this.eng_buttton.TabIndex = 1;
            this.eng_buttton.UseVisualStyleBackColor = true;
            this.eng_buttton.Click += new System.EventHandler(this.eng_buttton_Click);
            // 
            // button_game1
            // 
            this.button_game1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_game1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button_game1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_game1.FlatAppearance.BorderSize = 0;
            this.button_game1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_game1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_game1.ForeColor = System.Drawing.Color.White;
            this.button_game1.Location = new System.Drawing.Point(67, 421);
            this.button_game1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_game1.Name = "button_game1";
            this.button_game1.Size = new System.Drawing.Size(432, 112);
            this.button_game1.TabIndex = 3;
            this.button_game1.Text = "ALIEN SAYS";
            this.button_game1.UseVisualStyleBackColor = false;
            this.button_game1.Click += new System.EventHandler(this.button_game1_Click);
            // 
            // translate_button
            // 
            this.translate_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.translate_button.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.translate_button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.translate_button.FlatAppearance.BorderSize = 0;
            this.translate_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.translate_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.translate_button.ForeColor = System.Drawing.Color.White;
            this.translate_button.Location = new System.Drawing.Point(67, 197);
            this.translate_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.translate_button.Name = "translate_button";
            this.translate_button.Size = new System.Drawing.Size(432, 112);
            this.translate_button.TabIndex = 4;
            this.translate_button.Text = "TRANSLATE";
            this.translate_button.UseVisualStyleBackColor = false;
            this.translate_button.Click += new System.EventHandler(this.translate_button_Click);
            // 
            // button_maintMode
            // 
            this.button_maintMode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_maintMode.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button_maintMode.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button_maintMode.FlatAppearance.BorderSize = 0;
            this.button_maintMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_maintMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_maintMode.ForeColor = System.Drawing.Color.White;
            this.button_maintMode.Location = new System.Drawing.Point(31, 636);
            this.button_maintMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_maintMode.Name = "button_maintMode";
            this.button_maintMode.Size = new System.Drawing.Size(511, 112);
            this.button_maintMode.TabIndex = 5;
            this.button_maintMode.Text = "MAINTENANCE";
            this.button_maintMode.UseVisualStyleBackColor = false;
            this.button_maintMode.Click += new System.EventHandler(this.button_maintMode_Click);
            // 
            // MAIN_MENU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(576, 991);
            this.Controls.Add(this.eng_buttton);
            this.Controls.Add(this.fr_button);
            this.Controls.Add(this.button_maintMode);
            this.Controls.Add(this.translate_button);
            this.Controls.Add(this.button_game1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MAIN_MENU";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button eng_buttton;
        private System.Windows.Forms.Button fr_button;
        private System.Windows.Forms.Button button_game1;
        private System.Windows.Forms.Button translate_button;
        private System.Windows.Forms.Button button_maintMode;
    }
}