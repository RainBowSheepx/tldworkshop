using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace XP
{
	// Token: 0x02000004 RID: 4
	public class EmbeddedAssembly
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000024B4 File Offset: 0x000006B4
		public static void Load(string embeddedResource, string fileName)
		{
			if (EmbeddedAssembly.dic == null)
			{
				EmbeddedAssembly.dic = new Dictionary<string, Assembly>();
			}
			byte[] array = null;
			Assembly assembly;
			using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedResource))
			{
				if (manifestResourceStream == null)
				{
					throw new Exception(embeddedResource + " is not found in Embedded Resources.");
				}
				array = new byte[(int)manifestResourceStream.Length];
				manifestResourceStream.Read(array, 0, (int)manifestResourceStream.Length);
				try
				{
					assembly = Assembly.Load(array);
					EmbeddedAssembly.dic.Add(assembly.FullName, assembly);
					return;
				}
				catch
				{
				}
			}
			bool flag = false;
			string path = "";
			using (SHA1CryptoServiceProvider sha1CryptoServiceProvider = new SHA1CryptoServiceProvider())
			{
				string a = BitConverter.ToString(sha1CryptoServiceProvider.ComputeHash(array)).Replace("-", string.Empty);
				path = Path.GetTempPath() + fileName;
				if (File.Exists(path))
				{
					byte[] buffer = File.ReadAllBytes(path);
					string b = BitConverter.ToString(sha1CryptoServiceProvider.ComputeHash(buffer)).Replace("-", string.Empty);
					if (a == b)
					{
						flag = true;
					}
					else
					{
						flag = false;
					}
				}
				else
				{
					flag = false;
				}
			}
			if (!flag)
			{
				File.WriteAllBytes(path, array);
			}
			assembly = Assembly.LoadFile(path);
			EmbeddedAssembly.dic.Add(assembly.FullName, assembly);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000261C File Offset: 0x0000081C
		public static Assembly Get(string assemblyFullName)
		{
			if (EmbeddedAssembly.dic == null || EmbeddedAssembly.dic.Count == 0)
			{
				return null;
			}
			if (EmbeddedAssembly.dic.ContainsKey(assemblyFullName))
			{
				return EmbeddedAssembly.dic[assemblyFullName];
			}
			return null;
		}

		// Token: 0x04000005 RID: 5
		private static Dictionary<string, Assembly> dic;
	}
}
