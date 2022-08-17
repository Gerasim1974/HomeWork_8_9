using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHomeWork_8_9
{
    public class Car : Vehile, ITaxi
    {
        private byte _number_of_doors;
        public Car(double fuelConsumption, string govermentNumber, byte numberOfDoors) : base(fuelConsumption, govermentNumber)
        {

            this.FuelConsumption = fuelConsumption;
            this.GovermentNumber = govermentNumber;
            NumberOfDoors = numberOfDoors;  
        }


        public void MakeRide(User user)
        {
            Console.WriteLine($"{user.Name} {user.Surname} совершил поездку на автомобиле гос. № {this.GovermentNumber}");
        }


        public byte NumberOfDoors
        {
            get
            {
                return _number_of_doors;
            }
            set
            {
                if (value < 2)
                {
                    _number_of_doors = 2;
                }
                else if (value > 5)
                {
                    _number_of_doors = 5;
                }
                else
                {
                    _number_of_doors = value;
                }
            }

        }

        public override string ToString()
        {
            string s = $"Расход топлива: {FuelConsumption} на 100 км" + Environment.NewLine +
                       $"Гос.Номер: {GovermentNumber}" + Environment.NewLine +
                       $"Количество : {NumberOfDoors}";
            return s;
        }

        public override string NameVahil()
        {
            return "Легковой автомобиль";
        }


    }
}
