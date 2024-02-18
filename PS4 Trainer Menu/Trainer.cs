using System;
using System.Windows.Forms;
using static PS4_Trainer_Menu.GameHandles;
using System.Threading;


namespace PS4_Trainer_Menu

{
    public partial class Trainer : Form
    {
        public string gamename = "Resident Evil 0";//Gamename this is optional but it make it look better

        public string Eboot1 = "bh0hd.elf";//name of the file you are attaching to, an elf file is the ps4 version of a an windows .exe
        //public string Eboot2 = "bh1hd.elf";
        //public string Eboot3 = "";
        public string Cheatname1 = "Inf Health";// this will display what shows up in the text next to the checkbox to make like easier so so don't have to change it manually on form designer
        public string Cheatname2 = "Inf Ammo";//same as above
        public string Cheatname3 = "Inf PTAS";//same as above
        public string Cheatname4 = "";
        public string Cheatname5 = "";
        public string Cheatname6 = "";

        //ulong addr; //variable to store a result of a search from searchaddress
        // ulong addr2;

        void setcaves()// this function will allow you to place where you want to code
        {
            ps4.WriteMemory(processID, 0x00d6e870, new byte[] { 0x41, 0x5C, 0x41, 0x5D, 0x41, 0x5E, 0xBE, 0xFA, 0x00, 0x00, 0x00, 0x68, 0xF0, 0xFA, 0x54, 0x00, 0xC3 });
            //this is where your cave will set at address 0x00d6e870 and write this byte array. The byte array is the bytes/hex form of opcodes, you will need to search manually for a space with wrx mwmory (ps4 cheater and/or ps4 debugger will find wrx memory) you need a length thats longer then your code just to make sure it doesn't interfere with another function. in debugger or cheater try finding a big space of zeroes so type 00 at the length you need I'd say 100 bytes of zeroes to be safe
      /*    0:  41                      inc ecx
            1:  5c                      pop esp
            2:  41                      inc ecx
            3:  5d                      pop ebp
            4:  41                      inc ecx
            5:  5e                      pop esi
            6:  be fa 00 00 00          mov esi,0xfa
            b:  68 f0 fa 54 00          push 0x54faf0
            10: c3                      ret             */
          //above is a rough translation of what the byte array would read like in opcode
        }
        void search()
        {
            //addr = SearchAddress(Eboot1, 0x58C760, 0x010000, new byte[] { 0x41, 0x89, 0x86, 0x4C, 0x17, 0x00, 0x00 }); //basically this is an aobscan that is written in this format. search Eboot1 (bh0hd.elf named above) starting from address 0x58C760 within the length of 0x010000 (to 0x59C760 can be as long as you like) for this byte array (0x41, 0x89, 0x86, 0x4C, 0x17, 0x00, 0x00) when found store it in the variable addr

            //addr2 = SearchAddress(Eboot2, 0x74C000, 0x010000, new byte[] { 0x2B, 0x8B, 0x2C, 0x13, 0x00, 0x00 });//this is the same but this searches the second eboot which is handy if a game has a few like the dmc hd collection which has 4

        }


        private void Game1Connect_Click(object sender, EventArgs e)//nothing needs touching here other then if you want
        {


            Connecter(Eboot1, gamename, Game1Connect);
            gamenamelabel.Text = gamename;
            ShowCheat1 = true;//all hidden by default activate per how many cheats you use so currently it supports show cheats 1-6
            ShowCheat2 = true;
         //   ShowCheat3 = true;
         //   ShowCheat4 = true;
         //   ShowCheat5 = true;
         //   ShowCheat6 = true;
            vis_on();// will run vis on if it connects to the game

        }

        public void vis_on()//nothing needs touching in here this will simply grab all the game info from the game and the boxart directly from playstaton store and display the trainer and cheats if it connects successfully
        {

            loadingamelabel.Hide();

            Cursor = Cursors.WaitCursor;
            temp = Util.GameInfoArray();
            bool flag = string.IsNullOrEmpty(temp[0]) && string.IsNullOrEmpty(temp[1]);
            if (flag)
            {
                Cursor = Cursors.Default;
            }
            else
            {
                dummylabel.Text = string.Format("{0}\n{1}", temp[0], temp[1]);
                Gameidnumber.Text = temp[0];
                VersionNumber.Text = temp[1];
                try
                {
                    GamePicBox.Load("https://store.playstation.com/store/api/chihiro/00_09_000/titlecontainer/US/en/999/" + Util.GameInfoArray()[0] + "_00/image");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                Cursor = Cursors.Default;

                setcaves();

                Thread.Sleep(500);
                if (ShowCheat1 == true)
                    cheat1check.Visible = true;
                if (ShowCheat2 == true)
                    cheat2check.Visible = true;
                if (ShowCheat3 == true)
                    cheat3check.Visible = true;
                if (ShowCheat4 == true)
                    cheat4check.Visible = true;
                if (ShowCheat5 == true)
                    cheat5check.Visible = true;
                if (ShowCheat6 == true)
                    cheat6check.Visible = true;
            }

        }
        public string[] temp { get; private set; }

        public Trainer()
        {
            InitializeComponent();
            loadingamelabel.Text = "Select While In Game";
            Game1Connect.Text = gamename;
            cheat1check.Text = Cheatname1;
            cheat2check.Text = Cheatname2;
            cheat3check.Text = Cheatname3;
            cheat4check.Text = Cheatname4;
            cheat5check.Text = Cheatname5;
            cheat6check.Text = Cheatname6;


            Properties.Settings.Default.GameEboot1 = Eboot1;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            attached = false;
            Application.Exit();
        }

        private void cheat1check_CheckedChanged(object sender, EventArgs e)//first cheat
        {

            if (cheat1check.Checked)//if the checkbox is ticked do the code below
                ps4.WriteMemory(processID, 0x54faea, new byte[] { 0x68, 0x70, 0xE8, 0xD6, 0x00, 0xC3 });//this basically alters the code from the original below to jump to the cave set above, again bytes to opcode: 68 70 e8 d6 00 (push 0xd6e870) c3 (ret)
            else//if unchecked
                ps4.WriteMemory(processID, 0x54faea, new byte[] { 0x41, 0x5c, 0x41, 0x5d, 0x41, 0x5e });//restore original code

        }

        private void cheat2check_CheckedChanged(object sender, EventArgs e)//second cheat
        {

            if (cheat2check.Checked)
                ps4.WriteMemory(processID, 0x511232, nop5byte);//this doesn't jmp to anywhere it just nulls the operation so no values pass through it called a nop (no operation) this engine supports nops from 1-9 bytes with an easy function just types how many bytes you need nop1byte, nop2byte etc otherwise its written like this {0x90} for one byte {0x90, 0x90} for two bytes etc
            else
                ps4.WriteMemory(processID, 0x511232, new byte[] { 0x43, 0x8B, 0x44, 0xEC, 0x08 });

        }

        private void cheat3check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cheat4check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cheat5check_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cheat6check_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}