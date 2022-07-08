using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class VIP
    {
        public VIP(DateTime vIPStartingTime, DateTime vIPEndingTime)
        {
            VIPStartingTime = vIPStartingTime;
            VIPEndingTime = vIPEndingTime;
        }

        public VIP()
        {
            //fill this 
        }

        public DateTime VIPStartingTime { get; set; }
        public DateTime VIPEndingTime { get; set; }
        public static int VIPDuration { get; set; }
        public static double VIPCost { get; set; }
    }
}
