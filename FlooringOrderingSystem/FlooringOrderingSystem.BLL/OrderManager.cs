using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model.Interfaces;
using FlooringOrderingSystem.Model.Responses;
using System.Collections;
using FlooringOrderingSystem.Model;

namespace FlooringOrderingSystem.BLL
{
    public class OrderManager
    {
        private  IOrderRepository _orderRepository;
       

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;   
        }



        public OrderLookupResponse LookupOrders(string date)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Orders = _orderRepository.RetrieveOrders(date);
            
            if(response.Orders == null)
            {
                response.Success = false;
                response.Message = $"There was no orders made on {date}";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public SaveOrderResponse SaveOrder(string date, Order order)
        {
            SaveOrderResponse response = new SaveOrderResponse();


            if (!_orderRepository.SaveOrder(date, order))
            {
                response.Success = false;
                response.Message = $"Unable to save {order.OrderNumber} on {date}";
            } 
            else
            {
                response.Success = true;
            }


            return response;
        }

        public DeleteOrderResponse DeleteOrder(string date, int orderNumber)
        {
            DeleteOrderResponse response = new DeleteOrderResponse();


            if(!_orderRepository.DeleteOrder(date, orderNumber))
            {
                response.Success = false;
                response.Message = $"Failed to remove {orderNumber} on {date}";

            }
            else
            {
                response.Success = true;

            }



            return response;


        }
      
        public IndividualOrderResponse LocateOrder(string date, int orderNumber)
        {
            IndividualOrderResponse response = new IndividualOrderResponse();
            response.Order = _orderRepository.RetrieveOneOrder(date, orderNumber);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = $"Unable to locate Order #{orderNumber} on {date}";
            }
            else
            {
                response.Success = true;

            }

            return response;
        }
    }
}
