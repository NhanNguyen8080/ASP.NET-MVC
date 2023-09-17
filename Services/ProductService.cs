using MVC01.Models;

namespace MVC01.Services
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[]
            {
                new ProductModel() { Id = 1, Name = "Iphone X", Price = 1000 },
                new ProductModel() { Id = 2, Name = "Samsung abc", Price = 800 },
                new ProductModel() { Id = 3, Name = "Sonny xyz", Price = 500 },
                new ProductModel() { Id = 4, Name = "Nokia 1280", Price = 100 },

            });
        }
    }
}
