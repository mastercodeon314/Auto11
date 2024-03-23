using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto11
{
    public class RebootChecker
    {
        private const string LastRunKey = "LastRunTime";

        public static bool CheckRebootStatus()
        {
            // Get the last run time from the registry
            DateTime lastRunTime = GetLastRunTime();

            if (lastRunTime == DateTime.MinValue)
            {
                // Registry key not found or first run of the application
                //MessageBox.Show("This is the first run of the application or the registry key is missing.");
                // Perform actions as needed for first run
                // Update the last run time
                SaveLastRunTime(DateTime.Now);
                return false;
            }

            // Get the system boot time
            DateTime lastBootTime = GetLastBootTime();

            // Compare last run time with system boot time
            bool rebooted = lastRunTime < lastBootTime;

            // Update the last run time
            SaveLastRunTime(DateTime.Now);

            return rebooted;
        }

        private static DateTime GetLastRunTime()
        {
            DateTime lastRunTime = DateTime.MinValue;
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Win11AutoUpgradeTool"))
            {
                if (key != null)
                {
                    object value = key.GetValue(LastRunKey);
                    if (value != null && value is long)
                    {
                        lastRunTime = DateTime.FromBinary((long)value);
                    }
                }
            }
            return lastRunTime;
        }

        private static void SaveLastRunTime(DateTime lastRunTime)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\Win11AutoUpgradeTool"))
            {
                key.SetValue(LastRunKey, lastRunTime.ToBinary(), RegistryValueKind.QWord);
            }
        }

        private static DateTime GetLastBootTime()
        {
            // Use PerformanceCounter to get system uptime
            PerformanceCounter uptimeCounter = new PerformanceCounter("System", "System Up Time");
            uptimeCounter.NextValue(); // Call NextValue once before reading its value
            return DateTime.Now - TimeSpan.FromSeconds(uptimeCounter.NextValue());
        }
    }
}
