using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Model;
using FlooringOrderingSystem.Model.Responses;

namespace FlooringOrderingSystem.Tests
{
    [TestFixture]
    public class OrderTests
    {
        OrderManager manager = OrderManagerFactory.Create();

        [Test]
        public void CanRetrieveOrdersTest()
        {

            Order order = new Order
            {

                CustomerName = "Jack",
                State = "OH",
                ProductType = "Tile",
                Area = 100.00m

            };

            SaveOrderResponse response = manager.SaveOrder("01/04/2020", order);

            OrderLookupResponse response2 = manager.LookupOrders("01/04/2020");
            Assert.IsNotNull(response2.Orders);
         
            Assert.IsTrue(response2.Success);
            

        }

        
        [Test]
        public void CanAddOrderTest()
        {
            Order order = new Order
            {
                
                CustomerName = "West",
                State = "OH",
                ProductType = "Tile",
                Area = 100.00m
               
            };

          
            SaveOrderResponse response = manager.SaveOrder("01/02/2020", order);

            Assert.IsTrue(response.Success);

            IndividualOrderResponse response2 = manager.LocateOrder("01/02/2020", 1);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(response2.Order.OrderNumber, 1);
            

        }

        [Test]
        public void CanDeleteOrderTest()
        {
           
            DeleteOrderResponse response = manager.DeleteOrder("06/01/2013", 2);
            Assert.IsFalse(response.Success);

            response = manager.DeleteOrder("06/01/2013", 1);

            Assert.IsTrue(response.Success);



        }

    }
}
