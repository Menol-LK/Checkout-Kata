using Chekout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chekout
{
    public class BasicPricingStrategy : IPricingStrategy
    {
        public string ApplicableItemType { get; set; }

        public int GetSubTotal(IEnumerable<string> allItems)
        {
            var priceProvider = new DummyPriceProvider();

            return allItems?.Where(item => item.Equals(ApplicableItemType, StringComparison.OrdinalIgnoreCase))?.Sum(item => priceProvider.GetPrice(item)) ?? 0;
        }
    }
}
