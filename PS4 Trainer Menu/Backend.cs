using System;
using System.Windows.Forms;
using librpc;

namespace PS4_Trainer_Menu
{

    internal class Calling
    {
       
        public static ulong malloc(int size)
        {
            bool flag = version == 405;
            ulong result;
            if (flag)
            {
                result = ps4.Call(notifyPid, notifyStub, libSceLibcInternal.start + 230128UL, new object[]
                {
                    size
                });
            }
            else
            {
                bool flag2 = version == 455;
                if (flag2)
                {
                    result = ps4.Call(notifyPid, notifyStub, libSceLibcInternal.start + 180896UL, new object[]
                    {
                        size
                    });
                }
                else
                {
                    bool flag3 = version == 505;
                    if (flag3)
                    {
                        result = ps4.Call(notifyPid, notifyStub, libSceLibcInternal.start + 146832UL, new object[]
                        {
                            size
                        });
                    }
                    else
                    {
                        result = ps4.Call(notifyPid, notifyStub, libSceLibcInternal.start + 146832UL, new object[]
                        {
                            size
                        });
                    }
                }
            }
            return result;
        }

        // Token: 0x06000053 RID: 83 RVA: 0x00003A38 File Offset: 0x00001C38
        public static void free(ulong address)
        {
            bool flag = version == 405;
            if (flag)
            {
                ps4.Call(notifyPid, notifyStub, libSceLibcInternal.start + 230272UL, new object[]
                {
                    address
                });
            }
            else
            {
                bool flag2 = version == 455;
                if (flag2)
                {
                    ps4.Call(notifyPid, notifyStub, libSceLibcInternal.start + 181040UL, new object[]
                    {
                        address
                    });
                }
                else
                {
                    bool flag3 = version == 505;
                    if (flag3)
                    {
                        ps4.Call(notifyPid, notifyStub, libSceLibcInternal.start + 146976UL, new object[]
                        {
                            address
                        });
                    }
                    else
                    {
                        ps4.Call(notifyPid, notifyStub, libSceLibcInternal.start + 146976UL, new object[]
                        {
                            address
                        });
                    }
                }
            }
        }

        // Token: 0x06000054 RID: 84 RVA: 0x00003B54 File Offset: 0x00001D54
        public static void Notify(string text, int type = 222)
        {
            bool flag = version == 405;
            ulong num;
            if (flag)
            {
                num = 768UL;
            }
            else
            {
                bool flag2 = version == 455;
                if (flag2)
                {
                    num = 848UL;
                }
                else
                {
                    bool flag3 = version == 505;
                    if (flag3)
                    {
                        num = 816UL;
                    }
                    else
                    {
                        num = 816UL;
                    }
                }
            }
            ps4.Connect();
            bool flag4 = notifyPid == -1;
            if (flag4)
            {
                ProcessList processList = ps4.GetProcessList();
                foreach (Process process in processList.processes)
                {
                    bool flag5 = process.name == "SceSysCore.elf";
                    if (flag5)
                    {
                        notifyPid = process.pid;
                    }
                }
            }
            ProcessInfo processInfo = ps4.GetProcessInfo(notifyPid);
            bool flag6 = notifyStub == 0UL;
            if (flag6)
            {
                notifyStub = ps4.InstallRPC(notifyPid);
                libSceLibcInternal = processInfo.FindEntry("libSceLibcInternal.sprx");
            }
            ulong num2 = malloc(text.Length + 1);
            ps4.WriteString(notifyPid, num2, text);
            MemoryEntry memoryEntry = processInfo.FindEntry("libSceSysUtil.sprx");
            ps4.Call(notifyPid, notifyStub, memoryEntry.start + num, new object[]
            {
                type,
                num2
            });
            free(num2);
        }



        // Token: 0x04000026 RID: 38
        public static int version = -1;

        // Token: 0x04000027 RID: 39
        public static PS4RPC ps4 = MainLoader.ps4;

        // Token: 0x04000028 RID: 40
        public static ulong notifyStub = 0UL;

        // Token: 0x04000029 RID: 41
        public static int notifyPid = -1;

        // Token: 0x0400002A RID: 42
        public static MemoryEntry libSceLibcInternal = null;
    }
    internal class Util
    {
        // Token: 0x060002E3 RID: 739 RVA: 0x000375A4 File Offset: 0x000357A4
        public static void AttachToGame(string processName, string gameName, ref bool att, ref int pid, ref ulong procEntry, Button attBtn, ref ulong stub, ref ulong stringbuf, bool initRpc = false)
        {
            try
            {
                ps4.Connect();
                ProcessList processList = ps4.GetProcessList();
                foreach (Process process in processList.processes)
                {
                    bool flag = process.name == processName;
                    if (flag)
                    {
                        pid = process.pid;
                        ProcessInfo processInfo = ps4.GetProcessInfo(process.pid);
                        for (int j = 0; j < processInfo.entries.Length; j++)
                        {
                            MemoryEntry memoryEntry = processInfo.entries[j];
                            bool flag2 = memoryEntry.prot == 5u;
                            if (flag2)
                            {
                                procEntry = memoryEntry.start;
                                if (initRpc)
                                {
                                    bool flag3 = stub == 0UL;
                                    if (flag3)
                                    {
                                        stub = ps4.InstallRPC(pid);
                                        vme = processInfo.FindEntry("libSceLibcInternal.sprx");
                                        bool flag4 = Calling.version == 405;
                                        if (flag4)
                                        {
                                            stringbuf = ps4.Call(pid, stub, vme.start + 230128UL, new object[]
                                            {
                                                4096
                                            });
                                        }
                                        else
                                        {
                                            bool flag5 = Calling.version == 455;
                                            if (flag5)
                                            {
                                                stringbuf = ps4.Call(pid, stub, vme.start + 180896UL, new object[]
                                                {
                                                    4096
                                                });
                                            }
                                            else
                                            {
                                                bool flag6 = Calling.version == 505;
                                                if (flag6)
                                                {
                                                    stringbuf = ps4.Call(pid, stub, vme.start + 146832UL, new object[]
                                                    {
                                                        4096
                                                    });
                                                }
                                                else
                                                {
                                                    stringbuf = ps4.Call(pid, stub, vme.start + 146832UL, new object[]
                                                    {
                                                        4096
                                                    });
                                                }
                                            }
                                        }
                                    }
                                }
                                Calling.Notify("Trainer Successfully\nConnected to\n\n " + gameName + "!\n\n\n\n\n\n", 210);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    

        // Token: 0x040004D3 RID: 1235
        private static PS4RPC ps4 = MainLoader.ps4;

        // Token: 0x040004D5 RID: 1237
        private static MemoryEntry vme;
    }
}
