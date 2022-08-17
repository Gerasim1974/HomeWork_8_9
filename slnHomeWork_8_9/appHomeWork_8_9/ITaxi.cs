using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHomeWork_8_9
{
    interface ITaxi
    {
        public void MakeRide(User user);
        public double GetPriceOfRide();
    }
}
