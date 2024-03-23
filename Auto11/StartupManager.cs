using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Auto11
{
    public class StartupManager
    {
        //static StartupManager()
        //{
        //    DisableAutoRunDelay();
        //}
        public static void DisableAutoRunDelay()
        {
            const string keyPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Serialize";
            const string valueName1 = "StartupDelayInMSec";
            const string valueName2 = "WaitforIdleState";

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath))
            {
                // If the key doesn't exist, or if both values exist, return
                if (key != null && key.GetValue(valueName1) != null && key.GetValue(valueName2) != null)
                {
                    Console.WriteLine("Registry keys and values already exist. Skipping.");
                    return;
                }
            }

            // Create or open the key
            using (RegistryKey subKey = Registry.CurrentUser.CreateSubKey(keyPath))
            {
                try
                {
                    // Add the values if they don't exist
                    if (subKey != null)
                    {
                        if (subKey.GetValue(valueName1) == null)
                            subKey.SetValue(valueName1, 0, RegistryValueKind.DWord);
                        if (subKey.GetValue(valueName2) == null)
                            subKey.SetValue(valueName2, 0, RegistryValueKind.DWord);
                        Console.WriteLine("Registry keys and values added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Error creating or accessing registry key.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding registry values: " + ex.Message);
                }
            }
        }

        public static bool IsAddedToStartup
        {
            get
            {
                string appName = Assembly.GetEntryAssembly().GetName().Name;

                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (key != null)
                {
                    object value = key.GetValue(appName);
                    key.Close();
                    return (value != null);
                }
                else
                {
                    return false;
                }
            }
        }

        public static void AddToStartup()
        {
            try
            {
                string appName = Assembly.GetEntryAssembly().GetName().Name;
                string appPath = Assembly.GetEntryAssembly().Location.Replace(".dll", ".exe");

                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (key == null)
                    key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");

                key.SetValue(appName, appPath);
                key.Close();
                Console.WriteLine("Added to startup successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void RemoveFromStartup()
        {
            try
            {
                string appName = Assembly.GetEntryAssembly().GetName().Name;

                RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                if (key != null)
                {
                    key.DeleteValue(appName, false);
                    key.Close();
                    Console.WriteLine("Removed from startup successfully.");
                }
                else
                {
                    Console.WriteLine("Key not found in registry.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
