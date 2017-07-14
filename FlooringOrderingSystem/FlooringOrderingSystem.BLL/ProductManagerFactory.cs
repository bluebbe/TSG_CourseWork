using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringOrderingSystem.Data;


namespace FlooringOrderingSystem.BLL
{
    public static class ProductManagerFactory
    {
        public static ProductManager Create()
        {

            string productMode = ConfigurationManager.AppSettings["productMode"].ToString();
            string repositoryLocation = ConfigurationManager.AppSettings["respositoryFolder"].ToString();

            switch (productMode)
            {
                case "Test":
                    return new ProductManager(new ProductTestRepository());
                case "Prod":
                    return new ProductManager(new ProductProdRepository(repositoryLocation));
                default:
                    throw new Exception("Product Mode value in app config is not valid");
            }
        }

    }
}
