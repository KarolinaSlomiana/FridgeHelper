using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FridgeHelper.ViewModels
{
    public class ProductDetailsViewModel
    {
        public long ProductId { get; set; }

        public string Name { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string Category { get; set; }

        public int? ShelfNumber { get; set; }

        public string CupboardName { get; set; }

        public string SpecificName { get; set; }

        public decimal Price { get; set; }

        public DateTime PurchaseDate { get; set; }

        public bool IsOpen { get; set; }
    }
}
