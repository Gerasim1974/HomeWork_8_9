using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHomeWork_8_9
{
    internal class Cash : IPaymentMethod
    {
        private double _amount;


        public double Amount
        {
            get
            {
                return _amount; 
            }
            set
            {
                _amount = value;    
            }
        }
        public bool IsPaymentPossible(double amount)
        {
            if ((amount < 0) || (amount > Amount))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void MakePayment(double payValue)
        {
            if ((payValue > 0) && (IsPaymentPossible(payValue)))
            {
                Amount -= payValue;
            }
        }
        public void AddMoney(double addMoney)
        {
            if (addMoney > 0)
            {
                Amount += addMoney;
            }
        }
    }
}
