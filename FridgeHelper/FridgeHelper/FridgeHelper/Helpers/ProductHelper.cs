using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FridgeHelper.Models;
using FridgeHelper.ViewModels;

namespace FridgeHelper.Helpers
{
    public static class ProductHelper
    {
        public static ProductDetailsViewModel MapToProductDetailsViewModel(Product product)
        {
            ProductDetailsViewModel viewModel = new ProductDetailsViewModel
            {
                ExpiryDate = product.ExpiryDate,
                Name = product.Name,
                Category = product.Category,
                ShelfNumber = product.ShelfNumber,
                PurchaseDate = product.PurchaseDate,
                Price = product.Price,
                IsOpen = product.IsOpen,
                CupboardName = product.CupboardName,
                SpecificName = product.SpecificName,
                ProductId = product.ProductId,
            };
            return viewModel;
        }

        public static Product MapToProduct(ProductDetailsViewModel productDetailsViewModel)
        {
            Product product = new Product
            {
                ExpiryDate = productDetailsViewModel.ExpiryDate,
                Name = productDetailsViewModel.Name,
                Category = productDetailsViewModel.Category,
                ShelfNumber = productDetailsViewModel.ShelfNumber,
                PurchaseDate = productDetailsViewModel.PurchaseDate,
                Price = productDetailsViewModel.Price,
                IsOpen = productDetailsViewModel.IsOpen,
                CupboardName = productDetailsViewModel.CupboardName,
                SpecificName = productDetailsViewModel.SpecificName,
                ProductId = productDetailsViewModel.ProductId
            };
            return product;
        }
    }
}
