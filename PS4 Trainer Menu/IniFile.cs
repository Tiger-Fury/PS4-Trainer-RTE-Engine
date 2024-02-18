using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ini
{
	// Token: 0x02000007 RID: 7
	public class IniFile
	{
		// Token: 0x06000039 RID: 57
		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		// Token: 0x0600003A RID: 58
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		// Token: 0x0600003B RID: 59 RVA: 0x000035F5 File Offset: 0x000017F5
		public IniFile(string IniPath)
		{
			this.path = IniPath;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00003606 File Offset: 0x00001806
		public void IniWriteValue(string Section, string Key, string Value)
		{
			IniFile.WritePrivateProfileString(Section, Key, Value, this.path);
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003618 File Offset: 0x00001818
		public string IniReadValue(string Section, string Key)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			int privateProfileString = IniFile.GetPrivateProfileString(Section, Key, "", stringBuilder, 255, this.path);
			return stringBuilder.ToString();
		}

		// Token: 0x04000021 RID: 33
		public string path;
	}
}
