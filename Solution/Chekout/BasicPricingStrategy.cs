using Chekout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chekout
{
    class BasicPricingStrategy : IPricingStrategy
    {
        public string ApplicableItemType { get; set; }

        public int GetPrice(string[] allItems)
        {
            return allItems.Where(item => item.Equals(ApplicableItemType, StringComparison.OrdinalIgnoreCase)).Sum(item => /* get item price */);
        }
    }
}
