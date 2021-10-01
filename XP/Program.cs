using System;
using System.Reflection;
using System.Windows.Forms;

namespace XP
{
	// Token: 0x02000006 RID: 6
	internal static class Program
	{
		// Token: 0x06000040 RID: 64 RVA: 0x000085A0 File Offset: 0x000067A0
		[STAThread]
		private static void Main(string[] args)
		{
			try
			{
				EmbeddedAssembly.Load("XP.Ionic.Zip.dll", "Ionic.Zip.dll");
				AppDomain.CurrentDomain.AssemblyResolve += Program.CurrentDomain_AssemblyResolve;
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Form1());
			}
			catch (Exception ex)
			{
				MessageBox.Show("Unable to run workshop: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x0000861C File Offset: 0x0000681C
		private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			return EmbeddedAssembly.Get(args.Name);
		}
	}
}
