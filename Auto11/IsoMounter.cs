using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto11
{
    public class IsoMounter
    {
        public event EventHandler IsoMounted;
        public event EventHandler IsoDismounted;

        bool mounting = false;

        public void Mount(string isoPath, string driveLetter)
        {
            if (!driveLetter.Contains(":"))
            {
                driveLetter += ":";
            }
            string command = "$isoImg='" + isoPath + "';$driveLetter='" + driveLetter + "';$diskImg=Mount-DiskImage -ImagePath $isoImg -NoDriveLetter;$volInfo=$diskImg|Get-Volume;mountvol $driveLetter $volInfo.UniqueId";

            Task.Run(() =>
            {
                mounting = true;

                ExecutePowerShellCommand(command);
            });
        }

        public void Unmount(string isoPath)
        {
            string command = "$isoImg='" + isoPath + "';DisMount-DiskImage -ImagePath $isoImg";
            Task.Run(() =>
            {
                mounting = false;

                ExecutePowerShellCommand(command);
            });
        }

        private void ExecutePowerShellCommand(string command)
        {
            Process PowerShellProcess = new Process();
            PowerShellProcess.StartInfo.FileName = "powershell.exe";
            PowerShellProcess.StartInfo.Arguments = "-NoProfile -ExecutionPolicy unrestricted -Command " + command;
            PowerShellProcess.StartInfo.CreateNoWindow = true;
            PowerShellProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            PowerShellProcess.StartInfo.RedirectStandardOutput = true;
            PowerShellProcess.EnableRaisingEvents = true;
            PowerShellProcess.Exited += PowerShellProcess_Exited;
            PowerShellProcess.Start();
            PowerShellProcess.WaitForExit();
        }

        private void PowerShellProcess_Exited(object? sender, EventArgs e)
        {
            if (mounting)
            {
                if (IsoMounted != null)
                {
                    IsoMounted(this, null);
                }
            }
            else
            {
                if (IsoDismounted != null)
                {
                    IsoDismounted(this, null);
                }
            }
        }
    }
}
