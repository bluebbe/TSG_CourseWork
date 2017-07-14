using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Model.Responses;
using FlooringOrderingSystem.Model;

namespace FlooringOrderingSystem.Tests
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void RetrieveProductListTest()
        {
            ProductManager manager = ProductManagerFactory.Create();

            ProductListResponse response = manager.ProductsAvailable();

            Assert.IsNotNull(response.Products);

            Product product = response.Products.Find(p => p.ProductType == "Tile");

            Assert.AreEqual(product.ProductType, "Tile");

        }

        [Test]
        public void RetrieveProductInformationTest()
        {
            ProductManager manager = ProductManagerFactory.Create();

            ProductInformationResponse response = manager.ProductInformation("Tile");

            Assert.IsNotNull(response.Product);

            Product product = response.Product;
            Assert.AreEqual(product.ProductType, "Tile");

        }

    }
}
