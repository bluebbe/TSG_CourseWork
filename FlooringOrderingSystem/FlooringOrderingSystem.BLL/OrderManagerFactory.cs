using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringOrderingSystem.Data;

namespace FlooringOrderingSystem.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string orderMode = ConfigurationManager.AppSettings["orderMode"].ToString();
            string repositoryLocation = ConfigurationManager.AppSettings["respositoryFolder"].ToString();
            switch (orderMode)
            {
                case "Test":
                    return new OrderManager(new OrderTestRepository());
                case "Prod":
                    return new OrderManager(new OrderProdRepository(repositoryLocation));
                default:
                    throw new Exception("Order Mode value in app config is not valid");
            }

        }
    }
}
