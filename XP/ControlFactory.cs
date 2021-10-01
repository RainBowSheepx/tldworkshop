using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace XP
{
	// Token: 0x02000002 RID: 2
	public class ControlFactory
	{

		// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public static Control CreateControl(string ctrlName, string partialName)
		{
			Control result;
			try
			{
				Control control;
				if (ctrlName != null)
				{
					uint num = 1; //<PrivateImplementationDetails>.ComputeStringHash(ctrlName);
					if (num <= 1595554146U)
					{
						if (num <= 496722843U)
						{
							if (num != 278373862U)
							{
								if (num == 496722843U)
								{
									if (ctrlName == "TextBox")
									{
										control = new TextBox();
										goto IL_193;
									}
								}
							}
							else if (ctrlName == "PictureBox")
							{
								control = new PictureBox();
								goto IL_193;
							}
						}
						else if (num != 864557713U)
						{
							if (num == 1595554146U)
							{
								if (ctrlName == "DateTimePicker")
								{
									control = new DateTimePicker();
									goto IL_193;
								}
							}
						}
						else if (ctrlName == "Button")
						{
							control = new Button();
							goto IL_193;
						}
					}
					else if (num <= 1933324558U)
					{
						if (num != 1819906012U)
						{
							if (num == 1933324558U)
							{
								if (ctrlName == "ComboBox")
								{
									control = new ComboBox();
									goto IL_193;
								}
							}
						}
						else if (ctrlName == "ListView")
						{
							control = new ListView();
							goto IL_193;
						}
					}
					else if (num != 2642369432U)
					{
						if (num != 2664231581U)
						{
							if (num == 3911048475U)
							{
								if (ctrlName == "MonthCalender")
								{
									control = new MonthCalendar();
									goto IL_193;
								}
							}
						}
						else if (ctrlName == "Label")
						{
							control = new Label();
							goto IL_193;
						}
					}
					else if (ctrlName == "CheckBox")
					{
						control = new CheckBox();
						goto IL_193;
					}
				}
				control = (Control)Activator.CreateInstance(Assembly.LoadWithPartialName(partialName).GetType(partialName + "." + ctrlName));
				IL_193:
				result = control;
			}
			catch (Exception ex)
			{
				Trace.WriteLine("create control failed:" + ex.Message);
				result = new Control();
			}
			return result;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002238 File Offset: 0x00000438
		public static void SetControlProperties(Control ctrl, Hashtable propertyList)
		{
			foreach (object obj in TypeDescriptor.GetProperties(ctrl))
			{
				PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj;
				if (propertyList.Contains(propertyDescriptor.Name))
				{
					object value = propertyList[propertyDescriptor.Name];
					try
					{
						propertyDescriptor.SetValue(ctrl, value);
					}
					catch (Exception ex)
					{
						Trace.WriteLine(ex.Message);
					}
				}
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000022C8 File Offset: 0x000004C8
		public static Control CloneCtrl(Control ctrl)
		{
			CBFormCtrl cbformCtrl = new CBFormCtrl(ctrl);
			Control control = ControlFactory.CreateControl(cbformCtrl.CtrlName, cbformCtrl.PartialName);
			ControlFactory.SetControlProperties(control, cbformCtrl.PropertyList);
			return control;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000022FC File Offset: 0x000004FC
		public static void CopyCtrl2ClipBoard(Control ctrl)
		{
			CBFormCtrl data = new CBFormCtrl(ctrl);
			DataObject dataObject = new DataObject();
			((IDataObject)dataObject).SetData(CBFormCtrl.Format.Name, true, data);
			Clipboard.SetDataObject(dataObject, false);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002330 File Offset: 0x00000530
		public static Control GetCtrlFromClipBoard()
		{
			Control control = new Control();
			IDataObject dataObject = Clipboard.GetDataObject();
			if (dataObject.GetDataPresent(CBFormCtrl.Format.Name))
			{
				CBFormCtrl cbformCtrl = dataObject.GetData(CBFormCtrl.Format.Name) as CBFormCtrl;
				control = ControlFactory.CreateControl(cbformCtrl.CtrlName, cbformCtrl.PartialName);
				ControlFactory.SetControlProperties(control, cbformCtrl.PropertyList);
			}
			return control;
		}
	}
}
