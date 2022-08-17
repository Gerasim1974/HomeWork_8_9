using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHomeWork_8_9
{
    public class Vehile
    {
        private double _fuel_consumption = 0;
        private string _goverment_number = String.Empty;
        private double fuelConsumption;
        private string govermentNumber;

        public Vehile(double fuelConsumption, string govermentNumber)
        {
           FuelConsumption = fuelConsumption;   
           GovermentNumber = govermentNumber;
        }

        public double FuelConsumption
        {
            get
            {
               return _fuel_consumption;    
            }
            set
            {
              _fuel_consumption = value;    //пока без проверок
            }
        }
        public string GovermentNumber
        {
            get
            {
                return _goverment_number;
            }
            set
            {
                _goverment_number = value;
            }
        }

        public virtual string NameVahil() 
        {
            return String.Empty;
        }

        public virtual double GetPriceOfRide()
        {
            Random random = new Random();
            double coast = Math.Round(Convert.ToDouble(random.Next(100, 200) / random.Next(5, 90)), 2);
            return coast;
        }
    }
}
