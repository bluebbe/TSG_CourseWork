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
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            Order newOrder = new Order();
            string orderDate;

            
            orderDate = Input.OrderInformation.RequestingOrderDate(true);


            Input.OrderInformation.RequestingCustomerName(newOrder,true);


            Input.OrderInformation.RequestingState(newOrder,true);

            
            Input.OrderInformation.RequestingProduct(newOrder,true);


            Input.OrderInformation.RequestingArea(newOrder,true);  
          
            
            Calculation.Field(newOrder);


            Input.OrderInformation.RequestingToSaveOrder(orderDate, newOrder);

        }

    }
}
