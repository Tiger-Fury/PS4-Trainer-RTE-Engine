using System;
using librpc;

namespace PS4_Trainer_Menu
{
	// Token: 0x02000009 RID: 9
	internal class Calling
	{
		// Token: 0x06000052 RID: 82 RVA: 0x00003918 File Offset: 0x00001B18
		public static ulong malloc(int size)
		{
			bool flag = Calling.version == 405;
			ulong result;
			if (flag)
			{
				result = Calling.ps4.Call(Calling.notifyPid, Calling.notifyStub, Calling.libSceLibcInternal.start + 230128UL, new object[]
				{
					size
				});
			}
			else
			{
				bool flag2 = Calling.version == 455;
				if (flag2)
				{
					result = Calling.ps4.Call(Calling.notifyPid, Calling.notifyStub, Calling.libSceLibcInternal.start + 180896UL, new object[]
					{
						size
					});
				}
				else
				{
					bool flag3 = Calling.version == 505;
					if (flag3)
					{
						result = Calling.ps4.Call(Calling.notifyPid, Calling.notifyStub, Calling.libSceLibcInternal.start + 146832UL, new object[]
						{
							size
						});
					}
					else
					{
						result = Calling.ps4.Call(Calling.notifyPid, Calling.notifyStub, Calling.libSceLibcInternal.start + 146832UL, new object[]
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
			bool flag = Calling.version == 405;
			if (flag)
			{
				Calling.ps4.Call(Calling.notifyPid, Calling.notifyStub, Calling.libSceLibcInternal.start + 230272UL, new object[]
				{
					address
				});
			}
			else
			{
				bool flag2 = Calling.version == 455;
				if (flag2)
				{
					Calling.ps4.Call(Calling.notifyPid, Calling.notifyStub, Calling.libSceLibcInternal.start + 181040UL, new object[]
					{
						address
					});
				}
				else
				{
					bool flag3 = Calling.version == 505;
					if (flag3)
					{
						Calling.ps4.Call(Calling.notifyPid, Calling.notifyStub, Calling.libSceLibcInternal.start + 146976UL, new object[]
						{
							address
						});
					}
					else
					{
						Calling.ps4.Call(Calling.notifyPid, Calling.notifyStub, Calling.libSceLibcInternal.start + 146976UL, new object[]
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
			bool flag = Calling.version == 405;
			ulong num;
			if (flag)
			{
				num = 768UL;
			}
			else
			{
				bool flag2 = Calling.version == 455;
				if (flag2)
				{
					num = 848UL;
				}
				else
				{
					bool flag3 = Calling.version == 505;
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
			Calling.ps4.Connect();
			bool flag4 = Calling.notifyPid == -1;
			if (flag4)
			{
				ProcessList processList = Calling.ps4.GetProcessList();
				foreach (Process process in processList.processes)
				{
					bool flag5 = process.name == "SceSysCore.elf";
					if (flag5)
					{
						Calling.notifyPid = process.pid;
					}
				}
			}
			ProcessInfo processInfo = Calling.ps4.GetProcessInfo(Calling.notifyPid);
			bool flag6 = Calling.notifyStub == 0UL;
			if (flag6)
			{
				Calling.notifyStub = Calling.ps4.InstallRPC(Calling.notifyPid);
				Calling.libSceLibcInternal = processInfo.FindEntry("libSceLibcInternal.sprx");
			}
			ulong num2 = Calling.malloc(text.Length + 1);
			Calling.ps4.WriteString(Calling.notifyPid, num2, text);
			MemoryEntry memoryEntry = processInfo.FindEntry("libSceSysUtil.sprx");
			Calling.ps4.Call(Calling.notifyPid, Calling.notifyStub, memoryEntry.start + num, new object[]
			{
				type,
				num2
			});
			Calling.free(num2);
		}

		// Token: 0x04000026 RID: 38
		public static int version = -1;

		// Token: 0x04000027 RID: 39
		public static PS4RPC ps4 = PS4_Trainer_Menu.MainLoader.ps4;

		// Token: 0x04000028 RID: 40
		public static ulong notifyStub = 0UL;

		// Token: 0x04000029 RID: 41
		public static int notifyPid = -1;

		// Token: 0x0400002A RID: 42
		public static MemoryEntry libSceLibcInternal = null;
	}
}
