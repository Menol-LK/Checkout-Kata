using Chekout.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chekout
{
    public class PricingEngine
    {
        private List<string> allItems;
        private IEnumerable<IPricingStrategy> pricingStrategies;

        public PricingEngine(IEnumerable<IPricingStrategy> pricingStrategies)
        {
            this.pricingStrategies = pricingStrategies;
        }
        
        public void AddItem(string item)
        {
            if(allItems == null)
            {
                allItems = new List<string>();
            }

            allItems.Add(item);
        }

        public int GetTotal()
        {
            int total = 0;

            var itemTypes = allItems.Distinct();
            foreach (var itemType in itemTypes)
            {
                // use basic strategy if a special strategy is not assigned for this item type
                var pricingStrategy = pricingStrategies.SingleOrDefault(ps => ps.ApplicableItemType.Equals(itemType, StringComparison.OrdinalIgnoreCase));
                if(pricingStrategy == null)
                {
                    pricingStrategy = new BasicPricingStrategy() { ApplicableItemType = itemType }; // todo: reuse single instance
                }

                total += pricingStrategy.GetSubTotal(allItems);
            }

            return total;
        }

        public void ClearItems()
        {
            allItems?.Clear();
        }
    }
}
