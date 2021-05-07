using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XP
{
   public class ModsDetector
    {
        public static List<Mod> LoadedMods { get; internal set; }
        public static int count = 0;
        public static string ModsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TheLongDrive\Mods\";

		internal static List<string> InvalidMods;



		public void Main()
		{
			// Load .dll files
			foreach (string file in Directory.GetFiles(ModsFolder))
			{
				if (file.EndsWith(".dll"))
				{
					LoadDLL(file);
				}
			}
		}
		private static void LoadDLL(string file)
		{
			try
			{
				Assembly asm = Assembly.LoadFrom(file);
				bool isMod = false;

				AssemblyName[] list = asm.GetReferencedAssemblies();

				//Warn about wrong .net target, source of some mod crashes.
				if (!asm.ImageRuntimeVersion.Equals(Assembly.GetExecutingAssembly().ImageRuntimeVersion))
					Console.WriteLine(string.Format("File <b>{0}</b> is targeting runtime version <b>{1}</b> which is different that current running version <b>{2}</b>. This may cause unexpected behaviours, check your target assembly.", Path.GetFileName(file), asm.ImageRuntimeVersion, Assembly.GetExecutingAssembly().ImageRuntimeVersion));

				// Look through all public classes                
				foreach (Type type in asm.GetTypes())
				{
					string msVer = null;
					if (typeof(Mod).IsAssignableFrom(type))
					{
						for (int i = 0; i < list.Length; i++)
						{
							if (list[i].Name == "TLDLoader")
							{
								string[] verparse = list[i].Version.ToString().Split('.');
								if (list[i].Version.ToString() == "1.0.0.0")
									msVer = "0.1";
								else
								{
									if (verparse[2] == "0")
										msVer = string.Format("{0}.{1}", verparse[0], verparse[1]);
									else
										msVer = string.Format("{0}.{1}.{2}", verparse[0], verparse[1], verparse[2]);
								}
							}
						}
						isMod = true;
						LoadMod((Mod)Activator.CreateInstance(type), msVer, file);
						break;
					}
					else
					{
						isMod = false;
					}
				}
				if (!isMod)
				{

					Console.WriteLine(string.Format("<b>{0}</b> - doesn't look like a mod or missing Mod subclass!", Path.GetFileName(file)));
					InvalidMods.Add(Path.GetFileName(file));
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(string.Format("<b>{0}</b> - doesn't look like a mod, remove this file from mods folder!", Path.GetFileName(file)));
				//UnityEngine.Debug.Log(e);
				InvalidMods.Add(Path.GetFileName(file));
			}

		}
		private static void LoadMod(Mod mod, string msver, string fname = null)
		{
			// Check if mod already exists
			if (!LoadedMods.Contains(mod))
			{
				mod.fileName = fname;
				LoadedMods.Add(mod);
			}
			else
			{
				Console.WriteLine(string.Format("<color=orange><b>Mod already loaded (or duplicated ID):</b></color><color=red><b>{0}</b></color>", mod.ID));
			}
		}

	}
}
