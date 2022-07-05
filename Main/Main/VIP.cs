using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class VIP
    {
        public int Duration { get; set; }
        public List<NormalUser> ActiveUsers()
        {
            List<NormalUser> users = new List<NormalUser>();
            foreach(NormalUser user in NormalUser.AllUsers)
            {
                if(user.VIPSubscription == this)
                {
                    users.Add(user);
                }
            }
            return users;
        }
        public VIP(int Duration)
        {
            this.Duration = Duration;
        }
    }
}
