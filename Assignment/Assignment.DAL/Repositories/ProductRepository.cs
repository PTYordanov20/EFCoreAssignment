using Assignment.DAL.Interfaces;
using Assignment.DM.Models;

public class ProductRepository : IProductRepository
{
   private readonly List<Product> _products = new()
   {
       new Product { ProductId = 1, CategoryId = 1, Name = "Smartphone", Price = 699.99m, Stock = 30, Description = "128GB Smartphone" },
       new Product { ProductId = 2, CategoryId = 2, Name = "Office Chair", Price = 120.00m, Stock = 50, Description = "Ergonomic office chair" }
   };
   public Task<IEnumerable<Product>> GetAllProductsAsync() => Task.FromResult((IEnumerable<Product>)_products);
   public Task<Product> GetProductByIdAsync(int id) => Task.FromResult(_products.FirstOrDefault(p => p.ProductId == id));
   public Task<Product> CreateProductAsync(Product product)
   {
       product.ProductId = _products.Max(p => p.ProductId) + 1;
       _products.Add(product);
       return Task.FromResult(product);
   }
   public Task<Product> UpdateProductAsync(int id, Product product)
   {
       var existingProduct = _products.FirstOrDefault(p => p.ProductId == id);
       if (existingProduct == null) return Task.FromResult<Product>(null);
       existingProduct.Name = product.Name;
       existingProduct.Price = product.Price;
       existingProduct.Stock = product.Stock;
       existingProduct.Description = product.Description;
       return Task.FromResult(existingProduct);
   }
   public Task<bool> DeleteProductAsync(int id)
   {
       var product = _products.FirstOrDefault(p => p.ProductId == id);
       if (product == null) return Task.FromResult(false);
       _products.Remove(product);
       return Task.FromResult(true);
   }
}