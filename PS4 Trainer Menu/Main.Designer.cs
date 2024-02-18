namespace PS4_Trainer_Menu
{
    partial class MainLoader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainLoader));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.firmwareSelector = new System.Windows.Forms.ToolStripComboBox();
            this.colourborder1 = new System.Windows.Forms.Panel();
            this.ipboxlabel = new System.Windows.Forms.Label();
            this.IPAddr = new System.Windows.Forms.TextBox();
            this.btn_injectPayload = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.colourborder2 = new System.Windows.Forms.Panel();
            this.colourborder3 = new System.Windows.Forms.Panel();
            this.Colourborder4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.payloadInjector = new System.ComponentModel.BackgroundWorker();
            this.testConnectionWorker = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.colourborder1.SuspendLayout();
            this.Colourborder4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(44, 457);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(79, 22);
            this.panel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firmwareSelector});
            this.toolStrip1.Location = new System.Drawing.Point(21, 297);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(102, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // firmwareSelector
            // 
            this.firmwareSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firmwareSelector.Items.AddRange(new object[] {
            "5.05"});
            this.firmwareSelector.Name = "firmwareSelector";
            this.firmwareSelector.Size = new System.Drawing.Size(75, 33);
            this.firmwareSelector.Visible = false;
            // 
            // colourborder1
            // 
            this.colourborder1.BackColor = System.Drawing.Color.OrangeRed;
            this.colourborder1.Controls.Add(this.ipboxlabel);
            this.colourborder1.Controls.Add(this.toolStrip1);
            this.colourborder1.Controls.Add(this.IPAddr);
            this.colourborder1.Controls.Add(this.btn_injectPayload);
            this.colourborder1.Controls.Add(this.ExitButton);
            this.colourborder1.Controls.Add(this.panel1);
            this.colourborder1.Dock = System.Windows.Forms.DockStyle.Left;
            this.colourborder1.Location = new System.Drawing.Point(0, 0);
            this.colourborder1.Name = "colourborder1";
            this.colourborder1.Size = new System.Drawing.Size(172, 496);
            this.colourborder1.TabIndex = 2;
            // 
            // ipboxlabel
            // 
            this.ipboxlabel.AutoSize = true;
            this.ipboxlabel.Location = new System.Drawing.Point(39, 56);
            this.ipboxlabel.Name = "ipboxlabel";
            this.ipboxlabel.Size = new System.Drawing.Size(130, 29);
            this.ipboxlabel.TabIndex = 5;
            this.ipboxlabel.Text = "IP Address";
            this.ipboxlabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // IPAddr
            // 
            this.IPAddr.Location = new System.Drawing.Point(34, 79);
            this.IPAddr.MaxLength = 15;
            this.IPAddr.Name = "IPAddr";
            this.IPAddr.Size = new System.Drawing.Size(100, 35);
            this.IPAddr.TabIndex = 4;
            this.IPAddr.TextChanged += new System.EventHandler(this.IPAddr_TextChanged);
            // 
            // btn_injectPayload
            // 
            this.btn_injectPayload.BackColor = System.Drawing.Color.Black;
            this.btn_injectPayload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_injectPayload.ForeColor = System.Drawing.Color.Transparent;
            this.btn_injectPayload.Location = new System.Drawing.Point(12, 150);
            this.btn_injectPayload.Name = "btn_injectPayload";
            this.btn_injectPayload.Size = new System.Drawing.Size(148, 51);
            this.btn_injectPayload.TabIndex = 2;
            this.btn_injectPayload.Text = "Start Trainer";
            this.btn_injectPayload.UseVisualStyleBackColor = false;
            this.btn_injectPayload.Click += new System.EventHandler(this.btn_injectPayload_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.Transparent;
            this.ExitButton.Location = new System.Drawing.Point(12, 400);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(148, 51);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Close";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // colourborder2
            // 
            this.colourborder2.BackColor = System.Drawing.Color.OrangeRed;
            this.colourborder2.Dock = System.Windows.Forms.DockStyle.Top;
            this.colourborder2.Location = new System.Drawing.Point(172, 0);
            this.colourborder2.Name = "colourborder2";
            this.colourborder2.Size = new System.Drawing.Size(986, 12);
            this.colourborder2.TabIndex = 3;
            // 
            // colourborder3
            // 
            this.colourborder3.BackColor = System.Drawing.Color.OrangeRed;
            this.colourborder3.Dock = System.Windows.Forms.DockStyle.Right;
            this.colourborder3.Location = new System.Drawing.Point(1147, 12);
            this.colourborder3.Name = "colourborder3";
            this.colourborder3.Size = new System.Drawing.Size(11, 484);
            this.colourborder3.TabIndex = 4;
            // 
            // Colourborder4
            // 
            this.Colourborder4.BackColor = System.Drawing.Color.OrangeRed;
            this.Colourborder4.Controls.Add(this.label1);
            this.Colourborder4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Colourborder4.Location = new System.Drawing.Point(172, 473);
            this.Colourborder4.Name = "Colourborder4";
            this.Colourborder4.Size = new System.Drawing.Size(975, 23);
            this.Colourborder4.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trainer By Tiger Fury";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // payloadInjector
            // 
            this.payloadInjector.DoWork += new System.ComponentModel.DoWorkEventHandler(this.payloadInjector_DoWork);
            // 
            // testConnectionWorker
            // 
            this.testConnectionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.testConnectionWorker_DoWork);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(312, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(885, 87);
            this.label2.TabIndex = 6;
            this.label2.Text = "Make Sure Ip Is Set, Make Sure You Have Payload Running, Hit Start Trainer\r\n\r\nIf " +
    "Trainer does not load you have the WRONG IP!, so change IP and hit start again!";
            // 
            // MainLoader
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1158, 496);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Colourborder4);
            this.Controls.Add(this.colourborder3);
            this.Controls.Add(this.colourborder2);
            this.Controls.Add(this.colourborder1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainLoader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PS4 Trainer";
            this.Load += new System.EventHandler(this.MainLoader_Load_1);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.colourborder1.ResumeLayout(false);
            this.colourborder1.PerformLayout();
            this.Colourborder4.ResumeLayout(false);
            this.Colourborder4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel colourborder1;
        private System.Windows.Forms.Panel colourborder2;
        private System.Windows.Forms.Panel colourborder3;
        private System.Windows.Forms.Panel Colourborder4;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button btn_injectPayload;
        private System.ComponentModel.BackgroundWorker payloadInjector;
        private System.ComponentModel.BackgroundWorker testConnectionWorker;
        public System.Windows.Forms.ToolStripComboBox firmwareSelector;
        private System.Windows.Forms.TextBox IPAddr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ipboxlabel;
    }
}

