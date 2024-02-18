using System;

namespace librpc
{
	// Token: 0x02000002 RID: 2
	public class Process
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Process(string name, int pid)
		{
			this.name = name;
			this.pid = pid;
		}

		// Token: 0x04000001 RID: 1
		public string name;

		// Token: 0x04000002 RID: 2
		public int pid;
	}
}
