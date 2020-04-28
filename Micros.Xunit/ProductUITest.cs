
using Xunit;
using Moq;
using Micro.Controllers;
using Micro.Repository;
using Micro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Web.Mvc;
using System.Net;

namespace MicroXUnitTests
{
    public class ProductTest
    {
        [Fact]
        public void Get()
        {
            Product p = new Product()
            {
                Id = 1,
                Name = "Iphone",
                Price = 20000,
            };

            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            ProductController productController = new ProductController(productRepositoryMock.Object);
            productRepositoryMock.Setup(da => da.GetProductByID(p.Id)).Returns(p);
            IActionResult product= productController.Get(1);//product and datatype
            Assert.NotNull(product);
          
        }

        [Fact]
        public void Insert()
        {

            Product product = new Product()
            {
                Id = 1,
                Name = "Iphone",
                Price = 20000,
            };
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            ProductController productController = new ProductController(productRepositoryMock.Object);
            productRepositoryMock.Setup(da => da.InsertProduct(product));//not call yet
            IActionResult insert = productController.Post(product);
            Assert.NotNull(insert);
        }

        [Fact]
        public void Delete()
        {
            Product product = new Product()
            {
                Id = 1,
                Name = "Iphone",
                Price = 20000,
            };
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            ProductController productController = new ProductController(productRepositoryMock.Object);
            productRepositoryMock.Setup(da => da.DeleteProduct(product.Id));
            IActionResult delete = productController.Delete(product.Id);
            
        }

        [Fact]
        public void Update()
        {
            Product product = new Product()
            {
                Id = 1,
                Name = "Iphone",
                Price = 20000,
            };
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            ProductController productController = new ProductController(productRepositoryMock.Object);
            productRepositoryMock.Setup(da => da.UpdateProduct(product));
            IActionResult update = productController.Put(product);
            
        }



    }
}
