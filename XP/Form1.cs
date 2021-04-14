using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;   
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Ionic.Zip;
using Newtonsoft.Json;
using System.Threading;
using Ionic.Zlib;
using System.Linq;
using System.Runtime;
using Newtonsoft.Json.Serialization;
using Chilkat;
using System.Windows.Forms.VisualStyles;
using System.Net.Configuration;

namespace XP
{
    public partial class Form1 : Form
    {
        public static string pwd = "RainbeanLP345";
        public string filecheck;
        public static Form1 refrence;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public float nowversion = 1.1f;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        //------------------------------WINDOWS XP STYLE WINDOW STUFF HAPPENS HERE
        public Form1()
        {
            InitializeComponent();
            submodl.Visible = false;
            this.MaximumSize = new Size(Screen.FromControl(this).WorkingArea.Width, Screen.FromControl(this).WorkingArea.Height);
            refrence = this;
            submodl.Visible = false;
            submodl2.Visible = false;
            SubModDes.Visible = false;

        }

        private void Move_Window(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks > 1)
                    Maximise_Window_Toggle(sender, e);

                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Maximise_Window_Toggle(object sender, EventArgs e)
        {

            this.WindowState = (this.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;

            /* if (WindowState == FormWindowState.Maximized)
             {
                 Rectangle wa = Screen.FromControl(this).WorkingArea;
                 this.MaximumSize = new Size(wa.Width, wa.Height);
                 this.WindowState = FormWindowState.Maximized;
             }*/
        }

        private void Minimise_Window(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Control[] elements = new Control[] { TitleBarLeft, TitleBarRight, ResizeBarBottom, ResizeBarLeft, ResizeBarRight };
            bool enable = !(this.WindowState == FormWindowState.Maximized);
            foreach (Control element in elements)
                element.Visible = enable;
        }

        private void Close_Window(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
            Application.Exit();
        }
        private Rectangle resizeTemp;

        private void Resize_Window(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                resizeTemp = Rectangle.Empty;
                return;
            }

            try
            {
                if (resizeTemp.IsEmpty)
                {
                    Cursor.Current = areNumbersClose(ClientRectangle.Bottom, e.Y, 10) ? Cursors.SizeNS : Cursor.Current;
                    Cursor.Current = areNumbersClose(ClientRectangle.Right, e.X, 10) ? (Cursor.Current == Cursors.SizeNS) ? Cursors.SizeNWSE : Cursors.SizeWE : Cursor.Current;
                }
                else
                {
                    Cursor.Current = resizeTemp.Height != 0 ? Cursors.SizeNS : Cursor.Current;
                    Cursor.Current = resizeTemp.Width != 0 ? (Cursor.Current == Cursors.SizeNS) ? Cursors.SizeNWSE : Cursors.SizeWE : Cursor.Current;

                }
            }
            catch { Cursor.Current = Cursors.Default; }


            if (e.Button == MouseButtons.Left)
            {
                if (!resizeTemp.IsEmpty)
                {
                    this.ClientSize = new Size((resizeTemp.Width == 0) ? this.ClientSize.Width : e.X, (resizeTemp.Height == 0) ? this.ClientSize.Height : e.Y);
                }
                else if (e.Clicks != 0)
                {
                    if (areNumbersClose(ClientRectangle.Bottom, e.Y, 10))
                        resizeTemp.Height = 1;
                    if (areNumbersClose(ClientRectangle.Right, e.X, 10))
                        resizeTemp.Width = 1;
                }
            }
            else
            {
                resizeTemp = Rectangle.Empty;
            }
        }

        private void Leave_Window(object sender, EventArgs e)
        {
            Resize_Window(((object)this), new MouseEventArgs(Control.MouseButtons, 0, PointToClient(Cursor.Position).X, PointToClient(Cursor.Position).Y, 0));
        }

        private void Enter_Window(object sender, EventArgs e)
        {
            resizeTemp = Rectangle.Empty;
        }

        static bool areNumbersClose(int num1, int num2, int distanceThreshold)
        {
            return Math.Abs(num1 - num2) <= distanceThreshold;
        }








