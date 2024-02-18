using System;

namespace librpc
{
	// Token: 0x02000003 RID: 3
	public class ProcessList
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
		public ProcessList(int number, string[] names, int[] pids)
		{
			this.processes = new Process[number];
			for (int i = 0; i < number; i++)
			{
				this.processes[i] = new Process(names[i], pids[i]);
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000020B0 File Offset: 0x000002B0
		public Process FindProcess(string name, bool contains = false)
		{
			foreach (Process process in this.processes)
			{
				if (contains)
				{
					bool flag = process.name.Contains(name);
					if (flag)
					{
						return process;
					}
				}
				else
				{
					bool flag2 = process.name == name;
					if (flag2)
					{
						return process;
					}
				}
			}
			return null;
		}

		// Token: 0x04000003 RID: 3
		public Process[] processes;
	}
}
