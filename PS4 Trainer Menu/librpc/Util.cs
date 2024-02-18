using System;
using System.Windows.Forms;
using librpc;

namespace PS4_Trainer_Menu
{
	
	internal class Util
	{
      

        public static ulong PointerBase(string input, int pid)
        {
            bool flag = input.StartsWith("@") && input.Contains("_") && input.Contains("+");
            ulong result;
            if (flag)
            {
                string text = input.TrimStart(new char[]
                {
                    '@'
                });
                string[] array = text.Split(new char[]
                {
                    '_'
                });
                int num = Convert.ToInt32(array[1]) + 1;
                string[] array2 = array[2].Split(new char[]
                {
                    '+'
                });
                ProcessInfo processInfo = ps4.GetProcessInfo(pid);
                ulong num2 = Convert.ToUInt64(array2[0], 16);
                num2 += processInfo.entries[num].start;
                result = num2;
            }
            else
            {
                result = 0UL;
            }
            return result;
        }

        public static ulong[] PointerLevels(string input)
        {
            bool flag = input.StartsWith("@");
            ulong[] result;
            if (flag)
            {
                string[] array = input.Split(new char[]
                {
                    '+'
                });
                ulong[] array2 = new ulong[array.Length - 1];
                for (int i = 1; i < array.Length; i++)
                {
                    array2[i - 1] = Convert.ToUInt64(array[i], 16);
                }
                result = array2;
            }
            else
            {
                result = null;
            }
            return result;
        }

        public static ulong GetPointerAdress(string pointer, int pid)
        {
            ulong result;
            try
            {
                ulong num = ps4.ReadUInt64(pid, PointerBase(pointer, pid));
                for (int i = 0; i < PointerLevels(pointer).Length - 1; i++)
                {
                    num = ps4.ReadUInt64(pid, num + PointerLevels(pointer)[i]);
                }
                num += PointerLevels(pointer)[PointerLevels(pointer).Length - 1];
                result = num;
            }
            catch
            {
                result = 0UL;
            }
            return result;
        }

        public static string[] GameInfoArray()
        {
            string b = "SceCdlgApp";
            string b2 = "libSceCdlgUtilServer.sprx";
            ulong num = 160UL;
            ulong num2 = 200UL;
            int num3 = 3;
            string[] array = new string[2];
            string[] result;
            try
            {
                ps4.Connect();
                ProcessList processList = ps4.GetProcessList();
                foreach (Process process in processList.processes)
                {
                    bool flag = process.name == b;
                    if (flag)
                    {
                        ProcessInfo processInfo = ps4.GetProcessInfo(process.pid);
                        for (int j = 0; j < processInfo.entries.Length; j++)
                        {
                            MemoryEntry memoryEntry = processInfo.entries[j];
                            bool flag2 = memoryEntry.prot == (ulong)num3 && memoryEntry.name == b2;
                            if (flag2)
                            {
                                array[0] = ps4.ReadString(process.pid, memoryEntry.start + num);
                                array[1] = ps4.ReadString(process.pid, memoryEntry.start + num2);
                                return array;
                            }
                        }
                    }
                }
                result = new string[2];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                result = new string[2];
            }
            return result;
        }

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
                    
						att = true;
						attBtn.Enabled = false;
						return;
					}
				}
				MessageBox.Show("Failed to detect game process.\nMake sure " + gameName + " is running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				att = false;
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
