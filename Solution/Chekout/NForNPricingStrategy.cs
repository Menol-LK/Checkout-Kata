using Chekout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chekout
{
    public class NForNPricingStrategy : IPricingStrategy
    {
        public string ApplicableItemType { get; set; }
        public int SetSize { get; set; } 
        public int PriceForASet { get; set; }

        private static DummyPriceProvider dummyPriceProvider = new DummyPriceProvider();

        public int GetSubTotal(IEnumerable<string> allItems)
        {
            int unitPrice = dummyPriceProvider.GetPrice(ApplicableItemType);
            var noOfItemsOfThisType = allItems?.Count(item => item.Equals(ApplicableItemType, StringComparison.OrdinalIgnoreCase)) ?? 0;
            
            int subTotal = (noOfItemsOfThisType / SetSize) * PriceForASet; // price for complete sets
            subTotal += (noOfItemsOfThisType % SetSize) * unitPrice;  // price for any remaining items

            return subTotal;
        }
    }
}
