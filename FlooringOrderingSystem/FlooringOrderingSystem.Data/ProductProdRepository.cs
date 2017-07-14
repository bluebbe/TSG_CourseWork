using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlooringOrderingSystem.Model.Interfaces;
using FlooringOrderingSystem.Model;

namespace FlooringOrderingSystem.Data 
{
    public class ProductProdRepository : IProductRepository
    {
        private List<Product> _product = new List<Product>();
        private string _repositoryLocation;
        private string _productFile = "Products.txt";

        public ProductProdRepository(string repositoryLocation)
        {
            this._repositoryLocation = repositoryLocation;


            using (StreamReader sr = new StreamReader(_repositoryLocation + "\\" + _productFile))
            {
                sr.ReadLine();
                string line;

                Product product;
                while ((line = sr.ReadLine()) != null)
                {
                    product = new Product();

                    string[] columns = line.Split(',');

                    product.ProductType = columns[0];
                    product.CostPerSquareFoot = Convert.ToDecimal(columns[1]);
                    product.LaborCostPerSquareFoot = Convert.ToDecimal(columns[2]);

                    _product.Add(product);

                    
                }
                
            }
            
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
