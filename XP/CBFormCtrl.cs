using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace XP
{
	// Token: 0x02000003 RID: 3
	[Serializable]
	public class CBFormCtrl
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000023AB File Offset: 0x000005AB
		public static DataFormats.Format Format
		{
			get
			{
				return CBFormCtrl.format;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000023B2 File Offset: 0x000005B2
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000023BA File Offset: 0x000005BA
		public string CtrlName
		{
			get
			{
				return this.ctrlName;
			}
			set
			{
				this.ctrlName = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000B RID: 11 RVA: 0x000023C3 File Offset: 0x000005C3
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000023CB File Offset: 0x000005CB
		public string PartialName
		{
			get
			{
				return this.partialName;
			}
			set
			{
				this.partialName = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000023D4 File Offset: 0x000005D4
		public Hashtable PropertyList
		{
			get
			{
				return this.propertyList;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000023DC File Offset: 0x000005DC
		public CBFormCtrl()
		{
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000023F0 File Offset: 0x000005F0
		public CBFormCtrl(Control ctrl)
		{
			this.CtrlName = ctrl.GetType().Name;
			this.PartialName = ctrl.GetType().Namespace;
			foreach (object obj in TypeDescriptor.GetProperties(ctrl))
			{
				PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj;
				try
				{
					if (propertyDescriptor.PropertyType.IsSerializable)
					{
						this.propertyList.Add(propertyDescriptor.Name, propertyDescriptor.GetValue(ctrl));
					}
				}
				catch (Exception ex)
				{
					Trace.WriteLine(ex.Message);
				}
			}
		}

		// Token: 0x04000001 RID: 1
		private static DataFormats.Format format = DataFormats.GetFormat(typeof(CBFormCtrl).FullName);

		// Token: 0x04000002 RID: 2
		private string ctrlName;

		// Token: 0x04000003 RID: 3
		private string partialName;

		// Token: 0x04000004 RID: 4
		private Hashtable propertyList = new Hashtable();
	}
}
