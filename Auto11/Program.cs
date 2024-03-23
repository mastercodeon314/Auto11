using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Security.Principal;

namespace Auto11
{
    internal static class Program
    {
        // Generate a unique MutexName
        private static readonly string MutexName = "Win11AutoUpgradeTool";

        static string GetWindowsVersion()
        {
            string version = "Unknown";
            string key = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";

            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(key))
            {
                if (registryKey != null)
                {
                    version = registryKey.GetValue("ProductName").ToString();
                }
            }

            return version;
        }

        static string GetWindowsBuildNumber()
        {
            string buildNumber = "Unknown";
            string key = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";

            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(key))
            {
                if (registryKey != null)
                {
                    buildNumber = registryKey.GetValue("CurrentBuild").ToString();
                }
            }

            return buildNumber;
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            // Check if another instance is already running
            bool createdNew;
            using (Mutex mutex = new Mutex(true, MutexName, out createdNew))
            {
                if (createdNew)
                {
                    // Check if the current user is an administrator
                    if (!IsAdministrator())
                    {
                        // If not, restart the application with administrative privileges
                        ElevateProcess();
                        return; // Exit the current instance of the application
                    }
                    
                    ApplicationConfiguration.Initialize();
                    Application.Run(new MainForm());
                }
                else
                {
                    // If another instance is already running, inform the user or take necessary action
                    MessageBox.Show("Another instance of the application is already running.", "Application Already Running", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        static bool IsAdministrator()
        {
            // Check if the current user is a member of the Administrators group
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        static void ElevateProcess()
        {
            // Restart the current application with administrative privileges
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Environment.ProcessPath;
            startInfo.Verb = "runas"; // This verb triggers elevation prompt

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to restart application with administrative privileges.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}