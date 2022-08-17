using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHomeWork_8_9
{
    interface IPaymentMethod
    {
        public bool IsPaymentPossible(double amount);
        public void MakePayment(double payValue);
        public void AddMoney(double addMoney);
    }
}
