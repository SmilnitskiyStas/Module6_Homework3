using Books_Shop.Entities;
using Books_Shop.Interfaces;

namespace Books_Shop.Infrastructura
{
    public class MemoryDataProvider : IDataProvider
    {
        private List<Product> _data = new List<Product>() 
        { 
        };

        public void CreateProduct(Product product)
        {
            _data.Add(product);
        }

        public void DeleteProductById(int id)
        {
            _data.Remove(GetProductById(id));
        }

        public Product[] GetAllProducts()
        {
            return _data.ToArray();
        }

        public Product GetProductById(int id)
        {
            return _data.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(Product product)
        {
            Product existingProduct = _data.FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Title = product.Title;
                existingProduct.Author = product.Author;
                existingProduct.DateOfCreate = product.DateOfCreate;
                existingProduct.Price = product.Price;
            }
        }
    }
}
