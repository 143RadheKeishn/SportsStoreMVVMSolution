using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SportsStoreDomailLibrary.Abstract;
using SportsStoreDomailLibrary.Entities;
using System.Data.Entity;

namespace SportsStoreDomailLibrary.Concrete
{
   public class clsEFProductRepository : IProductRepository
   {
      clsSportsStoreDBContext _context;

      public clsEFProductRepository()
      {
         _context = new clsSportsStoreDBContext();
      }

      public async Task<Product> AddProductAsync(Product prod)
      {
         _context.Products.Add(prod);
         await _context.SaveChangesAsync();
         return prod;
      }

      public async Task DeleteProductAsync(int ProdId)
      {
         //if (_context.Products.FirstOrDefaultAsync(p => p.ProductId == ProdId))
         //{
         //   _context.Products.Remove(ProdId);
         //   await _context.SaveChangesAsync(); 
         //}
         //var Prod = _context.Products.FirstOrDefaultAsync(p => p.ProductId == ProdId);
         var prod = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == ProdId);
         if (prod != null)
         {
            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();
         }

      }

      public Task<List<Product>> GetProductAsync()
      {
         return _context.Products.ToListAsync();
      }

      public async Task<Product> GetProductAsync(int ProductId)
      {
         var Prod = _context.Products.FirstOrDefaultAsync(p => p.ProductId == ProductId);

         return await Prod;
      }

      public Task<List<Product>> GetProductByCategoryAsync(string CaetgoryName)
      {
         return  _context.Products.Where(p => p.Category == CaetgoryName).ToListAsync();
      }

      public async Task<Product> UpdateProductAsync(Product Prod)
      {
         if (!_context.Products.Local.Any(p => p.ProductId == Prod.ProductId))
            _context.Products.Attach(Prod);

         _context.Entry<Product>(Prod).State = EntityState.Modified;
         await _context.SaveChangesAsync();
         return Prod;
      }
   }
}
