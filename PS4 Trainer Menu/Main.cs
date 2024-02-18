using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using librpc;


namespace PS4_Trainer_Menu
{
    public partial class MainLoader : Form
    {
       
        public static PS4RPC ps4 = new PS4RPC(Properties.Settings.Default.IPAddressText);
        private Assembly assembly = Assembly.GetExecutingAssembly();
        public static int port = 9020;


        public static Trainer Trainer = new Trainer();

        public void SendPayload(string IP, string payloadPath, int port)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.ReceiveTimeout = 10000;
            socket.SendTimeout = 3000;
            socket.Connect(new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.IPAddressText), port));
            socket.SendFile(payloadPath);
            socket.Close();
        }

        private void checkSettings()
        {
             bool flag3 = Properties.Settings.Default.FWIndex == "5.05";
             if (flag3)
             {
                firmwareSelector.SelectedIndex = 0;
                MainLoader.ps4 = new PS4RPC(Properties.Settings.Default.IPAddressText);
                Calling.ps4 = MainLoader.ps4;
             }
             else
             {
                firmwareSelector.SelectedIndex = 0;
             }
                
        }
       
        public MainLoader()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Trainer.CheatDoWorker.CancelAsync();
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void btn_injectPayload_Click(object sender, EventArgs e)
        {
            ps4 = new PS4RPC(Properties.Settings.Default.IPAddressText);
            try
            { 
       
                testConnectionWorker.RunWorkerAsync();
                

        }
            catch (Exception arg)
            {
                MessageBox.Show("Error!\n\n\n\n\nWRONG IP!!! TRY AGAIN!\n\n\nEdit IP and hit Start");
            }
}

        private void MainLoader_Load_1(object sender, EventArgs e)
        {
            payloadInjector.RunWorkerAsync();
            IPAddr.Text = Properties.Settings.Default.IPAddressText;
            checkSettings();
        }

        public void ShowTrainer()
        {
            bool flag = Application.OpenForms["Trainer"] == null;
            if (flag)
            {
                new Trainer
                {
                    MdiParent = this
                }.Show();
            }
        }


        private void IPAddr_TextChanged(object sender, EventArgs e)
        {
           Properties.Settings.Default.IPAddressText = IPAddr.Text;
           Properties.Settings.Default.Save();

        }

        private void testConnectionWorker_DoWork(object sender, DoWorkEventArgs e)
        {{
            try
            {
             ps4.Connect();
             Invoke(new MethodInvoker(delegate ()
             {
                 colourborder1.BackColor = Color.Green;
                 colourborder2.BackColor = Color.Green;
                 colourborder3.BackColor = Color.Green;
                 Colourborder4.BackColor = Color.Green;
                 firmwareSelector.Enabled = false;
                 btn_injectPayload.ForeColor = Color.White;
                 //btn_injectPayload.Enabled = false;
                 Thread.Sleep(500);
                 ShowTrainer();
                 label2.Hide();
                 btn_injectPayload.Text = "Trainer Loaded";
             }));
                }
                catch
                {
                }
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("GoldZ");
        }


        private void payloadInjector_DoWork(object sender, DoWorkEventArgs e)
        {
            {
                try
                {
                    ps4.Connect();
                    Invoke(new MethodInvoker(delegate ()
                    {
                        colourborder1.BackColor = Color.Green;
                        colourborder2.BackColor = Color.Green;
                        colourborder3.BackColor = Color.Green;
                        Colourborder4.BackColor = Color.Green;
                        firmwareSelector.Enabled = false;
                        btn_injectPayload.ForeColor = Color.White;
                        //btn_injectPayload.Enabled = false;
                        Thread.Sleep(500);
                        ShowTrainer();
                        label2.Hide();
                        btn_injectPayload.Text = "Trainer Loaded";
                    }));
                }
                catch
                {
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
