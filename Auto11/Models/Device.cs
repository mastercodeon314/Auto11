using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto11.Models
{
    public class Device
    {
        public Device(string? model, string? version)
        {
            Model = model;
            Version = version;
        }

        public string? Model { get; set; }
        public string? Version { get; set; }
    }
}
