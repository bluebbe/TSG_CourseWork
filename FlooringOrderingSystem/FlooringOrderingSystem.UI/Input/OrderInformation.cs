using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model;
using FlooringOrderingSystem.UI.Helper;
using FlooringOrderingSystem.Model.Responses;
using FlooringOrderingSystem.BLL;

namespace FlooringOrderingSystem.UI.Input
{
    public static class OrderInformation
    {
        public static string RequestingOrderDate(bool acceptOnlyFutureDates)
        {
            string orderDate;
            
            do
            {
                Console.Clear();
                Console.WriteLine("Please Enter the following information ");

                Console.Write("Order Date <MM/DD/YYY>: ");

            } while (!Validation.OrderDateValidation(Console.ReadLine(), acceptOnlyFutureDates, out orderDate));

            return orderDate;
        }



        public static int RequestOrderNumber()
        {
            Console.Clear();
            Console.Write("Order Number : ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static void RequestingCustomerName(Order order, bool newOrder)
        {

            string originalCustomer = order.CustomerName;

            do
            {

                Console.Write(!newOrder ? $"Enter customer name ({originalCustomer}) :" : "Customer Name : ");
                order.CustomerName = Console.ReadLine();
                if (!newOrder ? string.IsNullOrEmpty(order.CustomerName) : false) break;
            } while (!Validation.CustomerNameValidation(order.CustomerName));
            if (!newOrder ? string.IsNullOrEmpty(order.CustomerName) : false) order.CustomerName = originalCustomer;

            
        }

        public static void RequestingState(Order order, bool newOrder)
        {

            //Entered states must be checked against the tax file. If the state does not exist in the
            //tax file we cannot sell there.If a state is added to the tax file it should be allowed without
            //changing the application code.


            string originalState = order.State;
            do
            {
                Console.Write(!newOrder ? $"Enter State ({originalState})" : "State : "  );
                order.State = Console.ReadLine();
                if (!newOrder ? string.IsNullOrEmpty(order.State) : false) break;

            } while (!Validation.StateValidation(order.State));
            if (!newOrder ? string.IsNullOrEmpty(order.State) : false) order.State = originalState;

        }

        public static void RequestingProduct(Order order, bool newOrder)
        {
            //Show a list of available products and pricing information to choose from. Again,
            //if a product is added to the file it should show up in the application without a code change.


            string originalProduct = order.ProductType;

            ProductListResponse productResponse = ProductManagerFactory.Create().ProductsAvailable();
            List<Product> products = productResponse.Products;

            int productNumber = -1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(!newOrder ? "Select Number to Replace Current Product Type\n" :
                    "Select Number for Which Product Type\n");

                Output.DisplayIO.DisplayProductsList(products);

                Console.Write(!newOrder ? $"\nEnter Product Type #({originalProduct})" :
                    "\nProduct Type (#): ");
                string selectedNumber = Console.ReadLine();
                
                if(!newOrder ? selectedNumber == "" : false)
                {
                    order.ProductType = originalProduct;
                    break;
                }


                if (!int.TryParse(selectedNumber, out productNumber))
                {
                    continue;
                }

                if (0 <= productNumber && productNumber <= (products.Count - 1))
                {
                    order.ProductType = products[productNumber].ProductType;
                    break;

                }

            }

        }

        public static void RequestingArea(Order order, bool newOrder)
        {
            // The area must be a positive decimal. Minimum order size is 100 sq ft.
            decimal result = 0;
            string input;
            decimal originalArea = order.Area;
            do
            {
                Console.Write(!newOrder ? $"Enter Area ({originalArea})" : "Area : ");
                input = Console.ReadLine();
                if (!newOrder ? string.IsNullOrEmpty(input) : false ) break;

            } while (!Validation.AreaValidation(input, out result));
            if(string.IsNullOrEmpty(input))
            {
                order.Area = originalArea;

            }
            else order.Area = result;
        }

        public static void RequestingToSaveOrder(string orderDate,Order order)
        {
            string placeOrder = "";
            while (true)
            {
                Console.Clear();

                Output.DisplayIO.DisplayOrderSummary(orderDate, order);

                Console.Write("Do you want to save this order (Y/N): ");

                switch (placeOrder = Console.ReadLine())
                {
                    case "Y":
                        //Saved order number for the next availabe order #


                        SaveOrderResponse response = OrderManagerFactory.Create().SaveOrder(orderDate, order);
                        Console.WriteLine("Saving to repository: {0}", response.Success ? "Successful" : "Failed");
                        Console.ReadKey();
                        return;
                    case "N":
                        Console.WriteLine("You Didn't save the new order to repository");
                        Console.ReadKey();
                        return;
                }

            }
        }
    }
}
