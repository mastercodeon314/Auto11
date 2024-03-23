using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using Auto11.Models;
using WinverUWP.Helpers;
using Microsoft.Win32;

namespace Auto11
{
    public partial class MainForm : MaterialForm
    {
        FlightSigningManager flightManager;
        IsoMounter isoMan;

        private int restartCounter = 5;

        [DllImport("user32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool turnOn);

        static string GetWindowsBuildNumber()
        {
            string buildNumber = "Unknown";
            string key = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";

            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(key))
            {
                if (registryKey != null)
                {
                    buildNumber = registryKey.GetValue("BuildLabEx").ToString();
                }
            }

            return buildNumber;
        }

        public MainForm()
        {
            InitializeComponent();

            this.Region = Region.FromHrgn(Utils.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            StartupManager.DisableAutoRunDelay();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Red200, TextShade.WHITE);

            startUpgradeBtn.Enabled = false;
            mountIsoBtn.Enabled = false;
            dismountIsoBtn.Enabled = false;

            restartingWindowsLbl.Text = $"Restarting windows in {restartCounter} seconds...";

            mainTabs.Selected += MainTabs_Selected;

            loadSettings();

            if (Properties.Settings.Default.autoSystemReservedFix)
            {
                ApplySystemReservedFix();
            }

            checkIsoMounted();

            flightManager = new FlightSigningManager();
            isoMan = new IsoMounter();
            isoMan.IsoMounted += IsoMan_IsoMounted;
            isoMan.IsoDismounted += IsoMan_IsoDismounted;

            if (!flightManager.IsFlightSigningEnabled)
            {
                mainTabs.TabPages.Remove(upgradePage);
                flightSigningStatusLbl.Text = "Off";
            }
            else
            {
                if (Properties.Settings.Default.flightSigningNeedsReboot)
                {
                    if (!RebootChecker.CheckRebootStatus())
                    {
                        mainTabs.TabPages.Remove(upgradePage);
                        flightSigningStatusLbl.Text = "On, but Needs reboot";
                        rebootLbl.Visible = true;
                        enableFlightSigningBtn.Enabled = false;
                    }
                    else
                    {
                        flightSigningStatusLbl.Text = "On";
                        enableFlightSigningBtn.Text = "Next";
                        this.mainTabs.SelectedTab = upgradePage;
                        rebootLbl.Visible = false;

                        Properties.Settings.Default.flightSigningNeedsReboot = false;
                        Properties.Settings.Default.Save();
                    }
                }
                else
                {
                    flightSigningStatusLbl.Text = "On";
                    enableFlightSigningBtn.Text = "Next";
                    this.mainTabs.SelectedTab = upgradePage;
                }
            }

            if (StartupManager.IsAddedToStartup && RebootChecker.CheckRebootStatus())
            {
                StartupManager.RemoveFromStartup();
            }

            string productName = WinbrandHelper.GetWinbrand();

            var displayVersion = RegistryHelper.GetInfoString("DisplayVersion");

            string buildNumber = GetWindowsBuildNumber();

            string versionStirng = productName + " " + displayVersion + " (OS Build " + buildNumber + ")";

            windowsVersionLbl.Text = versionStirng;
        }

        private void IsoMan_IsoDismounted(object? sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(IsoMan_IsoDismounted), new object[] { sender, e });
            }
            else
            {
                if (File.Exists(@"G:\setup.exe"))
                {
                    dismountIsoBtn.Enabled = true;
                    mountIsoBtn.Enabled = false;
                    openIsoBtn.Enabled = false;
                    startUpgradeBtn.Enabled = true;
                }
                else
                {
                    dismountIsoBtn.Enabled = false;
                    mountIsoBtn.Enabled = true;
                    openIsoBtn.Enabled = true;
                    startUpgradeBtn.Enabled = false;
                }
            }
        }

