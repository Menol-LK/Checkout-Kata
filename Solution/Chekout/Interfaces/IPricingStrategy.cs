using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chekout.Interfaces
{
    interface IPricingStrategy
    {
        string ApplicableItemType { get; set; }

        int GetSubTotal(IEnumerable<string> allItems);  
    }
}
