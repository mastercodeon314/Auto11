namespace Auto11
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            mainTabs = new MaterialSkin.Controls.MaterialTabControl();
            flightSigningPage = new TabPage();
            flightSigningStatusLbl = new MaterialSkin.Controls.MaterialLabel();
            restartingWindowsLbl = new MaterialSkin.Controls.MaterialLabel();
            rebootLbl = new MaterialSkin.Controls.MaterialLabel();
            enableFlightSigningBtn = new MaterialSkin.Controls.MaterialButton();
            flightSigningStatusLbl1 = new MaterialSkin.Controls.MaterialLabel();
            upgradePage = new TabPage();
            dismountIsoBtn = new MaterialSkin.Controls.MaterialButton();
            mountIsoBtn = new MaterialSkin.Controls.MaterialButton();
            startUpgradeBtn = new MaterialSkin.Controls.MaterialButton();
            isoSelectorCard = new MaterialSkin.Controls.MaterialCard();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            isoPathBox = new MaterialSkin.Controls.MaterialTextBox();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            openIsoBtn = new MaterialSkin.Controls.MaterialButton();
            usbSelectorCard = new MaterialSkin.Controls.MaterialCard();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            usbDriveBox = new MaterialSkin.Controls.MaterialComboBox();
            settingsPage = new TabPage();
            enableUsbDriveSwitch = new MaterialSkin.Controls.MaterialSwitch();
            autoCloseSwitch = new MaterialSkin.Controls.MaterialSwitch();
            systemReservedFixSwitch = new MaterialSkin.Controls.MaterialSwitch();
            enableAutoRestartSwitch = new MaterialSkin.Controls.MaterialSwitch();
            autoRebootSwitch = new MaterialSkin.Controls.MaterialSwitch();
            aboutPage = new TabPage();
            githubLink = new LinkLabel();
            stobaughGroupLink = new LinkLabel();
            windowsVersionLbl = new MaterialSkin.Controls.MaterialLabel();
            websiteLbl = new MaterialSkin.Controls.MaterialLabel();
            githubLbl = new MaterialSkin.Controls.MaterialLabel();
            authorLbl = new MaterialSkin.Controls.MaterialLabel();
            versionLbl = new MaterialSkin.Controls.MaterialLabel();
            programNameLbl = new MaterialSkin.Controls.MaterialLabel();
            exitPage = new TabPage();
            helpTips = new ToolTip(components);
            restartTimer = new System.Windows.Forms.Timer(components);
            setupCheckerTimer = new System.Windows.Forms.Timer(components);
            mainTabs.SuspendLayout();
            flightSigningPage.SuspendLayout();
            upgradePage.SuspendLayout();
            isoSelectorCard.SuspendLayout();
            usbSelectorCard.SuspendLayout();
            settingsPage.SuspendLayout();
            aboutPage.SuspendLayout();
            SuspendLayout();
            // 
            // mainTabs
            // 
            mainTabs.Controls.Add(flightSigningPage);
            mainTabs.Controls.Add(upgradePage);
            mainTabs.Controls.Add(settingsPage);
            mainTabs.Controls.Add(aboutPage);
            mainTabs.Controls.Add(exitPage);
            mainTabs.Depth = 0;
            mainTabs.Location = new Point(6, 67);
            mainTabs.MouseState = MaterialSkin.MouseState.HOVER;
            mainTabs.Multiline = true;
            mainTabs.Name = "mainTabs";
            mainTabs.SelectedIndex = 0;
            mainTabs.Size = new Size(773, 273);
            mainTabs.TabIndex = 0;
            // 
            // flightSigningPage
            // 
            flightSigningPage.Controls.Add(flightSigningStatusLbl);
            flightSigningPage.Controls.Add(restartingWindowsLbl);
            flightSigningPage.Controls.Add(rebootLbl);
            flightSigningPage.Controls.Add(enableFlightSigningBtn);
            flightSigningPage.Controls.Add(flightSigningStatusLbl1);
            flightSigningPage.Location = new Point(4, 24);
            flightSigningPage.Name = "flightSigningPage";
            flightSigningPage.Size = new Size(765, 245);
            flightSigningPage.TabIndex = 6;
            flightSigningPage.Text = "Flight Signing";
            flightSigningPage.UseVisualStyleBackColor = true;
            // 
            // flightSigningStatusLbl
            // 
            flightSigningStatusLbl.AutoSize = true;
            flightSigningStatusLbl.Depth = 0;
            flightSigningStatusLbl.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            flightSigningStatusLbl.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            flightSigningStatusLbl.Location = new Point(16, 61);
            flightSigningStatusLbl.MouseState = MaterialSkin.MouseState.HOVER;
            flightSigningStatusLbl.Name = "flightSigningStatusLbl";
            flightSigningStatusLbl.Size = new Size(34, 29);
            flightSigningStatusLbl.TabIndex = 4;
            flightSigningStatusLbl.Text = "Off";
            // 
            // restartingWindowsLbl
            // 
            restartingWindowsLbl.AutoSize = true;
            restartingWindowsLbl.Depth = 0;
            restartingWindowsLbl.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            restartingWindowsLbl.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            restartingWindowsLbl.ForeColor = Color.FromArgb(192, 192, 0);
            restartingWindowsLbl.HighEmphasis = true;
            restartingWindowsLbl.Location = new Point(16, 133);
            restartingWindowsLbl.MouseState = MaterialSkin.MouseState.HOVER;
            restartingWindowsLbl.Name = "restartingWindowsLbl";
            restartingWindowsLbl.Size = new Size(310, 24);
            restartingWindowsLbl.TabIndex = 3;
            restartingWindowsLbl.Text = "Restarting windows in 5 seconds...";
            restartingWindowsLbl.UseAccent = true;
            restartingWindowsLbl.Visible = false;
            // 
            // rebootLbl
            // 
            rebootLbl.AutoSize = true;
            rebootLbl.Depth = 0;
            rebootLbl.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            rebootLbl.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            rebootLbl.ForeColor = Color.FromArgb(192, 192, 0);
            rebootLbl.HighEmphasis = true;
            rebootLbl.Location = new Point(16, 109);
            rebootLbl.MouseState = MaterialSkin.MouseState.HOVER;
            rebootLbl.Name = "rebootLbl";
            rebootLbl.Size = new Size(388, 24);
            rebootLbl.TabIndex = 2;
            rebootLbl.Text = "You must reboot for changes to take effect!";
            rebootLbl.UseAccent = true;
            rebootLbl.Visible = false;
            // 
            // enableFlightSigningBtn
            // 
            enableFlightSigningBtn.AutoSize = false;
            enableFlightSigningBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            enableFlightSigningBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            enableFlightSigningBtn.Depth = 0;
            enableFlightSigningBtn.HighEmphasis = true;
            enableFlightSigningBtn.Icon = null;
            enableFlightSigningBtn.Location = new Point(16, 203);
            enableFlightSigningBtn.Margin = new Padding(4, 6, 4, 6);
            enableFlightSigningBtn.MouseState = MaterialSkin.MouseState.HOVER;
            enableFlightSigningBtn.Name = "enableFlightSigningBtn";
            enableFlightSigningBtn.NoAccentTextColor = Color.Empty;
            enableFlightSigningBtn.Size = new Size(190, 36);
            enableFlightSigningBtn.TabIndex = 1;
            enableFlightSigningBtn.Text = "Enable Flight Signing";
            enableFlightSigningBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            enableFlightSigningBtn.UseAccentColor = false;
            enableFlightSigningBtn.UseVisualStyleBackColor = true;
            enableFlightSigningBtn.Click += enableFlightSigningBtn_Click;
            // 
            // flightSigningStatusLbl1
            // 
            flightSigningStatusLbl1.AutoSize = true;
            flightSigningStatusLbl1.Depth = 0;
            flightSigningStatusLbl1.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            flightSigningStatusLbl1.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            flightSigningStatusLbl1.Location = new Point(16, 20);
            flightSigningStatusLbl1.MouseState = MaterialSkin.MouseState.HOVER;
            flightSigningStatusLbl1.Name = "flightSigningStatusLbl1";
            flightSigningStatusLbl1.Size = new Size(319, 41);
            flightSigningStatusLbl1.TabIndex = 0;
            flightSigningStatusLbl1.Text = "Flight Signing Status:";
            // 
            // upgradePage
            // 
            upgradePage.Controls.Add(dismountIsoBtn);
            upgradePage.Controls.Add(mountIsoBtn);
            upgradePage.Controls.Add(startUpgradeBtn);
            upgradePage.Controls.Add(isoSelectorCard);
            upgradePage.Controls.Add(usbSelectorCard);
            upgradePage.Location = new Point(4, 24);
            upgradePage.Name = "upgradePage";
            upgradePage.Padding = new Padding(3);
            upgradePage.Size = new Size(765, 245);
            upgradePage.TabIndex = 0;
            upgradePage.Text = "Upgrade";
            upgradePage.UseVisualStyleBackColor = true;
            // 
            // dismountIsoBtn
            // 
            dismountIsoBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dismountIsoBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            dismountIsoBtn.Depth = 0;
            dismountIsoBtn.HighEmphasis = true;
            dismountIsoBtn.Icon = null;
            dismountIsoBtn.Location = new Point(259, 200);
            dismountIsoBtn.Margin = new Padding(4, 6, 4, 6);
            dismountIsoBtn.MouseState = MaterialSkin.MouseState.HOVER;
            dismountIsoBtn.Name = "dismountIsoBtn";
            dismountIsoBtn.NoAccentTextColor = Color.Empty;
            dismountIsoBtn.Size = new Size(123, 36);
            dismountIsoBtn.TabIndex = 6;
            dismountIsoBtn.Text = "Dismount ISO";
            dismountIsoBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            dismountIsoBtn.UseAccentColor = false;
            dismountIsoBtn.UseVisualStyleBackColor = true;
            dismountIsoBtn.Click += dismountIsoBtn_Click;
            // 
            // mountIsoBtn
            // 
            mountIsoBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mountIsoBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            mountIsoBtn.Depth = 0;
            mountIsoBtn.HighEmphasis = true;
            mountIsoBtn.Icon = null;
            mountIsoBtn.Location = new Point(151, 200);
            mountIsoBtn.Margin = new Padding(4, 6, 4, 6);
            mountIsoBtn.MouseState = MaterialSkin.MouseState.HOVER;
            mountIsoBtn.Name = "mountIsoBtn";
            mountIsoBtn.NoAccentTextColor = Color.Empty;
            mountIsoBtn.Size = new Size(100, 36);
            mountIsoBtn.TabIndex = 5;
            mountIsoBtn.Text = "Mount ISO";
            mountIsoBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            mountIsoBtn.UseAccentColor = false;
            mountIsoBtn.UseVisualStyleBackColor = true;
            mountIsoBtn.Click += mountIsoBtn_Click;
            // 
            // startUpgradeBtn
            // 
            startUpgradeBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startUpgradeBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            startUpgradeBtn.Depth = 0;
            startUpgradeBtn.HighEmphasis = true;
            startUpgradeBtn.Icon = null;
            startUpgradeBtn.Location = new Point(7, 200);
            startUpgradeBtn.Margin = new Padding(4, 6, 4, 6);
            startUpgradeBtn.MouseState = MaterialSkin.MouseState.HOVER;
            startUpgradeBtn.Name = "startUpgradeBtn";
            startUpgradeBtn.NoAccentTextColor = Color.Empty;
            startUpgradeBtn.Size = new Size(136, 36);
            startUpgradeBtn.TabIndex = 0;
            startUpgradeBtn.Text = "Start Upgrade";
            startUpgradeBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            startUpgradeBtn.UseAccentColor = false;
            startUpgradeBtn.UseVisualStyleBackColor = true;
            startUpgradeBtn.Click += startUpgradeBtn_Click;
            // 
            // isoSelectorCard
            // 
            isoSelectorCard.BackColor = Color.FromArgb(255, 255, 255);
            isoSelectorCard.Controls.Add(materialLabel1);
            isoSelectorCard.Controls.Add(isoPathBox);
            isoSelectorCard.Controls.Add(materialLabel2);
            isoSelectorCard.Controls.Add(openIsoBtn);
            isoSelectorCard.Depth = 0;
            isoSelectorCard.ForeColor = Color.FromArgb(222, 0, 0, 0);
            isoSelectorCard.Location = new Point(14, 14);
            isoSelectorCard.Margin = new Padding(14);
            isoSelectorCard.MouseState = MaterialSkin.MouseState.HOVER;
            isoSelectorCard.Name = "isoSelectorCard";
            isoSelectorCard.Padding = new Padding(14);
            isoSelectorCard.Size = new Size(734, 136);
            isoSelectorCard.TabIndex = 7;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(17, 14);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(220, 19);
            materialLabel1.TabIndex = 2;
            materialLabel1.Text = "Windows Installer Iso Selection";
            // 
            // isoPathBox
            // 
            isoPathBox.AnimateReadOnly = false;
            isoPathBox.BorderStyle = BorderStyle.None;
            isoPathBox.Depth = 0;
            isoPathBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            isoPathBox.LeadingIcon = null;
            isoPathBox.Location = new Point(69, 78);
            isoPathBox.MaxLength = 50;
            isoPathBox.MouseState = MaterialSkin.MouseState.OUT;
            isoPathBox.Multiline = false;
            isoPathBox.Name = "isoPathBox";
            isoPathBox.Size = new Size(648, 50);
            isoPathBox.TabIndex = 3;
            isoPathBox.Text = "";
            isoPathBox.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.ForeColor = Color.Silver;
            materialLabel2.Location = new Point(17, 56);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(152, 19);
            materialLabel2.TabIndex = 4;
            materialLabel2.Text = "Iso file path to mount";
            // 
            // openIsoBtn
            // 
            openIsoBtn.AutoSize = false;
            openIsoBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            openIsoBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            openIsoBtn.Depth = 0;
            openIsoBtn.HighEmphasis = true;
            openIsoBtn.Icon = Properties.Resources.selectFileBtn_Image;
            openIsoBtn.Image = Properties.Resources.selectFileBtn_Image;
            openIsoBtn.Location = new Point(23, 94);
            openIsoBtn.Margin = new Padding(4, 6, 4, 6);
            openIsoBtn.MouseState = MaterialSkin.MouseState.HOVER;
            openIsoBtn.Name = "openIsoBtn";
            openIsoBtn.NoAccentTextColor = Color.Empty;
            openIsoBtn.Size = new Size(39, 34);
            openIsoBtn.TabIndex = 1;
            openIsoBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            openIsoBtn.UseAccentColor = false;
            openIsoBtn.UseVisualStyleBackColor = true;
            openIsoBtn.Click += openIsoBtn_Click;
            // 
            // usbSelectorCard
            // 
            usbSelectorCard.BackColor = Color.FromArgb(255, 255, 255);
            usbSelectorCard.Controls.Add(materialLabel3);
            usbSelectorCard.Controls.Add(materialLabel4);
            usbSelectorCard.Controls.Add(usbDriveBox);
            usbSelectorCard.Depth = 0;
            usbSelectorCard.ForeColor = Color.FromArgb(222, 0, 0, 0);
            usbSelectorCard.Location = new Point(14, 14);
            usbSelectorCard.Margin = new Padding(14);
            usbSelectorCard.MouseState = MaterialSkin.MouseState.HOVER;
            usbSelectorCard.Name = "usbSelectorCard";
            usbSelectorCard.Padding = new Padding(14);
            usbSelectorCard.Size = new Size(734, 136);
            usbSelectorCard.TabIndex = 5;
            usbSelectorCard.Visible = false;
            // 
            // materialLabel3
            // 
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(17, 14);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(229, 19);
            materialLabel3.TabIndex = 5;
            materialLabel3.Text = "Windows Installer USB Selection";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.ForeColor = Color.Silver;
            materialLabel4.Location = new Point(23, 48);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(71, 19);
            materialLabel4.TabIndex = 6;
            materialLabel4.Text = "USB Drive";
            // 
            // usbDriveBox
            // 
            usbDriveBox.AutoResize = false;
            usbDriveBox.BackColor = Color.FromArgb(255, 255, 255);
            usbDriveBox.Depth = 0;
            usbDriveBox.DrawMode = DrawMode.OwnerDrawVariable;
            usbDriveBox.DropDownHeight = 174;
            usbDriveBox.DropDownStyle = ComboBoxStyle.DropDownList;
            usbDriveBox.DropDownWidth = 121;
            usbDriveBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            usbDriveBox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            usbDriveBox.FormattingEnabled = true;
            usbDriveBox.IntegralHeight = false;
            usbDriveBox.ItemHeight = 43;
            usbDriveBox.Location = new Point(17, 70);
            usbDriveBox.MaxDropDownItems = 4;
            usbDriveBox.MouseState = MaterialSkin.MouseState.OUT;
            usbDriveBox.Name = "usbDriveBox";
            usbDriveBox.Size = new Size(700, 49);
            usbDriveBox.StartIndex = 0;
            usbDriveBox.TabIndex = 0;
            usbDriveBox.SelectedIndexChanged += usbDriveBox_SelectedIndexChanged;
            // 
            // settingsPage
            // 
            settingsPage.Controls.Add(enableUsbDriveSwitch);
            settingsPage.Controls.Add(autoCloseSwitch);
            settingsPage.Controls.Add(systemReservedFixSwitch);
            settingsPage.Controls.Add(enableAutoRestartSwitch);
            settingsPage.Controls.Add(autoRebootSwitch);
            settingsPage.Location = new Point(4, 24);
            settingsPage.Name = "settingsPage";
            settingsPage.Size = new Size(765, 245);
            settingsPage.TabIndex = 7;
            settingsPage.Text = "Settings";
            settingsPage.UseVisualStyleBackColor = true;
            // 
            // enableUsbDriveSwitch
            // 
            enableUsbDriveSwitch.AutoSize = true;
            enableUsbDriveSwitch.Depth = 0;
            enableUsbDriveSwitch.Location = new Point(11, 208);
            enableUsbDriveSwitch.Margin = new Padding(0);
            enableUsbDriveSwitch.MouseLocation = new Point(-1, -1);
            enableUsbDriveSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            enableUsbDriveSwitch.Name = "enableUsbDriveSwitch";
            enableUsbDriveSwitch.Ripple = true;
            enableUsbDriveSwitch.Size = new Size(241, 37);
            enableUsbDriveSwitch.TabIndex = 5;
            enableUsbDriveSwitch.Text = "Enable USB Drive Selector";
            enableUsbDriveSwitch.UseVisualStyleBackColor = true;
            enableUsbDriveSwitch.CheckedChanged += enableUsbDriveSwitch_CheckedChanged;
            // 
            // autoCloseSwitch
            // 
            autoCloseSwitch.AutoSize = true;
            autoCloseSwitch.Depth = 0;
            autoCloseSwitch.Location = new Point(11, 160);
            autoCloseSwitch.Margin = new Padding(0);
            autoCloseSwitch.MouseLocation = new Point(-1, -1);
            autoCloseSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            autoCloseSwitch.Name = "autoCloseSwitch";
            autoCloseSwitch.Ripple = true;
            autoCloseSwitch.Size = new Size(533, 37);
            autoCloseSwitch.TabIndex = 4;
            autoCloseSwitch.Text = "Enable automatic exiting of the program once an upgrade is started";
            helpTips.SetToolTip(autoCloseSwitch, "Enables automatic exiting of the app once the upgrade setup is started.");
            autoCloseSwitch.UseVisualStyleBackColor = true;
            autoCloseSwitch.CheckedChanged += autoCloseSwitch_CheckedChanged;
            // 
            // systemReservedFixSwitch
            // 
            systemReservedFixSwitch.AutoSize = true;
            systemReservedFixSwitch.Depth = 0;
            systemReservedFixSwitch.Location = new Point(11, 109);
            systemReservedFixSwitch.Margin = new Padding(0);
            systemReservedFixSwitch.MouseLocation = new Point(-1, -1);
            systemReservedFixSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            systemReservedFixSwitch.Name = "systemReservedFixSwitch";
            systemReservedFixSwitch.Ripple = true;
            systemReservedFixSwitch.Size = new Size(555, 37);
            systemReservedFixSwitch.TabIndex = 3;
            systemReservedFixSwitch.Text = "Enable automatic fix for couldnt update system reserved partition error";
            helpTips.SetToolTip(systemReservedFixSwitch, "Enables an automatic fix that will correct the \"couldnt update system reserved partition\" error that sometimes the installer will throw. ");
            systemReservedFixSwitch.UseVisualStyleBackColor = true;
            systemReservedFixSwitch.CheckedChanged += systemReservedFixSwitch_CheckedChanged;
            // 
            // enableAutoRestartSwitch
            // 
            enableAutoRestartSwitch.AutoSize = true;
            enableAutoRestartSwitch.Depth = 0;
            enableAutoRestartSwitch.Location = new Point(11, 58);
            enableAutoRestartSwitch.Margin = new Padding(0);
            enableAutoRestartSwitch.MouseLocation = new Point(-1, -1);
            enableAutoRestartSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            enableAutoRestartSwitch.Name = "enableAutoRestartSwitch";
            enableAutoRestartSwitch.Ripple = true;
            enableAutoRestartSwitch.Size = new Size(274, 37);
            enableAutoRestartSwitch.TabIndex = 2;
            enableAutoRestartSwitch.Text = "Enable application auto restart";
            helpTips.SetToolTip(enableAutoRestartSwitch, "Enable automatic restart of application when rebooting from enabling flight signing mode.");
            enableAutoRestartSwitch.UseVisualStyleBackColor = true;
            enableAutoRestartSwitch.CheckedChanged += enableAutoRestartSwitch_CheckedChanged;
            // 
            // autoRebootSwitch
            // 
            autoRebootSwitch.AutoSize = true;
            autoRebootSwitch.Depth = 0;
            autoRebootSwitch.Location = new Point(11, 9);
            autoRebootSwitch.Margin = new Padding(0);
            autoRebootSwitch.MouseLocation = new Point(-1, -1);
            autoRebootSwitch.MouseState = MaterialSkin.MouseState.HOVER;
            autoRebootSwitch.Name = "autoRebootSwitch";
            autoRebootSwitch.Ripple = true;
            autoRebootSwitch.Size = new Size(392, 37);
            autoRebootSwitch.TabIndex = 1;
            autoRebootSwitch.Text = "Enable Auto Windows Reboot for Flight Signing";
            helpTips.SetToolTip(autoRebootSwitch, "Enables automatic reboot of windows when turning on Flight Signing mode.");
            autoRebootSwitch.UseVisualStyleBackColor = true;
            autoRebootSwitch.CheckedChanged += autoShutdownSwitch_CheckedChanged;
            // 
            // aboutPage
            // 
            aboutPage.Controls.Add(githubLink);
            aboutPage.Controls.Add(stobaughGroupLink);
            aboutPage.Controls.Add(windowsVersionLbl);
            aboutPage.Controls.Add(websiteLbl);
            aboutPage.Controls.Add(githubLbl);
            aboutPage.Controls.Add(authorLbl);
            aboutPage.Controls.Add(versionLbl);
            aboutPage.Controls.Add(programNameLbl);
            aboutPage.Location = new Point(4, 24);
            aboutPage.Name = "aboutPage";
            aboutPage.Size = new Size(765, 245);
            aboutPage.TabIndex = 5;
            aboutPage.Text = "About";
            aboutPage.UseVisualStyleBackColor = true;
            // 
            // githubLink
            // 
            githubLink.AutoSize = true;
            githubLink.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            githubLink.LinkBehavior = LinkBehavior.HoverUnderline;
            githubLink.LinkColor = Color.Silver;
            githubLink.Location = new Point(81, 154);
            githubLink.Name = "githubLink";
            githubLink.Size = new Size(238, 17);
            githubLink.TabIndex = 7;
            githubLink.TabStop = true;
            githubLink.Text = "https://github.com/mastercodeon314";
            githubLink.LinkClicked += githubLink_LinkClicked;
            // 
            // stobaughGroupLink
            // 
            stobaughGroupLink.AutoSize = true;
            stobaughGroupLink.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            stobaughGroupLink.LinkBehavior = LinkBehavior.HoverUnderline;
            stobaughGroupLink.LinkColor = Color.Silver;
            stobaughGroupLink.Location = new Point(90, 190);
            stobaughGroupLink.Name = "stobaughGroupLink";
            stobaughGroupLink.Size = new Size(208, 17);
            stobaughGroupLink.TabIndex = 6;
            stobaughGroupLink.TabStop = true;
            stobaughGroupLink.Text = "https://www.stobaughgroup.com";
            stobaughGroupLink.LinkClicked += stobaughGroupLink_LinkClicked;
            // 
            // windowsVersionLbl
            // 
            windowsVersionLbl.AutoSize = true;
            windowsVersionLbl.Depth = 0;
            windowsVersionLbl.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            windowsVersionLbl.Location = new Point(29, 226);
            windowsVersionLbl.MouseState = MaterialSkin.MouseState.HOVER;
            windowsVersionLbl.Name = "windowsVersionLbl";
            windowsVersionLbl.Size = new Size(28, 19);
            windowsVersionLbl.TabIndex = 5;
            windowsVersionLbl.Text = "123";
            // 
            // websiteLbl
            // 
            websiteLbl.AutoSize = true;
            websiteLbl.Depth = 0;
            websiteLbl.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            websiteLbl.Location = new Point(29, 188);
            websiteLbl.MouseState = MaterialSkin.MouseState.HOVER;
            websiteLbl.Name = "websiteLbl";
            websiteLbl.Size = new Size(61, 19);
            websiteLbl.TabIndex = 4;
            websiteLbl.Text = "Website:";
            // 
            // githubLbl
            // 
            githubLbl.AutoSize = true;
            githubLbl.Depth = 0;
            githubLbl.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            githubLbl.Location = new Point(29, 152);
            githubLbl.MouseState = MaterialSkin.MouseState.HOVER;
            githubLbl.Name = "githubLbl";
            githubLbl.Size = new Size(52, 19);
            githubLbl.TabIndex = 3;
            githubLbl.Text = "Github:";
            // 
            // authorLbl
            // 
            authorLbl.AutoSize = true;
            authorLbl.Depth = 0;
            authorLbl.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            authorLbl.Location = new Point(29, 113);
            authorLbl.MouseState = MaterialSkin.MouseState.HOVER;
            authorLbl.Name = "authorLbl";
            authorLbl.Size = new Size(148, 19);
            authorLbl.TabIndex = 2;
            authorLbl.Text = "Author: Dainen Dunn";
            // 
            // versionLbl
            // 
            versionLbl.AutoSize = true;
            versionLbl.Depth = 0;
            versionLbl.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            versionLbl.Location = new Point(29, 72);
            versionLbl.MouseState = MaterialSkin.MouseState.HOVER;
            versionLbl.Name = "versionLbl";
            versionLbl.Size = new Size(80, 19);
            versionLbl.TabIndex = 1;
            versionLbl.Text = "Version 1.1";
            // 
            // programNameLbl
            // 
            programNameLbl.AutoSize = true;
            programNameLbl.Depth = 0;
            programNameLbl.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            programNameLbl.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            programNameLbl.Location = new Point(29, 15);
            programNameLbl.MouseState = MaterialSkin.MouseState.HOVER;
            programNameLbl.Name = "programNameLbl";
            programNameLbl.Size = new Size(685, 41);
            programNameLbl.TabIndex = 0;
            programNameLbl.Text = "In-place Upgrade Tool for Windows 11 Insider";
            // 
            // exitPage
            // 
            exitPage.Location = new Point(4, 24);
            exitPage.Name = "exitPage";
            exitPage.Size = new Size(765, 245);
            exitPage.TabIndex = 8;
            exitPage.Text = "Exit";
            exitPage.UseVisualStyleBackColor = true;
            // 
            // helpTips
            // 
            helpTips.AutomaticDelay = 250;
            helpTips.AutoPopDelay = 5000;
            helpTips.InitialDelay = 250;
            helpTips.ReshowDelay = 50;
            helpTips.ShowAlways = true;
            // 
            // restartTimer
            // 
            restartTimer.Interval = 1000;
            restartTimer.Tick += restartTimer_Tick;
            // 
            // setupCheckerTimer
            // 
            setupCheckerTimer.Interval = 1000;
            setupCheckerTimer.Tick += setupCheckerTimer_Tick;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(781, 346);
            Controls.Add(mainTabs);
            DrawerTabControl = mainTabs;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Sizable = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Auto11";
            Load += MainForm_Load;
            mainTabs.ResumeLayout(false);
            flightSigningPage.ResumeLayout(false);
            flightSigningPage.PerformLayout();
            upgradePage.ResumeLayout(false);
            upgradePage.PerformLayout();
            isoSelectorCard.ResumeLayout(false);
            isoSelectorCard.PerformLayout();
            usbSelectorCard.ResumeLayout(false);
            usbSelectorCard.PerformLayout();
            settingsPage.ResumeLayout(false);
            settingsPage.PerformLayout();
            aboutPage.ResumeLayout(false);
            aboutPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl mainTabs;
        private TabPage upgradePage;
        private MaterialSkin.Controls.MaterialButton startUpgradeBtn;
        private TabPage aboutPage;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox isoPathBox;
        private MaterialSkin.Controls.MaterialButton openIsoBtn;
        private MaterialSkin.Controls.MaterialLabel authorLbl;
        private MaterialSkin.Controls.MaterialLabel versionLbl;
        private MaterialSkin.Controls.MaterialLabel programNameLbl;
        private MaterialSkin.Controls.MaterialButton mountIsoBtn;
        private TabPage flightSigningPage;
        private MaterialSkin.Controls.MaterialLabel flightSigningStatusLbl1;
        private MaterialSkin.Controls.MaterialButton enableFlightSigningBtn;
        private MaterialSkin.Controls.MaterialLabel rebootLbl;
        private TabPage settingsPage;
        private MaterialSkin.Controls.MaterialSwitch autoRebootSwitch;
        private ToolTip helpTips;
        private MaterialSkin.Controls.MaterialSwitch enableAutoRestartSwitch;
        private MaterialSkin.Controls.MaterialLabel restartingWindowsLbl;
        private System.Windows.Forms.Timer restartTimer;
        private MaterialSkin.Controls.MaterialButton dismountIsoBtn;
        private MaterialSkin.Controls.MaterialSwitch systemReservedFixSwitch;
        private TabPage exitPage;
        private MaterialSkin.Controls.MaterialSwitch autoCloseSwitch;
        private System.Windows.Forms.Timer setupCheckerTimer;
        private MaterialSkin.Controls.MaterialLabel githubLbl;
        private MaterialSkin.Controls.MaterialLabel websiteLbl;
        private MaterialSkin.Controls.MaterialLabel flightSigningStatusLbl;
        private MaterialSkin.Controls.MaterialLabel windowsVersionLbl;
        private LinkLabel githubLink;
        private LinkLabel stobaughGroupLink;
        private MaterialSkin.Controls.MaterialCard usbSelectorCard;
        private MaterialSkin.Controls.MaterialComboBox usbDriveBox;
        private MaterialSkin.Controls.MaterialCard isoSelectorCard;
        private MaterialSkin.Controls.MaterialSwitch enableUsbDriveSwitch;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
    }
}