        private void IsoMan_IsoMounted(object? sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(IsoMan_IsoMounted), new object[] { sender, e });
            }
            else
            {
                if (!File.Exists("G:\\setup.exe"))
                {
                    mountIsoBtn.Enabled = true;
                    openIsoBtn.Enabled = true;
                    startUpgradeBtn.Enabled = false;
                    dismountIsoBtn.Enabled = false;
                }
                else
                {
                    mountIsoBtn.Enabled = false;
                    openIsoBtn.Enabled = false;
                    startUpgradeBtn.Enabled = true;
                    dismountIsoBtn.Enabled = true;
                }
            }
        }

        private void checkIsoMounted()
        {
            //  Get-Volume -DriveLetter G | ForEach-Object {Get-DiskImage -DevicePath $($_.Path -replace "\\$")} | Select-Object -ExpandProperty ImagePath

            string command = @"Get-Volume -DriveLetter G | ForEach-Object {Get-DiskImage -DevicePath $($_.Path -replace ""\\$"")} | Select-Object -ExpandProperty ImagePath";

            string b64 = Convert.ToBase64String(Encoding.Unicode.GetBytes(command));
            string result = ExecutePowerShellCommandB64(b64);

            if (File.Exists(result))
            {
                isoPathBox.Clear();
                isoPathBox.Text = result.Trim();
                mountIsoBtn.Enabled = false;
                startUpgradeBtn.Enabled = true;
                dismountIsoBtn.Enabled = true;
                openIsoBtn.Enabled = false;
            }
        }

        private void MainTabs_Selected(object? sender, TabControlEventArgs e)
        {
            if (e.TabPage == exitPage)
            {
                this.Close();
            }
        }

        private void ApplySystemReservedFix()
        {
            // Create a process to execute the command
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = @"/C mountvol y: /s && y: && cd EFI\Microsoft\Boot\Fonts && del /Q *.*";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            // Start the process
            process.Start();

            // Wait for the process to exit
            process.WaitForExit();

            string output = process.StandardOutput.ReadToEnd();
        }

        private void loadSettings()
        {
            autoRebootSwitch.Checked = Properties.Settings.Default.autoRebootForFlightSigning;
            enableAutoRestartSwitch.Checked = Properties.Settings.Default.autoAppRestart;
            systemReservedFixSwitch.Checked = Properties.Settings.Default.autoSystemReservedFix;
            autoCloseSwitch.Checked = Properties.Settings.Default.autoClose;

            if (Properties.Settings.Default.LastFile != String.Empty)
            {
                isoPathBox.Text = Properties.Settings.Default.LastFile;
                mountIsoBtn.Enabled = true;
            }
        }

        private void openIsoBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "Iso files (*.iso)|*.iso";
            diag.RestoreDirectory = true;
            if (diag.ShowDialog() == DialogResult.OK)
            {
                isoPathBox.Text = diag.FileName;
                Properties.Settings.Default.LastFile = diag.FileName;
                Properties.Settings.Default.Save();

                mountIsoBtn.Enabled = true;
            }
        }

        private void mountIsoBtn_Click(object sender, EventArgs e)
        {
            mountIsoBtn.Enabled = false;
            openIsoBtn.Enabled = false;

            isoMan.Mount(isoPathBox.Text, "G");
        }

        Process upgradeProcess;
        private void startUpgradeBtn_Click(object sender, EventArgs e)
        {
            // Run the setup exe with cmd line on the mounted drive

            startUpgradeBtn.Enabled = false;
            dismountIsoBtn.Enabled = false;
            upgradeProcess = new Process();
            upgradeProcess.StartInfo.FileName = "G:\\setup.exe";
            upgradeProcess.StartInfo.Arguments = "/Product Server /Auto Upgrade /Compat IgnoreWarning /MigrateDrivers All /Telemetry Disable";
            upgradeProcess.StartInfo.UseShellExecute = false;
            upgradeProcess.EnableRaisingEvents = true;
            upgradeProcess.Exited += upgradeProcess_Exited;
            upgradeProcess.Start();

            //setupCheckerTimer.Start();

            if (Properties.Settings.Default.autoClose)
            {
                this.Close();
            }
        }

        private void upgradeProcess_Exited(object? sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(upgradeProcess_Exited), new object[] { sender, e });
            }
            else
            {
                startUpgradeBtn.Enabled = true;
                dismountIsoBtn.Enabled = true;
            }
        }

        static string ExecutePowerShellCommandB64(string command)
        {
            using (Process PowerShellProcess = new Process())
            {
                PowerShellProcess.StartInfo.FileName = "powershell.exe";
                PowerShellProcess.StartInfo.Arguments = "-NoProfile -ExecutionPolicy unrestricted -EncodedCommand \"" + command + "\"";
                PowerShellProcess.StartInfo.CreateNoWindow = true;
                PowerShellProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                PowerShellProcess.StartInfo.RedirectStandardOutput = true;
                PowerShellProcess.Start();
                PowerShellProcess.WaitForExit();

                string output = PowerShellProcess.StandardOutput.ReadToEnd();

                return output.Replace("\r\n", "");
            }
        }

        private void restart()
        {
            // Construct the command to unmount the drive using mountvol utility
            string command = "shutdown /r /t 0";

            // Create a process to execute the command
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/C {command}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            // Start the process
            process.Start();

            // Wait for the process to exit
            process.WaitForExit();
        }

        private void enableFlightSigningBtn_Click(object sender, EventArgs e)
        {
            if (enableFlightSigningBtn.Text == "Enable Flight Signing")
            {
                flightManager.EnableFlightSigning();
                enableFlightSigningBtn.Enabled = false;

                if (Properties.Settings.Default.autoAppRestart)
                {
                    StartupManager.AddToStartup();
                }

                if (Properties.Settings.Default.autoRebootForFlightSigning)
                {
                    // Auto restart call here...
                    restartTimer.Start();
                    restartingWindowsLbl.Visible = true;
                }
                else
                {
                    rebootLbl.Visible = true;
                    Properties.Settings.Default.flightSigningNeedsReboot = true;
                    Properties.Settings.Default.Save();
                }
            }
            else if (enableFlightSigningBtn.Text == "Next")
            {
                this.mainTabs.SelectedTab = upgradePage;
            }
        }

        private void autoShutdownSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoRebootForFlightSigning = autoRebootSwitch.Checked;
            Properties.Settings.Default.Save();
        }

        private void enableAutoRestartSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoAppRestart = enableAutoRestartSwitch.Checked;
            Properties.Settings.Default.Save();
        }

        private void restartTimer_Tick(object sender, EventArgs e)
        {
            restartCounter -= 1;

            if (restartCounter == 0)
            {
                restartingWindowsLbl.Text = $"Restarting windows now";
                restartTimer.Stop();

                if (Properties.Settings.Default.autoAppRestart)
                {
                    StartupManager.AddToStartup();
                }

                // Windows restart call here
                restart();
            }
            else
            {
                if (restartCounter == 1)
                {
                    restartingWindowsLbl.Text = $"Restarting windows now";
                }
                else
                {
                    restartingWindowsLbl.Text = $"Restarting windows in {restartCounter} seconds...";
                }
            }


        }

        private void dismountIsoBtn_Click(object sender, EventArgs e)
        {
            dismountIsoBtn.Enabled = false;
            startUpgradeBtn.Enabled = false;

            isoMan.Unmount(isoPathBox.Text);
        }

        private void systemReservedFixSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoSystemReservedFix = systemReservedFixSwitch.Checked;
            Properties.Settings.Default.Save();
        }

        private void autoCloseSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoClose = autoCloseSwitch.Checked;
            Properties.Settings.Default.Save();
        }

        private void setupCheckerTimer_Tick(object sender, EventArgs e)
        {
            string processName = "setup.exe";
            string expectedPath = @"G:\setup.exe";

            bool isRunningFromExpectedPath = IsProcessRunningFromPath(processName, expectedPath);
            if (!isRunningFromExpectedPath && File.Exists(@"G:\setup.exe"))
            {
                startUpgradeBtn.Enabled = true;
                dismountIsoBtn.Enabled = true;
                setupCheckerTimer.Stop();
            }
        }

        static bool IsProcessRunningFromPath(string processName, string expectedPath)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            foreach (Process process in processes)
            {
                try
                {
                    string processPath = process.MainModule.FileName;
                    if (string.Equals(processPath, expectedPath, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error occurred while checking process: {ex.Message}");
                }
            }

            return false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SwitchToThisWindow(this.Handle, true);
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = githubLink.Text;
            p.Start();
        }

        private void stobaughGroupLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = stobaughGroupLink.Text;
            p.Start();
        }
    }
}