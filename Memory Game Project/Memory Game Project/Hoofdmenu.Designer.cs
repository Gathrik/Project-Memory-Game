namespace prototype
{
    partial class Hoofdmenu
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
            this.nieuw_spel_knop = new System.Windows.Forms.Button();
            this.sluit_programma_knop = new System.Windows.Forms.Button();
            this.muziek_checkbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.multiplayer_knop = new System.Windows.Forms.Button();
            this.huidige_thema_label = new System.Windows.Forms.Label();
            this.verander_thema_knop = new System.Windows.Forms.Button();
            this.highscore_knop = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // nieuw_spel_knop
            // 
            this.nieuw_spel_knop.Location = new System.Drawing.Point(180, 106);
            this.nieuw_spel_knop.Name = "nieuw_spel_knop";
            this.nieuw_spel_knop.Size = new System.Drawing.Size(100, 40);
            this.nieuw_spel_knop.TabIndex = 0;
            this.nieuw_spel_knop.Text = "Nieuw Spel";
            this.nieuw_spel_knop.UseVisualStyleBackColor = true;
            this.nieuw_spel_knop.Click += new System.EventHandler(this.nieuw_spel_klik);
            // 
            // sluit_programma_knop
            // 
            this.sluit_programma_knop.Location = new System.Drawing.Point(342, 297);
            this.sluit_programma_knop.Margin = new System.Windows.Forms.Padding(2);
            this.sluit_programma_knop.Name = "sluit_programma_knop";
            this.sluit_programma_knop.Size = new System.Drawing.Size(100, 40);
            this.sluit_programma_knop.TabIndex = 1;
            this.sluit_programma_knop.Text = "Sluit programma";
            this.sluit_programma_knop.UseVisualStyleBackColor = true;
            this.sluit_programma_knop.Click += new System.EventHandler(this.sluit_programma_klik);
            // 
            // muziek_checkbox
            // 
            this.muziek_checkbox.AutoSize = true;
            this.muziek_checkbox.Location = new System.Drawing.Point(363, 215);
            this.muziek_checkbox.Margin = new System.Windows.Forms.Padding(2);
            this.muziek_checkbox.Name = "muziek_checkbox";
            this.muziek_checkbox.Size = new System.Drawing.Size(63, 17);
            this.muziek_checkbox.TabIndex = 5;
            this.muziek_checkbox.Text = "Muziek ";
            this.muziek_checkbox.UseVisualStyleBackColor = true;
            this.muziek_checkbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label2.Location = new System.Drawing.Point(222, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 48);
            this.label2.TabIndex = 6;
            this.label2.Text = "      Memory Game";
            // 
            // multiplayer_knop
            // 
            this.multiplayer_knop.Location = new System.Drawing.Point(180, 149);
            this.multiplayer_knop.Margin = new System.Windows.Forms.Padding(2);
            this.multiplayer_knop.Name = "multiplayer_knop";
            this.multiplayer_knop.Size = new System.Drawing.Size(100, 40);
            this.multiplayer_knop.TabIndex = 8;
            this.multiplayer_knop.Text = "Multiplayer";
            this.multiplayer_knop.UseVisualStyleBackColor = true;
            this.multiplayer_knop.Click += new System.EventHandler(this.multiplayer_klik);
            // 
            // huidige_thema_label
            // 
            this.huidige_thema_label.AutoSize = true;
            this.huidige_thema_label.Location = new System.Drawing.Point(210, 216);
            this.huidige_thema_label.Name = "huidige_thema_label";
            this.huidige_thema_label.Size = new System.Drawing.Size(36, 13);
            this.huidige_thema_label.TabIndex = 13;
            this.huidige_thema_label.Text = "thema";
            this.huidige_thema_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // verander_thema_knop
            // 
            this.verander_thema_knop.Location = new System.Drawing.Point(259, 379);
            this.verander_thema_knop.Name = "verander_thema_knop";
            this.verander_thema_knop.Size = new System.Drawing.Size(100, 40);
            this.verander_thema_knop.TabIndex = 12;
            this.verander_thema_knop.Text = "Verander Thema";
            this.verander_thema_knop.UseVisualStyleBackColor = true;
            this.verander_thema_knop.Click += new System.EventHandler(this.verander_thema_klik);
            // 
            // highscore_knop
            // 
            this.highscore_knop.Location = new System.Drawing.Point(342, 252);
            this.highscore_knop.Name = "highscore_knop";
            this.highscore_knop.Size = new System.Drawing.Size(100, 40);
            this.highscore_knop.TabIndex = 14;
            this.highscore_knop.Text = "Highscores";
            this.highscore_knop.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Memory_Game_Project.Properties.Resources.marvel_icon;
            this.pictureBox1.Location = new System.Drawing.Point(330, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Memory_Game_Project.Properties.Resources.dc_icon;
            this.pictureBox3.Location = new System.Drawing.Point(171, 246);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(120, 100);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Memory_Game_Project.Properties.Resources.imageedit_1_3125092949;
            this.pictureBox2.Location = new System.Drawing.Point(-112, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(329, 374);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Memory_Game_Project.Properties.Resources.iron_man_png_render_by_mrvideo_vidman_d9volq1;
            this.pictureBox4.Location = new System.Drawing.Point(456, 44);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(352, 389);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            // 
            // Hoofdmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory_Game_Project.Properties.Resources.mix_n_match_icon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(621, 445);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.highscore_knop);
            this.Controls.Add(this.huidige_thema_label);
            this.Controls.Add(this.verander_thema_knop);
            this.Controls.Add(this.multiplayer_knop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.muziek_checkbox);
            this.Controls.Add(this.sluit_programma_knop);
            this.Controls.Add(this.nieuw_spel_knop);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Hoofdmenu";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nieuw_spel_knop;
        private System.Windows.Forms.Button sluit_programma_knop;
        private System.Windows.Forms.CheckBox muziek_checkbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button multiplayer_knop;
        private System.Windows.Forms.Label huidige_thema_label;
        private System.Windows.Forms.Button verander_thema_knop;
        private System.Windows.Forms.Button highscore_knop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}

