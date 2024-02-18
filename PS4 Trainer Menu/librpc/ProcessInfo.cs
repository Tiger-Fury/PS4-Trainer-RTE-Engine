using System;

namespace librpc
{
	// Token: 0x02000005 RID: 5
	public class ProcessInfo
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002125 File Offset: 0x00000325
		public ProcessInfo(int pid, MemoryEntry[] entries)
		{
			this.pid = pid;
			this.entries = entries;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002140 File Offset: 0x00000340
		public MemoryEntry FindEntry(string name)
		{
			foreach (MemoryEntry memoryEntry in this.entries)
			{
				bool flag = memoryEntry.name == name;
				if (flag)
				{
					return memoryEntry;
				}
			}
			return null;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002188 File Offset: 0x00000388
		public MemoryEntry FindEntry(ulong size)
		{
			foreach (MemoryEntry memoryEntry in this.entries)
			{
				bool flag = memoryEntry.start - memoryEntry.end == size;
				if (flag)
				{
					return memoryEntry;
				}
			}
			return null;
		}

		// Token: 0x04000009 RID: 9
		public int pid;

		// Token: 0x0400000A RID: 10
		public MemoryEntry[] entries;
	}
}
