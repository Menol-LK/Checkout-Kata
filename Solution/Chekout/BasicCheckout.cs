using Chekout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chekout
{
    public class BasicCheckout : ICheckout
    {
        readonly PricingEngine pricingEngine;

        public BasicCheckout()
        {
            var stratForA = new NForNPricingStrategy() { ApplicableItemType = "A", SetSize = 3, PriceForASet = 130 };
            var stratForB = new NForNPricingStrategy() { ApplicableItemType = "B", SetSize = 2, PriceForASet = 45 };

            pricingEngine = new PricingEngine(new IPricingStrategy[] { stratForA, stratForB });
        }

        public int GetTotalPrice()
        {
            return pricingEngine.GetTotal();
        }

        public void Scan(string item)
        {
            pricingEngine.AddItem(item);
        }

        public void NewSession()
        {
            pricingEngine.ClearItems();
        }
    }
}
