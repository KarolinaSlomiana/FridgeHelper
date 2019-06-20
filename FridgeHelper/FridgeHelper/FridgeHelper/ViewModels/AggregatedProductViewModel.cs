using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeHelper.ViewModels
{
    public class AggregatedProductViewModel
    {
        public string Name { get; set; }

        public DateTime? MinimumExpiryDate { get; set; }

        public string Category { get; set; }

        public bool IsOpen { get; set; }

        public int Amount { get; set; }
    }
}
