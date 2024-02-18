using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace librpc
{
    // Token: 0x02000006 RID: 6
    public class PS4RPC
    {
        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000008 RID: 8 RVA: 0x000021D4 File Offset: 0x000003D4
        public bool IsConnected
        {
            get
            {
                return connected;
            }
        }

        // Token: 0x06000009 RID: 9 RVA: 0x000021EC File Offset: 0x000003EC
        public PS4RPC(IPAddress addr)
        {
            enp = new IPEndPoint(addr, RPC_PORT);
            sock = new Socket(enp.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true
            };
            sock.ReceiveTimeout = (sock.SendTimeout = 2000);
        }

        // Token: 0x0600000A RID: 10 RVA: 0x0000226C File Offset: 0x0000046C
        public PS4RPC(string ip)
        {
            IPAddress address = null;
            try
            {
                address = IPAddress.Parse(ip);
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            enp = new IPEndPoint(address, RPC_PORT);
            sock = new Socket(enp.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true
            };
            sock.ReceiveTimeout = (sock.SendTimeout = 2000);
        }

        // Token: 0x0600000B RID: 11 RVA: 0x00002310 File Offset: 0x00000510
        private static string GetNullTermString(byte[] data, int offset)
        {
            int num = Array.IndexOf<byte>(data, 0, offset) - offset;
            bool flag = num < 0;
            if (flag)
            {
                num = data.Length - offset;
            }
            return Encoding.ASCII.GetString(data, offset, num);
        }

        // Token: 0x0600000C RID: 12 RVA: 0x0000234C File Offset: 0x0000054C
        private static byte[] SubArray(byte[] data, int offset, int length)
        {
            byte[] array = new byte[length];
            Buffer.BlockCopy(data, offset, array, 0, length);
            return array;
        }

        // Token: 0x0600000D RID: 13 RVA: 0x00002374 File Offset: 0x00000574
        private static bool IsFatalStatus(RPC_STATUS status)
        {
          //  return status >> 28 == (PS4RPC.RPC_STATUS)15u;
            return (uint)status >> 28 == 15;
        }

        // Token: 0x0600000E RID: 14 RVA: 0x00002390 File Offset: 0x00000590
        public void Connect()
        {
            bool flag = !connected;
            if (flag)
            {
                sock.Connect(enp);
                connected = true;
            }
        }

        // Token: 0x0600000F RID: 15 RVA: 0x000023C6 File Offset: 0x000005C6
        public void Disconnect()
        {
            SendCMDPacket((RPC_CMDS)3170893832u, 0);
            sock.Dispose();
            connected = false;
        }

        // Token: 0x06000010 RID: 16 RVA: 0x000023EC File Offset: 0x000005EC
        private void SendPacketData(int length, params object[] fields)
        {
            MemoryStream memoryStream = new MemoryStream();
            foreach (object obj in fields)
            {
                byte[] array = null;
                bool flag = obj.GetType() == typeof(char);
                if (flag)
                {
                    array = BitConverter.GetBytes((char)obj);
                }
                else
                {
                    bool flag2 = obj.GetType() == typeof(byte);
                    if (flag2)
                    {
                        array = BitConverter.GetBytes((byte)obj);
                    }
                    else
                    {
                        bool flag3 = obj.GetType() == typeof(short);
                        if (flag3)
                        {
                            array = BitConverter.GetBytes((short)obj);
                        }
                        else
                        {
                            bool flag4 = obj.GetType() == typeof(ushort);
                            if (flag4)
                            {
                                array = BitConverter.GetBytes((ushort)obj);
                            }
                            else
                            {
                                bool flag5 = obj.GetType() == typeof(int);
                                if (flag5)
                                {
                                    array = BitConverter.GetBytes((int)obj);
                                }
                                else
                                {
                                    bool flag6 = obj.GetType() == typeof(uint);
                                    if (flag6)
                                    {
                                        array = BitConverter.GetBytes((uint)obj);
                                    }
                                    else
                                    {
                                        bool flag7 = obj.GetType() == typeof(long);
                                        if (flag7)
                                        {
                                            array = BitConverter.GetBytes((long)obj);
                                        }
                                        else
                                        {
                                            bool flag8 = obj.GetType() == typeof(ulong);
                                            if (flag8)
                                            {
                                                array = BitConverter.GetBytes((ulong)obj);
                                            }
                                            else
                                            {
                                                bool flag9 = obj.GetType() == typeof(byte[]);
                                                if (flag9)
                                                {
                                                    array = (byte[])obj;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                memoryStream.Write(array, 0, array.Length);
            }
            this.SendData(memoryStream.ToArray(), length);
            memoryStream.Dispose();
        }

        // Token: 0x06000011 RID: 17 RVA: 0x000025D7 File Offset: 0x000007D7
        private void SendCMDPacket(RPC_CMDS cmd, int length)
        {
            SendPacketData(RPC_PACKET_SIZE, new object[]
            {
                RPC_PACKET_MAGIC,
                (uint)cmd,
                length
            });
        }

        // Token: 0x06000012 RID: 18 RVA: 0x0000260C File Offset: 0x0000080C
        private RPC_STATUS ReceiveRPCStatus()
        {
            byte[] array = new byte[4];
            sock.Receive(array, 4, SocketFlags.None);
            return (RPC_STATUS)BitConverter.ToUInt32(array, 0);
        }

        // Token: 0x06000013 RID: 19 RVA: 0x0000263C File Offset: 0x0000083C
        private RPC_STATUS CheckRPCStatus()
        {
            RPC_STATUS rpc_STATUS = ReceiveRPCStatus();
            bool flag = IsFatalStatus(rpc_STATUS);
            if (flag)
            {
                string str = "";
                StatusMessages.TryGetValue(rpc_STATUS, out str);
                //throw new Exception("librpc: " + str);
            }
            return rpc_STATUS;
        }

        // Token: 0x06000014 RID: 20 RVA: 0x00002688 File Offset: 0x00000888
        private void SendData(byte[] data, int length)
        {
            int i = length;
            int num = 0;
            while (i > 0)
            {
                bool flag = i > RPC_MAX_DATA_LEN;
                if (flag)
                {
                    byte[] buffer = SubArray(data, num, RPC_MAX_DATA_LEN);
                    int num2 = sock.Send(buffer, RPC_MAX_DATA_LEN, SocketFlags.None);
                    num += num2;
                    i -= num2;
                }
                else
                {
                    byte[] buffer2 = SubArray(data, num, i);
                    int num2 = sock.Send(buffer2, i, SocketFlags.None);
                    num += num2;
                    i -= num2;
                }
            }
        }

        // Token: 0x06000015 RID: 21 RVA: 0x00002708 File Offset: 0x00000908
        private byte[] ReceiveData(int length)
        {
            MemoryStream memoryStream = new MemoryStream();
            int num;
            for (int i = length; i > 0; i -= num)
            {
                byte[] buffer = new byte[RPC_MAX_DATA_LEN];
                num = sock.Receive(buffer, RPC_MAX_DATA_LEN, SocketFlags.None);
                memoryStream.Write(buffer, 0, num);
            }
            byte[] result = memoryStream.ToArray();
            memoryStream.Dispose();
            return result;
        }

        // Token: 0x06000016 RID: 22 RVA: 0x00002774 File Offset: 0x00000974
        public byte[] ReadMemory(int pid, ulong address, int length)
        {
            bool flag = !connected;
            if (flag)
            {
                throw new Exception("librpc: not connected");
            }
            this.SendCMDPacket((RPC_CMDS)3170893825u, RPC_PROC_READ_SIZE);
            this.SendPacketData(RPC_PROC_READ_SIZE, new object[]
            {
                pid,
                address,
                length
            });
            CheckRPCStatus();
            return ReceiveData(length);
        }

        // Token: 0x06000017 RID: 23 RVA: 0x000027EC File Offset: 0x000009EC
        public void WriteMemory(int pid, ulong address, byte[] data)
        {
            bool flag = !connected;
            if (flag)
            {
                throw new Exception("librpc: not connected");
            }
            bool flag2 = data.Length > RPC_MAX_DATA_LEN;
            if (flag2)
            {
                byte[] data2 = SubArray(data, 0, RPC_MAX_DATA_LEN);
                SendCMDPacket((RPC_CMDS)3170893826u, RPC_PROC_WRITE_SIZE);
                SendPacketData(RPC_PROC_WRITE_SIZE, new object[]
                {
                    pid,
                    address,
                    RPC_MAX_DATA_LEN
                });
                CheckRPCStatus();
                SendData(data2, RPC_MAX_DATA_LEN);
                CheckRPCStatus();
                int length = data.Length - RPC_MAX_DATA_LEN;
                ulong address2 = address + (ulong)RPC_MAX_DATA_LEN;
                byte[] data3 = SubArray(data, RPC_MAX_DATA_LEN, length);
                WriteMemory(pid, address2, data3);
            }
            else
            {
                bool flag3 = data.Length != 0;
                if (flag3)
                {
                    SendCMDPacket((RPC_CMDS)3170893826u, RPC_PROC_WRITE_SIZE);
                    SendPacketData(RPC_PROC_WRITE_SIZE, new object[]
                    {
                        pid,
                        address,
                        data.Length
                    });
                    CheckRPCStatus();
                    SendData(data, data.Length);
                    CheckRPCStatus();
                }
            }
        }

        // Token: 0x06000018 RID: 24 RVA: 0x00002928 File Offset: 0x00000B28
        public ulong KernelBase()
        {
            bool flag = !connected;
            if (flag)
            {
                throw new Exception("librpc: not connected");
            }
            this.SendCMDPacket((RPC_CMDS)3170893834u, 0);
            this.CheckRPCStatus();
            return BitConverter.ToUInt64(ReceiveData(RPC_KERN_BASE_SIZE), 0);
        }

        // Token: 0x06000019 RID: 25 RVA: 0x00002978 File Offset: 0x00000B78
        public byte[] KernelReadMemory(ulong address, int length)
        {
            bool flag = !connected;
            if (flag)
            {
                throw new Exception("librpc: not connected");
            }
            SendCMDPacket((RPC_CMDS)3170893835u, RPC_KERN_READ_SIZE);
            SendPacketData(RPC_KERN_READ_SIZE, new object[]
            {
                address,
                length
            });
            CheckRPCStatus();
            return ReceiveData(length);
        }

        // Token: 0x0600001A RID: 26 RVA: 0x000029E8 File Offset: 0x00000BE8
        public void KernelWriteMemory(ulong address, byte[] data)
        {
            bool flag = !connected;
            if (flag)
            {
                throw new Exception("librpc: not connected");
            }
            bool flag2 = data.Length > RPC_MAX_DATA_LEN;
            if (flag2)
            {
                byte[] data2 = SubArray(data, 0, RPC_MAX_DATA_LEN);
                SendCMDPacket((RPC_CMDS)3170893836u, RPC_KERN_WRITE_SIZE);
                SendPacketData(RPC_KERN_WRITE_SIZE, new object[]
                {
                    address,
                    RPC_MAX_DATA_LEN
                });
                CheckRPCStatus();
                SendData(data2, RPC_MAX_DATA_LEN);
                CheckRPCStatus();
                int length = data.Length - RPC_MAX_DATA_LEN;
                ulong address2 = address + (ulong)((long)RPC_MAX_DATA_LEN);
                byte[] data3 = SubArray(data, RPC_MAX_DATA_LEN, length);
                KernelWriteMemory(address2, data3);
            }
            else
            {
                bool flag3 = data.Length != 0;
                if (flag3)
                {
                    SendCMDPacket((RPC_CMDS)3170893836u, RPC_KERN_WRITE_SIZE);
                    SendPacketData(RPC_KERN_WRITE_SIZE, new object[]
                    {
                        address,
                        data.Length
                    });
                    CheckRPCStatus();
                    SendData(data, data.Length);
                    CheckRPCStatus();
                }
            }
        }

        // Token: 0x0600001B RID: 27 RVA: 0x00002B10 File Offset: 0x00000D10
        public ProcessList GetProcessList()
        {
            bool flag = !connected;
            if (flag)
            {
                throw new Exception("librpc: not connected");
            }
            SendCMDPacket((RPC_CMDS)3170893827u, 0);
            CheckRPCStatus();
            byte[] array = new byte[4];
            sock.Receive(array, 4, SocketFlags.None);
            int num = BitConverter.ToInt32(array, 0);
            byte[] array2 = ReceiveData(num * RPC_PROC_LIST_SIZE);
            string[] array3 = new string[num];
            int[] array4 = new int[num];
            for (int i = 0; i < num; i++)
            {
                int num2 = i * RPC_PROC_LIST_SIZE;
                array3[i] = GetNullTermString(array2, num2);
                array4[i] = BitConverter.ToInt32(array2, num2 + 32);
            }
            return new ProcessList(num, array3, array4);
        }

        // Token: 0x0600001C RID: 28 RVA: 0x00002BD8 File Offset: 0x00000DD8
        public ProcessInfo GetProcessInfo(int pid)
        {
            bool flag = !connected;
            if (flag)
            {
                throw new Exception("librpc: not connected");
            }
            SendCMDPacket((RPC_CMDS)3170893828u, RPC_PROC_INFO1_SIZE);
            SendPacketData(RPC_PROC_INFO1_SIZE, new object[]
            {
                pid
            });
            RPC_STATUS rpc_STATUS = CheckRPCStatus();
            bool flag2 = rpc_STATUS == (RPC_STATUS)2147483654u;
            ProcessInfo result;
            if (flag2)
            {
                result = new ProcessInfo(pid, null);
            }
            else
            {
                byte[] array = new byte[4];
                sock.Receive(array, 4, SocketFlags.None);
                int num = BitConverter.ToInt32(array, 0);
                byte[] array2 = this.ReceiveData(num * RPC_PROC_INFO2_SIZE);
                MemoryEntry[] array3 = new MemoryEntry[num];
                for (int i = 0; i < num; i++)
                {
                    int num2 = i * RPC_PROC_INFO2_SIZE;
                    array3[i] = new MemoryEntry
                    {
                        name = GetNullTermString(array2, num2),
                        start = BitConverter.ToUInt64(array2, num2 + 32),
                        end = BitConverter.ToUInt64(array2, num2 + 40),
                        offset = BitConverter.ToUInt64(array2, num2 + 48),
                        prot = BitConverter.ToUInt32(array2, num2 + 56)
                    };
                }
                result = new ProcessInfo(pid, array3);
            }
            return result;
        }

        // Token: 0x0600001D RID: 29 RVA: 0x00002D2C File Offset: 0x00000F2C
        public ulong InstallRPC(int pid)
        {
            bool flag = !connected;
            if (flag)
            {
                throw new Exception("librpc: not connected");
            }
            SendCMDPacket((RPC_CMDS)3170893829u, RPC_PROC_INSTALL1_SIZE);
            SendPacketData(RPC_PROC_INSTALL1_SIZE, new object[]
            {
                pid
            });
            CheckRPCStatus();
            byte[] value = ReceiveData(RPC_PROC_INSTALL2_SIZE);
            return BitConverter.ToUInt64(value, 4);
        }

        // Token: 0x0600001E RID: 30 RVA: 0x00002DA0 File Offset: 0x00000FA0
        public ulong Call(int pid, ulong rpcstub, ulong address, params object[] args)
        {
            bool flag = !connected;
            if (flag)
            {
                throw new Exception("librpc: not connected");
            }
            SendCMDPacket((RPC_CMDS)3170893830u, RPC_PROC_CALL1_SIZE);
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.Write(BitConverter.GetBytes(pid), 0, 4);
            memoryStream.Write(BitConverter.GetBytes(rpcstub), 0, 8);
            memoryStream.Write(BitConverter.GetBytes(address), 0, 8);
            int num = 0;
            foreach (object obj in args)
            {
                byte[] array = new byte[8];
                bool flag2 = obj.GetType() == typeof(char);
                if (flag2)
                {
                    byte[] bytes = BitConverter.GetBytes((char)obj);
                    Buffer.BlockCopy(bytes, 0, array, 0, 2);
                    byte[] array2 = new byte[6];
                    Buffer.BlockCopy(array2, 0, array, 2, array2.Length);
                }
                else
                {
                    bool flag3 = obj.GetType() == typeof(byte);
                    if (flag3)
                    {
                        byte[] bytes2 = BitConverter.GetBytes((byte)obj);
                        Buffer.BlockCopy(bytes2, 0, array, 0, 1);
                        byte[] array3 = new byte[7];
                        Buffer.BlockCopy(array3, 0, array, 1, array3.Length);
                    }
                    else
                    {
                        bool flag4 = obj.GetType() == typeof(short);
                        if (flag4)
                        {
                            byte[] bytes3 = BitConverter.GetBytes((short)obj);
                            Buffer.BlockCopy(bytes3, 0, array, 0, 2);
                            byte[] array4 = new byte[6];
                            Buffer.BlockCopy(array4, 0, array, 2, array4.Length);
                        }
                        else
                        {
                            bool flag5 = obj.GetType() == typeof(ushort);
                            if (flag5)
                            {
                                byte[] bytes4 = BitConverter.GetBytes((ushort)obj);
                                Buffer.BlockCopy(bytes4, 0, array, 0, 2);
                                byte[] array5 = new byte[6];
                                Buffer.BlockCopy(array5, 0, array, 2, array5.Length);
                            }
                            else
                            {
                                bool flag6 = obj.GetType() == typeof(int);
                                if (flag6)
                                {
                                    byte[] bytes5 = BitConverter.GetBytes((int)obj);
                                    Buffer.BlockCopy(bytes5, 0, array, 0, 4);
                                    byte[] array6 = new byte[4];
                                    Buffer.BlockCopy(array6, 0, array, 4, array6.Length);
                                }
                                else
                                {
                                    bool flag7 = obj.GetType() == typeof(uint);
                                    if (flag7)
                                    {
                                        byte[] bytes6 = BitConverter.GetBytes((uint)obj);
                                        Buffer.BlockCopy(bytes6, 0, array, 0, 4);
                                        byte[] array7 = new byte[4];
                                        Buffer.BlockCopy(array7, 0, array, 4, array7.Length);
                                    }
                                    else
                                    {
                                        bool flag8 = obj.GetType() == typeof(long);
                                        if (flag8)
                                        {
                                            byte[] bytes7 = BitConverter.GetBytes((long)obj);
                                            Buffer.BlockCopy(bytes7, 0, array, 0, 8);
                                        }
                                        else
                                        {
                                            bool flag9 = obj.GetType() == typeof(ulong);
                                            if (flag9)
                                            {
                                                byte[] bytes8 = BitConverter.GetBytes((ulong)obj);
                                                Buffer.BlockCopy(bytes8, 0, array, 0, 8);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                memoryStream.Write(array, 0, array.Length);
                num++;
            }
            bool flag10 = num > 6;
            if (flag10)
            {
                throw new Exception("librpc: too many call arguments");
            }
            bool flag11 = num < 6;
            if (flag11)
            {
                for (int j = 0; j < 6 - num; j++)
                {
                    memoryStream.Write(BitConverter.GetBytes(0UL), 0, 8);
                }
            }
            SendData(memoryStream.ToArray(), RPC_PROC_CALL1_SIZE);
            memoryStream.Dispose();
            CheckRPCStatus();
            byte[] value = ReceiveData(RPC_PROC_CALL2_SIZE);
            return BitConverter.ToUInt64(value, 4);
        }

        // Token: 0x0600001F RID: 31 RVA: 0x00003148 File Offset: 0x00001348
        public void LoadElf(int pid, byte[] elf)
        {
            SendCMDPacket((RPC_CMDS)3170893831u, RPC_PROC_ELF_SIZE);
            SendPacketData(RPC_PROC_ELF_SIZE, new object[]
            {
                pid,
                elf.Length
            });
            SendData(elf, elf.Length);
            CheckRPCStatus();
        }

        // Token: 0x06000020 RID: 32 RVA: 0x0000319F File Offset: 0x0000139F
        public void LoadElf(int pid, string filename)
        {
            LoadElf(pid, File.ReadAllBytes(filename));
        }

        // Token: 0x06000021 RID: 33 RVA: 0x000031B0 File Offset: 0x000013B0
        public void Reboot()
        {
            bool flag = !connected;
            if (flag)
            {
                throw new Exception("librpc: not connected");
            }
            SendCMDPacket((RPC_CMDS)3170893833u, 0);
            sock.Dispose();
            connected = false;
        }

        // Token: 0x06000022 RID: 34 RVA: 0x000031F8 File Offset: 0x000013F8
        public byte ReadByte(int pid, ulong address)
        {
            return ReadMemory(pid, address, 1)[0];
        }

        // Token: 0x06000023 RID: 35 RVA: 0x00003218 File Offset: 0x00001418
        public char ReadChar(int pid, ulong address)
        {
            return BitConverter.ToChar(ReadMemory(pid, address, 2), 0);
        }

        // Token: 0x06000024 RID: 36 RVA: 0x0000323C File Offset: 0x0000143C
        public short ReadInt16(int pid, ulong address)
        {
            return BitConverter.ToInt16(ReadMemory(pid, address, 2), 0);
        }

        // Token: 0x06000025 RID: 37 RVA: 0x00003260 File Offset: 0x00001460
        public ushort ReadUInt16(int pid, ulong address)
        {
            return BitConverter.ToUInt16(ReadMemory(pid, address, 2), 0);
        }

        // Token: 0x06000026 RID: 38 RVA: 0x00003284 File Offset: 0x00001484
        public int ReadInt32(int pid, ulong address)
        {
            return BitConverter.ToInt32(ReadMemory(pid, address, 4), 0);
        }

        // Token: 0x06000027 RID: 39 RVA: 0x000032A8 File Offset: 0x000014A8
        public uint ReadUInt32(int pid, ulong address)
        {
            return BitConverter.ToUInt32(ReadMemory(pid, address, 4), 0);
        }

        // Token: 0x06000028 RID: 40 RVA: 0x000032CC File Offset: 0x000014CC
        public long ReadInt64(int pid, ulong address)
        {
            return BitConverter.ToInt64(ReadMemory(pid, address, 8), 0);
        }

        // Token: 0x06000029 RID: 41 RVA: 0x000032F0 File Offset: 0x000014F0
        public ulong ReadUInt64(int pid, ulong address)
        {
            return BitConverter.ToUInt64(ReadMemory(pid, address, 8), 0);
        }

        // Token: 0x0600002A RID: 42 RVA: 0x00003311 File Offset: 0x00001511
        public void WriteByte(int pid, ulong address, byte value)
        {
            WriteMemory(pid, address, new byte[]
            {
                value
            });
        }

        // Token: 0x0600002B RID: 43 RVA: 0x00003327 File Offset: 0x00001527
        public void WriteChar(int pid, ulong address, char value)
        {
            WriteMemory(pid, address, BitConverter.GetBytes(value));
        }

        // Token: 0x0600002C RID: 44 RVA: 0x00003339 File Offset: 0x00001539
        public void WriteInt16(int pid, ulong address, short value)
        {
            WriteMemory(pid, address, BitConverter.GetBytes(value));
        }

        // Token: 0x0600002D RID: 45 RVA: 0x0000334B File Offset: 0x0000154B
        public void WriteUInt16(int pid, ulong address, ushort value)
        {
            WriteMemory(pid, address, BitConverter.GetBytes(value));
        }

        public void WriteRUInt16(int pid, ulong address, ushort value)
        {
            byte[] temp = BitConverter.GetBytes(value);
            Array.Reverse(temp);
            value = BitConverter.ToUInt16(temp, 0);
            WriteMemory(pid, address, BitConverter.GetBytes(value));
        }

        // Token: 0x0600002E RID: 46 RVA: 0x0000335D File Offset: 0x0000155D
        public void WriteInt32(int pid, ulong address, int value)
        {
           
            WriteMemory(pid, address, BitConverter.GetBytes(value));
        }

        // Token: 0x0600002F RID: 47 RVA: 0x0000336F File Offset: 0x0000156F
        public void WriteUInt32(int pid, ulong address, uint value)
        {
            WriteMemory(pid, address, BitConverter.GetBytes(value));
        }

        public void WriteRUInt32(int pid, ulong address, uint value)
        {
            byte[] temp = BitConverter.GetBytes(value);
            Array.Reverse(temp);
            value = BitConverter.ToUInt32(temp, 0);
            WriteMemory(pid, address, BitConverter.GetBytes(value));
        }

        // Token: 0x06000030 RID: 48 RVA: 0x00003381 File Offset: 0x00001581
        public void WriteInt64(int pid, ulong address, long value)
        {
            WriteMemory(pid, address, BitConverter.GetBytes(value));
        }

        // Token: 0x06000031 RID: 49 RVA: 0x00003393 File Offset: 0x00001593
        public void WriteUInt64(int pid, ulong address, ulong value)
        {
            WriteMemory(pid, address, BitConverter.GetBytes(value));
        }

        public void WriteRUInt64(int pid, ulong address, ulong value)
        {
            byte[] temp = BitConverter.GetBytes(value);
            Array.Reverse(temp);
            value = BitConverter.ToUInt64(temp, 0);
            WriteMemory(pid, address, BitConverter.GetBytes(value));
        }

        // Token: 0x06000032 RID: 50 RVA: 0x000033A8 File Offset: 0x000015A8
        public float ReadSingle(int pid, ulong address)
        {
            return BitConverter.ToSingle(ReadMemory(pid, address, 4), 0);
        }

        // Token: 0x06000033 RID: 51 RVA: 0x000033C9 File Offset: 0x000015C9
        public void WriteSingle(int pid, ulong address, float value)
        {
            WriteMemory(pid, address, BitConverter.GetBytes(value));
        }

        // Token: 0x06000034 RID: 52 RVA: 0x000033DC File Offset: 0x000015DC
        public double ReadDouble(int pid, ulong address)
        {
            return BitConverter.ToDouble(this.ReadMemory(pid, address, 8), 0);
        }

        // Token: 0x06000035 RID: 53 RVA: 0x000033FD File Offset: 0x000015FD
        public void WriteDouble(int pid, ulong address, double value)
        {
            WriteMemory(pid, address, BitConverter.GetBytes(value));
        }

        // Token: 0x06000036 RID: 54 RVA: 0x00003410 File Offset: 0x00001610
        public string ReadString(int pid, ulong address)
        {
            string text = "";
            ulong num = 0UL;
            for (; ; )
            {
                byte b = ReadByte(pid, address + num);
                bool flag = b == 0;
                if (flag)
                {
                    break;
                }
                text += Convert.ToChar(b).ToString();
                num += 1UL;
            }
            return text;
        }

        // Token: 0x06000037 RID: 55 RVA: 0x00003468 File Offset: 0x00001668
        public void WriteString(int pid, ulong address, string str)
        {
            WriteMemory(pid, address, Encoding.ASCII.GetBytes(str));
            WriteByte(pid, address + (ulong)((long)str.Length), 0);
        }



       

      

        // Token: 0x0400000B RID: 11
        private Socket sock = null;

        // Token: 0x0400000C RID: 12
        private IPEndPoint enp = null;

        // Token: 0x0400000D RID: 13
        private bool connected = false;

        // Token: 0x0400000E RID: 14
        private static int RPC_PORT = 733;

        // Token: 0x0400000F RID: 15
        private static uint RPC_PACKET_MAGIC = 3182083020u;

        // Token: 0x04000010 RID: 16
        private static int RPC_MAX_DATA_LEN = 8192;

        // Token: 0x04000011 RID: 17
        private static int RPC_PACKET_SIZE = 12;

        // Token: 0x04000012 RID: 18
        private static int RPC_PROC_READ_SIZE = 16;

        // Token: 0x04000013 RID: 19
        private static int RPC_PROC_WRITE_SIZE = 16;

        // Token: 0x04000014 RID: 20
        private static int RPC_PROC_LIST_SIZE = 36;

        // Token: 0x04000015 RID: 21
        private static int RPC_PROC_INFO1_SIZE = 4;

        // Token: 0x04000016 RID: 22
        private static int RPC_PROC_INFO2_SIZE = 60;

        // Token: 0x04000017 RID: 23
        private static int RPC_PROC_INSTALL1_SIZE = 4;

        // Token: 0x04000018 RID: 24
        private static int RPC_PROC_INSTALL2_SIZE = 12;

        // Token: 0x04000019 RID: 25
        private static int RPC_PROC_CALL1_SIZE = 68;

        // Token: 0x0400001A RID: 26
        private static int RPC_PROC_CALL2_SIZE = 12;

        // Token: 0x0400001B RID: 27
        private static int RPC_PROC_ELF_SIZE = 8;

        // Token: 0x0400001C RID: 28
        private static int RPC_KERN_BASE_SIZE = 8;

        // Token: 0x0400001D RID: 29
        private static int RPC_KERN_READ_SIZE = 12;

        // Token: 0x0400001E RID: 30
        private static int RPC_KERN_WRITE_SIZE = 12;

        // Token: 0x0400001F RID: 31
        private static Dictionary<RPC_STATUS, string> StatusMessages = new Dictionary<RPC_STATUS, string>
        {
            {
                (RPC_STATUS)2147483648u,
                "success"
            },
            {
                (RPC_STATUS)4026531841u,
                "too much data"
            },
            {
                (RPC_STATUS)4026531842u,
                "read error"
            },
            {
                (RPC_STATUS)4026531843u,
                "write error"
            },
            {
                (RPC_STATUS)4026531844u,
                "process list error"
            },
            {
                (RPC_STATUS)4026531845u,
                "process information error"
            },
            {
                (RPC_STATUS)4026531847u,
                "no such process error"
            },
            {
                (RPC_STATUS)4026531848u,
                "could not install rpc"
            },
            {
                (RPC_STATUS)4026531849u,
                "could not call address"
            },
            {
                (RPC_STATUS)4026531850u,
                "could not map elf"
            }
        };

        // Token: 0x02000064 RID: 100
        private enum RPC_CMDS : uint
        {
            // Token: 0x04000A35 RID: 2613
            RPC_PROC_READ = 3170893825u,
            // Token: 0x04000A36 RID: 2614
            RPC_PROC_WRITE,
            // Token: 0x04000A37 RID: 2615
            RPC_PROC_LIST,
            // Token: 0x04000A38 RID: 2616
            RPC_PROC_INFO,
            // Token: 0x04000A39 RID: 2617
            RPC_PROC_INTALL,
            // Token: 0x04000A3A RID: 2618
            RPC_PROC_CALL,
            // Token: 0x04000A3B RID: 2619
            RPC_PROC_ELF,
            // Token: 0x04000A3C RID: 2620
            RPC_END,
            // Token: 0x04000A3D RID: 2621
            RPC_REBOOT,
            // Token: 0x04000A3E RID: 2622
            RPC_KERN_BASE,
            // Token: 0x04000A3F RID: 2623
            RPC_KERN_READ,
            // Token: 0x04000A40 RID: 2624
            RPC_KERN_WRITE
        }

        // Token: 0x02000065 RID: 101
        public enum RPC_STATUS : uint
        {
            // Token: 0x04000A42 RID: 2626
            RPC_SUCCESS = 2147483648u,
            // Token: 0x04000A43 RID: 2627
            RPC_TOO_MUCH_DATA = 4026531841u,
            // Token: 0x04000A44 RID: 2628
            RPC_READ_ERROR,
            // Token: 0x04000A45 RID: 2629
            RPC_WRITE_ERROR,
            // Token: 0x04000A46 RID: 2630
            RPC_LIST_ERROR,
            // Token: 0x04000A47 RID: 2631
            RPC_INFO_ERROR,
            // Token: 0x04000A48 RID: 2632
            RPC_INFO_NO_MAP = 2147483654u,
            // Token: 0x04000A49 RID: 2633
            RPC_NO_PROC = 4026531847u,
            // Token: 0x04000A4A RID: 2634
            RPC_INSTALL_ERROR,
            // Token: 0x04000A4B RID: 2635
            RPC_CALL_ERROR,
            // Token: 0x04000A4C RID: 2636
            RPC_ELF_ERROR
        }

      
    }
}
