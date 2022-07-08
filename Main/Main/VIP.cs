using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class VIP
    {
        public DateTime VIPStartingTime { get; set; }
        public DateTime VIPEndingTime { get; set; }
        public static int VIPDuration { get; set; } = 20;
        public static double VIPCost { get; set; } = 80000;
        public VIP()
        {
            VIPStartingTime = DateTime.Now;
            VIPEndingTime = VIPStartingTime.AddDays(VIPDuration);
        }
    }
}
