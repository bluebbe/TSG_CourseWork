using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Model.Responses;
using FlooringOrderingSystem.Model;

namespace FlooringOrderingSystem.UI.Workflows
{
    public static class Calculation
    {
        public static void Field(Order order)

        {
            TaxLookUpResponse taxResponse = TaxManagerFactory.Create().TaxLookUp(order.State);
            ProductInformationResponse productResponse = ProductManagerFactory.Create().ProductInformation(order.ProductType);
            

            order.TaxRate = Math.Round(taxResponse.TaxInformation.TaxRate,2);
            order.CostPerSquareFoot = Math.Round(productResponse.Product.CostPerSquareFoot,2);
            order.LaborCostPerSquare = Math.Round(productResponse.Product.LaborCostPerSquareFoot,2);


            order.MaterialCost = Math.Round(order.Area * order.CostPerSquareFoot,2);
            order.LaborCost = Math.Round(order.Area * order.LaborCostPerSquare,2);

            order.Tax = Math.Round(((order.MaterialCost + order.LaborCost) * (order.TaxRate / 100)),2);
            order.Total = Math.Round((order.MaterialCost + order.LaborCost + order.Tax),2);
        }
    }
}
