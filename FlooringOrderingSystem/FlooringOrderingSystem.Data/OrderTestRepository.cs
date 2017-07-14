using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model;
using FlooringOrderingSystem.Model.Interfaces;

namespace FlooringOrderingSystem.Data
{
    public class OrderTestRepository : IOrderRepository
    {
       
        private static Dictionary<string, List<Order>> _orders = new Dictionary<string, List<Order>>();
        private static bool loadFirstTime = true;

        public OrderTestRepository()
        {

            if (loadFirstTime)
            {
                Order order = new Order
                {

                    OrderNumber = 1,
                    CustomerName = "Wise",
                    State = "OH",
                    TaxRate = 6.25m,
                    ProductType = "Wood",
                    Area = 100.00m,
                    CostPerSquareFoot = 5.15m,
                    LaborCostPerSquare = 4.75m,
                    MaterialCost = 515.00m,
                    LaborCost = 475.00m,
                    Tax = 61.88m,
                    Total = 1051.88m

                };

                //_orders.Add(order);
                _orders.Add("06/01/2013", new List<Order> { order });
                loadFirstTime = false;
            }
        }

        public bool DeleteOrder(string orderDate, int orderNumber)
        {
            if (_orders.ContainsKey(orderDate))
            { 
                Order foundOrder = _orders[orderDate].Find(o => o.OrderNumber == orderNumber);
                if (foundOrder == null) return false;
                _orders[orderDate].Remove(foundOrder);
                if (_orders[orderDate].Count() == 0) _orders.Remove(orderDate);

                return true;

            }


            return false;
          

        }

        public Order RetrieveOneOrder(string orderDate, int orderNumber)
        {
            if (_orders.ContainsKey(orderDate))
            {
                Order retreived = _orders[orderDate].Find(o => o.OrderNumber == orderNumber);
                return retreived;
               
            }

            return null;
        }

        public List<Order> RetrieveOrders(string orderDate)
        {
            if (!_orders.ContainsKey(orderDate)) return null;

            return _orders[orderDate];
        }

        
        public bool SaveOrder(string orderDate, Order order)
        {
            if (_orders.ContainsKey(orderDate))
            {
                Order checkOrder = _orders[orderDate].Find(o => o.OrderNumber == order.OrderNumber);
                if (checkOrder != null)
                {

                    _orders[orderDate].Remove(checkOrder);
                    _orders[orderDate].Add(order);
                }
                else
                {

                    checkOrder = _orders[orderDate].OrderByDescending(o => o.OrderNumber).First();
                    order.OrderNumber = checkOrder.OrderNumber + 1;
                    _orders[orderDate].Add(order);
                }


            }
            else
            {
                order.OrderNumber = 1;
                _orders.Add(orderDate,new List<Order> { order });

            }

            
            return true;
        }

      


       


    }
}
