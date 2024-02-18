namespace PS4_Trainer_Menu
{
    partial class Trainer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Game1Connect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Gameidnumber = new System.Windows.Forms.Label();
            this.Gameid = new System.Windows.Forms.Label();
            this.VersionNumber = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.gamenamelabel = new System.Windows.Forms.Label();
            this.Gamelab = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.loadingamelabel = new System.Windows.Forms.Label();
            this.cheat1check = new System.Windows.Forms.CheckBox();
            this.cheat2check = new System.Windows.Forms.CheckBox();
            this.cheat3check = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dummylabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.GamePicBox = new System.Windows.Forms.PictureBox();
            this.cheat4check = new System.Windows.Forms.CheckBox();
            this.cheat5check = new System.Windows.Forms.CheckBox();
            this.cheat6check = new System.Windows.Forms.CheckBox();
            this.CheatDoWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamePicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Game1Connect);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(126, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Trainer";
            // 
            // Game1Connect
            // 
            this.Game1Connect.BackColor = System.Drawing.SystemColors.ControlText;
            this.Game1Connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Game1Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Game1Connect.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Game1Connect.Location = new System.Drawing.Point(15, 19);
            this.Game1Connect.Name = "Game1Connect";
            this.Game1Connect.Size = new System.Drawing.Size(94, 45);
            this.Game1Connect.TabIndex = 0;
            this.Game1Connect.Text = "Game 1";
            this.Game1Connect.UseVisualStyleBackColor = false;
            this.Game1Connect.Click += new System.EventHandler(this.Game1Connect_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Controls.Add(this.Gameidnumber);
            this.panel2.Controls.Add(this.Gameid);
            this.panel2.Controls.Add(this.VersionNumber);
            this.panel2.Controls.Add(this.version);
            this.panel2.Controls.Add(this.gamenamelabel);
            this.panel2.Controls.Add(this.Gamelab);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(151, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 27);
            this.panel2.TabIndex = 1;
            // 
            // Gameidnumber
            // 
            this.Gameidnumber.AutoSize = true;
            this.Gameidnumber.BackColor = System.Drawing.SystemColors.ControlText;
            this.Gameidnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gameidnumber.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Gameidnumber.Location = new System.Drawing.Point(415, 4);
            this.Gameidnumber.Name = "Gameidnumber";
            this.Gameidnumber.Size = new System.Drawing.Size(54, 20);
            this.Gameidnumber.TabIndex = 9;
            this.Gameidnumber.Text = "NONE";
            // 
            // Gameid
            // 
            this.Gameid.AutoSize = true;
            this.Gameid.BackColor = System.Drawing.SystemColors.ControlText;
            this.Gameid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gameid.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Gameid.Location = new System.Drawing.Point(357, 4);
            this.Gameid.Name = "Gameid";
            this.Gameid.Size = new System.Drawing.Size(78, 20);
            this.Gameid.TabIndex = 8;
            this.Gameid.Text = "Game ID:";
            // 
            // VersionNumber
            // 
            this.VersionNumber.AutoSize = true;
            this.VersionNumber.BackColor = System.Drawing.SystemColors.ControlText;
            this.VersionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionNumber.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.VersionNumber.Location = new System.Drawing.Point(269, 4);
            this.VersionNumber.Name = "VersionNumber";
            this.VersionNumber.Size = new System.Drawing.Size(54, 20);
            this.VersionNumber.TabIndex = 7;
            this.VersionNumber.Text = "NONE";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.BackColor = System.Drawing.SystemColors.ControlText;
            this.version.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.version.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.version.Location = new System.Drawing.Point(211, 4);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(67, 20);
            this.version.TabIndex = 6;
            this.version.Text = "Version:";
            // 
            // gamenamelabel
            // 
            this.gamenamelabel.AutoSize = true;
            this.gamenamelabel.BackColor = System.Drawing.SystemColors.ControlText;
            this.gamenamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamenamelabel.ForeColor = System.Drawing.SystemColors.Control;
            this.gamenamelabel.Location = new System.Drawing.Point(56, 4);
            this.gamenamelabel.Name = "gamenamelabel";
            this.gamenamelabel.Size = new System.Drawing.Size(54, 20);
            this.gamenamelabel.TabIndex = 5;
            this.gamenamelabel.Text = "NONE";
            // 
            // Gamelab
            // 
            this.Gamelab.AutoSize = true;
            this.Gamelab.BackColor = System.Drawing.SystemColors.ControlText;
            this.Gamelab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gamelab.ForeColor = System.Drawing.SystemColors.Control;
            this.Gamelab.Location = new System.Drawing.Point(7, 4);
            this.Gamelab.Name = "Gamelab";
            this.Gamelab.Size = new System.Drawing.Size(57, 20);
            this.Gamelab.TabIndex = 4;
            this.Gamelab.Text = "Game:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(151, 422);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(649, 28);
            this.panel3.TabIndex = 2;
            // 
            // loadingamelabel
            // 
            this.loadingamelabel.AutoSize = true;
            this.loadingamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingamelabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loadingamelabel.Location = new System.Drawing.Point(245, 328);
            this.loadingamelabel.Name = "loadingamelabel";
            this.loadingamelabel.Size = new System.Drawing.Size(0, 42);
            this.loadingamelabel.TabIndex = 7;
            // 
            // cheat1check
            // 
            this.cheat1check.AutoSize = true;
            this.cheat1check.BackColor = System.Drawing.SystemColors.ControlText;
            this.cheat1check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheat1check.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cheat1check.Location = new System.Drawing.Point(208, 290);
            this.cheat1check.Name = "cheat1check";
            this.cheat1check.Size = new System.Drawing.Size(98, 24);
            this.cheat1check.TabIndex = 8;
            this.cheat1check.Text = "Inf Health";
            this.cheat1check.UseVisualStyleBackColor = false;
            this.cheat1check.Visible = false;
            this.cheat1check.CheckedChanged += new System.EventHandler(this.cheat1check_CheckedChanged);
            // 
            // cheat2check
            // 
            this.cheat2check.AutoSize = true;
            this.cheat2check.BackColor = System.Drawing.SystemColors.ControlText;
            this.cheat2check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheat2check.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cheat2check.Location = new System.Drawing.Point(208, 333);
            this.cheat2check.Name = "cheat2check";
            this.cheat2check.Size = new System.Drawing.Size(97, 24);
            this.cheat2check.TabIndex = 9;
            this.cheat2check.Text = "Inf Ammo";
            this.cheat2check.UseVisualStyleBackColor = false;
            this.cheat2check.Visible = false;
            // 
            // cheat3check
            // 
            this.cheat3check.AutoSize = true;
            this.cheat3check.BackColor = System.Drawing.SystemColors.ControlText;
            this.cheat3check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheat3check.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cheat3check.Location = new System.Drawing.Point(208, 375);
            this.cheat3check.Name = "cheat3check";
            this.cheat3check.Size = new System.Drawing.Size(88, 24);
            this.cheat3check.TabIndex = 10;
            this.cheat3check.Text = "Inf Cash";
            this.cheat3check.UseVisualStyleBackColor = false;
            this.cheat3check.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Controls.Add(this.dummylabel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(780, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 395);
            this.panel4.TabIndex = 3;
            // 
            // dummylabel
            // 
            this.dummylabel.AutoSize = true;
            this.dummylabel.Location = new System.Drawing.Point(-3, 17);
            this.dummylabel.Name = "dummylabel";
            this.dummylabel.Size = new System.Drawing.Size(40, 13);
            this.dummylabel.TabIndex = 10;
            this.dummylabel.Text = "dummy";
            this.dummylabel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(151, 450);
            this.panel1.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.SystemColors.Control;
            this.Title.Location = new System.Drawing.Point(34, 4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(92, 20);
            this.Title.TabIndex = 0;
            this.Title.Text = "PS4 Trainer";
            // 
            // GamePicBox
            // 
            this.GamePicBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.GamePicBox.Location = new System.Drawing.Point(151, 26);
            this.GamePicBox.Name = "GamePicBox";
            this.GamePicBox.Size = new System.Drawing.Size(629, 258);
            this.GamePicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GamePicBox.TabIndex = 11;
            this.GamePicBox.TabStop = false;
            // 
            // cheat4check
            // 
            this.cheat4check.AutoSize = true;
            this.cheat4check.BackColor = System.Drawing.SystemColors.ControlText;
            this.cheat4check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheat4check.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cheat4check.Location = new System.Drawing.Point(396, 290);
            this.cheat4check.Name = "cheat4check";
            this.cheat4check.Size = new System.Drawing.Size(161, 24);
            this.cheat4check.TabIndex = 12;
            this.cheat4check.Text = "Inf Badass Tokens";
            this.cheat4check.UseVisualStyleBackColor = false;
            this.cheat4check.Visible = false;
            // 
            // cheat5check
            // 
            this.cheat5check.AutoSize = true;
            this.cheat5check.BackColor = System.Drawing.SystemColors.ControlText;
            this.cheat5check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheat5check.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cheat5check.Location = new System.Drawing.Point(396, 333);
            this.cheat5check.Name = "cheat5check";
            this.cheat5check.Size = new System.Drawing.Size(72, 24);
            this.cheat5check.TabIndex = 13;
            this.cheat5check.Text = "Inf XP";
            this.cheat5check.UseVisualStyleBackColor = false;
            this.cheat5check.Visible = false;
            // 
            // cheat6check
            // 
            this.cheat6check.AutoSize = true;
            this.cheat6check.BackColor = System.Drawing.SystemColors.ControlText;
            this.cheat6check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cheat6check.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.cheat6check.Location = new System.Drawing.Point(396, 375);
            this.cheat6check.Name = "cheat6check";
            this.cheat6check.Size = new System.Drawing.Size(122, 24);
            this.cheat6check.TabIndex = 14;
            this.cheat6check.Text = "Inf Grenades";
            this.cheat6check.UseVisualStyleBackColor = false;
            this.cheat6check.Visible = false;
            // 
            // CheatDoWorker
            // 
            this.CheatDoWorker.WorkerSupportsCancellation = true;
            // 
            // Trainer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cheat6check);
            this.Controls.Add(this.cheat5check);
            this.Controls.Add(this.cheat4check);
            this.Controls.Add(this.GamePicBox);
            this.Controls.Add(this.cheat3check);
            this.Controls.Add(this.cheat2check);
            this.Controls.Add(this.cheat1check);
            this.Controls.Add(this.loadingamelabel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Trainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trainer";
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamePicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Game1Connect;
        private System.Windows.Forms.Label Gameid;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label gamenamelabel;
        private System.Windows.Forms.Label Gamelab;
        private System.Windows.Forms.CheckBox cheat1check;
        private System.Windows.Forms.CheckBox cheat2check;
        private System.Windows.Forms.CheckBox cheat3check;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.CheckBox cheat4check;
        private System.Windows.Forms.CheckBox cheat5check;
        private System.Windows.Forms.CheckBox cheat6check;
        public System.ComponentModel.BackgroundWorker CheatDoWorker;
        public System.Windows.Forms.Label dummylabel;
        public System.Windows.Forms.Label loadingamelabel;
        public System.Windows.Forms.Label Gameidnumber;
        public System.Windows.Forms.Label VersionNumber;
        public System.Windows.Forms.PictureBox GamePicBox;
    }
}