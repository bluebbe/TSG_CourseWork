using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model.Responses;
using FlooringOrderingSystem.Model;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.UI.Helper;

namespace FlooringOrderingSystem.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            string date;
            int order;
            Order editOrder = new Order() ;
           
            
            date = Input.OrderInformation.RequestingOrderDate(false);

           
            order = Input.OrderInformation.RequestOrderNumber();

            // If order exists (both condition are met), each piece of the order that can be
            // be editted will display one line at time.

            IndividualOrderResponse findIndResponse = OrderManagerFactory.Create().LocateOrder(date, order);
            if (findIndResponse.Success)
            {
                Order originalOrder = findIndResponse.Order;

                editOrder.Copy(originalOrder);

             
                Input.OrderInformation.RequestingCustomerName(editOrder, false);

                

                Input.OrderInformation.RequestingState(editOrder, false);


                Input.OrderInformation.RequestingProduct(editOrder, false);

            
            
                Input.OrderInformation.RequestingArea(editOrder, false);

                // if State, Product, or Area  are change, recalculate needs to be done.
                if (Validation.DoesEditedOrderNeedRecaluation(editOrder,originalOrder)) Calculation.Field(editOrder);

                
                Input.OrderInformation.RequestingToSaveOrder(date, editOrder);
               
            }
            else
            {
                Console.WriteLine(findIndResponse.Message);
                Console.ReadKey();
            }
        }
    }
}
