﻿using Assignment.DM.Models;
public interface IProductRepository
{
   Task<IEnumerable<Product>> GetAllProductsAsync();
   Task<Product> GetProductByIdAsync(int id);
   Task<Product> CreateProductAsync(Product product);
   Task<Product> UpdateProductAsync(int id, Product product);
   Task<bool> DeleteProductAsync(int id);
}