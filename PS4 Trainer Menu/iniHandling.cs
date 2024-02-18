using System;
using System.Windows.Forms;
using Ini;

namespace PS4_Trainer_Menu
{
	// Token: 0x0200000A RID: 10
	internal class iniHandling
	{
		// Token: 0x0400002B RID: 43
		public static IniFile ini = new IniFile(Application.StartupPath + "\\Settings.ini");

		// Token: 0x0400002C RID: 44
		public static string ip = iniHandling.ini.IniReadValue("Console", "IP");

		// Token: 0x0400002D RID: 45
		public static bool showAttached = iniHandling.ini.IniReadValue("GameTools", "DisplayAttached") == "1";

		// Token: 0x0400002E RID: 46
		public static bool testConOnStartup = iniHandling.ini.IniReadValue("Console", "TestConnectionOnStartup") == "1";
	}
}
