using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHomeWork_8_9
{
    public class Helicopter : Vehile, ITaxi
    {
        private byte _number_of_seats;
        public Helicopter(double fuelConsumption, string govermentNumber, byte numberOfSeats) : base(fuelConsumption, govermentNumber)
        {

            this.FuelConsumption = fuelConsumption;
            this.GovermentNumber = govermentNumber;
            NumberOfSeats = numberOfSeats;  
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

        public byte NumberOfSeats
        {
            get
            {
                return _number_of_seats;
            }
            set
            {
               _number_of_seats = value;
            }
        }

        public override string ToString()
        {
            string s = $"Расход топлива: {FuelConsumption} на 100 км" + Environment.NewLine +
                       $"Гос.Номер: {GovermentNumber}" + Environment.NewLine +
                       $"Количество пассажирских мест: {NumberOfSeats}";
            return s;
        }

        public override string NameVahil()
        {
            return "Вертолет";
        }

    }
}
