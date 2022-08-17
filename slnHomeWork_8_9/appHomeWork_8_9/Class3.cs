using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHomeWork_8_9
{
    public class Motorbike : Vehile, ITaxi
    {
        private bool _is_sidecar = false; //с коляской или без   
        public Motorbike(double fuelConsumption, string govermentNumber, bool isSidecar) : base (fuelConsumption, govermentNumber)
        {
            this.FuelConsumption = fuelConsumption;
            this.GovermentNumber = govermentNumber;
            IsSidecar = isSidecar;  
        }
        public void MakeRide(User user)
        {
            Console.WriteLine($"{user.Name} {user.Surname} совершил поездку на автомобиле гос. № {this.GovermentNumber}");
        }

        public double GetPriceOfRide()
        {
            Random random = new Random();
            double coast = Math.Round(Convert.ToDouble(random.Next(100, 200) / random.Next(5, 90)), 2);
            return coast;
        }

        public bool IsSidecar
        {
            get
            { 
                return _is_sidecar; 
            }
            set
            {
                _is_sidecar = value; 
            }   

        }

        public override string ToString()
        {
            string s;
            if (IsSidecar)
            {
                s = "с коляской";
            } 
            else
            {
                s = "без коляски";
            }
            s = $"Расход топлива: {FuelConsumption} на 100 км" + Environment.NewLine +
                $"Гос.Номер: {GovermentNumber}" + Environment.NewLine +
                $"Количество дверей: {s}";
            return s;
        }

        public override string NameVahil()
        {
            return "Мотоцикл";
        }

    }
}
