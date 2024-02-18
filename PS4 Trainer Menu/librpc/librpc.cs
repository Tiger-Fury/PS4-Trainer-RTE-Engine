using System;


namespace librpc
{
    public class MemoryEntry
    {
        // Token: 0x04000004 RID: 4
        public string name;

        // Token: 0x04000005 RID: 5
        public ulong start;

        // Token: 0x04000006 RID: 6
        public ulong end;

        // Token: 0x04000007 RID: 7
        public ulong offset;

        // Token: 0x04000008 RID: 8
        public uint prot;
    }

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
            foreach (MemoryEntry memoryEntry in entries)
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
            foreach (MemoryEntry memoryEntry in entries)
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

    public class ProcessList
    {
        // Token: 0x06000002 RID: 2 RVA: 0x00002068 File Offset: 0x00000268
        public ProcessList(int number, string[] names, int[] pids)
        {
            processes = new Process[number];
            for (int i = 0; i < number; i++)
            {
                processes[i] = new Process(names[i], pids[i]);
            }
        }

        // Token: 0x06000003 RID: 3 RVA: 0x000020B0 File Offset: 0x000002B0
        public Process FindProcess(string name, bool contains = false)
        {
            foreach (Process process in processes)
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
