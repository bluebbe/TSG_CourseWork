using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model.Responses;
using FlooringOrderingSystem.BLL;

namespace FlooringOrderingSystem.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            string date;
            int order;
            Console.Clear();
            Console.WriteLine("Please Enter the following information ");


            Console.Write("Order Date <MM/DD/YYY>: ");
            date = Console.ReadLine();

            Console.Write("Order Number : ");
            order = Convert.ToInt32(Console.ReadLine());


            string placeOrder = "";
            while (true)
            {
                Console.Clear();
                // Once caculations are completed (tax/product information), show summary with information 
                //Output.DisplayIO.DisplayOrderSummary();
                IndividualOrderResponse orderResponse = OrderManagerFactory.Create().LocateOrder(date, order);
                if (orderResponse.Success)
                {
                    Output.DisplayIO.DisplayOrderSummary(date, orderResponse.Order);

                    //Console.WriteLine("TODO: DisplySummary of Order BEFORE Removing to Respository");
                    Console.Write("Do you want to remove the order (Y/N): ");
                    placeOrder = Console.ReadLine();
                    switch (placeOrder)
                    {
                        case "Y":
                            //Saved order number for the next availabe order #
                            DeleteOrderResponse deleteOrder = OrderManagerFactory.Create().DeleteOrder(date, order);
                            Console.WriteLine($"Removing from repository: {deleteOrder.Success}");
                            Console.ReadKey();
                            return;
                        case "N":
                            Console.WriteLine($"You will not remove Order {order} from repository");
                            Console.ReadKey();
                            return;
                    }
                }
                else
                {
                    Console.WriteLine(orderResponse.Message);
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
