using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FridgeHelper.Models
{
    public class Product
    {
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public bool IsHistoric { get; set; }
    }
}
