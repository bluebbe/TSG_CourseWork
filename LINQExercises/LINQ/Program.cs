using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            //Exercise1(); // -- Verified
            //Exercise2(); // -- Verified
            //Exercise3(); // -- Verified
            //Exercise4(); // -- Verified
            //Exercise5(); // -- Verified
            //Exercise6(); // -- Verified
            //Exercise7(); // -- Verified
            //Exercise8(); // -- Verified
            //Exercise9(); // -- Verified
            //Exercise10(); // -- Verified
            //Exercise11(); // -- Verified
            //Exercise12(); // -- Verified  
            //Exercise13(); // -- Verified
            //Exercise14(); // -- Verified
            //Exercise15(); // -- Verified
            //Exercise16(); // -- Verified
            //Exercise17(); // -- Verified
            //Exercise18(); // -- Verified
            //Exercise19(); // -- Verified
            //Exercise20(); // -- Verified
            //Exercise21(); // -- Verified
            //Exercise22(); // -- Verified
            //Exercise23(); // -- Verified
            //Exercise24(); // -- Verified
            //Exercise25(); // -- Verified
            //Exercise26(); // -- Verified
            //Exercise27(); // -- Verified
            //Exercise28(); // -- Verified
            //Exercise29(); // -- Verified
            //Exercise30(); // -- Verified
            //Exercise31(); // -- Verified

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,7:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();

            var filitered = products.Where(product => product.UnitsInStock == 0);
            PrintProductInformation(filitered);

        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();

            var filitered = products.Where(product => product.UnitsInStock != 0 && product.UnitPrice > 3M);
            PrintProductInformation(filitered);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {

            List<Customer> customers = DataLoader.LoadCustomers();

            var filitered = customers.Where(info => info.Region == "WA");
            PrintCustomerInformation(filitered);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var productNames = from p in DataLoader.LoadProducts()
                              select new { p.ProductName };

            foreach(var productName in productNames)
            {

                Console.WriteLine(productName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            //IncreasedUnitPrice = (Unit Price * 25%) + Unit Price
            var productNames = from p in DataLoader.LoadProducts()
                               select new { p.ProductName,p.UnitPrice ,IncreasedUnitPrice = p.UnitPrice * 1.25M };

            foreach (var productName in productNames)
            {

                Console.WriteLine(productName);

            }
        }
            /// <summary>
            /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
            /// </summary>
            static void Exercise6()
        {
            var productNameandCategories = from p in DataLoader.LoadProducts()
                                         select new { ProductName = p.ProductName.ToUpper(),
                                                        Category = p.Category.ToUpper() };


            foreach (var productNameandCategory in productNameandCategories)
            {

                Console.WriteLine(productNameandCategory);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {

           
            var productNames = from p in DataLoader.LoadProducts()
                               select new { p.ProductName, p.UnitsInStock  , ReOrder = (p.UnitsInStock < 3) ? true : false  };

            foreach (var productName in productNames)
            {

                Console.WriteLine(productName);

            }

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {

            var productNames = from p in DataLoader.LoadProducts()
                               select new { p.ProductName, p.UnitsInStock, p.UnitPrice , StockValue = p.UnitPrice * p.UnitsInStock };

            foreach (var productName in productNames)
            {

                Console.WriteLine(productName);

            }

        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var evenNumbersInA = from numbers in DataLoader.NumbersA
                                 where (numbers % 2 == 0)
                                 select numbers;


            foreach (var evenNumber in evenNumbersInA)
            {

                Console.WriteLine(evenNumber);

            }


        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            

            List<Customer> customersLess500 = customers.Where(orders => orders.Orders.Any(order => order.Total < 500)).ToList();


            PrintCustomerInformation(customersLess500);
            
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            int[] numbers = DataLoader.NumbersC;


            var numbersFirstOdd = numbers.Where(n => n % 2 != 0).Take<int>(3);

            foreach (var result in numbersFirstOdd)
            {
                Console.WriteLine(result);

            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            int[] numbers = DataLoader.NumbersB;
            
            foreach (var number in numbers.Skip(3))
            {
                Console.WriteLine(number);

            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            List<Customer> customers = DataLoader.LoadCustomers();


            var orders = customers.Where(s => s.Region == "WA")
                                  .Select(p => new { p.CompanyName ,
                                      (p.Orders).OrderByDescending(h=>h.OrderDate)
                                                .First()
                                                .OrderID});
                
            

            foreach (var order in orders)
            {
                Console.WriteLine($"Company: {order.CompanyName}, Most recent order: {order.OrderID}");

            }
                
          
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            int[] numbers = DataLoader.NumbersC;


            foreach (int number in numbers.TakeWhile(n => !(n >= 6)))
            {
                Console.WriteLine(number);

            }

        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            int[] numbers = DataLoader.NumbersC;


            foreach (int number in numbers.SkipWhile(n => !(n % 3 == 0)).Skip(1))
            {
                Console.WriteLine(number);

            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {

            List<Product> products = DataLoader.LoadProducts();

            var filtered = products.OrderBy(nameOfProduct => nameOfProduct.ProductName);
        
            PrintProductInformation(filtered);
            

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();

            var filtered = products.OrderByDescending(unit=>unit.UnitsInStock);

            PrintProductInformation(filtered);
            

        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> products = DataLoader.LoadProducts();

            var filtered = products.OrderBy(cat => cat.Category).ThenByDescending(p => p.UnitPrice);

            PrintProductInformation(filtered);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            int[] numbers = DataLoader.NumbersB;

            foreach (int number in numbers.Reverse())
            {

                Console.WriteLine(number);
            }

        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            List<Product> products = DataLoader.LoadProducts();

            var filtered = products.Select(o => new { o.Category, o.ProductName })
                                    .GroupBy(cat => cat.Category);

            foreach (var group in filtered)
            {
                Console.WriteLine(group.Key);

               foreach (var product in group)
                {

                    Console.WriteLine(product.ProductName);
                }


                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var filtered = customers.Select(o => new {o.CompanyName,o.Orders});

            foreach (var customer in filtered)
            {
                Console.WriteLine(customer.CompanyName);
                int year = 0;

                foreach (var order in customer.Orders.ToArray())
                {

                    if (year != order.OrderDate.Year)
                    {
                        Console.WriteLine(order.OrderDate.Year);
                        year = order.OrderDate.Year;
                    }

                        Console.WriteLine($"\t{order.OrderDate.Month,2} - ${order.Total,4:#.00}");

                    
                }

                Console.WriteLine();
            }

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            List<Product> products = DataLoader.LoadProducts();

            var productCategoris = products.Select(categories => categories.Category).Distinct();

            foreach (var category in productCategoris)
            {

                Console.WriteLine(category);
            }


        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            List<Product> products = DataLoader.LoadProducts();

            var product789Exist = products.Any(p => p.ProductID.Equals(789));

            
            Console.WriteLine($"Does Product ID 789 exists? : {product789Exist}");

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            List<Product> products = DataLoader.LoadProducts();

            
            var categoris = products.Where(p => p.UnitsInStock == 0).Select(c => c.Category).Distinct();
            foreach (var category in categoris)
            {
                Console.WriteLine(category);

            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            List<Product> products = DataLoader.LoadProducts();

            var categoris = products.Select(o => new { o.Category, o.UnitsInStock })
                                    .GroupBy(g => g.Category)
                                    .Where(u => u.All(h => h.UnitsInStock != 0));

            foreach (var category in categoris)
            {
                Console.WriteLine(category.Key);

            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            int[] number = DataLoader.NumbersA;
            var filter = number.Where(o => o % 2 != 0).Count();

            Console.WriteLine(filter);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var filtered = customers.Select(n => new { n.CustomerID, CountofTheirOrders=n.Orders.Count() });



            foreach(var customer in filtered)
            {

                Console.WriteLine(customer);
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            List<Product> products = DataLoader.LoadProducts();

            //var filitered = products.Select(s => new { s.Category, s.ProductName })
            //                        .Distinct()
            //                        .GroupBy(g => g.Category);

            var filitered = products.GroupBy(g => g.Category); // Select(s => new { s.Category, s.ProductName })
                                    
                                   


            foreach (var group in filitered)
            {

                Console.WriteLine(group.Key + " " + group.Count());

               
            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {

            List<Product> products = DataLoader.LoadProducts();

            var filitered = products.Select(s => new { s.Category, s.ProductName,s.UnitsInStock })
                                    .Distinct()
                                    .GroupBy(g => g.Category);





            foreach (var group in filitered)
            {

                Console.WriteLine("Group: " + group.Key + ", UnitInStock: " + group.Sum(p => p.UnitsInStock));

            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {

            List<Product> products = DataLoader.LoadProducts();

            var filitered = products.Select(s => new { s.Category, s.ProductName, s.UnitPrice })
                                    .Distinct()
                                    .GroupBy(g => g.Category);

            
            foreach (var group in filitered)
            {

                Console.WriteLine($"Group: {group.Key}, Lowest priced product: ${group.Min(p => p.UnitPrice):#.00}");

            }

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {

            List<Product> products = DataLoader.LoadProducts();

            //var filitered = products.GroupBy(categories => new { Category = categories.Category })
            //    .Select(group => new
            //    {
            //        Category = group.Key.Category,
            //        AverageUnitPrice = group.Average(price => price.UnitPrice)
                    

            //    }).OrderByDescending(price => price.AverageUnitPrice).Take(3);


            var filitered = products.GroupBy(categories =>  categories.Category )
              .Select(group => new
              {
                  Category = group.Key,
                  AverageUnitPrice = group.Average(price => price.UnitPrice)


              }).OrderByDescending(price => price.AverageUnitPrice).Take(3);


            foreach (var output in filitered)
            {

                Console.WriteLine($"{output.Category} average unit price of their products is ${output.AverageUnitPrice:#.00}");
            }




        }
    }
}
