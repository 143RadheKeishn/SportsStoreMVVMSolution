using SportsStoreDomailLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStoreDomailLibrary.Abstract
{
   public interface IProductRepository
   {
      Task<List<Product>> GetProductAsync();

      Task<List<Product>> GetProductByCategoryAsync(string CaetgoryName);

      Task<Product> GetProductAsync(int ProductId);

      Task<Product> AddProductAsync(Product prod);

      Task<Product> UpdateProductAsync(Product Prod);

      Task DeleteProductAsync(int ProdId);
   }
}
