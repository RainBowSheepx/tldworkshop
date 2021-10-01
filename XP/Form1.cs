using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using Ionic.Zip;
using XP.Properties;
using ZipFile = Ionic.Zip.ZipFile;

namespace XP
{
	// Token: 0x02000005 RID: 5
	public partial class Form1 : Form
	{
		// Token: 0x06000014 RID: 20
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x06000015 RID: 21
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x06000016 RID: 22 RVA: 0x00002650 File Offset: 0x00000850
		public Form1()
		{
			this.InitializeComponent();
			this.submodl.Visible = false;
			this.MaximumSize = new Size(Screen.FromControl(this).WorkingArea.Width, Screen.FromControl(this).WorkingArea.Height);
			Form1.refrence = this;
			this.submodl.Visible = false;
			this.submodl2.Visible = false;
			this.SubModDes.Visible = false;
			if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +  "\\TheLongDrive\\Dark.dat"))
			{
				this.checkBox1.Checked = true;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000026F1 File Offset: 0x000008F1
		private void Move_Window(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (e.Clicks > 1)
				{
					this.Maximise_Window_Toggle(sender, e);
				}
				Form1.ReleaseCapture();
				Form1.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000272A File Offset: 0x0000092A
		private void Maximise_Window_Toggle(object sender, EventArgs e)
		{
			base.WindowState = ((base.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000273F File Offset: 0x0000093F
		private void Minimise_Window(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002748 File Offset: 0x00000948
		private void Form1_Resize(object sender, EventArgs e)
		{
			Control[] array = new Control[]
			{

				this.ResizeBarBottom,
				this.ResizeBarLeft,
				this.ResizeBarRight
			};
			bool visible = base.WindowState != FormWindowState.Maximized;
			Control[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Visible = visible;
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000027AD File Offset: 0x000009AD
		private void Close_Window(object sender, EventArgs e)
		{
			Form.ActiveForm.Close();
			Application.Exit();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000027C0 File Offset: 0x000009C0
		private void Resize_Window(object sender, MouseEventArgs e)
		{
			if (base.WindowState == FormWindowState.Maximized)
			{
				this.resizeTemp = Rectangle.Empty;
				return;
			}
			try
			{
				if (this.resizeTemp.IsEmpty)
				{
					Cursor.Current = (Form1.areNumbersClose(base.ClientRectangle.Bottom, e.Y, 10) ? Cursors.SizeNS : Cursor.Current);
					Cursor.Current = (Form1.areNumbersClose(base.ClientRectangle.Right, e.X, 10) ? ((Cursor.Current == Cursors.SizeNS) ? Cursors.SizeNWSE : Cursors.SizeWE) : Cursor.Current);
				}
				else
				{
					Cursor.Current = ((this.resizeTemp.Height != 0) ? Cursors.SizeNS : Cursor.Current);
					Cursor.Current = ((this.resizeTemp.Width != 0) ? ((Cursor.Current == Cursors.SizeNS) ? Cursors.SizeNWSE : Cursors.SizeWE) : Cursor.Current);
				}
			}
			catch
			{
				Cursor.Current = Cursors.Default;
			}
			if (e.Button == MouseButtons.Left)
			{
				if (!this.resizeTemp.IsEmpty)
				{
					base.ClientSize = new Size((this.resizeTemp.Width == 0) ? base.ClientSize.Width : e.X, (this.resizeTemp.Height == 0) ? base.ClientSize.Height : e.Y);
					return;
				}
				if (e.Clicks != 0)
				{
					if (Form1.areNumbersClose(base.ClientRectangle.Bottom, e.Y, 10))
					{
						this.resizeTemp.Height = 1;
					}
					if (Form1.areNumbersClose(base.ClientRectangle.Right, e.X, 10))
					{
						this.resizeTemp.Width = 1;
						return;
					}
				}
			}
			else
			{
				this.resizeTemp = Rectangle.Empty;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000029B0 File Offset: 0x00000BB0
		private void Leave_Window(object sender, EventArgs e)
		{
			this.Resize_Window(this, new MouseEventArgs(Control.MouseButtons, 0, base.PointToClient(Cursor.Position).X, base.PointToClient(Cursor.Position).Y, 0));
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000029F6 File Offset: 0x00000BF6
		private void Enter_Window(object sender, EventArgs e)
		{
			this.resizeTemp = Rectangle.Empty;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002A03 File Offset: 0x00000C03
		private static bool areNumbersClose(int num1, int num2, int distanceThreshold)
		{
			return Math.Abs(num1 - num2) <= distanceThreshold;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002A14 File Offset: 0x00000C14
		private static Image DownloadImage(string fromUrl)
		{
			Image result;
			try
			{
				if (fromUrl.ToLower().StartsWith("http") || !fromUrl.ToLower().EndsWith("gif"))
				{
					using (WebClient webClient = new WebClient())
					{
						using (Stream stream = webClient.OpenRead(fromUrl))
						{
							return Image.FromStream(stream);
						}
					}
				}
				using (FileStream fileStream = new FileStream(fromUrl, FileMode.Open, FileAccess.Read))
				{
					MemoryStream memoryStream = new MemoryStream();
					byte[] array = new byte[16384];
					int count;
					while ((count = fileStream.Read(array, 0, array.Length)) > 0)
					{
						memoryStream.Write(array, 0, count);
					}
					memoryStream.Position = 0L;
					result = Image.FromStream(memoryStream);
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002B04 File Offset: 0x00000D04
		private void Select_Listing(object listingSender, EventArgs args)
		{
			download.Enabled = true;
			if (this.downloadperc.Text == "Complete!")
			{
				this.downloadbar.Visible = false;
				this.downloadperc.Visible = false;
				this.downloadtext.Visible = false;
			}
			foreach (Form1.ModListing modListing in Form1.ModListings)
			{
				if (modListing.MainControl == (Control)listingSender || modListing.MainControl == ((Control)listingSender).Parent)
				{
					string text = modListing.ItemName.Text;
					string text2 = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TheLongDrive\\Mods\\temp\\" + text + ".txt";
					File.Delete(text2);
					this.updatemods.Visible = false;
					this.ModAuthor.Text = "Author: " + modListing.ItemAuthor.Text;
					this.ModDes2.Text = modListing.ItemDescription.Text;
					this.ModDate.Text = "Date of release: " + modListing.ItemDate.Text;
					this.ModPic.Image = modListing.ItemImage.Image;
					this.ModName.Text = modListing.ItemName.Text;
					modListing.Select(true);
					this.ModDes2.Visible = true;
					this.mymods.Text = "Back";
					this.ModName.Visible = true;
					this.mymods.Text = "Back";
					this.ModAuthor.Visible = true;
					this.ModDate.Visible = true;
					this.ModDes.Visible = true;
					this.ModDownloads.Visible = true;
					this.ModPic.Visible = true;
					this.itemPanel.Visible = false;
					this.searchl.Visible = false;
					this.searchin.Visible = false;
					this.refresh.Visible = false;
					this.ItemList.Visible = false;
					this.mymods.Visible = true;
					this.back.Visible = true;
					this.download.Visible = true;
					this.submod.Visible = false;
					this.submodl.Visible = false;
					this.submodl.Visible = false;
					this.submodl2.Visible = false;
					this.SubModDes.Visible = false;
					this.SubModl3.Visible = false;
					this.submoddragdrop.Visible = false;
					this.submodl4.Visible = false;
					this.submodb.Visible = false;
					this.modderl1.Visible = false;
					this.modderl2.Visible = false;
					this.adminpwd.Visible = false;
					this.submodd.Visible = false;
					this.modsubdok.Visible = false;
				}
				else
				{
					modListing.Select(false);
				}
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002E9C File Offset: 0x0000109C
		private void Form1_Load(object sender, EventArgs e)
		{
			WebClient webClient = new WebClient();
			if (float.Parse(((Form1.CheckVer)new DataContractJsonSerializer(typeof(Form1.CheckVer)).ReadObject(new MemoryStream(webClient.DownloadData("http://tldworkshop.hopto.org/check.json")))).newversion) > this.nowversion)
			{
				MessageBox.Show("New version of workshop is now available! \nDownload from discord.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				Environment.Exit(0);
			}
			Form1.JSONN jsonn = (Form1.JSONN)new DataContractJsonSerializer(typeof(Form1.JSONN)).ReadObject(new MemoryStream(webClient.DownloadData("http://tldworkshop.hopto.org/modlist_2.json")));
			string[] array = new string[]
			{
				"https://cdn.discordapp.com/attachments/752578049064697906/753228626752831609/zefQXQ7XrXo.jpg",
				"https://cdn.discordapp.com/attachments/752578049064697906/753243489512194098/DCIM_2019-02-23-5285246.png",
				"https://cdn.discordapp.com/attachments/752578049064697906/753616272217866341/catjammercar_sqenu_is_rarted_v2.gif",
				"https://cdn.discordapp.com/attachments/752578049064697906/755897138956861572/unknown.png",
				"https://cdn.discordapp.com/attachments/752578049064697906/758121802643013643/2019112610435374.png",
				"https://cdn.discordapp.com/attachments/752578049064697906/758122531721969694/20190129_033224252.png",
				"https://cdn.discordapp.com/attachments/752578049064697906/758123152521166848/unknown.png",
				"https://cdn.discordapp.com/attachments/655083079324532759/760163314734071879/72327593_1673268889469772_6064536625596071936_n.png",
				"https://cdn.discordapp.com/attachments/752578049064697906/761441490282217483/Screenshot_2020-09-06-21-51-27.png",
				"https://cdn.discordapp.com/attachments/752578049064697906/761526785392246794/Screenshot_2020-09-06-22-00-19-1.png",
				"https://cdn.discordapp.com/attachments/701698502060671079/761639368376844308/image.jpg",
				"https://cdn.discordapp.com/attachments/701698502060671079/761639646392090644/image.jpg",
				"https://cdn.discordapp.com/attachments/701698502060671079/761639772799762472/image.jpg",
				"https://cdn.discordapp.com/attachments/701698502060671079/761639797151236106/image.jpg",
				"https://cdn.discordapp.com/attachments/701698502060671079/761640053695971348/image.jpg",
				"https://cdn.discordapp.com/attachments/701698502060671079/761639828935934003/image.jpg",
				"https://cdn.discordapp.com/attachments/701698502060671079/761639815031947344/image.jpg"
			};
			for (int i = 0; i < jsonn.ModList.Length; i++)
			{
				Form1.Mod mod = new Form1.Mod
				{
					Author = jsonn.ModList[i].Author,
					Link = jsonn.ModList[i].Link,
					Name = jsonn.ModList[i].Name,
					Date = jsonn.ModList[i].Date,
					Description = jsonn.ModList[i].Description,
					Version = jsonn.ModList[i].Version
				};
				if (jsonn.ModList[i].PictureLink.Contains(".png"))
				{
					mod.PictureLink = jsonn.ModList[i].PictureLink;
				}
				else
				{
					mod.PictureLink = "http://tldworkshop.hopto.org/mods/pictures/notfound.png";
				}
				Form1.ModListings.Add(new Form1.ModListing(mod));
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000030A0 File Offset: 0x000012A0
		private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			try
			{
				if (this.downloadbar.Value != e.ProgressPercentage)
				{
					this.downloadbar.Value = e.ProgressPercentage;
				}
				if (this.downloadperc.Text != e.ProgressPercentage.ToString() + "%")
				{
					this.downloadperc.Text = e.ProgressPercentage.ToString() + "%";
				}
				this.downloadperc.Text = (Convert.ToDouble(e.BytesReceived) / 1024.0 / this.sw.Elapsed.TotalSeconds).ToString("0.00") + " KB/c " + e.ProgressPercentage.ToString() + "%";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000319C File Offset: 0x0000139C
		private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			this.downloadbar.Value = 100;
			this.downloadperc.Text = "Complete!";
			this.sw.Stop();
			this.download.Enabled = true;
			this.mymods.Enabled = true;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000031EC File Offset: 0x000013EC
		private void webClient_DownloadFileCompletedZip(object sender, AsyncCompletedEventArgs e)
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TheLongDrive\\Mods");
			this.downloadbar.Value = 80;
			this.downloadperc.Text = "Unzipping...";
			this.sw.Stop();
			ZipFile zipFile = new ZipFile(text + "/temp/" + Form1.selectedMod.ItemName.Text + ".zip");
			zipFile.ZipError += this.zip_Error;
			zipFile.ExtractProgress += this.zip_Progress;
			zipFile.ExtractAll(text, ExtractExistingFileAction.OverwriteSilently);
			this.download.Enabled = true;
			this.mymods.Enabled = true;
			this.downloadperc.Text = "Complete!";
			this.downloadbar.Value = 100;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000032B8 File Offset: 0x000014B8
		private void webClient_DownloadFileCompletedPatch(object sender, AsyncCompletedEventArgs e)
		{
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TheLongDrive\\Mods");
			this.downloadbar.Value = 80;
			this.downloadperc.Text = "Unzipping...";
			this.sw.Stop();
			ZipFile zipFile = new ZipFile(text + "/temp/TLDPatcherNEW.zip");
			zipFile.ZipError += this.zip_Error;
			zipFile.ExtractProgress += this.zip_Progress;
			try
			{
				zipFile.ExtractAll(text + "/temp/");
				this.download.Enabled = true;
				this.mymods.Enabled = true;
				this.downpatcher.Enabled = true;
				this.downloadperc.Text = "Complete!";
				this.downloadbar.Value = 100;
				zipFile.Dispose();
				this.webClient.Dispose();
			}
			catch (Exception)
			{
				
			}
			File.Copy(text + "/temp/patcher/TLDLoader.dll", Application.StartupPath + "/TLDLoader.dll", true);
			Process.Start(text + "/temp/patcher/TLDPatcher.exe", "\"" + text + "/temp/patcher/\"");
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000033F8 File Offset: 0x000015F8
		private void zip_Error(object sender, ZipErrorEventArgs e)
		{
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TheLongDrive\\Mods");
			this.downloadbar.Value = 80;
			this.downloadperc.Text = "Unzipping Failed!";
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003428 File Offset: 0x00001628
		private void zip_Progress(object sender, ExtractProgressEventArgs e)
		{
			Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TheLongDrive\\Mods");
			this.downloadperc.Text = string.Concat(new string[]
			{
				"Unzipping... ",
				e.EntriesTotal.ToString(),
				"B/",
				e.TotalBytesToTransfer.ToString(),
				"B"
			});
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003498 File Offset: 0x00001698
		private void download_Click(object sender, EventArgs e)
		{

			if (Form1.selectedMod != null || this.ModName.Visible)
			{
				string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TheLongDrive\\Mods");
				if (this.download.Text == "Download")
				{
					if (this.download.Text != "Doasdwnload")
					{
						string text2 = Form1.selectedMod.ItemName.Text;
						this.downloadbar.Visible = true;
						this.downloadperc.Visible = true;
						this.downloadtext.Visible = true;
						this.downloadtext.Text = "Downloading: " + Form1.selectedMod.ItemName.Text;
						this.downloadperc.Text = "0%";
						this.downloadbar.Value = 0;
						this.download.Enabled = false;
						this.mymods.Enabled = false;
						
					}
					if (!Directory.Exists(text))
					{
						Directory.CreateDirectory(text);
					}
					if (Form1.selectedMod.ItemDetails.Link.Contains(".dll"))
					{
						Uri address = new Uri(Form1.selectedMod.ItemDetails.Link);
						if (File.Exists(text + "\\" + Form1.selectedMod.ItemName.Text + ".dll"))
						{
							File.Delete(text + "\\" + Form1.selectedMod.ItemName.Text + ".dll");
						}
						this.webClient.DownloadFileAsync(address, text + "/" + Form1.selectedMod.ItemName.Text + ".dll", true);
						this.webClient.DownloadProgressChanged += this.webClient_DownloadProgressChanged;
						this.webClient.DownloadFileCompleted += this.webClient_DownloadFileCompleted;
						this.sw.Start();
						return;
					}
					if (Form1.selectedMod.ItemDetails.Link.Contains(".zip"))
					{
						Uri address2 = new Uri(Form1.selectedMod.ItemDetails.Link);
						if (File.Exists(text + "\\" + Form1.selectedMod.ItemName.Text + ".dll"))
						{
							File.Delete(text + "\\" + Form1.selectedMod.ItemName.Text + ".dll");
						}
						if (!Directory.Exists(text + "/temp/"))
						{
							Directory.CreateDirectory(text + "/temp/");
						}
						this.webClient.DownloadFileAsync(address2, text + "/temp/" + Form1.selectedMod.ItemName.Text + ".zip", true);
						this.webClient.DownloadProgressChanged += this.webClient_DownloadProgressChanged;
						this.webClient.DownloadFileCompleted += this.webClient_DownloadFileCompletedZip;
						this.sw.Start();
						return;
					}
					this.downloadperc.Text = "Internal Server Error!";
					this.download.Enabled = true;
					this.mymods.Enabled = true;
					return;
				}
				else
				{
					File.Delete(text + "/" + Form1.selectedMod.ItemName.Text + ".dll");
					Form1.selectedMod.MainControl.Controls.Clear();
					this.refreshList(1);
					this.download.Enabled = false;
				}
			}
		}

		bool listref = false;

		// Token: 0x0600002A RID: 42 RVA: 0x000039B8 File Offset: 0x00001BB8
		public void refreshList(int mods)
		{
			loadingmods.Visible = true;
			if (mods == 0)
			{
				listref = false;
				ModListings.Clear();
				ItemList.Controls.Clear();
				WebClient web = new WebClient();

				DataContractJsonSerializer json1 = new DataContractJsonSerializer(typeof(JSONN));

				JSONN jsonn = (JSONN)json1.ReadObject(new System.IO.MemoryStream(web.DownloadData("http://tldworkshop.hopto.org/modlist_2.json")));
				download.Text = "Download";
				mymods.Text = "My Mods";
				string[] h = new string[] { "https://cdn.discordapp.com/attachments/752578049064697906/753228626752831609/zefQXQ7XrXo.jpg", "https://cdn.discordapp.com/attachments/752578049064697906/753243489512194098/DCIM_2019-02-23-5285246.png", "https://cdn.discordapp.com/attachments/752578049064697906/753616272217866341/catjammercar_sqenu_is_rarted_v2.gif", "https://cdn.discordapp.com/attachments/752578049064697906/755897138956861572/unknown.png", "https://cdn.discordapp.com/attachments/752578049064697906/758121802643013643/2019112610435374.png", "https://cdn.discordapp.com/attachments/752578049064697906/758122531721969694/20190129_033224252.png", "https://cdn.discordapp.com/attachments/752578049064697906/758123152521166848/unknown.png", "https://cdn.discordapp.com/attachments/655083079324532759/760163314734071879/72327593_1673268889469772_6064536625596071936_n.png", "https://cdn.discordapp.com/attachments/752578049064697906/761441490282217483/Screenshot_2020-09-06-21-51-27.png", "https://cdn.discordapp.com/attachments/752578049064697906/761526785392246794/Screenshot_2020-09-06-22-00-19-1.png", "https://cdn.discordapp.com/attachments/701698502060671079/761639368376844308/image.jpg", "https://cdn.discordapp.com/attachments/701698502060671079/761639646392090644/image.jpg", "https://cdn.discordapp.com/attachments/701698502060671079/761639772799762472/image.jpg", "https://cdn.discordapp.com/attachments/701698502060671079/761639797151236106/image.jpg", "https://cdn.discordapp.com/attachments/701698502060671079/761640053695971348/image.jpg", "https://cdn.discordapp.com/attachments/701698502060671079/761639828935934003/image.jpg", "https://cdn.discordapp.com/attachments/701698502060671079/761639815031947344/image.jpg" };
				for (int x = 0; x < jsonn.ModList.Length; x++)
				{
					Mod mod = new Mod() { Author = jsonn.ModList[x].Author, Link = jsonn.ModList[x].Link, Name = jsonn.ModList[x].Name, Date = jsonn.ModList[x].Date, Description = jsonn.ModList[x].Description, Version = jsonn.ModList[x].Version };

					if (jsonn.ModList[x].PictureLink.Contains(".png"))
						mod.PictureLink = jsonn.ModList[x].PictureLink;
					else
						mod.PictureLink = "http://tldworkshop.hopto.org/mods/pictures/notfound.png";

					ModListings.Add(new ModListing(mod));
				}
				downloadbar.Visible = false;
				downloadperc.Visible = false;
				downloadtext.Visible = false;
				selectedMod = null;
			}
			if (mods == 1)
			{
				listref = true;
				XmlObjectSerializer xmlObjectSerializer = new DataContractJsonSerializer(typeof(Form1.JSONN));
				WebClient webClient2 = new WebClient();
				Form1.JSONN jsonn2 = (Form1.JSONN)xmlObjectSerializer.ReadObject(new MemoryStream(webClient2.DownloadData("http://tldworkshop.hopto.org/modlist_2.json")));
				string str2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TheLongDrive\\Mods");
				Form1.ModListings.Clear();
				this.ItemList.Controls.Clear();
				this.download.Text = "Delete";
				this.mymods.Text = "Back";
				this.mymods.Visible = true;
				string[] array2 = new string[]
				{
					"https://cdn.discordapp.com/attachments/752578049064697906/753228626752831609/zefQXQ7XrXo.jpg",
					"https://cdn.discordapp.com/attachments/752578049064697906/753243489512194098/DCIM_2019-02-23-5285246.png",
					"https://cdn.discordapp.com/attachments/752578049064697906/753616272217866341/catjammercar_sqenu_is_rarted_v2.gif",
					"https://cdn.discordapp.com/attachments/752578049064697906/755897138956861572/unknown.png",
					"https://cdn.discordapp.com/attachments/752578049064697906/758121802643013643/2019112610435374.png",
					"https://cdn.discordapp.com/attachments/752578049064697906/758122531721969694/20190129_033224252.png",
					"https://cdn.discordapp.com/attachments/752578049064697906/758123152521166848/unknown.png",
					"https://cdn.discordapp.com/attachments/655083079324532759/760163314734071879/72327593_1673268889469772_6064536625596071936_n.png",
					"https://cdn.discordapp.com/attachments/752578049064697906/761441490282217483/Screenshot_2020-09-06-21-51-27.png",
					"https://cdn.discordapp.com/attachments/752578049064697906/761526785392246794/Screenshot_2020-09-06-22-00-19-1.png",
					"https://cdn.discordapp.com/attachments/701698502060671079/761639368376844308/image.jpg",
					"https://cdn.discordapp.com/attachments/701698502060671079/761639646392090644/image.jpg",
					"https://cdn.discordapp.com/attachments/701698502060671079/761639772799762472/image.jpg",
					"https://cdn.discordapp.com/attachments/701698502060671079/761639797151236106/image.jpg",
					"https://cdn.discordapp.com/attachments/701698502060671079/761640053695971348/image.jpg",
					"https://cdn.discordapp.com/attachments/701698502060671079/761639828935934003/image.jpg",
					"https://cdn.discordapp.com/attachments/701698502060671079/761639815031947344/image.jpg"
				};
				for (int j = 0; j < jsonn2.ModList.Length; j++)
				{
					if (File.Exists(str2 + "/" + jsonn2.ModList[j].Name + ".dll"))
					{
						Form1.Mod mod3 = new Form1.Mod
						{
							Author = jsonn2.ModList[j].Author,
							Link = jsonn2.ModList[j].Link,
							Name = jsonn2.ModList[j].Name,
							Date = jsonn2.ModList[j].Date,
							Description = jsonn2.ModList[j].Description,
							Version = jsonn2.ModList[j].Version
						};
						if (jsonn2.ModList[j].PictureLink.Contains(".png"))
						{
							mod3.PictureLink = jsonn2.ModList[j].PictureLink;
						}
						else
						{
							mod3.PictureLink = "http://tldworkshop.hopto.org/mods/pictures/notfound.png";
						}
						Form1.ModListings.Add(new Form1.ModListing(mod3));
					}
				}
				this.downloadbar.Visible = false;
				this.downloadperc.Visible = false;
				this.downloadtext.Visible = false;
				Form1.selectedMod = null;
			}
			loadingmods.Visible = false;
		}
		// Token: 0x0600002B RID: 43 RVA: 0x00003F00 File Offset: 0x00002100
		public void mymods_Click(object sender, EventArgs e)
		{
			

			bool mods = false;
			download.Enabled = true;
			this.download.Enabled = false;
			this.ModDes2.Visible = false;
			this.ModName.Visible = false;
			this.ModDate.Visible = false;
			this.ModDes.Visible = false;
			this.ModDownloads.Visible = false;
			this.ModPic.Visible = false;
			this.mymods.Visible = true;
			this.searchin.Visible = false;
			this.refresh.Visible = true;
			this.searchl.Visible = false;
			if (this.mymods.Text == "My Mods")
			{
				openfolder.Visible = true;
				this.refreshList(1);
				mods = true;
				ItemList.Visible = true;
				this.updatemods.Visible = true;
				return;
			}
			this.ItemList.Visible = true;
			this.itemPanel.Visible = true;
			this.searchin.Text = "";
			this.searchin.Visible = true;
			this.refresh.Visible = true;
			this.searchl.Visible = true;

			if (mods == true)
			{
				mymods.Text = "Back";
			}
			mods = false;
			mymods.Text = "My Mods";
			
			
			openfolder.Visible = false;
			
			
			if (listref == true && ModAuthor.Visible == true)
			{
				mymods.Text = "Back";
				updatemods.Visible = true;
				searchin.Visible = false;
				searchl.Visible = false;
				openfolder.Visible = true;
				ModAuthor.Visible = false;
				return;
			}

			this.ModAuthor.Visible = false;

			if (updatemods.Visible == true)
			{
				refreshList(0);
			}
			this.updatemods.Visible = false;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000402C File Offset: 0x0000222C
		private void gotomods_Click(object sender, EventArgs e)
		{
			welcometext.Visible = false;
			int num = 0;
			foreach (Form1.ModListing modListing in Form1.ModListings)
			{
				num++;
			}
			download.Enabled = false;
			string str = num.ToString();
			string date = DateTime.UtcNow.ToString("MM/dd/yyyy");
			Form1.Mod mod = new Form1.Mod();
			mod.Author = "";
			mod.Name = "Mods Count";
			mod.Date = date;
			mod.Description = "Mods: " + str;
			mod.Version = "";
			mod.PictureLink = "https://drive.google.com/uc?export=download&id=1zoWS9DvfNQaVeEIliMEeLwI2APQkd-u3";
			this.ModName.Visible = false;
			this.ModAuthor.Visible = false;
			openfolder.Visible = false;
			this.ModDate.Visible = false;
			this.ModDes.Visible = false;
			this.ModDownloads.Visible = false;
			this.ModPic.Visible = false;
			this.searchin.Text = "";
			this.mymods.Text = "My Mods";
			this.ItemList.Visible = true;
			this.mymods.Visible = true;
			this.download.Visible = true;
			this.back.Visible = true;
			this.searchin.Visible = true;
			this.refresh.Visible = true;
			this.searchl.Visible = true;
			this.welcome.Visible = false;
			this.credits.Visible = false;
			this.modder.Visible = false;
			this.downpatcher.Visible = false;
			this.gotomods.Visible = false;
			this.label1.Visible = false;
			this.checkBox1.Visible = false;
			this.XPcheck.Visible = false;
			this.downloadbar.Width = 240;
			this.downloadperc.Location = new Point(170, 527);
			refreshList(0);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00004228 File Offset: 0x00002428
		private void button1_Click(object sender, EventArgs e)
		{
			download.Enabled = false;
			this.mymods.Visible = true;
			if (this.mymods.Visible)
			{

				download.Enabled = false;
				download.Text = "Download";
				download.Enabled = true;
				welcometext.Visible = true;
				this.updatemods.Visible = false;
				openfolder.Visible = false;
				this.ModDes2.Visible = false;
				this.ModName.Visible = false;
				this.ModAuthor.Visible = false;
				this.ModDate.Visible = false;
				this.ModDes.Visible = false;
				this.ModDownloads.Visible = false;
				this.ModPic.Visible = false;
				this.searchl.Visible = false;
				this.searchin.Visible = false;
				this.refresh.Visible = false;
				this.ItemList.Visible = false;
				this.mymods.Visible = false;
				this.download.Visible = false;
				this.back.Visible = false;
				this.submod.Visible = false;
				this.submodl.Visible = false;
				this.submodl.Visible = false;
				this.submodl2.Visible = false;
				this.SubModDes.Visible = false;
				this.SubModl3.Visible = false;
				this.submoddragdrop.Visible = false;
				this.submodl4.Visible = false;
				this.submodb.Visible = false;
				this.modderl1.Visible = false;
				this.modderl2.Visible = false;
				this.adminpwd.Visible = false;
				this.submodd.Visible = false;
				this.modsubdok.Visible = false;
				this.welcome.Visible = true;
				this.credits.Visible = true;
				this.modder.Visible = true;
				this.downpatcher.Visible = true;
				this.gotomods.Visible = true;
				this.label1.Visible = true;
				this.checkBox1.Visible = true;
				this.XPcheck.Visible = true;
				this.downloadbar.Width = 633;
				this.downloadperc.Location = new Point(559, 527);
				return;
			}
			this.mymods.Visible = true;
			this.submodl.Visible = false;
			this.refreshList(0);
		}

		private bool ml = false;
		// Token: 0x0600002E RID: 46 RVA: 0x00004460 File Offset: 0x00002660
		private void downpatcher_Click(object sender, EventArgs e)
		{
			if(ml)
			{
				try
				{
					Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheLongDrive\\Mods\\temp\\patcher\\TLDPatcher.exe");
					return;
				}
				catch
				{

				}
				
			}

			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TheLongDrive\\Mods");

			try
			{
				Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheLongDrive\\Mods\\temp", true);
			}
			catch(Exception)
			{
				MessageBox.Show("Do not worry about this. Specially if you install this the first time, everything is alright :thumbsup:", "Greetings from Workshop", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			
			this.downloadbar.Visible = true;
			this.downloadperc.Visible = true;
			this.downloadtext.Visible = true;
			string str = this.webClient.DownloadString("http://tldworkshop.hopto.org/mods/patchver.txt");
			this.downloadtext.Text = "Downloading: TLDPatcher " + str;
			this.downloadperc.Text = "0%";
			this.downloadbar.Value = 0;
			this.download.Enabled = false;
			this.mymods.Enabled = false;
			this.downpatcher.Enabled = false;
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			Uri addresss = new Uri("http://tldworkshop.hopto.org/mods/TLDPatcherNEW.zip");
			if (File.Exists(text + "/temp/TLDPatcherNEW.zip"))
			{
				File.Delete(text + "/temp/TLDPatcherNEW.zip");
			}
			if (Directory.Exists(text + "/temp/patcher/"))
			{
				Directory.Delete(text + "/temp/patcher/", true);
			}
			if (!Directory.Exists(text + "/temp/"))
			{
				Directory.CreateDirectory(text + "/temp/");
			}

			this.web.DownloadFileAsync(addresss, text + "/temp/TLDPatcherNEW.zip");
			this.web.DownloadProgressChanged += this.webClient_DownloadProgressChanged;
			this.web.DownloadFileCompleted += this.webClient_DownloadFileCompletedPatch;
			this.sw.Start();
			ml = true;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000045DB File Offset: 0x000027DB
		private void credits_DoubleClick(object sender, EventArgs e)
		{
			this.credits.Text = "Credits: \n_RainBowShip_ \nrUWUden \nKolbeanLP \nSpecial thank to: \nsplendoo";
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000045F0 File Offset: 0x000027F0
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBox1.Checked)
			{
				try
				{
					File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheLongDrive\\Dark.dat");
				}
				catch
				{

				}
				this.ModDes2.BackColor = Color.Gray;
				this.BackColor = SystemColors.ControlDarkDark;
				this.ItemList.BackColor = SystemColors.ControlDark;
				this.gotomods.BackColor = Color.Gray;
				this.downpatcher.BackColor = Color.Gray;
				this.modder.BackColor = Color.Gray;
				this.back.BackColor = Color.Gray;
				this.mymods.BackColor = Color.Gray;
				this.download.BackColor = Color.Gray;
				this.ModThumbnail.BackColor = Color.DarkGray;
				this.itemPanel.BackColor = Color.Gray;
				this.SubModDes.BackColor = Color.Gray;
				this.submoddragdrop.BackColor = Color.Gray;
				this.searchin.BackColor = Color.Gray;
				this.refreshList(0);
				return;
			}
			try
			{
				File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheLongDrive\\Dark.dat");
			}
			catch
			{

			}
			this.ModDes2.BackColor = Color.White;
			this.searchin.BackColor = Color.GhostWhite;
			this.BackColor = SystemColors.Control;
			this.ItemList.BackColor = SystemColors.Control;
			this.gotomods.BackColor = SystemColors.Control;
			this.downpatcher.BackColor = SystemColors.Control;
			this.modder.BackColor = SystemColors.Control;
			this.back.BackColor = SystemColors.Control;
			this.mymods.BackColor = SystemColors.Control;
			this.download.BackColor = SystemColors.Control;
			this.ModThumbnail.BackColor = Color.Transparent;
			this.itemPanel.BackColor = Color.GhostWhite;
			this.SubModDes.BackColor = Color.GhostWhite;
			this.submoddragdrop.BackColor = Color.GhostWhite;
			this.refreshList(0);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000047B4 File Offset: 0x000029B4
		private void submod_Click(object sender, EventArgs e)
		{
			if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDModSubmission"))
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDModSubmission");
			}
			if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDWorkshopModPreset"))
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDWorkshopModPreset");
			}
			if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDWorkshopModPreset\\ModInfo.txt"))
			{
				File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDWorkshopModPreset\\ModInfo.txt");
			}
			if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDModSubmission"))
			{
				Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDModSubmission", true);
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDModSubmission");
				File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDWorkshopModPreset\\ModInfo.txt", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDModSubmission\\ModInfo.txt");
			}
			else
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDModSubmission");
				File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDWorkshopModPreset\\ModInfo.txt", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDModSubmission\\ModInfo.txt");
			}
			this.modderl1.Visible = false;
			this.ItemList.Visible = false;
			this.mymods.Visible = false;
			this.download.Visible = false;
			this.submod.Visible = false;
			this.modderl2.Visible = false;
			this.adminpwd.Visible = false;
			this.submodd.Visible = false;
			this.modsubdok.Visible = false;
			this.submodb.Visible = true;
			this.submodl4.Visible = true;
			this.submodl.Visible = true;
			this.submodl2.Visible = true;
			this.SubModDes.Visible = true;
			this.SubModl3.Visible = true;
			this.submoddragdrop.Visible = true;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x0000264D File Offset: 0x0000084D
		private void SubModl3_DragDrop(object sender, DragEventArgs e)
		{
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000049B0 File Offset: 0x00002BB0
		private void submoddragdrop_DragDrop(object sender, DragEventArgs e)
		{
			foreach (string text in (string[])e.Data.GetData(DataFormats.FileDrop, false))
			{
				if (File.Exists(text))
				{
					string fileName = Path.GetFileName(text);
					File.Copy(text, Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDModSubmission\\" + fileName);
					this.submodl4.Text = "File: " + fileName;
					this.filecheck = text;
				}
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00004A29 File Offset: 0x00002C29
		private void submoddragdrop_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.All;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00004A38 File Offset: 0x00002C38
		private void submodb_Click(object sender, EventArgs e)
		{
			if (File.Exists(this.filecheck))
			{
				if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDModSubmission\\ModInfo.txt"))
				{
					MessageBox.Show("This process can take up to 1 or 2 Minutes (Depending on your Internet connection), after clicking OK on this MessageBox the Mod will be Uploaded!", "Workshop", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					using (StreamWriter streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDModSubmission\\ModInfo.txt"))
					{
						streamWriter.WriteLine(this.SubModDes.Text);
					}
					this.filecheck = null;
					this.submodl4.Text = "File:";
					this.SubModDes.Text = "Name: \nYour Username(Discord): \nVersion of Mod(Optional): \nShort description:";
					int num = 11;
					StringBuilder stringBuilder = new StringBuilder();
					Random random = new Random();
					for (int i = 0; i < num; i++)
					{
						double num2 = random.NextDouble();
						char value = Convert.ToChar(Convert.ToInt32(Math.Floor(25.0 * num2)) + 65);
						stringBuilder.Append(value);
					}
					string str = stringBuilder.ToString();
					if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions"))
					{
						Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions", true);
					}
					using (WebClient webClient = new WebClient())
					{
						webClient.Credentials = new NetworkCredential("kolben1000", "Kolben1000");
						webClient.DownloadFile("ftp://files.000webhost.com/htdocs/Submissions/Submissions.zip", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions.zip");
					}
					System.IO.Compression.ZipFile.CreateFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TLDModSubmission", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submission.zip");
					if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions"))
					{
						Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions");
					}
					System.IO.Compression.ZipFile.ExtractToDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions.zip", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions");
					File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submission.zip", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions\\Submission" + str + ".zip");
					if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions.zip"))
					{
						File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions.zip");
					}
					System.IO.Compression.ZipFile.CreateFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions.zip");
					using (WebClient webClient2 = new WebClient())
					{
						webClient2.Credentials = new NetworkCredential("kolben1000", "Kolben1000");
						webClient2.UploadFile("ftp://files.000webhost.com/htdocs/Submissions/Submissions.zip", "STOR", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submissions.zip");
					}
					MessageBox.Show("Thanks for you Mod submission, we will check it out soon!", "Workshop", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\Submission.zip");
					this.mymods.Visible = true;
					if (this.mymods.Visible)
					{
						this.ItemList.Visible = false;
						this.mymods.Visible = false;
						this.download.Visible = false;
						this.back.Visible = false;
						this.submod.Visible = false;
						this.submodl.Visible = false;
						this.submodl.Visible = false;
						this.submodl2.Visible = false;
						this.SubModDes.Visible = false;
						this.SubModl3.Visible = false;
						this.submoddragdrop.Visible = false;
						this.submodl4.Visible = false;
						this.submodb.Visible = false;
						this.modsubdok.Visible = false;
						this.welcome.Visible = true;
						this.credits.Visible = true;
						this.modder.Visible = true;
						this.downpatcher.Visible = true;
						this.gotomods.Visible = true;
						this.label1.Visible = true;
						this.checkBox1.Visible = true;
						this.XPcheck.Visible = true;
						this.downloadbar.Width = 633;
						this.downloadperc.Location = new Point(559, 527);
						return;
					}
					this.mymods.Visible = true;
					this.submodl.Visible = false;
					this.refreshList(0);
					return;
				}
				else
				{
					MessageBox.Show("Please make sure that you drop your Mod file in that box before submitting your Mod", "Workshop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00004EC0 File Offset: 0x000030C0
		private void modder_Click(object sender, EventArgs e)
		{
			this.welcome.Visible = false;
			this.credits.Visible = false;
			this.modder.Visible = false;
			this.downpatcher.Visible = false;
			this.gotomods.Visible = false;
			this.label1.Visible = false;
			this.checkBox1.Visible = false;
			this.XPcheck.Visible = false;
			this.modsubdok.Visible = true;
			this.submodd.Visible = true;
			this.adminpwd.Visible = true;
			this.modderl2.Visible = true;
			this.back.Visible = true;
			this.submod.Visible = true;
			this.modderl1.Visible = true;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00004F84 File Offset: 0x00003184
		private void modsubdok_Click(object sender, EventArgs e)
		{
			if (this.adminpwd.Text == Form1.pwd)
			{
				this.submodd.Enabled = true;
				return;
			}
			MessageBox.Show("Wrong Password!", "Workshop", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			this.submodd.Enabled = false;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00004FD4 File Offset: 0x000031D4
		private void submodd_Click(object sender, EventArgs e)
		{
			using (WebClient webClient = new WebClient())
			{
				webClient.Credentials = new NetworkCredential("kolben1000", "Kolben1000");
				webClient.DownloadFile("ftp://files.000webhost.com/htdocs/Submissions/Submissions.zip", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Submission.zip");
			}
			if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TheLongDrive\\Submissions.zip"))
			{
				Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TheLongDrive\\Submissions");
				System.IO.Compression.ZipFile.CreateFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TheLongDrive\\Submissions", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TheLongDrive\\Submissions.zip");
			}
			using (WebClient webClient2 = new WebClient())
			{
				webClient2.Credentials = new NetworkCredential("kolben1000", "Kolben1000");
				webClient2.UploadFile("ftp://files.000webhost.com/htdocs/Submissions/Submissions.zip", Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\TheLongDrive\\Submissions.zip");
			}
			MessageBox.Show("The file with the Mods should have appeared on your Desktop!", "Workshop - Admin Mode", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000050E8 File Offset: 0x000032E8
		private void searchin_TextChanged(object sender, EventArgs e)
		{
			if (this.searchin.Text == "")
			{
				using (List<Form1.ModListing>.Enumerator enumerator = Form1.ModListings.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Form1.ModListing modListing = enumerator.Current;
						modListing.MainControl.Visible = true;
					}
					return;
				}
			}
			foreach (Form1.ModListing modListing2 in Form1.ModListings)
			{
				if (modListing2.ItemName.Text.IndexOf(this.searchin.Text, StringComparison.OrdinalIgnoreCase) >= 0 || modListing2.ItemDescription.Text.IndexOf(this.searchin.Text, StringComparison.OrdinalIgnoreCase) >= 0 || modListing2.ItemAuthor.Text.IndexOf(this.searchin.Text, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					modListing2.MainControl.Visible = true;
				}
				else
				{
					modListing2.Select(false);
					modListing2.MainControl.Visible = false;
				}
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00005218 File Offset: 0x00003418
		private void refresh_Click(object sender, EventArgs e)
		{
			if (this.mymods.Text == "Back")
			{
				this.refreshList(1);
				return;
			}
			this.refreshList(0);
			this.searchin.Text = "";
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00005250 File Offset: 0x00003450
		private void updatemods_Click(object sender, EventArgs e)
		{
			try
			{
				this.loadingmods.Visible = true;
				foreach (Form1.ModListing modListing in Form1.ModListings)
				{
					modListing.Select(true);
					while (!this.modupdated)
					{
						try
						{
							this.Download();
						}
						catch
						{
						}
					}
					modListing.Select(false);
					this.modupdated = false;
				}
				this.loadingmods.Visible = false;
			}
			catch
			{
				
			}
			
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000052D4 File Offset: 0x000034D4
		private void Download()
		{
			int num = 2;
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TheLongDrive\\Mods");
			if (this.downloadbar.Value == 100 || num > 0)
			{
				File.Delete(text + "\\" + Form1.selectedMod.ItemName.Text + ".dll");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				if (Form1.selectedMod.ItemDetails.Link.Contains(".dll"))
				{
					Uri address = new Uri(Form1.selectedMod.ItemDetails.Link);
					if (File.Exists(text + "/" + Form1.selectedMod.ItemName.Text + ".dll"))
					{
						File.Delete(text + "/" + Form1.selectedMod.ItemName.Text + ".dll");
					}
					this.webClient.DownloadFileAsync(address, text + "/" + Form1.selectedMod.ItemName.Text + ".dll");
					this.webClient.DownloadProgressChanged += this.webClient_DownloadProgressChanged;
					this.webClient.DownloadFileCompleted += this.webClient_DownloadFileCompleted;
					this.sw.Start();
					this.modupdated = true;
				}
				else if (Form1.selectedMod.ItemDetails.Link.Contains(".zip"))
				{
					Uri address2 = new Uri(Form1.selectedMod.ItemDetails.Link);
					if (File.Exists(text + "/" + Form1.selectedMod.ItemName.Text + ".dll"))
					{
						File.Delete(text + "/" + Form1.selectedMod.ItemName.Text + ".dll");
					}
					if (!Directory.Exists(text + "/temp/"))
					{
						Directory.CreateDirectory(text + "/temp/");
					}
					this.webClient.DownloadFileAsync(address2, text + "/temp/" + Form1.selectedMod.ItemName.Text + ".zip");
					this.webClient.DownloadProgressChanged += this.webClient_DownloadProgressChanged;
					this.webClient.DownloadFileCompleted += this.webClient_DownloadFileCompletedZip;
					this.sw.Start();
					this.modupdated = true;
				}
				this.downloadperc.Text = "Internal Server Error!";
				this.download.Enabled = true;
				this.mymods.Enabled = true;
			}
		}

		// Token: 0x04000006 RID: 6
		public static string pwd = "RainbeanLP345";

		// Token: 0x04000007 RID: 7
		public string filecheck;

		// Token: 0x04000008 RID: 8
		public static Form1 refrence;

		// Token: 0x04000009 RID: 9
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x0400000A RID: 10
		public const int HT_CAPTION = 2;

		// Token: 0x0400000B RID: 11
		public float nowversion = 1.1f;

		// Token: 0x0400000C RID: 12
		private Rectangle resizeTemp;

		// Token: 0x0400000D RID: 13
		public static List<Form1.ModListing> ModListings = new List<Form1.ModListing>();

		// Token: 0x0400000E RID: 14
		public static Form1.ModListing selectedMod;

		// Token: 0x0400000F RID: 15
		private WebClient webClient = new WebClient();

		private WebClient web = new WebClient();

		// Token: 0x04000010 RID: 16
		private Stopwatch sw = new Stopwatch();

		// Token: 0x04000011 RID: 17
		public bool modupdated;

		// Token: 0x0200000A RID: 10
		public class ModListing
		{
			// Token: 0x0600004B RID: 75 RVA: 0x000086DC File Offset: 0x000068DC
			public ModListing(Form1.Mod modData)
			{
				this.ItemDetails = modData;
				this.MainControl = ControlFactory.CloneCtrl(Form1.refrence.itemPanel);
				Form1.refrence.Controls.Add(this.MainControl);
				this.MainControl.Show();
				this.MainControl.Click += Form1.refrence.Select_Listing;
				foreach (object obj in Form1.refrence.itemPanel.Controls)
				{
					Control control = (Control)obj;
					Control control2 = ControlFactory.CloneCtrl(control);
					this.MainControl.Controls.Add(control2);
					control2.Show();
					control2.Click += Form1.refrence.Select_Listing;
					string text = control.Name.ToLower();
					if (text != null)
					{
						if (!(text == "title"))
						{
							if (!(text == "versiontext"))
							{
								if (!(text == "authtext"))
								{
									if (!(text == "datetext"))
									{
										if (!(text == "descriptiontext"))
										{
											if (text == "modthumbnail")
											{
												this.ItemImage = (PictureBox)control2;
											}
										}
										else
										{
											this.ItemDescription = (Label)control2;
										}
									}
									else
									{
										this.ItemDate = (Label)control2;
									}
								}
								else
								{
									this.ItemAuthor = (Label)control2;
								}
							}
							else
							{
								this.ItemVersion = (Label)control2;
							}
						}
						else
						{
							this.ItemName = (Label)control2;
						}
					}
				}
				Form1.refrence.itemPanel.BackColor = Color.Gray;
				this.MainControl.Parent = Form1.refrence.ItemList;
				Form1.refrence.ItemList.Update();
				this.UpdateDetails();
			}

			// Token: 0x0600004C RID: 76 RVA: 0x000088CC File Offset: 0x00006ACC
			public void UpdateDetails()
			{
				if (Form1.refrence.checkBox1.Checked)
				{
					Form1.refrence.itemPanel.BackColor = Color.Gray;
				}
				else
				{
					Form1.refrence.itemPanel.BackColor = Color.GhostWhite;
				}
				this.ItemName.Text = this.ItemDetails.Name;
				this.ItemImage.Tag = this.ItemDetails.PictureLink;
				this.ItemAuthor.Text = this.ItemDetails.Author;
				this.ItemVersion.Text = this.ItemDetails.Version;
				this.ItemDate.Text = this.ItemDetails.Date;
				this.ItemDescription.Text = this.ItemDetails.Description;
				new Thread(delegate()
				{
					this.ItemImage.Image = Form1.DownloadImage(this.ItemDetails.PictureLink);
				}).Start();
			}

			// Token: 0x0600004D RID: 77 RVA: 0x000089B0 File Offset: 0x00006BB0
			public void Select(bool selected)
			{
				if (Form1.refrence.checkBox1.Checked)
				{
					this.MainControl.BackColor = (selected ? Color.LightGray : Color.Gray);
				}
				else
				{
					this.MainControl.BackColor = (selected ? Color.CornflowerBlue : Color.GhostWhite);
				}
				if (selected)
				{
					Form1.selectedMod = this;
				}
			}

			// Token: 0x04000051 RID: 81
			public Control MainControl;

			// Token: 0x04000052 RID: 82
			public PictureBox ItemImage;

			// Token: 0x04000053 RID: 83
			public Label ItemName;

			// Token: 0x04000054 RID: 84
			public Label ItemAuthor;

			// Token: 0x04000055 RID: 85
			public Label ItemVersion;

			// Token: 0x04000056 RID: 86
			public Label ItemDate;

			// Token: 0x04000057 RID: 87
			public Label ItemDescription;

			// Token: 0x04000058 RID: 88
			public Form1.Mod ItemDetails;
		}

		// Token: 0x0200000B RID: 11
		[DataContract]
		public class Mod
		{
			// Token: 0x17000009 RID: 9
			// (get) Token: 0x0600004F RID: 79 RVA: 0x00008A2A File Offset: 0x00006C2A
			// (set) Token: 0x06000050 RID: 80 RVA: 0x00008A32 File Offset: 0x00006C32
			[DataMember(Name = "Name")]
			public string Name { get; set; }

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000051 RID: 81 RVA: 0x00008A3B File Offset: 0x00006C3B
			// (set) Token: 0x06000052 RID: 82 RVA: 0x00008A43 File Offset: 0x00006C43
			[DataMember(Name = "Version")]
			public string Version { get; set; }

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000053 RID: 83 RVA: 0x00008A4C File Offset: 0x00006C4C
			// (set) Token: 0x06000054 RID: 84 RVA: 0x00008A54 File Offset: 0x00006C54
			[DataMember(Name = "Author")]
			public string Author { get; set; }

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x06000055 RID: 85 RVA: 0x00008A5D File Offset: 0x00006C5D
			// (set) Token: 0x06000056 RID: 86 RVA: 0x00008A65 File Offset: 0x00006C65
			[DataMember(Name = "Description")]
			public string Description { get; set; }

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x06000057 RID: 87 RVA: 0x00008A6E File Offset: 0x00006C6E
			// (set) Token: 0x06000058 RID: 88 RVA: 0x00008A76 File Offset: 0x00006C76
			[DataMember(Name = "Date")]
			public string Date { get; set; }

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000059 RID: 89 RVA: 0x00008A7F File Offset: 0x00006C7F
			// (set) Token: 0x0600005A RID: 90 RVA: 0x00008A87 File Offset: 0x00006C87
			[DataMember(Name = "Link")]
			public string Link { get; set; }

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x0600005B RID: 91 RVA: 0x00008A90 File Offset: 0x00006C90
			// (set) Token: 0x0600005C RID: 92 RVA: 0x00008A98 File Offset: 0x00006C98
			[DataMember(Name = "PictureLink")]
			public string PictureLink { get; set; }
		}

		// Token: 0x0200000C RID: 12
		[DataContract]
		public class CheckVer
		{
			// Token: 0x17000010 RID: 16
			// (get) Token: 0x0600005E RID: 94 RVA: 0x00008AA1 File Offset: 0x00006CA1
			// (set) Token: 0x0600005F RID: 95 RVA: 0x00008AA9 File Offset: 0x00006CA9
			[DataMember(Name = "VersionWorkShop")]
			public string newversion { get; set; }

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x06000060 RID: 96 RVA: 0x00008AB2 File Offset: 0x00006CB2
			// (set) Token: 0x06000061 RID: 97 RVA: 0x00008ABA File Offset: 0x00006CBA
			[DataMember(Name = "VersionPatcher")]
			public string VersionPatcher { get; set; }
		}

		// Token: 0x0200000D RID: 13
		[DataContract]
		public class JSONN
		{
			// Token: 0x17000012 RID: 18
			// (get) Token: 0x06000063 RID: 99 RVA: 0x00008AC3 File Offset: 0x00006CC3
			// (set) Token: 0x06000064 RID: 100 RVA: 0x00008ACB File Offset: 0x00006CCB
			[DataMember(Name = "Mods")]
			public Form1.Mod[] ModList { get; set; }
		}

		private void openfolder_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start(@Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheLongDrive\\Mods");
			}
			catch
			{
				MessageBox.Show("Your Mods Folder doesnt exist WTF, do you have ModLoader installed?? Anyway go install ModLoader now. I can wait here :) \n Hmm well I go to bed now good night..", "TLDWorkshop", MessageBoxButtons.OK, MessageBoxIcon.Question);
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}