        //Image downloading stuff , also works for local files and GIF
        static Image DownloadImage(string fromUrl)
        {
            try
            {
                if (fromUrl.ToLower().StartsWith("http") || !fromUrl.ToLower().EndsWith("gif"))
                {
                    using (System.Net.WebClient webClient = new System.Net.WebClient())
                    {
                        using (System.IO.Stream stream = webClient.OpenRead(fromUrl))
                        {
                            return Image.FromStream(stream);
                        }
                    }
                }
                else
                {

                    using (System.IO.FileStream fs = new System.IO.FileStream(fromUrl, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();


                        byte[] buffer = new byte[16 * 1024]; // Fairly arbitrary size
                        int bytesRead;
                        while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                        }

                        ms.Position = 0;
                        return Image.FromStream(ms);
                    }

                }
            }
            catch { return null; }
        }










        //------------------------------MOD LISTING STUFF HAPPENS BELOW


        public class ModListing
        {
            public Control MainControl;// { get;}
            public PictureBox ItemImage;//{ get;}
            public Label ItemName;//{ get;}
            public Label ItemAuthor;//{ get;}
            public Label ItemVersion;//{ get;}
            public Label ItemDate;//{ get;}
            public Label ItemDescription;//{ get;}
            public Mod ItemDetails;//{ get;set; }

            public ModListing(Mod modData)
            {
                ItemDetails = modData;

                
                MainControl = ControlFactory.CloneCtrl(Form1.refrence.itemPanel);

                Form1.refrence.Controls.Add(MainControl);
                MainControl.Show();
                MainControl.Click += new System.EventHandler(Form1.refrence.Select_Listing);

                foreach (Control subControl in Form1.refrence.itemPanel.Controls)
                {
                    Control newSubControl = ControlFactory.CloneCtrl(subControl);
                    MainControl.Controls.Add(newSubControl);
                    newSubControl.Show();
                    newSubControl.Click += new System.EventHandler(Form1.refrence.Select_Listing);

                    switch (subControl.Name.ToLower())
                    {
                        case "title":
                            ItemName = (Label)newSubControl; break;
                        case "versiontext":
                            ItemVersion = (Label)newSubControl; break;
                        case "authtext":
                            ItemAuthor = (Label)newSubControl; break;
                        case "datetext":
                            ItemDate = (Label)newSubControl; break;
                        case "descriptiontext":
                            ItemDescription = (Label)newSubControl; break;
                        case "modthumbnail":
                            ItemImage = (PictureBox)newSubControl; break;
                    }

                }
                Form1.refrence.itemPanel.BackColor = Color.Gray;
                MainControl.Parent = Form1.refrence.ItemList;
                Form1.refrence.ItemList.Update();
                UpdateDetails();
            }

            public void UpdateDetails()
            {
                if (Form1.refrence.checkBox1.Checked)

                    Form1.refrence.itemPanel.BackColor = Color.Gray;
                else
                    Form1.refrence.itemPanel.BackColor = Color.GhostWhite;
                ItemName.Text = ItemDetails.Name;
                ItemImage.Tag = ItemDetails.PictureLink;
                ItemAuthor.Text = ItemDetails.Author;
                ItemVersion.Text = ItemDetails.Version;
                ItemDate.Text = ItemDetails.Date;

                ItemDescription.Text = ItemDetails.Description;
                //Add those ^ to the mod class for the json pls


                //Image loading stuff
                System.Threading.Thread imageDownloadThread = new System.Threading.Thread((System.Threading.ThreadStart)(delegate { ItemImage.Image = DownloadImage(ItemDetails.PictureLink); }));
                imageDownloadThread.Start();
                //we load the image on the other thread or the whole program hangs while downloading the mod images
            }

            public void Select(bool selected)
            {
                if (Form1.refrence.checkBox1.Checked)
                    MainControl.BackColor = (selected) ? Color.LightGray : Color.Gray;
                else
                    MainControl.BackColor = (selected) ? Color.CornflowerBlue : Color.GhostWhite;
                if (selected)
                    selectedMod = this;
            }
        }
        [DataContract]
        public class Mod
        {
            [DataMember(Name = "Name")]
            public string Name { get; set; }
            [DataMember(Name = "Version")]
            public string Version { get; set; }

