using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model.Interfaces;
using FlooringOrderingSystem.Model;

namespace FlooringOrderingSystem.Data
{
    public class ProductTestRepository : IProductRepository
    {
        private List<Product> _product = new List<Product>();

        public ProductTestRepository()
        {

            _product.Add(new Product
            {
                ProductType = "Tile",
                CostPerSquareFoot = 3.50m,
                LaborCostPerSquareFoot = 4.15m

            });

        }

        public Product ProductInformation(string product)
        {
            return _product.Find(p => p.ProductType == product);
        }

        public List<Product> RetrieveProducts()
        {
            return _product;
        }
    }
}
