using System.Text.Json;
using Dsw2025Ej14.API.Domain;
namespace Dsw2025Ej14.API.Data
{
    public class PersistenciaEnMemoria : IPersistencia; 
    {
        private List<Product> _products = [];

        public PersistenciaEnMemoria()
        {
            LoadProducts();
        }

        private LoadProducts()
        {
            var json = File.ReadAllTextAsync("Daproducts.json");
            _products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public List<Product> GetActiveProducts() =>
            _products.Where(p => p.IsActive).ToList();

        public Product? GetBySku(string sku) =>
            _product.FirstOrDefault(p => p.Sku.Equals(sku, StringComparison.OrdinalIgnoreCase));

    }
}