            [DataMember(Name = "Author")]
            public string Author { get; set; }
            [DataMember(Name = "Description")]
            public string Description { get; set; }
            [DataMember(Name = "Date")]
            public string Date { get; set; }
            [DataMember(Name = "Link")]
            public string Link { get; set; }
            [DataMember(Name = "PictureLink")]
            public string PictureLink { get; set; }
        }
        [DataContract]
        public class CheckVer
        {
            [DataMember(Name = "VersionWorkShop")]
            public string newversion { get; set; }
            [DataMember(Name = "VersionPatcher")]
            public string VersionPatcher { get; set; }


        }

        private void Select_Listing(object listingSender, EventArgs args)
        {
            //   if (listingSender.GetType() != typeof(Control))
            //      return;
            if (downloadperc.Text == "Complete!")
            {
                downloadbar.Visible = false;
                downloadperc.Visible = false;
                downloadtext.Visible = false;
            }
            foreach (ModListing mod in ModListings)
                if (mod.MainControl == ((Control)listingSender) || mod.MainControl == ((Control)listingSender).Parent)
                    mod.Select(true);
                else
                    mod.Select(false);

        }
        [DataContract]
        public class JSONN
        {
            [DataMember(Name = "Mods")]
            public Mod[] ModList { get; set; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this is just example test, populating with a bunch of made up mods, delete this 
            WebClient web = new WebClient();
            DataContractJsonSerializer json2 = new DataContractJsonSerializer(typeof(CheckVer));
            CheckVer check = (CheckVer)json2.ReadObject(new System.IO.MemoryStream(web.DownloadData("http://tldworkshop.hopto.org/check.json")));

            //            CheckVer restoredPerson = JsonConvert.DeserializeObject<CheckVer>(new MemoryStream(web.DownloadData("http://tldworkshop.hopto.org/mo.json")));
            if (float.Parse(check.newversion) > nowversion)
            {
                MessageBox.Show("New version of workshop is now available! \nDownload from discord.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }


            DataContractJsonSerializer json1 = new DataContractJsonSerializer(typeof(JSONN));
            Debug.WriteLine(json1);
            JSONN jsonn = (JSONN)json1.ReadObject(new System.IO.MemoryStream(web.DownloadData("http://tldworkshop.hopto.org/modlist_2.json")));

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
            //end of example

        }

        public static List<ModListing> ModListings = new List<ModListing>();

        public static ModListing selectedMod;
        System.Net.WebClient webClient = new System.Net.WebClient();
        Stopwatch sw = new Stopwatch();


        void webClient_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            try
            {
                //    if (labelX1.Text != (Convert.ToDouble(e.BytesReceived) / 1024 / sw.Elapsed.TotalSeconds).ToString("0"))
                //      labelX2.Text = (Convert.ToDouble(e.BytesReceived) / 1024 / sw.Elapsed.TotalSeconds).ToString("0.00") + " สม/๑";

                if (downloadbar.Value != e.ProgressPercentage)
                    downloadbar.Value = e.ProgressPercentage;

                if (downloadperc.Text != e.ProgressPercentage.ToString() + "%")
                    downloadperc.Text = e.ProgressPercentage.ToString() + "%";

                downloadperc.Text = (Convert.ToDouble(e.BytesReceived) / 1024 / sw.Elapsed.TotalSeconds).ToString("0.00") + " KB/c " + e.ProgressPercentage.ToString() + "%";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {

            downloadbar.Value = 100;
            downloadperc.Text = "Complete!";

            sw.Stop();

            download.Enabled = true;
            mymods.Enabled = true;



        }
        void webClient_DownloadFileCompletedZip(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"TheLongDrive\Mods");
            downloadbar.Value = 80;
            downloadperc.Text = "Unzipping...";

            sw.Stop();
            //     MessageBox.Show(this, "Download complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Ionic.Zip.ZipFile zipFile = new Ionic.Zip.ZipFile(path + "/" + "temp/" + selectedMod.ItemName.Text + ".zip");
            zipFile.ZipError += new EventHandler<Ionic.Zip.ZipErrorEventArgs>(zip_Error);
            zipFile.ExtractProgress += new EventHandler<ExtractProgressEventArgs>(zip_Progress);

            zipFile.ExtractAll(path, ExtractExistingFileAction.OverwriteSilently);
            download.Enabled = true;
            mymods.Enabled = true;
            downloadperc.Text = "Complete!";
            downloadbar.Value = 100;
        }

        void webClient_DownloadFileCompletedPatch(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"TheLongDrive\Mods");
            downloadbar.Value = 80;
            downloadperc.Text = "Unzipping...";

            sw.Stop();
            //     MessageBox.Show(this, "Download complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Ionic.Zip.ZipFile zipFile = new Ionic.Zip.ZipFile(path + "/" + "temp/TLDPatcherNEW.zip");
            zipFile.ZipError += new EventHandler<Ionic.Zip.ZipErrorEventArgs>(zip_Error);
            zipFile.ExtractProgress += new EventHandler<ExtractProgressEventArgs>(zip_Progress);
            try
            {
                zipFile.ExtractAll(path + "/temp/", ExtractExistingFileAction.OverwriteSilently);
                download.Enabled = true;
                mymods.Enabled = true;
                downpatcher.Enabled = true;
                downloadperc.Text = "Complete!";
                downloadbar.Value = 100;
                zipFile.Dispose();
                webClient.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Close TLDPatcher!");
            }
            System.IO.File.Copy(path + "/temp/patcher/TLDLoader.dll", Application.StartupPath + "/TLDLoader.dll", true);
            Process.Start(path + "/temp/patcher/TLDPatcher.exe", "\"" + path + "/temp/patcher/" + "\"");
        }
        void zip_Error(object sender, ZipErrorEventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"TheLongDrive\Mods");
            downloadbar.Value = 80;

            downloadperc.Text = "Unzipping Failed!";
        }
        void zip_Progress(object sender, ExtractProgressEventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"TheLongDrive\Mods");


