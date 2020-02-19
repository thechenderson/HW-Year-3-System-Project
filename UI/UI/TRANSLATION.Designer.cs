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
            this.Translate = new System.Windows.Forms.Button();
            this.Texttotrans = new System.Windows.Forms.TextBox();
            this.Texttranslate = new System.Windows.Forms.Label();
            this.backtomm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Translate
            // 
            this.Translate.Location = new System.Drawing.Point(320, 284);
            this.Translate.Name = "Translate";
            this.Translate.Size = new System.Drawing.Size(94, 23);
            this.Translate.TabIndex = 0;
            this.Translate.Text = "Translate";
            this.Translate.UseVisualStyleBackColor = true;
            this.Translate.Click += new System.EventHandler(this.Translate_Click);
            // 
            // Texttotrans
            // 
            this.Texttotrans.Location = new System.Drawing.Point(106, 178);
            this.Texttotrans.Name = "Texttotrans";
            this.Texttotrans.Size = new System.Drawing.Size(152, 22);
            this.Texttotrans.TabIndex = 1;
            // 
            // Texttranslate
            // 
            this.Texttranslate.AutoSize = true;
            this.Texttranslate.Location = new System.Drawing.Point(463, 182);
            this.Texttranslate.Name = "Texttranslate";
            this.Texttranslate.Size = new System.Drawing.Size(48, 17);
            this.Texttranslate.TabIndex = 2;
            this.Texttranslate.Text = "Result";
            // 
            // backtomm
            // 
            this.backtomm.Location = new System.Drawing.Point(554, 378);
            this.backtomm.Name = "backtomm";
            this.backtomm.Size = new System.Drawing.Size(208, 23);
            this.backtomm.TabIndex = 3;
            this.backtomm.Text = "Back to main menu";
            this.backtomm.UseVisualStyleBackColor = true;
            this.backtomm.Click += new System.EventHandler(this.backtomm_Click);
            // 
            // TRANSLATION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backtomm);
            this.Controls.Add(this.Texttranslate);
            this.Controls.Add(this.Texttotrans);
            this.Controls.Add(this.Translate);
            this.Name = "TRANSLATION";
            this.Text = "TRANSLATION";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Translate;
        private System.Windows.Forms.TextBox Texttotrans;
        private System.Windows.Forms.Label Texttranslate;
        private System.Windows.Forms.Button backtomm;
    }
}