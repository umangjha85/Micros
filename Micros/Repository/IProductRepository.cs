using Micro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micro.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProductByID(int ProductId);
        public  void InsertProduct(Product product);
        public void DeleteProduct(int ProductId);
        public void UpdateProduct(Product product);
        void Save();
    }
}
