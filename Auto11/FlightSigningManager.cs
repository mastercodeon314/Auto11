using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto11
{
    public class FlightSigningManager
    {
        public bool IsFlightSigningEnabled
        {
            get
            {
                // Execute bcdedit command to check if flight signing is enabled
                Process process = new Process();
                process.StartInfo.FileName = "bcdedit";
                process.StartInfo.Arguments = "/enum";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                bool result = output.Contains("flightsigning           Yes");

                // Check if the output contains "Yes"
                return result;
            }
        }

        public void EnableFlightSigning()
        {
            // Execute bcdedit command to enable flight signing
            Process process = new Process();
            process.StartInfo.FileName = "bcdedit";
            process.StartInfo.Arguments = "/set flightsigning on";
            process.StartInfo.Verb = "runas"; // Run as administrator
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();

            // Execute bcdedit command to enable flight signing
            Process process2 = new Process();
            process2.StartInfo.FileName = "bcdedit";
            process2.StartInfo.Arguments = "/set {bootmgr} flightsigning on";
            process2.StartInfo.Verb = "runas"; // Run as administrator
            process2.StartInfo.CreateNoWindow = true;
            process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process2.Start();
            process2.WaitForExit();
        }

        public void DisableFlightSigning()
        {
            // Execute bcdedit command to disable flight signing
            Process process = new Process();
            process.StartInfo.FileName = "bcdedit";
            process.StartInfo.Arguments = "/set flightsigning off";
            process.StartInfo.Verb = "runas"; // Run as administrator
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();

            // Execute bcdedit command to disable flight signing
            Process process2 = new Process();
            process2.StartInfo.FileName = "bcdedit";
            process2.StartInfo.Arguments = "/set {bootmgr} flightsigning off";
            process2.StartInfo.Verb = "runas"; // Run as administrator
            process2.StartInfo.CreateNoWindow = true;
            process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process2.Start();
            process2.WaitForExit();
        }
    }
}
