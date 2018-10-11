using Moq;
using System;
using System.IO;
using WebShopApp.Core.Application_Service.Impl;
using WebShopApp.Core.Application_Service.Service;
using WebShopApp.Core.Domain_Service;
using WebShopApp.Core.Entity;
using WebShopApp.Infrastructure.Data.Repositories;
using Xunit;

namespace XUnitTestProject1
{
    public class ProductTest
    {


       
        [Fact]
        public void Test1()
        {
            IProductService prodRepo = new ProductService();
        }
    }
}
