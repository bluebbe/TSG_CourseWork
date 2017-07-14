using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model;

namespace FlooringOrderingSystem.UI.Output
{
    public static class DisplayIO
    {
        public static void DisplayOrderSummary(string date, Order order)
        {


                Console.Write(order.OrderNumber == 0 ? "New order" : $"{order.OrderNumber}"); 
                Console.WriteLine($" | {date}");
                Console.WriteLine($"{order.CustomerName}");
                Console.WriteLine($"{order.State}");
                Console.WriteLine($"Product : {order.ProductType}");
                Console.WriteLine($"MaterialCost : {order.MaterialCost}");
                Console.WriteLine($"Labor: {order.LaborCost}");
                Console.WriteLine($"Tax: {order.Tax}");
                Console.WriteLine($"Total: {order.Total}");
            
          
        }

        public static void DisplayProductsList(List<Product> products)
        {

            for (int item = 0; item < products.Count; item++)
            {
                Console.WriteLine($"{item} => {products[item].ProductType} - {products[item].LaborCostPerSquareFoot} - {products[item].CostPerSquareFoot}");

            }
        }
    }
}
