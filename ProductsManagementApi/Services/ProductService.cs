// Services/ProductService.cs
using ProductsManagementApi.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductsManagementApi.Services
{
    public class ProductService
    {
        private readonly string _filePath = "Data/products.json";

        public ProductService()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Product>>(jsonData);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var products = await GetAllProductsAsync();
            return products.FirstOrDefault(p => p.Id == id);
        }

        public async Task AddProductAsync(Product product)
        {
            var products = await GetAllProductsAsync();
            product.Id = products.Any() ? products.Max(p => p.Id) + 1 : 1;
            products.Add(product);
            await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(products));
        }

        public async Task UpdateProductAsync(Product product)
        {
            var products = await GetAllProductsAsync();
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(products));
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var products = await GetAllProductsAsync();
            var productToDelete = products.FirstOrDefault(p => p.Id == id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                await File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(products));
            }
        }
    }
}
