namespace XP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ResizeBarLeft = new System.Windows.Forms.Panel();
            this.ResizeBarRight = new System.Windows.Forms.Panel();
            this.ResizeBarBottom = new System.Windows.Forms.Panel();
            this.ItemList = new System.Windows.Forms.FlowLayoutPanel();
            this.itemPanel = new System.Windows.Forms.Panel();
            this.DownloadsCount = new System.Windows.Forms.Label();
            this.StarScore = new System.Windows.Forms.Label();
            this.DateText = new System.Windows.Forms.Label();
            this.VersionText = new System.Windows.Forms.Label();
            this.AuthText = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.DescriptionText = new System.Windows.Forms.Label();
            this.download = new System.Windows.Forms.Button();
            this.mymods = new System.Windows.Forms.Button();
            this.downloadbar = new System.Windows.Forms.ProgressBar();
            this.downloadtext = new System.Windows.Forms.Label();
            this.downloadperc = new System.Windows.Forms.Label();
            this.welcome = new System.Windows.Forms.Label();
            this.gotomods = new System.Windows.Forms.Button();
            this.downpatcher = new System.Windows.Forms.Button();
            this.credits = new System.Windows.Forms.Label();
            this.modder = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.XPcheck = new System.Windows.Forms.CheckBox();
            this.submodl2 = new System.Windows.Forms.Label();
            this.Count = new System.Windows.Forms.Label();
            this.TitleText = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Star5 = new System.Windows.Forms.PictureBox();
            this.Star4 = new System.Windows.Forms.PictureBox();
            this.Star3 = new System.Windows.Forms.PictureBox();
            this.Star2 = new System.Windows.Forms.PictureBox();
            this.Star1 = new System.Windows.Forms.PictureBox();
            this.dbImage = new System.Windows.Forms.PictureBox();
            this.ModThumbnail = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.MaximiseButton = new System.Windows.Forms.PictureBox();
            this.MinimiseButton = new System.Windows.Forms.PictureBox();
            this.TitleBarRight = new System.Windows.Forms.PictureBox();
            this.TitleBarLeft = new System.Windows.Forms.PictureBox();
            this.TitleBar = new System.Windows.Forms.PictureBox();
            this.itemPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModThumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximiseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimiseButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleBarRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleBarLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ResizeBarLeft
            // 
            this.ResizeBarLeft.BackColor = System.Drawing.Color.RoyalBlue;
            this.ResizeBarLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ResizeBarLeft.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.ResizeBarLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.ResizeBarLeft.Location = new System.Drawing.Point(0, 0);
            this.ResizeBarLeft.Name = "ResizeBarLeft";
            this.ResizeBarLeft.Size = new System.Drawing.Size(1, 570);
            this.ResizeBarLeft.TabIndex = 4;
            this.ResizeBarLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_Window);
            this.ResizeBarLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_Window);
            // 
            // ResizeBarRight
            // 
            this.ResizeBarRight.BackColor = System.Drawing.Color.RoyalBlue;
            this.ResizeBarRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ResizeBarRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.ResizeBarRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ResizeBarRight.Location = new System.Drawing.Point(660, 0);
            this.ResizeBarRight.Name = "ResizeBarRight";
            this.ResizeBarRight.Size = new System.Drawing.Size(1, 570);
            this.ResizeBarRight.TabIndex = 5;
            this.ResizeBarRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_Window);
            this.ResizeBarRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_Window);
            // 
            // ResizeBarBottom
            // 
            this.ResizeBarBottom.BackColor = System.Drawing.Color.RoyalBlue;
            this.ResizeBarBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ResizeBarBottom.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.ResizeBarBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ResizeBarBottom.Location = new System.Drawing.Point(1, 569);
            this.ResizeBarBottom.Name = "ResizeBarBottom";
            this.ResizeBarBottom.Size = new System.Drawing.Size(659, 1);
            this.ResizeBarBottom.TabIndex = 3;
            this.ResizeBarBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_Window);
            this.ResizeBarBottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_Window);
            // 
            // ItemList
            // 
            this.ItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemList.AutoScroll = true;
            this.ItemList.BackColor = System.Drawing.Color.White;
            this.ItemList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ItemList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemList.Location = new System.Drawing.Point(12, 55);
            this.ItemList.Name = "ItemList";
            this.ItemList.Size = new System.Drawing.Size(637, 452);
            this.ItemList.TabIndex = 12;
            this.ItemList.Visible = false;
            // 
            // itemPanel
            // 
            this.itemPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.itemPanel.BackColor = System.Drawing.Color.GhostWhite;
            this.itemPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itemPanel.Controls.Add(this.Star5);
            this.itemPanel.Controls.Add(this.Star4);
            this.itemPanel.Controls.Add(this.Star3);
            this.itemPanel.Controls.Add(this.Star2);
            this.itemPanel.Controls.Add(this.Star1);
            this.itemPanel.Controls.Add(this.DownloadsCount);
            this.itemPanel.Controls.Add(this.StarScore);
            this.itemPanel.Controls.Add(this.dbImage);
            this.itemPanel.Controls.Add(this.DateText);
            this.itemPanel.Controls.Add(this.VersionText);
            this.itemPanel.Controls.Add(this.AuthText);
            this.itemPanel.Controls.Add(this.Title);
            this.itemPanel.Controls.Add(this.DescriptionText);
            this.itemPanel.Controls.Add(this.ModThumbnail);
            this.itemPanel.Location = new System.Drawing.Point(16, 356);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(300, 136);
            this.itemPanel.TabIndex = 0;
            this.itemPanel.Visible = false;
            this.itemPanel.Click += new System.EventHandler(this.Select_Listing);
            // 
            // DownloadsCount
            // 
            this.DownloadsCount.BackColor = System.Drawing.Color.Transparent;
            this.DownloadsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DownloadsCount.Location = new System.Drawing.Point(1, 109);
            this.DownloadsCount.Name = "DownloadsCount";
            this.DownloadsCount.Size = new System.Drawing.Size(77, 16);
            this.DownloadsCount.TabIndex = 9;
            this.DownloadsCount.Text = "Downloads: ";
            // 
            // StarScore
            // 
            this.StarScore.BackColor = System.Drawing.Color.Transparent;
            this.StarScore.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StarScore.Location = new System.Drawing.Point(139, 112);
            this.StarScore.Name = "StarScore";
            this.StarScore.Size = new System.Drawing.Size(43, 16);
            this.StarScore.TabIndex = 8;
            this.StarScore.Text = "3.95/5";
            this.StarScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DateText
            // 
            this.DateText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateText.BackColor = System.Drawing.Color.Transparent;
            this.DateText.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateText.Location = new System.Drawing.Point(237, 22);
            this.DateText.Name = "DateText";
            this.DateText.Size = new System.Drawing.Size(61, 12);
            this.DateText.TabIndex = 4;
            this.DateText.Text = "01/01/2020";
            this.DateText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DateText.Click += new System.EventHandler(this.Select_Listing);
            // 
            // VersionText
            // 
            this.VersionText.BackColor = System.Drawing.Color.Transparent;
            this.VersionText.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionText.Location = new System.Drawing.Point(111, 22);
            this.VersionText.Name = "VersionText";
            this.VersionText.Size = new System.Drawing.Size(31, 12);
            this.VersionText.TabIndex = 3;
            this.VersionText.Text = "V1.0";
            this.VersionText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VersionText.Click += new System.EventHandler(this.Select_Listing);
            // 
            // AuthText
            // 
            this.AuthText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthText.BackColor = System.Drawing.Color.Transparent;
            this.AuthText.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthText.Location = new System.Drawing.Point(139, 22);
            this.AuthText.Name = "AuthText";
            this.AuthText.Size = new System.Drawing.Size(101, 12);
            this.AuthText.TabIndex = 2;
            this.AuthText.Text = "Author";
            this.AuthText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AuthText.Click += new System.EventHandler(this.Select_Listing);
            // 
            // Title
            // 
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(107, 3);
            this.Title.Margin = new System.Windows.Forms.Padding(0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(191, 19);
            this.Title.TabIndex = 1;
            this.Title.Text = "ModName";
            this.Title.Click += new System.EventHandler(this.Select_Listing);
            // 
            // DescriptionText
            // 
            this.DescriptionText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionText.BackColor = System.Drawing.Color.Transparent;
            this.DescriptionText.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionText.Location = new System.Drawing.Point(109, 34);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(190, 69);
            this.DescriptionText.TabIndex = 5;
            this.DescriptionText.Text = "Description";
            this.DescriptionText.Click += new System.EventHandler(this.Select_Listing);
            // 
            // download
            // 
            this.download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.download.Location = new System.Drawing.Point(541, 513);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(108, 45);
            this.download.TabIndex = 13;
            this.download.Text = "Download";
            this.download.UseVisualStyleBackColor = true;
            this.download.Visible = false;
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // mymods
            // 
            this.mymods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mymods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mymods.Location = new System.Drawing.Point(406, 513);
            this.mymods.Name = "mymods";
            this.mymods.Size = new System.Drawing.Size(129, 45);
            this.mymods.TabIndex = 14;
            this.mymods.Text = "My Mods";
            this.mymods.UseVisualStyleBackColor = true;
            this.mymods.Visible = false;
            this.mymods.Click += new System.EventHandler(this.mymods_Click);
            // 
            // downloadbar
            // 
            this.downloadbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadbar.Location = new System.Drawing.Point(16, 543);
            this.downloadbar.Name = "downloadbar";
            this.downloadbar.Size = new System.Drawing.Size(633, 14);
            this.downloadbar.TabIndex = 15;
            this.downloadbar.Value = 50;
            this.downloadbar.Visible = false;
            // 
            // downloadtext
            // 
            this.downloadtext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.downloadtext.AutoSize = true;
            this.downloadtext.Location = new System.Drawing.Point(12, 527);
            this.downloadtext.Name = "downloadtext";
            this.downloadtext.Size = new System.Drawing.Size(133, 13);
            this.downloadtext.TabIndex = 16;
            this.downloadtext.Text = "Downloading: TLDPatcher";
            this.downloadtext.Visible = false;
            // 
            // downloadperc
            // 
            this.downloadperc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadperc.Location = new System.Drawing.Point(559, 527);
            this.downloadperc.Name = "downloadperc";
            this.downloadperc.Size = new System.Drawing.Size(90, 13);
            this.downloadperc.TabIndex = 17;
            this.downloadperc.Text = "50%";
            this.downloadperc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.downloadperc.Visible = false;
            // 
            // welcome
            // 
            this.welcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.welcome.AutoSize = true;
            this.welcome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.welcome.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.welcome.Location = new System.Drawing.Point(90, 67);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(469, 78);
            this.welcome.TabIndex = 18;
            this.welcome.Text = resources.GetString("welcome.Text");
            // 
            // gotomods
            // 
            this.gotomods.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gotomods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gotomods.Location = new System.Drawing.Point(198, 209);
            this.gotomods.Name = "gotomods";
            this.gotomods.Size = new System.Drawing.Size(247, 64);
            this.gotomods.TabIndex = 19;
            this.gotomods.Text = "Go To Mods";
            this.gotomods.UseVisualStyleBackColor = true;
            this.gotomods.Click += new System.EventHandler(this.gotomods_Click);
            // 
            // downpatcher
            // 
            this.downpatcher.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.downpatcher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downpatcher.Location = new System.Drawing.Point(198, 286);
            this.downpatcher.Name = "downpatcher";
            this.downpatcher.Size = new System.Drawing.Size(247, 64);
            this.downpatcher.TabIndex = 20;
            this.downpatcher.Text = "Download TLDPatcher";
            this.downpatcher.UseVisualStyleBackColor = true;
            this.downpatcher.Click += new System.EventHandler(this.downpatcher_Click);
            // 
            // credits
            // 
            this.credits.Location = new System.Drawing.Point(2, 30);
            this.credits.Name = "credits";
            this.credits.Size = new System.Drawing.Size(93, 87);
            this.credits.TabIndex = 21;
            this.credits.Text = "Credits:\r\n_RainBowSheep_\r\nRUNDEN\r\nKolbenLP\r\nSpecial thank to:\r\nSplendid\r\n\r\n";
            this.credits.DoubleClick += new System.EventHandler(this.credits_DoubleClick);
            // 
            // modder
            // 
            this.modder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.modder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.modder.Location = new System.Drawing.Point(198, 367);
            this.modder.Name = "modder";
            this.modder.Size = new System.Drawing.Size(247, 64);
            this.modder.TabIndex = 22;
            this.modder.Text = "For Modders";
            this.modder.UseVisualStyleBackColor = true;
            // 
            // back
            // 
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Location = new System.Drawing.Point(12, 30);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 23;
            this.back.Text = "<- Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Visible = false;
            this.back.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(199, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 40);
            this.label1.TabIndex = 25;
            this.label1.Text = "v6";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(198, 437);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "Dark Theme";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // XPcheck
            // 
            this.XPcheck.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.XPcheck.AutoSize = true;
            this.XPcheck.Checked = true;
            this.XPcheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.XPcheck.Enabled = false;
            this.XPcheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.XPcheck.Location = new System.Drawing.Point(382, 437);
            this.XPcheck.Name = "XPcheck";
            this.XPcheck.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.XPcheck.Size = new System.Drawing.Size(63, 17);
            this.XPcheck.TabIndex = 27;
            this.XPcheck.Text = "XP Style";
            this.XPcheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.XPcheck.UseVisualStyleBackColor = true;
            // 
            // submodl2
            // 
            this.submodl2.AutoSize = true;
            this.submodl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submodl2.Location = new System.Drawing.Point(93, 130);
            this.submodl2.Name = "submodl2";
            this.submodl2.Size = new System.Drawing.Size(255, 16);
            this.submodl2.TabIndex = 30;
            this.submodl2.Text = "Write some information of your mod down:\r\n";
            // 
            // Count
            // 
            this.Count.Location = new System.Drawing.Point(540, 32);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(109, 21);
            this.Count.TabIndex = 31;
            this.Count.Text = "Mods Count: ";
            this.Count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TitleText
            // 
            this.TitleText.AutoSize = true;
            this.TitleText.BackColor = System.Drawing.Color.RoyalBlue;
            this.TitleText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TitleText.BackgroundImage")));
            this.TitleText.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.TitleText.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.TitleText.FlatAppearance.BorderSize = 0;
            this.TitleText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.TitleText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.TitleText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TitleText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleText.ForeColor = System.Drawing.Color.White;
            this.TitleText.Location = new System.Drawing.Point(23, 0);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.TitleText.MaximumSize = new System.Drawing.Size(0, 29);
            this.TitleText.MinimumSize = new System.Drawing.Size(0, 29);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(223, 29);
            this.TitleText.TabIndex = 11;
            this.TitleText.Text = "The Long Drive Mod Workshop 6";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleText.UseVisualStyleBackColor = false;
            this.TitleText.Click += new System.EventHandler(this.Close_Window);
            this.TitleText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_Window);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::XP.Properties.Resources.inactive;
            this.pictureBox2.Location = new System.Drawing.Point(225, 520);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 20);
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // Star5
            // 
            this.Star5.Location = new System.Drawing.Point(274, 112);
            this.Star5.Name = "Star5";
            this.Star5.Size = new System.Drawing.Size(16, 16);
            this.Star5.TabIndex = 14;
            this.Star5.TabStop = false;
            // 
            // Star4
            // 
            this.Star4.Location = new System.Drawing.Point(252, 112);
            this.Star4.Name = "Star4";
            this.Star4.Size = new System.Drawing.Size(16, 16);
            this.Star4.TabIndex = 13;
            this.Star4.TabStop = false;
            // 
            // Star3
            // 
            this.Star3.Location = new System.Drawing.Point(230, 112);
            this.Star3.Name = "Star3";
            this.Star3.Size = new System.Drawing.Size(16, 16);
            this.Star3.TabIndex = 12;
            this.Star3.TabStop = false;
            // 
            // Star2
            // 
            this.Star2.Location = new System.Drawing.Point(208, 112);
            this.Star2.Name = "Star2";
            this.Star2.Size = new System.Drawing.Size(16, 16);
            this.Star2.TabIndex = 11;
            this.Star2.TabStop = false;
            // 
            // Star1
            // 
            this.Star1.Location = new System.Drawing.Point(186, 112);
            this.Star1.Name = "Star1";
            this.Star1.Size = new System.Drawing.Size(16, 16);
            this.Star1.TabIndex = 10;
            this.Star1.TabStop = false;
            // 
            // dbImage
            // 
            this.dbImage.BackColor = System.Drawing.Color.Transparent;
            this.dbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbImage.Image = global::XP.Properties.Resources.db;
            this.dbImage.Location = new System.Drawing.Point(84, 109);
            this.dbImage.Name = "dbImage";
            this.dbImage.Size = new System.Drawing.Size(19, 19);
            this.dbImage.TabIndex = 7;
            this.dbImage.TabStop = false;
            // 
            // ModThumbnail
            // 
            this.ModThumbnail.BackColor = System.Drawing.Color.Transparent;
            this.ModThumbnail.Location = new System.Drawing.Point(3, 3);
            this.ModThumbnail.Name = "ModThumbnail";
            this.ModThumbnail.Size = new System.Drawing.Size(100, 100);
            this.ModThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ModThumbnail.TabIndex = 0;
            this.ModThumbnail.TabStop = false;
            this.ModThumbnail.Click += new System.EventHandler(this.Select_Listing);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox1.Image = global::XP.Properties.Resources.toolbox;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.CloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.BackgroundImage")));
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CloseButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.ErrorImage")));
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.InitialImage")));
            this.CloseButton.Location = new System.Drawing.Point(635, 5);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(21, 21);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.CloseButton.TabIndex = 6;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.Close_Window);
            // 
            // MaximiseButton
            // 
            this.MaximiseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaximiseButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.MaximiseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MaximiseButton.BackgroundImage")));
            this.MaximiseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MaximiseButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("MaximiseButton.ErrorImage")));
            this.MaximiseButton.Image = ((System.Drawing.Image)(resources.GetObject("MaximiseButton.Image")));
            this.MaximiseButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("MaximiseButton.InitialImage")));
            this.MaximiseButton.Location = new System.Drawing.Point(611, 5);
            this.MaximiseButton.Name = "MaximiseButton";
            this.MaximiseButton.Size = new System.Drawing.Size(21, 21);
            this.MaximiseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MaximiseButton.TabIndex = 7;
            this.MaximiseButton.TabStop = false;
            this.MaximiseButton.Click += new System.EventHandler(this.Maximise_Window_Toggle);
            // 
            // MinimiseButton
            // 
            this.MinimiseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimiseButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.MinimiseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MinimiseButton.BackgroundImage")));
            this.MinimiseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MinimiseButton.ErrorImage = ((System.Drawing.Image)(resources.GetObject("MinimiseButton.ErrorImage")));
            this.MinimiseButton.Image = ((System.Drawing.Image)(resources.GetObject("MinimiseButton.Image")));
            this.MinimiseButton.InitialImage = ((System.Drawing.Image)(resources.GetObject("MinimiseButton.InitialImage")));
            this.MinimiseButton.Location = new System.Drawing.Point(587, 5);
            this.MinimiseButton.Name = "MinimiseButton";
            this.MinimiseButton.Size = new System.Drawing.Size(21, 21);
            this.MinimiseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MinimiseButton.TabIndex = 8;
            this.MinimiseButton.TabStop = false;
            this.MinimiseButton.Click += new System.EventHandler(this.Minimise_Window);
            // 
            // TitleBarRight
            // 
            this.TitleBarRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleBarRight.BackColor = System.Drawing.Color.Lime;
            this.TitleBarRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TitleBarRight.BackgroundImage")));
            this.TitleBarRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TitleBarRight.ErrorImage = ((System.Drawing.Image)(resources.GetObject("TitleBarRight.ErrorImage")));
            this.TitleBarRight.Image = ((System.Drawing.Image)(resources.GetObject("TitleBarRight.Image")));
            this.TitleBarRight.InitialImage = ((System.Drawing.Image)(resources.GetObject("TitleBarRight.InitialImage")));
            this.TitleBarRight.Location = new System.Drawing.Point(647, 0);
            this.TitleBarRight.Name = "TitleBarRight";
            this.TitleBarRight.Size = new System.Drawing.Size(14, 29);
            this.TitleBarRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TitleBarRight.TabIndex = 2;
            this.TitleBarRight.TabStop = false;
            this.TitleBarRight.DoubleClick += new System.EventHandler(this.Maximise_Window_Toggle);
            this.TitleBarRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_Window);
            // 
            // TitleBarLeft
            // 
            this.TitleBarLeft.BackColor = System.Drawing.Color.Lime;
            this.TitleBarLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TitleBarLeft.BackgroundImage")));
            this.TitleBarLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TitleBarLeft.ErrorImage = ((System.Drawing.Image)(resources.GetObject("TitleBarLeft.ErrorImage")));
            this.TitleBarLeft.Image = ((System.Drawing.Image)(resources.GetObject("TitleBarLeft.Image")));
            this.TitleBarLeft.InitialImage = ((System.Drawing.Image)(resources.GetObject("TitleBarLeft.InitialImage")));
            this.TitleBarLeft.Location = new System.Drawing.Point(0, 0);
            this.TitleBarLeft.Name = "TitleBarLeft";
            this.TitleBarLeft.Size = new System.Drawing.Size(14, 29);
            this.TitleBarLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TitleBarLeft.TabIndex = 1;
            this.TitleBarLeft.TabStop = false;
            this.TitleBarLeft.DoubleClick += new System.EventHandler(this.Maximise_Window_Toggle);
            this.TitleBarLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_Window);
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.RoyalBlue;
            this.TitleBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TitleBar.BackgroundImage")));
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.ErrorImage = ((System.Drawing.Image)(resources.GetObject("TitleBar.ErrorImage")));
            this.TitleBar.Image = ((System.Drawing.Image)(resources.GetObject("TitleBar.Image")));
            this.TitleBar.InitialImage = ((System.Drawing.Image)(resources.GetObject("TitleBar.InitialImage")));
            this.TitleBar.Location = new System.Drawing.Point(1, 0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(659, 29);
            this.TitleBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TitleBar.TabIndex = 0;
            this.TitleBar.TabStop = false;
            this.TitleBar.DoubleClick += new System.EventHandler(this.Maximise_Window_Toggle);
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_Window);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.TitleText;
            this.ClientSize = new System.Drawing.Size(661, 570);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.itemPanel);
            this.Controls.Add(this.XPcheck);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.modder);
            this.Controls.Add(this.credits);
            this.Controls.Add(this.downpatcher);
            this.Controls.Add(this.gotomods);
            this.Controls.Add(this.welcome);
            this.Controls.Add(this.downloadperc);
            this.Controls.Add(this.downloadtext);
            this.Controls.Add(this.downloadbar);
            this.Controls.Add(this.mymods);
            this.Controls.Add(this.download);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.MaximiseButton);
            this.Controls.Add(this.MinimiseButton);
            this.Controls.Add(this.TitleBarRight);
            this.Controls.Add(this.TitleBarLeft);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.TitleBar);
            this.Controls.Add(this.ResizeBarBottom);
            this.Controls.Add(this.ResizeBarLeft);
            this.Controls.Add(this.ResizeBarRight);
            this.Controls.Add(this.ItemList);
            this.Controls.Add(this.submodl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(256, 128);
            this.Name = "Form1";
            this.Text = "TLD Mod Workshop";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Resize_Window);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Resize_Window);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.itemPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModThumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximiseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimiseButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleBarRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleBarLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.PictureBox TitleBar;
        private System.Windows.Forms.PictureBox TitleBarLeft;
        private System.Windows.Forms.PictureBox TitleBarRight;
        private System.Windows.Forms.PictureBox CloseButton;
        private System.Windows.Forms.PictureBox MaximiseButton;
        private System.Windows.Forms.PictureBox MinimiseButton;
        private System.Windows.Forms.Panel ResizeBarLeft;
        private System.Windows.Forms.Panel ResizeBarRight;
        private System.Windows.Forms.Panel ResizeBarBottom;
        private System.Windows.Forms.Button TitleText;
        private System.Windows.Forms.FlowLayoutPanel ItemList;
        private System.Windows.Forms.Panel itemPanel;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.PictureBox ModThumbnail;
        private System.Windows.Forms.Label AuthText;
        private System.Windows.Forms.Label VersionText;
        private System.Windows.Forms.Label DescriptionText;
        private System.Windows.Forms.Label DateText;
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.Button mymods;
        private System.Windows.Forms.ProgressBar downloadbar;
        private System.Windows.Forms.Label downloadtext;
        private System.Windows.Forms.Label downloadperc;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.Button gotomods;
        private System.Windows.Forms.Button downpatcher;
        private System.Windows.Forms.Label credits;
        private System.Windows.Forms.Button modder;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox XPcheck;
        private System.Windows.Forms.Label submodl2;
        private System.Windows.Forms.Label Count;
        private System.Windows.Forms.PictureBox dbImage;
        private System.Windows.Forms.Label StarScore;
        private System.Windows.Forms.Label DownloadsCount;
        private System.Windows.Forms.PictureBox Star5;
        private System.Windows.Forms.PictureBox Star4;
        private System.Windows.Forms.PictureBox Star3;
        private System.Windows.Forms.PictureBox Star2;
        private System.Windows.Forms.PictureBox Star1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

