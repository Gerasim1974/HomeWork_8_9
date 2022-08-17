using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHomeWork_8_9
{
    public class User
    {
        private Points _points = new Points();
        private Cash _cash = new Cash();
        private Card _card = new Card();
        private Dictionary<string, IPaymentMethod> _users = new Dictionary<string, IPaymentMethod>();
        private Dictionary<string, Card> _listCard = new Dictionary<string, Card>();
        private string _name;
        private string _surname;
        private string _phone_number;

        public User(string name, string surname, string phoneNumber, double cash)
        {
            if ((String.IsNullOrWhiteSpace(name)) ||
                 (String.IsNullOrWhiteSpace(surname)) ||
                 (String.IsNullOrWhiteSpace(phoneNumber))
                )
            {
                Name = name;
                Surname = surname;
                PhoneNumber = phoneNumber;
                {
                    TopUpCash(cash);
                    _users.Add("Cash", _cash);
                    _users.Add("Points", _points);
                    /*
                _users.Add("Card", _card);
                    */
                }
            }
            else
            {
                Console.WriteLine("Ошибочный идентификатор пользователя");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phone_number;
            }
            set
            {
                _phone_number = value;
            }
        }

        public void AddCard(string sign)
        {
            if (String.IsNullOrEmpty(sign))
            {
                Console.WriteLine("Карточка с пустым именем не может быть добавлена.");
            }
            else if (_users.ContainsKey(sign))
            {
                Console.WriteLine($"Карточка с именем {sign} уже добавлена.");
            }
            else
            {
                Card newCard = new Card();
                _listCard.Add(sign, newCard);
            }
        }

        public void TopUpCash(double amount)
        {
            _users["_cash"].AddMoney(amount);
        }
        public void TopUpCard(string sign, double amount)
        {
            if (_users.ContainsKey(sign))
            {
                if (amount > 0)
                {
                    _users[sign].AddMoney(amount);
                }
                else
                {
                    Console.WriteLine("Добавляемая сумма не является допустимой.");
                }
            }
            else
            {
                Console.WriteLine($"Карточки с именем <<{sign}>> не существует.");
            }
        }

        public void ShowAvailablePaymentMetods()
        {
            string s;
            s = "Вы можете оплатить поездку следующими способами:" + Environment.NewLine +
                $"1: Наличными деньгами. (у Вас {(_users["Cash"] as Cash).Amount} руб)" + Environment.NewLine +
                $"2: Баллами. (у Вас {(_users["Point"] as Points).Amount} руб)";
            //int i = 2;
            //foreach(var user in _users)
            //{
            //    if ((user.GetType()).Name == "Card")
            //    {
            //        i++;
            //        s = s + Environment.NewLine +
            //            $"{i}: Картой {(user as Card).Sign} (у Вас {(user as Card).Amount} руб))";

            //    }
            //}
            for (int i = 2; i < _users.Count; i++)
            {
                s = s + Environment.NewLine +
                    $"{i}: Картой {_users.ElementAt(i).Key} (у Вас {(_users.ElementAt(i).Value as Card).Amount} руб))";
            }
        }
        public string CardSign
        {
            get
            {
                return _card.Sign;
            }
        }

        public bool isCard(string signName)
        {
            bool f = false;
            foreach (var item in _listCard)
            {
                if (item.Key == signName)
                {
                    f = true;
                }
            }
            return f;
        }

        public void AddAmount(string signName, double addAmount)
        {
            for (int i = 0; i < _listCard.Count; i++)
            {
                var keyValuePair = _listCard.ElementAt(i);
                if (keyValuePair.Key == signName)
                {
                    keyValuePair.Value.AddMoney(addAmount);
                }
            }
        }

        public double AmountCash
        {
            get
            {
                return _cash.Amount;
            }
        }

        public double AmountPoints
        {
            get
            {
                return _points.Amount;
            }
        }
        public void AddPoint(int nPoint)
        {
            _points.AddPoints(nPoint);
        }

        public double AmountCard(string name)
        {
            double result = 0;
            for (int i = 0; i < _listCard.Count; i++)
            {
                var keyValuePair = _listCard.ElementAt(i);
                if (keyValuePair.Key == name)
                {
                    result = keyValuePair.Value.Amount;
                }
            }

            return result;
        }

        public bool VerifyPay(int idxPayement, string nameCard, double coast)
        {
            bool f = false;
            switch (idxPayement)
            {
                case 0:
                    f = _cash.IsPaymentPossible(coast);
                    break;
                case 1:
                    f = _points.IsPaymentPossible(coast);
                    break;
                case 2:
                    f = _listCard[nameCard].IsPaymentPossible(coast);
                    break;
            }
            return f;
        }

        public void ToPay(int idxPayement, string nameCard, double coast)
        {
            switch (idxPayement)
            {
                case 0:
                    _cash.MakePayment(coast);
                    break;
                case 1:
                    _points.MakePayment(coast);
                    break;
                case 2:
                    _listCard[nameCard].MakePayment(coast);
                    break;
            }
        }

        public int CountPoints
            {
             get
            {
                return _points.CountPoints;
            }
            }

    }
}
