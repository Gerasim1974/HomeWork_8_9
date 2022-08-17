using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHomeWork_8_9
{
    internal class Points : IPaymentMethod
    {
        private int _count_points = 0;
        private double _amount = 0;
        public bool IsPaymentPossible(double amount)
        {
            if (ConvertPointsToMoney() >= Amount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void MakePayment(double payValue)
        {
            Amount -= payValue;
            _count_points -= Convert.ToInt32(payValue/3);
            while (payValue % 3 > 0)
            {
                payValue++;
                _count_points--;    
            }
        }
        public void AddMoney(double addMoney)
        {
                Amount += addMoney;  
        }

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

        public bool IsPaymentPoints(double point)
        {
            if (point < CountPoints)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddPoints(int points)
        {
            CountPoints += points;
            AddMoney(ConvertPointsToMoney());
        }

        public void MakePoints(int points)
        {
            if ((CountPoints > points) && (ConvertPointsToMoney()<=Amount))
            {
                CountPoints -= points;
                MakePayment(ConvertPointsToMoney());
            }
        }

        public int CountPoints
        {
            get
            {
                return _count_points;
            }
            set
            {
                _count_points = value;
            }
        }

        //переводим баллы в рубли с точностью до копейки
        public double ConvertPointsToMoney()
        {
            double dPoint = Convert.ToDouble(CountPoints / 3);
            return Math.Round(dPoint, 2);
        }
    }
}
