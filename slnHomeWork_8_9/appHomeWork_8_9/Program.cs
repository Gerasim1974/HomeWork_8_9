namespace appHomeWork_8_9
{
    internal class Program
    {
        static List<ITaxi> Taxi = new List<ITaxi>();
        static User user1;
        static void Main(string[] args)
        {
            Car car1 = new Car(7.8d, "МН4020", 4);
            Taxi.Add(car1);
            Helicopter hel1 = new Helicopter(17.5d, "МО2034", 7);
            Taxi.Add(hel1);
            Motorbike bike1 = new Motorbike(5.2d, "МБ1245", true);
            Taxi.Add(bike1);

            user1 = new User("Петр", "Иванов", "375-29-345-67-89", 70d);

            string menu = "1 - добавить карту, 2 - Пополнить карту, 3 - совершить поездку, 0 - выход";
            char keyChar;

            do
            {
                Console.WriteLine(menu);
                keyChar = Console.ReadKey().KeyChar;
                switch (keyChar)
                {
                    case '1':
                        Console.WriteLine("Введите наименование платежной карточки:");
                        user1.AddCard(Console.ReadLine());
                        break;
                    case '2':
                        string sCard;
                        Console.WriteLine("Введите имя карточки,которую нужно пополнить:");
                        sCard = Console.ReadLine();
                        if (user1.isCard(sCard))
                        {
                            Console.WriteLine("Введите сумму, на которую нужно пополнить карту:");
                            double addToAmount;
                            addToAmount = Convert.ToDouble(Console.ReadLine());
                            user1.AddAmount(sCard, addToAmount);
                        }
                        else
                        {
                            Console.WriteLine($"Платёжная карта <<{sCard}>> отсутствует в списке доступных");
                        }
                        break;
                    case '3':
                        Print();
                        Console.WriteLine("Введите порядковый номер транспорта");
                        Console.WriteLine("1 - автомобиль, 2 - вертолет, 3 - мотоцикл");
                        int numbVehile = Convert.ToByte(Console.ReadLine())-1;
                        byte numbTypePay = NumbTypePay();
                        string signCard = String.Empty;
                        if (numbTypePay == 2)
                        {
                            Console.WriteLine("Введите имя карточки с которой производится оплата:");
                            signCard = Console.ReadLine();
                        }
                        double coast = Taxi[numbVehile].GetPriceOfRide();
                        Console.WriteLine($"Сумма к оплате: {coast} руб.");
                        if (user1.VerifyPay(numbTypePay, signCard, coast))
                        {
                            ToPay(numbTypePay, signCard, coast);//оплачиваем и добавляем баллы
                            Taxi[numbVehile].MakeRide(user1);
                            Console.WriteLine($"Количество баллов после поездки: {user1.CountPoints}");
                        }
                        break;
                }
            } while (keyChar != '0');
            Console.WriteLine("Hello, World!");
        }

        public static string Print()
        {
            string s = String.Empty;
            for (int i = 0; i < Taxi.Count; i++)
            {
                var keyValuePair = Taxi.ElementAt(i);
                {
                    if (s.Length > 0)
                    {
                        s += Environment.NewLine;
                    }

                    s += $"{i} - {(keyValuePair as Vehile).NameVahil} {(keyValuePair as Vehile).ToString()}";
                }
            }
            return s;
        }

        public static byte NumbTypePay()
        {
            string s = "1 - наличные деньги" + Environment.NewLine +
                       "2 - баллы" + Environment.NewLine+
                       "3 - карточка ";
            Console.WriteLine(s);
            byte bType = Convert.ToByte(Console.ReadLine());
            bType--;
            return bType;
        }

        public static void ToPay(byte idxPay, string nameCard, double coast)
        {
            user1.ToPay(idxPay, nameCard, coast);
            user1.AddPoint(5);
        }
    }
}