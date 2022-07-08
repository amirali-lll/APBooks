using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Rate
    {
        int amount;
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                if (value >= 0 && value <= 5)
                    amount = value;
                else
                    throw new Exception("the rate must between 0-5");
            }
        }
        public NormalUser user;

        public Rate(int amount, NormalUser user)
        {
            Amount = amount;
            this.user = user;
        }
    }
}
