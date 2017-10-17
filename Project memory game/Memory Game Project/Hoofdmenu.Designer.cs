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
            this.label1 = new System.Windows.Forms.Label();
            this.muziek_checkbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.multiplayer_knop = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nieuw_spel_knop
            // 
            this.nieuw_spel_knop.Location = new System.Drawing.Point(302, 102);
            this.nieuw_spel_knop.Name = "nieuw_spel_knop";
            this.nieuw_spel_knop.Size = new System.Drawing.Size(100, 45);
            this.nieuw_spel_knop.TabIndex = 0;
            this.nieuw_spel_knop.Text = "Nieuw Spel";
            this.nieuw_spel_knop.UseVisualStyleBackColor = true;
            this.nieuw_spel_knop.Click += new System.EventHandler(this.nieuw_spel_klik);
            // 
            // sluit_programma_knop
            // 
            this.sluit_programma_knop.Location = new System.Drawing.Point(302, 240);
            this.sluit_programma_knop.Margin = new System.Windows.Forms.Padding(2);
            this.sluit_programma_knop.Name = "sluit_programma_knop";
            this.sluit_programma_knop.Size = new System.Drawing.Size(100, 53);
            this.sluit_programma_knop.TabIndex = 1;
            this.sluit_programma_knop.Text = "Sluit programma";
            this.sluit_programma_knop.UseVisualStyleBackColor = true;
            this.sluit_programma_knop.Click += new System.EventHandler(this.sluit_programma_klik);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(518, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "HIGHSCORE:";
            // 
            // muziek_checkbox
            // 
            this.muziek_checkbox.AutoSize = true;
            this.muziek_checkbox.Location = new System.Drawing.Point(554, 240);
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
            this.label2.Location = new System.Drawing.Point(268, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 48);
            this.label2.TabIndex = 6;
            this.label2.Text = "      Memory Game";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Memory_Game_Project.Properties.Resources.muziek11;
            this.pictureBox2.Location = new System.Drawing.Point(609, 223);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Memory_Game_Project.Properties.Resources.B25;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // multiplayer_knop
            // 
            this.multiplayer_knop.Location = new System.Drawing.Point(302, 178);
            this.multiplayer_knop.Margin = new System.Windows.Forms.Padding(2);
            this.multiplayer_knop.Name = "multiplayer_knop";
            this.multiplayer_knop.Size = new System.Drawing.Size(100, 41);
            this.multiplayer_knop.TabIndex = 8;
            this.multiplayer_knop.Text = "Multiplayer";
            this.multiplayer_knop.UseVisualStyleBackColor = true;
            this.multiplayer_knop.Click += new System.EventHandler(this.multiplayer_klik);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(518, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 33);
            this.label3.TabIndex = 9;
            this.label3.Text = "Score vorig spel:";
            // 
            // Hoofdmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 424);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.multiplayer_knop);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.muziek_checkbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sluit_programma_knop);
            this.Controls.Add(this.nieuw_spel_knop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Hoofdmenu";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nieuw_spel_knop;
        private System.Windows.Forms.Button sluit_programma_knop;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox muziek_checkbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button multiplayer_knop;
        private System.Windows.Forms.Label label3;
    }
}

