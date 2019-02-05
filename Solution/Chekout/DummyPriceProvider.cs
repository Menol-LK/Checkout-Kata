using Chekout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chekout
{
    class DummyPriceProvider : IPriceProvider
    {
        public int GetPrice(string item)
        {
            int price = 0;

            switch (item)
            {
                case "A":
                    price = 50;
                    break;
                case "B":
                    price = 30;
                    break;
                case "C":
                    price = 20;
                    break;
                case "D":
                    price = 15;
                    break;
                default:
                    break;
            }

            return price;
        }
    }
}
