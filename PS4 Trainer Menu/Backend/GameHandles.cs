using librpc;
using System;
using System.Windows.Forms;
using System.Linq;
using System.IO;




//

namespace PS4_Trainer_Menu
{
    class GameHandles
    {
        public static PS4RPC ps4 = MainLoader.ps4;
        public static int gameselect = 0;
        public static int processID = 0;
        public static ulong processEntry = 0UL;
        public static bool attached = false;
        public static ulong stub = 0UL;
        public static ulong stringbuf;


        public static int TheGameSelector = Properties.Settings.Default.Game_Selector;
        public static uint null4bytes = 0x00000000;
        public static byte[] nop1byte = { 0x90 };
        public static byte[] nop2byte = { 0x90, 0x90 };
        public static byte[] nop3byte = { 0x90, 0x90, 0x90 };
        public static byte[] nop4byte = { 0x90, 0x90, 0x90, 0x90 };
        public static byte[] nop5byte = { 0x90, 0x90, 0x90, 0x90, 0x90 };
        public static byte[] nop6byte = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
        public static byte[] nop7byte = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
        public static byte[] nop8byte = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
        public static byte[] nop9byte = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
        public static byte[] nop10byte = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };

        public static bool ShowCheat1;
        public static bool ShowCheat2;
        public static bool ShowCheat3;
        public static bool ShowCheat4;
        public static bool ShowCheat5;
        public static bool ShowCheat6;

        public static void SetByte(ulong addy, byte values)
        {
            ps4.WriteByte(processID, addy, values);
        }
        public static void SetWord(ulong addy, ushort values)
        {
            ps4.WriteUInt16(processID, addy, values);
        }
        public static void SetRWord(ulong addy, ushort values)
        {
            ps4.WriteRUInt16(processID, addy, values);
        }
        public static void SetDword(ulong addy, uint values)
        {
            ps4.WriteUInt32(processID, addy, values); 
        }
        public static void SetRDword(ulong addy, uint values)
        {
            ps4.WriteRUInt32(processID, addy, values);
        }
        public static void SetQword(ulong addy, ulong values)
        {
            ps4.WriteUInt64(processID, addy, values);
        }
        public static void SetRQword(ulong addy, ulong values)
        {
            ps4.WriteRUInt64(processID, addy, values);
        }
        public static void SetFloat(ulong addy, float values)
        {
            ps4.WriteSingle(processID, addy, values);
        }
        public static void SetDouble(ulong addy, double values)
        {
            ps4.WriteDouble(processID, addy, values);
        }
  
        public static void DoPointer(string pointeraddr1, uint pointerval)
        {// DoPointer("@2726CF0_2_D6CF0+10+40+E90+A0", 1203982208); example
            bool flag = attached;
            if (flag)
            {
                ulong pointeraddr = Util.GetPointerAdress(pointeraddr1, processID);
                byte[] bytes = BitConverter.GetBytes(pointerval);
                bool flag2 = pointeraddr > 0UL;
                if (flag2)
                {
                    ps4.WriteMemory(processID, pointeraddr, bytes);
                }

            }
        }

        public static void Connecter(string ebooter, string thegamename, Button button)
        {
            Util.AttachToGame(ebooter, thegamename, ref attached, ref processID, ref processEntry, button, ref stub, ref stringbuf, false);
        }

        public static ulong GetAddress(Stream input, int addr_start, int addr_end, byte[] find)
        {
            if (find.Length > input.Length)
                return 0;


            var length = addr_end - addr_start;
            var buffer = new byte[find.Length];
            input.SetLength(length);
            using (var bufStream = new BufferedStream(input, find.Length))
            {
                while (bufStream.Read(buffer, addr_start, find.Length) == find.Length)
                {
                    if (find.SequenceEqual(buffer))
                    {
                        return (ulong)(bufStream.Position - find.Length);
                    }
                    bufStream.Position -= find.Length - Padding(buffer, find);
                }
            }

            return 0;
        }
        public static int Padding(byte[] bytes, byte[] seqBytes)
        {
            var i = 1;
            while (i < bytes.Length)
            {
                var n = bytes.Length - i;
                var a = new byte[n];
                var b = new byte[n];
                Array.Copy(bytes, i, a, 0, n);
                Array.Copy(seqBytes, b, n);
                if (a.SequenceEqual(b))
                    return i;
                i++;
            }

            return i;
        }


        public static ulong AddrVAR;


        public static ulong SearchAddress(string EbootOrElf, ulong StartSearchPosition, int SearchLength, byte[] bytesToFind)
        {

            var processes = ps4.GetProcessList();
            var process = processes.FindProcess(EbootOrElf);
            var pid = process.pid;
            var processInfo = ps4.GetProcessInfo(pid);
            var entries = processInfo.entries;
            ulong executable_base = 0x400000;
            int length = 0;
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i].prot == 5)
                {
                    executable_base = entries[i].start;
                    length = (int)(entries[i].end - entries[i].start);
                    
                    break;
                }
            }

            if (length != 0 && executable_base != 0)
            {

                var memory = ps4.ReadMemory(pid, executable_base + (StartSearchPosition - executable_base), SearchLength);
                var stream = new MemoryStream(memory);
                AddrVAR = GetAddress(stream, 0x0, memory.Length, bytesToFind) + executable_base + (StartSearchPosition - executable_base);
            }
            else {
            }
            return AddrVAR;
        
           
        }

        public static uint GetAddr(uint addr_start, uint addr_end, uint[] buf, uint buf_num, uint num)
        {
            uint i;
            uint addr;

            addr = addr_start;

            while (addr < addr_end)
            {
                if ((addr & 0xFFFF) == 0)
                {
                   
                        addr += 0x10000;
                        continue;
                   
                }

                for (i = 0; i < buf_num; i++)
                {
                    if ((uint)(addr + i * 4) != buf[i])
                    {
                        break;
                    }
                }

                if (i == buf_num)
                {
                    num--;
                    if (num == 0)
                    {
                        return addr;
                    }
                }

                addr += 4;
            }
            return 0;
        }


    }
}
