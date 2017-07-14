using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model;
using FlooringOrderingSystem.Model.Responses;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.UI.Helper;
namespace FlooringOrderingSystem.UI.Workflows
{
    public class DisplayOrderWorkflow
    {
        private static string border = "******************************************************";


        public void Execute()
        {
            string date;
            do {
                Console.Clear();
                Console.Write("Enter Date <MM/DD/YYY>: ");
               
            } while (!Validation.OrderDateValidation(Console.ReadLine(), false, out date));

            OrderLookupResponse response = OrderManagerFactory.Create().LookupOrders(date);

            if (response.Success)
            {
                Console.Clear();

                foreach (var order in response.Orders)
                {
                    Console.WriteLine(border);

                    // information is pass into Display Method

                    Output.DisplayIO.DisplayOrderSummary(date, order);
                    Console.WriteLine(border);
                }
            }
            else Console.WriteLine(response.Message);
            Console.ReadKey();
            
        }
        
    }
}
