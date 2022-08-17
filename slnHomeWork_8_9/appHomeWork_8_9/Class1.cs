using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHomeWork_8_9
{
    internal class Card : IPaymentMethod
    {
        private string _numb_cards = String.Empty;
        private string _sign = String.Empty;
        private double _amount = 0;


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

        public string NumberCards
        {
            get
            {
                return _numb_cards;
            }
            set
            {
                Int64 i;
                if ((value.Length != 16) || (Int64.TryParse(value, out i) == false))
                {
                    Console.WriteLine("Ошибка ввода имени карточки: Имя карточки должно быть более 3 символов.");
                    _numb_cards = "0000000000000000";
                }
                else
                {
                    _numb_cards = value;
                }
            }
        }

        public string Sign
        {
            get
            {
                return _sign;
            }
            set
            {
                _sign = value;
            }
        }

    }

}
