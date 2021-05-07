using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XP
{
	public abstract class Mod
	{
		bool disabled = false;
		bool update = false;
		string compiledVer = null;
		string filePath = null;
		int errorCount = 0;


		internal virtual int modErrors { get => errorCount; set => errorCount = value; }
		internal virtual bool isDisabled { get => disabled; set => disabled = value; }
		internal virtual string fileName { get => filePath; set => filePath = value; }
		public virtual bool SecondPass => false;
		public abstract string ID { get; }

		/// <summary>
		/// The name that will be displayed.
		/// </summary>
		public virtual string Name { get { return ID; } }
		public virtual bool UseAssetsFolder
		{
			get
			{
				return false;
			}
		}
		public virtual bool LoadInMenu
		{
			get
			{
				return false;
			}
		}

		public virtual bool LoadInDB
		{
			get
			{
				return false;
			}
		}
		/// <summary>
		/// The current version of the mod.
		/// </summary>
		public abstract string Version { get; }

		/// <summary>
		/// The name of the author.
		/// </summary>
		public abstract string Author { get; }

		public virtual void OnMenuLoad()
		{
		//	if (this.LoadInMenu)
		//	{
		//		Debug.LogError(string.Format("<b>LoadInMenu</b> is set to <b>true</b> for mod: <b>{0}</b> but <b>OnMenuLoad()</b> is empty.", this.ID));
		//	}
		}

		public virtual void dbLoad()
		{

		//	if (this.LoadInDB)
		//	{
			//	Debug.LogError(string.Format("<b>LoadInDB</b> is set to <b>true</b> for mod: <b>{0}</b> but <b>dbLoad()</b> is empty.", this.ID));
		//	}
		}
		/// <summary>
		/// Called when the mod is loaded.
		/// </summary>
		public virtual void OnLoad() { }

		/// <summary>
		/// Called to draw the mod's GUI.
		/// </summary>
		public virtual void OnGUI() { }

		/// <summary>
		/// Called every tick.
		/// </summary>
		public virtual void Update() { }
		public virtual void FixedUpdate() { }


		public virtual void SecondPassOnLoad() { }
	}
}
