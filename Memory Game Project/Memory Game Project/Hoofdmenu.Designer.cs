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
            this.highscore_knop = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.themas_combobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // nieuw_spel_knop
            // 
            this.nieuw_spel_knop.Location = new System.Drawing.Point(240, 130);
            this.nieuw_spel_knop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nieuw_spel_knop.Name = "nieuw_spel_knop";
            this.nieuw_spel_knop.Size = new System.Drawing.Size(133, 49);
            this.nieuw_spel_knop.TabIndex = 0;
            this.nieuw_spel_knop.Text = "Nieuw Spel";
            this.nieuw_spel_knop.UseVisualStyleBackColor = true;
            this.nieuw_spel_knop.Click += new System.EventHandler(this.nieuw_spel_klik);
            // 
            // sluit_programma_knop
            // 
            this.sluit_programma_knop.Location = new System.Drawing.Point(456, 366);
            this.sluit_programma_knop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sluit_programma_knop.Name = "sluit_programma_knop";
            this.sluit_programma_knop.Size = new System.Drawing.Size(133, 49);
            this.sluit_programma_knop.TabIndex = 1;
            this.sluit_programma_knop.Text = "Sluit programma";
            this.sluit_programma_knop.UseVisualStyleBackColor = true;
            this.sluit_programma_knop.Click += new System.EventHandler(this.sluit_programma_klik);
            // 
            // muziek_checkbox
            // 
            this.muziek_checkbox.AutoSize = true;
            this.muziek_checkbox.Location = new System.Drawing.Point(484, 265);
            this.muziek_checkbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.muziek_checkbox.Name = "muziek_checkbox";
            this.muziek_checkbox.Size = new System.Drawing.Size(78, 21);
            this.muziek_checkbox.TabIndex = 5;
            this.muziek_checkbox.Text = "Muziek ";
            this.muziek_checkbox.UseVisualStyleBackColor = true;
            this.muziek_checkbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.label2.Location = new System.Drawing.Point(296, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 59);
            this.label2.TabIndex = 6;
            this.label2.Text = "      Memory Game";
            // 
            // multiplayer_knop
            // 
            this.multiplayer_knop.Location = new System.Drawing.Point(240, 183);
            this.multiplayer_knop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.multiplayer_knop.Name = "multiplayer_knop";
            this.multiplayer_knop.Size = new System.Drawing.Size(133, 49);
            this.multiplayer_knop.TabIndex = 8;
            this.multiplayer_knop.Text = "Multiplayer";
            this.multiplayer_knop.UseVisualStyleBackColor = true;
            this.multiplayer_knop.Click += new System.EventHandler(this.multiplayer_klik);
            // 
            // huidige_thema_label
            // 
            this.huidige_thema_label.AutoSize = true;
            this.huidige_thema_label.Location = new System.Drawing.Point(280, 266);
            this.huidige_thema_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.huidige_thema_label.Name = "huidige_thema_label";
            this.huidige_thema_label.Size = new System.Drawing.Size(47, 17);
            this.huidige_thema_label.TabIndex = 13;
            this.huidige_thema_label.Text = "thema";
            this.huidige_thema_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // highscore_knop
            // 
            this.highscore_knop.Location = new System.Drawing.Point(456, 310);
            this.highscore_knop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.highscore_knop.Name = "highscore_knop";
            this.highscore_knop.Size = new System.Drawing.Size(133, 49);
            this.highscore_knop.TabIndex = 14;
            this.highscore_knop.Text = "Highscores";
            this.highscore_knop.UseVisualStyleBackColor = true;
            this.highscore_knop.Click += new System.EventHandler(this.highscores_klik);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Memory_Game_Project.Properties.Resources.marvel_icon;
            this.pictureBox1.Location = new System.Drawing.Point(440, 118);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Memory_Game_Project.Properties.Resources.dc_icon;
            this.pictureBox3.Location = new System.Drawing.Point(228, 303);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(160, 123);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 16;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Memory_Game_Project.Properties.Resources.imageedit_1_3125092949;
            this.pictureBox2.Location = new System.Drawing.Point(-149, 55);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(439, 460);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::Memory_Game_Project.Properties.Resources.iron_man_png_render_by_mrvideo_vidman_d9volq1;
            this.pictureBox4.Location = new System.Drawing.Point(608, 54);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(469, 479);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 466);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 49);
            this.button1.TabIndex = 19;
            this.button1.Text = "maak thema";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.open_maak_thema);
            // 
            // themas_combobox
            // 
            this.themas_combobox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.themas_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themas_combobox.FormattingEnabled = true;
            this.themas_combobox.Location = new System.Drawing.Point(284, 490);
            this.themas_combobox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.themas_combobox.Name = "themas_combobox";
            this.themas_combobox.Size = new System.Drawing.Size(160, 24);
            this.themas_combobox.TabIndex = 20;
            this.themas_combobox.SelectedIndexChanged += new System.EventHandler(this.themas_combobox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(309, 466);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "Kies thema";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(288, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 22;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(500, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 23;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Naam speler1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(479, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Naam speler2";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Hoofdmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Memory_Game_Project.Properties.Resources.mix_n_match_icon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(828, 548);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.themas_combobox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.highscore_knop);
            this.Controls.Add(this.huidige_thema_label);
            this.Controls.Add(this.multiplayer_knop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.muziek_checkbox);
            this.Controls.Add(this.sluit_programma_knop);
            this.Controls.Add(this.nieuw_spel_knop);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Hoofdmenu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Hoofdmenu_Load);
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
        private System.Windows.Forms.Button highscore_knop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox themas_combobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

