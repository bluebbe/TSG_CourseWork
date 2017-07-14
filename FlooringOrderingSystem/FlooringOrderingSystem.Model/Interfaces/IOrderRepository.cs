using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Model.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> RetrieveOrders(string orderDate);
        bool SaveOrder(string orderDate, Order order);
        Order RetrieveOneOrder(string orderDate, int orderNumber);
        bool DeleteOrder(string orderDate, int orderNumber);
        
    }
}
