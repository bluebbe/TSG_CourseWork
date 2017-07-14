using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model.Responses;

namespace FlooringOrderingSystem.Model.Interfaces
{
    public interface ISaveOrder
    {
        SaveOrderResponse SaveOrder(string date, Order order);
    }
}
