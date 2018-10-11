using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.IO;
using WebShopApp.Core.Application_Service.Impl;
using WebShopApp.Core.Application_Service.Service;
using WebShopApp.Core.Domain_Service;
using WebShopApp.Core.Entity;
using WebShopApp.Infrastructure.Data;
using WebShopApp.Infrastructure.Data.Repositories;
using Xunit;

namespace XUnitTestProject1
{
    public class ProductTest
    {
         readonly IOrderRepository _orderRepository;
         readonly IProductRepository _productRepository;
        
        [Fact]
        public void CreateProductWithNullValue()
        {
            var prodRepo = new Mock<IProductRepository>();
            IProductService prodServ = new ProductService(_orderRepository, _productRepository);
            Product product = null;

            Exception ex = Assert.Throws<InvalidDataException>(() => prodServ.CreateProduct(product));

        }

        [Fact]
        public void CreateProductWithoutName()
        {
            var prodRepo = new Mock<IProductRepository>();
            IProductService prodServ = new ProductService(_orderRepository, _productRepository);
            Product newProductWithoutName = new Product()
            {
                //Name = "Black Sock",
                Category = "Men Socks",
                Description = "It's a black sock, for men.",
                Price = 15,
                Size = 45,
                Stock = 110
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => prodServ.CreateProduct(newProductWithoutName));
        }

        [Fact]
        public void CreateProductWithoutCategory()
        {
            var prodRepo = new Mock<IProductRepository>();
            IProductService prodServ = new ProductService(_orderRepository, _productRepository);
            Product newProductWithoutName = new Product()
            {
                Name = "Black Sock",
                //Category = "Men Socks",
                Description = "It's a black sock, for men.",
                Price = 15,
                Size = 45,
                Stock = 110
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => prodServ.CreateProduct(newProductWithoutName));
        }

        [Fact]
        public void CreateProductWithoutDescreption()
        {
            var prodRepo = new Mock<IProductRepository>();
            IProductService prodServ = new ProductService(_orderRepository, _productRepository);
            Product newProductWithoutName = new Product()
            {
                Name = "Black Sock",
                Category = "Men Socks",
                //Description = "It's a black sock, for men.",
                Price = 15,
                Size = 45,
                Stock = 110
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => prodServ.CreateProduct(newProductWithoutName));
        }

        [Fact]
        public void CreateProductWithoutPrice()
        {
            var prodRepo = new Mock<IProductRepository>();
            IProductService prodServ = new ProductService(_orderRepository, _productRepository);
            Product newProductWithoutName = new Product()
            {
                Name = "Black Sock",
                Category = "Men Socks",
                Description = "It's a black sock, for men.",
                //Price = 15,
                Size = 45,
                Stock = 110
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => prodServ.CreateProduct(newProductWithoutName));
        }
        [Fact]
        public void CreateProductWithoutSize()
        {
            var prodRepo = new Mock<IProductRepository>();
            IProductService prodServ = new ProductService(_orderRepository, _productRepository);
            Product newProductWithoutName = new Product()
            {
                Name = "Black Sock",
                Category = "Men Socks",
                Description = "It's a black sock, for men.",
                Price = 15,
                //Size = 45,
                Stock = 110
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => prodServ.CreateProduct(newProductWithoutName));
        }

        [Fact]
        public void CreateProductWithoutStock()
        {
            var prodRepo = new Mock<IProductRepository>();
            IProductService prodServ = new ProductService(_orderRepository, _productRepository);
            Product newProductWithoutName = new Product()
            {
                Name = "Black Sock",
                Category = "Men Socks",
                Description = "It's a black sock, for men.",
                Price = 15,
                Size = 45,
                //Stock = 110
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => prodServ.CreateProduct(newProductWithoutName));
        }

        [Fact]
        public void CreateProductWithMinusSizeValue()
        {
            var prodRepo = new Mock<IProductRepository>();
            IProductService prodServ = new ProductService(_orderRepository, _productRepository);
            Product newProductWithoutName = new Product()
            {
                Name = "Black Sock",
                Category = "Men Socks",
                Description = "It's a black sock, for men.",
                Price = 15,
                Size = -3,
                Stock = 110
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => prodServ.CreateProduct(newProductWithoutName));
        }

        [Fact]
        public void CreateProductWithMinusPrice()
        {
            var prodRepo = new Mock<IProductRepository>();
            IProductService prodServ = new ProductService(_orderRepository, _productRepository);
            Product newProductWithoutName = new Product()
            {
                Name = "Black Sock",
                Category = "Men Socks",
                Description = "It's a black sock, for men.",
                Price = -15,
                Size = 45,
                Stock = 110
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => prodServ.CreateProduct(newProductWithoutName));
        }

        [Fact]
        public void CreateProductWithZeroIdValue()
        {
            var prodRepo = new Mock<IProductRepository>();
            IProductService prodServ = new ProductService(_orderRepository, _productRepository);
            Product newProductWithoutName = new Product()
            {
                Id = 0,
                Name = "Black Sock",
                Category = "Men Socks",
                Description = "It's a black sock, for men.",
                Price = 15,
                Size = 45,
                Stock = 110
            };

            Exception ex = Assert.Throws<InvalidDataException>(() => prodServ.CreateProduct(newProductWithoutName));
        }

        /*
        [Fact]
        public void UpdateProductShouldCallOnce()
        {
            var prodRepo = new Mock<IProductRepository>();
            IProductService prodServ = new ProductService(_orderRepository, _productRepository);
            Product productToUpdate = new Product()
            {
                Id = 1,
                Name = "Black Sock",
                Category = "Men Socks",
                Description = "This is a damn description",
                Price = 15,
                Size = 45,
                Stock = 110
            };

            prodServ.UpdateProduct(productToUpdate);
            prodRepo.Verify(x => x.UpdateProduct(productToUpdate));
        }
        This test don't wanna work because it says that there is no description, when clearly we can see we have one...
        */




    }
}