            downloadperc.Text = "Unzipping... " + e.EntriesTotal + "B/" + e.TotalBytesToTransfer + "B";
        }

        private void download_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"TheLongDrive\Mods");
            if (selectedMod != null)
            {
                if (download.Text == "Download")
                {
                    downloadbar.Visible = true;
                    downloadperc.Visible = true;
                    downloadtext.Visible = true;
                    downloadtext.Text = "Downloading: " + selectedMod.ItemName.Text;
                    downloadperc.Text = "0%";
                    downloadbar.Value = 0;
                    download.Enabled = false;
                    mymods.Enabled = false;

                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    if (selectedMod.ItemDetails.Link.Contains(".dll"))
                    {

                        Uri uri = new Uri(selectedMod.ItemDetails.Link);
                        if (System.IO.File.Exists(path + "/" + selectedMod.ItemName.Text + ".dll"))
                            System.IO.File.Delete(path + "/" + selectedMod.ItemName.Text + ".dll");
                        webClient.DownloadFileAsync(uri, path + "/" + selectedMod.ItemName.Text + ".dll");
                        webClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                        webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                        sw.Start();
                        return;

                    }
                    else if (selectedMod.ItemDetails.Link.Contains(".zip"))
                    {

                        Uri uri = new Uri(selectedMod.ItemDetails.Link);
                        if (System.IO.File.Exists(path + "/" + selectedMod.ItemName.Text + ".dll"))
                            System.IO.File.Delete(path + "/" + selectedMod.ItemName.Text + ".dll");
                        if (!Directory.Exists(path + "/" + "temp/"))
                            Directory.CreateDirectory(path + "/" + "temp/");
                        webClient.DownloadFileAsync(uri, path + "/" + "temp/" + selectedMod.ItemName.Text + ".zip");
                        webClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                        webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(webClient_DownloadFileCompletedZip);
                        sw.Start();
                        return;
                    }
                    downloadperc.Text = "Internal Server Error!";
                    download.Enabled = true;
                    mymods.Enabled = true;

                }
                else
                {
                    System.IO.File.Delete(path + "/" + selectedMod.ItemName.Text + ".dll");
                    selectedMod.MainControl.Controls.Clear();
                    refreshList(1);
                }



            }
        }
        public void refreshList(int mods)
        {
            if (mods == 0)
            {
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
                DataContractJsonSerializer json1 = new DataContractJsonSerializer(typeof(JSONN));
                WebClient web = new WebClient();
                JSONN jsonn = (JSONN)json1.ReadObject(new System.IO.MemoryStream(web.DownloadData("http://tldworkshop.hopto.org/modlist_2.json")));
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"TheLongDrive\Mods");
                ModListings.Clear();
                ItemList.Controls.Clear();
                download.Text = "Delete";
                mymods.Text = "Back";
                mymods.Visible = false;
                string[] h = new string[] { "https://cdn.discordapp.com/attachments/752578049064697906/753228626752831609/zefQXQ7XrXo.jpg", "https://cdn.discordapp.com/attachments/752578049064697906/753243489512194098/DCIM_2019-02-23-5285246.png", "https://cdn.discordapp.com/attachments/752578049064697906/753616272217866341/catjammercar_sqenu_is_rarted_v2.gif", "https://cdn.discordapp.com/attachments/752578049064697906/755897138956861572/unknown.png", "https://cdn.discordapp.com/attachments/752578049064697906/758121802643013643/2019112610435374.png", "https://cdn.discordapp.com/attachments/752578049064697906/758122531721969694/20190129_033224252.png", "https://cdn.discordapp.com/attachments/752578049064697906/758123152521166848/unknown.png", "https://cdn.discordapp.com/attachments/655083079324532759/760163314734071879/72327593_1673268889469772_6064536625596071936_n.png", "https://cdn.discordapp.com/attachments/752578049064697906/761441490282217483/Screenshot_2020-09-06-21-51-27.png", "https://cdn.discordapp.com/attachments/752578049064697906/761526785392246794/Screenshot_2020-09-06-22-00-19-1.png", "https://cdn.discordapp.com/attachments/701698502060671079/761639368376844308/image.jpg", "https://cdn.discordapp.com/attachments/701698502060671079/761639646392090644/image.jpg", "https://cdn.discordapp.com/attachments/701698502060671079/761639772799762472/image.jpg", "https://cdn.discordapp.com/attachments/701698502060671079/761639797151236106/image.jpg", "https://cdn.discordapp.com/attachments/701698502060671079/761640053695971348/image.jpg", "https://cdn.discordapp.com/attachments/701698502060671079/761639828935934003/image.jpg", "https://cdn.discordapp.com/attachments/701698502060671079/761639815031947344/image.jpg" };

                for (int x = 0; x < jsonn.ModList.Length; x++)
                {
                    if (System.IO.File.Exists(path + "/" + jsonn.ModList[x].Name + ".dll"))
                    {
                        Mod mod = new Mod() { Author = jsonn.ModList[x].Author, Link = jsonn.ModList[x].Link, Name = jsonn.ModList[x].Name, Date = jsonn.ModList[x].Date, Description = jsonn.ModList[x].Description, Version = jsonn.ModList[x].Version };


                        if (jsonn.ModList[x].PictureLink.Contains(".png"))
                            mod.PictureLink = jsonn.ModList[x].PictureLink;
                        else
                            mod.PictureLink = "http://tldworkshop.hopto.org/mods/pictures/notfound.png";
                        ModListings.Add(new ModListing(mod));
                    }
                }
                downloadbar.Visible = false;
                downloadperc.Visible = false;
                downloadtext.Visible = false;
                selectedMod = null;
            }
        }
        public void mymods_Click(object sender, EventArgs e)
        {
            searchin.Visible = false;
            searchl.Visible = false;
            if (mymods.Text == "My Mods")
            {
                refreshList(1);


            }
            else
            {
                refreshList(0);

            }

        }

        private void gotomods_Click(object sender, EventArgs e)
        {
            searchin.Text = "";
            refreshList(0);
            ItemList.Visible = true;
            mymods.Visible = true;
            download.Visible = true;
            back.Visible = true;
            searchin.Visible = true;
            searchl.Visible = true;
            welcome.Visible = false;
            credits.Visible = false;
            modder.Visible = false;
            downpatcher.Visible = false;
            gotomods.Visible = false;
            label1.Visible = false;
            checkBox1.Visible = false;
            XPcheck.Visible = false;
            
            downloadbar.Width = 384;
            downloadperc.Location = new Point(314, 527);


        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    mymods.Visible = true; //have to do that, else it would bug out...
            if (mymods.Visible)
            {
                searchl.Visible = false;
                searchin.Visible = false;
                ItemList.Visible = false;
                mymods.Visible = false;
                download.Visible = false;
                back.Visible = false;
                submod.Visible = false;
                submodl.Visible = false;
                submodl.Visible = false;
                submodl2.Visible = false;
                SubModDes.Visible = false;
                SubModl3.Visible = false;
                submoddragdrop.Visible = false;
                submodl4.Visible = false;
                submodb.Visible = false;
                modderl1.Visible = false;
                modderl2.Visible = false;
                adminpwd.Visible = false;
                submodd.Visible = false;
                modsubdok.Visible = false;


                welcome.Visible = true;
                credits.Visible = true;
                modder.Visible = true;
                downpatcher.Visible = true;
                gotomods.Visible = true;
                label1.Visible = true;
                checkBox1.Visible = true;
                XPcheck.Visible = true;
                downloadbar.Width = 633;
                downloadperc.Location = new Point(559, 527);

            }
            else
            {
                searchin.Text = "";
                searchin.Visible = true;
                searchl.Visible = true;
                mymods.Visible = true;
                submodl.Visible = false;
                refreshList(0);
            }

        }

        private void downpatcher_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"TheLongDrive\Mods");


            downloadbar.Visible = true;
            downloadperc.Visible = true;
            downloadtext.Visible = true;
            string ver = webClient.DownloadString("http://tldworkshop.hopto.org/mods/patchver.txt");
            downloadtext.Text = "Downloading: TLDPatcher " + ver;
            downloadperc.Text = "0%";
            downloadbar.Value = 0;
            download.Enabled = false;
            mymods.Enabled = false;
            downpatcher.Enabled = false;

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);


            Uri uri = new Uri("http://tldworkshop.hopto.org/mods/TLDPatcherNEW.zip");
            if (System.IO.File.Exists(path + "/temp/TLDPatcherNEW.zip"))
                System.IO.File.Delete(path + "/temp/TLDPatcherNEW.zip");
            if (Directory.Exists(path + "/temp/patcher/"))
                Directory.Delete(path + "/temp/patcher/", true);
            if (!Directory.Exists(path + "/" + "temp/"))
                Directory.CreateDirectory(path + "/" + "temp/");
            webClient.DownloadFileAsync(uri, path + "/" + "temp/TLDPatcherNEW.zip");
            webClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(webClient_DownloadFileCompletedPatch);
            sw.Start();
            return;





        }

        private void credits_DoubleClick(object sender, EventArgs e) // Easter Egg
        {
            credits.Text = "Credits: \n_RainBowShip_ \nrUWUden \nKolbeanLP \nSpecial thank to: \nsplendoo";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                this.ItemList.BackColor = SystemColors.ControlDark;
                this.gotomods.BackColor = System.Drawing.Color.Gray;
                this.downpatcher.BackColor = System.Drawing.Color.Gray;
                this.modder.BackColor = System.Drawing.Color.Gray;
                this.back.BackColor = Color.Gray;
                this.mymods.BackColor = Color.Gray;
                this.download.BackColor = Color.Gray;
                this.ModThumbnail.BackColor = Color.DarkGray;
                this.itemPanel.BackColor = Color.Gray;
                this.SubModDes.BackColor = Color.Gray;
                this.submoddragdrop.BackColor = Color.Gray;
                searchin.BackColor = Color.Gray;
                refreshList(0);

            }
            else
            {
                searchin.BackColor = Color.GhostWhite;
                this.BackColor = System.Drawing.SystemColors.Control;
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
                refreshList(0);
            }
        }

        private void submod_Click(object sender, EventArgs e) // Was ment for Mod Submitting, never was released
        {
            if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission");
            }

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDWorkshopModPreset"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDWorkshopModPreset");
            }

            

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDWorkshopModPreset\\ModInfo.txt"))
            {
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDWorkshopModPreset\\ModInfo.txt");
            }

            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission"))
            {
                Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission", true);
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission");
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDWorkshopModPreset\\ModInfo.txt", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission\\ModInfo.txt");
            }
            else
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission");
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDWorkshopModPreset\\ModInfo.txt", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission\\ModInfo.txt");
            }

            modderl1.Visible = false;
            ItemList.Visible = false;
            mymods.Visible = false;
            download.Visible = false;
            submod.Visible = false;
            modderl2.Visible = false;
            adminpwd.Visible = false;
            submodd.Visible = false;
            modsubdok.Visible = false;

            submodb.Visible = true;
            submodl4.Visible = true;
            submodl.Visible = true;
            submodl2.Visible = true;
            SubModDes.Visible = true;
            SubModl3.Visible = true;
            submoddragdrop.Visible = true;
        }

        private void SubModl3_DragDrop(object sender, DragEventArgs e) // Was ment for Mod Submitting, never was released
        {
            //nothing here lol
        }

        private void submoddragdrop_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in files)
            {
                if (System.IO.File.Exists(file))
                {
                    string filename = Path.GetFileName(file);
                    System.IO.File.Copy(file, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission\\" + filename);
                    submodl4.Text = "File: " + filename;
                    filecheck = file;
                }
            }
        }

        private void submoddragdrop_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }




        private void submodb_Click(object sender, EventArgs e) // Was ment for Mod Submitting, never was released
        {
            if (System.IO.File.Exists(filecheck))
            {

                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission\\ModInfo.txt"))
                {
                    MessageBox.Show("This process can take up to 1 or 2 Minutes (Depending on your Internet connection), after clicking OK on this MessageBox the Mod will be Uploaded!", "Workshop", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission\\ModInfo.txt"))
                    {
                        writer.WriteLine(SubModDes.Text);
                    }
                    filecheck = null;
                    submodl4.Text = "File:";
                    SubModDes.Text = "Name: \nYour Username(Discord): \nVersion of Mod(Optional): \nShort description:";              

                    int length = 11;

                    System.Text.StringBuilder str_build = new System.Text.StringBuilder();
                    Random random = new Random();

                    string read;
                    char letter;
                    
                    for (int i = 0; i < length; i++)
                    {
                        double flt = random.NextDouble();
                        int shift = Convert.ToInt32(Math.Floor(25 * flt));
                        letter = Convert.ToChar(shift + 65);
                        str_build.Append(letter);
                    }

                    string randomsub = str_build.ToString();

                    if(Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions"))
                    {
                        //MessageBox.Show("Delet");
                        Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions", true);
                    }

                    //using (var zip = new Ionic.Zip.ZipFile())
                    {
                        //zip.AddDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission", "\\ModAndInfo"); //create submission.zip
                        //zip.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submission.zip");
                    }

                    using (var client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential("kolben1000", "Kolben1000");
                        client.DownloadFile("ftp://files.000webhost.com/htdocs/Submissions/Submissions.zip", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions.zip");
                        //client.UploadFile("ftp://files.000webhost.com/htdocs/Submissions/Submissions.zip", WebRequestMethods.Ftp.UploadFile, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions.zip");
                    }
                    //Submissions.zip in documents is downloaded...

                    System.IO.Compression.ZipFile.CreateFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TLDModSubmission", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submission.zip");

                    if(!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions"))
                    {
                        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions");
                    }


                    //MessageBox.Show("next is extract shit");

                    System.IO.Compression.ZipFile.ExtractToDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions.zip", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions");
                    
                    
                    File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submission.zip", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions\\Submission" + randomsub + ".zip");
                    //MessageBox.Show("Copy");

                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions.zip"))
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions.zip");
                    }

                    System.IO.Compression.ZipFile.CreateFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions.zip");

                    //using (var zip = new Ionic.Zip.ZipFile())
                    {
                        //zip.AddDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions", "\\Submission" + randomsub + ".zip");
                        //zip.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions.zip");
                    }

                    using (var client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential("kolben1000", "Kolben1000");
                        //client.DownloadFile("ftp://files.000webhost.com/htdocs/Submissions/Submissions.zip", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions");
                        client.UploadFile("ftp://files.000webhost.com/htdocs/Submissions/Submissions.zip", WebRequestMethods.Ftp.UploadFile, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submissions.zip");
                    }




                    MessageBox.Show("Thanks for you Mod submission, we will check it out soon!", "Workshop", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Submission.zip");


                    mymods.Visible = true;
                    if (mymods.Visible)
                    {
                        ItemList.Visible = false;
                        mymods.Visible = false;
                        download.Visible = false;
                        back.Visible = false;
                        submod.Visible = false;
                        submodl.Visible = false;
                        submodl.Visible = false;
                        submodl2.Visible = false;
                        SubModDes.Visible = false;
                        SubModl3.Visible = false;
                        submoddragdrop.Visible = false;
                        submodl4.Visible = false;
                        submodb.Visible = false;
                        modsubdok.Visible = false;


                        welcome.Visible = true;
                        credits.Visible = true;
                        modder.Visible = true;
                        downpatcher.Visible = true;
                        gotomods.Visible = true;
                        label1.Visible = true;
                        checkBox1.Visible = true;
                        XPcheck.Visible = true;
                        downloadbar.Width = 633;
                        downloadperc.Location = new Point(559, 527);

                    }
                    else
                    {
                        mymods.Visible = true;
                        submodl.Visible = false;
                        refreshList(0);
                    }

                }
                else
                {
                    MessageBox.Show("Please make sure that you drop your Mod file in that box before submitting your Mod", "Workshop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void modder_Click(object sender, EventArgs e)
        {
            welcome.Visible = false;
            credits.Visible = false;
            modder.Visible = false;
            downpatcher.Visible = false;
            gotomods.Visible = false;
            label1.Visible = false;
            checkBox1.Visible = false;
            XPcheck.Visible = false;

            modsubdok.Visible = true;
            submodd.Visible = true;
            adminpwd.Visible = true;
            modderl2.Visible = true;
            back.Visible = true;
            submod.Visible = true;
            modderl1.Visible = true;
        }

        private void modsubdok_Click(object sender, EventArgs e)
        {
            if (adminpwd.Text == pwd)
            {
                submodd.Enabled = true;
            }
            else
            {
                MessageBox.Show("Wrong Password!", "Workshop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                submodd.Enabled = false;
            }
        }



        private void submodd_Click(object sender, EventArgs e)
        {
            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential("kolben1000", "Kolben1000");
                client.DownloadFile("ftp://files.000webhost.com/htdocs/Submissions/Submissions.zip", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Submission.zip");
            }
            if(!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheLongDrive\\Submissions.zip"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheLongDrive\\Submissions");
                System.IO.Compression.ZipFile.CreateFromDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheLongDrive\\Submissions", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheLongDrive\\Submissions.zip");
            }
            

            using (var client = new WebClient())
            {
                client.Credentials = new NetworkCredential("kolben1000", "Kolben1000");
                client.UploadFile("ftp://files.000webhost.com/htdocs/Submissions/Submissions.zip", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheLongDrive\\Submissions.zip");
            }

            MessageBox.Show("The file with the Mods should have appeared on your Desktop!", "Workshop - Admin Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void searchin_TextChanged(object sender, EventArgs e)
        {
            if(searchin.Text == "")
            {
                foreach (ModListing mod in ModListings)
                {
                    mod.MainControl.Visible = true;
                }
            }

            else
            {
                foreach (ModListing mod in ModListings)
                {

                    if (mod.ItemName.Text.IndexOf(searchin.Text, StringComparison.OrdinalIgnoreCase) >= 0 || mod.ItemDescription.Text.IndexOf(searchin.Text, StringComparison.OrdinalIgnoreCase) >= 0 || mod.ItemAuthor.Text.IndexOf(searchin.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        //mod.Select(true);
                        mod.MainControl.Visible = true;
                    }

                    else
                    {
                        mod.Select(false);
                        mod.MainControl.Visible = false;
                    }

                }
            }
        }
    }
}