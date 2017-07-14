using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringOrderingSystem.Data;

namespace FlooringOrderingSystem.BLL
{
    public static class TaxManagerFactory
    {
        public static TaxManager Create()
        {

            string taxMode = ConfigurationManager.AppSettings["taxMode"].ToString();
            string repositoryLocation = ConfigurationManager.AppSettings["respositoryFolder"].ToString();

            switch (taxMode)
            {
                case "Test":
                    return new TaxManager(new TaxTestRepository());
                case "Prod":
                    return new TaxManager(new TaxProdRepository(repositoryLocation));
                default:
                    throw new Exception("Tax Mode value in app config is not valid");
            }
        }
    }
}
