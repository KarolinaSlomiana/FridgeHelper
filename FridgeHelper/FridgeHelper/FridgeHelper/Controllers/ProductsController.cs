using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FridgeHelper.ContextModels;
using FridgeHelper.Helpers;
using FridgeHelper.Models;
using FridgeHelper.ViewModels;

namespace FridgeHelper.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDBContext _context;

        public ProductsController(ProductDBContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(bool showHistoric)
        {
            IEnumerable <Product> products = await _context.Products.Where(x => showHistoric || !x.IsHistoric ).ToListAsync();
            var groupingResult = products.GroupBy(x => x.Name);
            List<AggregatedProductViewModel> viewModels = new List<AggregatedProductViewModel>();
            foreach (var group in groupingResult)
            {
                Product productToMap = group.OrderBy(x=>x.ExpiryDate).First();
                AggregatedProductViewModel viewModel = new AggregatedProductViewModel
                {
                    Category = productToMap.Category,
                    IsOpen = group.Any(x => x.IsOpen),
                    Name = productToMap.Name,
                    Amount = group.Count(),
                    MinimumExpiryDate = productToMap.ExpiryDate
                };
                viewModels.Add(viewModel);
            }

            viewModels = viewModels.OrderBy(x => x.MinimumExpiryDate).ToList();
            return View(viewModels);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        
        public async Task<IActionResult> GetProductNameDetails(string name, bool showHistoric)
        {
            if (name == null)
            {
                return NotFound();
            }

            var products = await _context.Products.Where(x => (showHistoric || !x.IsHistoric) && x.Name == name).ToListAsync();
            var productDetailsViewModels = new List<ProductDetailsViewModel>();
            foreach (var product in products)
            {
                productDetailsViewModels.Add(ProductHelper.MapToProductDetailsViewModel(product));
            }
            
            return PartialView(productDetailsViewModels);
        }
        
        // GET: Products/Create
        public IActionResult Create(string name)
        {
            ProductDetailsViewModel viewModel = new ProductDetailsViewModel
            {
                Name = name,
                PurchaseDate = DateTime.Today
            };
            return View(viewModel);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("ProductId,Name,ExpiryDate,Category,ShelfNumber,CupboardName")]*/ ProductDetailsViewModel productDetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ProductHelper.MapToProduct(productDetailsViewModel));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productDetailsViewModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(ProductHelper.MapToProductDetailsViewModel(product));
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, /*[Bind("ProductId,Name,ExpiryDate,Category,ShelfNumber,CupboardName,Price")]*/ ProductDetailsViewModel viewModel)
        {
            if (id != viewModel.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Product product = ProductHelper.MapToProduct(viewModel);
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product = await _context.Products.FindAsync(id);
            product.IsHistoric = true;
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
