using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FlooringOrderingSystem.Model;
using FlooringOrderingSystem.Model.Interfaces;

namespace FlooringOrderingSystem.Data
{
    public class OrderProdRepository : IOrderRepository
    {
        private static string _repositoryLocation;
        private static Dictionary<string, List<Order>> _orders = new Dictionary<string, List<Order>>();
        private static string _fileHeader = "OrderNumber, CustomerName, State, TaxRate, ProductType, Area, CostPerSquareFoot, LaborCostPerSquareFoot, MaterialCost, LaborCost, Tax, Total";

        public OrderProdRepository(string repositoryLocation)
        {
           _repositoryLocation = repositoryLocation;

        }

        public bool DeleteOrder(string orderDate, int orderNumber)
        {
            string orderFile = "Orders_" + orderDate.Replace("/", "") + ".txt";


            if (!_orders.ContainsKey(orderDate))
            {


                if (File.Exists(_repositoryLocation + "/" + orderFile))
                {
                    ReadFile(orderDate, _repositoryLocation + "/" + orderFile);
                }
                else return false;
              
            }
           
            
            Order foundOrder = _orders[orderDate].Find(o => o.OrderNumber == orderNumber);
            if (foundOrder == null) return false;
            _orders[orderDate].Remove(foundOrder);

            WriteFile(_repositoryLocation + "/" + orderFile, _orders[orderDate]);


            if (_orders[orderDate].Count() == 0) _orders.Remove(orderDate);


            return true;
            

            

        }

        public Order RetrieveOneOrder(string orderDate, int orderNumber)
        {
            List<Order> order = RetrieveOrders(orderDate);

            if (order == null) return null;

            return _orders[orderDate].Find(o => o.OrderNumber == orderNumber);
        }

        public List<Order> RetrieveOrders(string orderDate)
        {
            string orderFile = "Orders_" + orderDate.Replace("/", "") + ".txt";

            if ((_orders.ContainsKey(orderDate)))
            {

                return _orders[orderDate];


            }
            else { 

                if (ReadFile(orderDate, _repositoryLocation + "/" + orderFile))
                {
                    return _orders[orderDate];

                }
            }

            return null;
            
        }


        public bool SaveOrder(string orderDate, Order order)
        {
            string orderFile = "Orders_" + orderDate.Replace("/", "") + ".txt";
            Order checkOrder;
            if (_orders.ContainsKey(orderDate))
            {
                checkOrder = _orders[orderDate].Find(o => o.OrderNumber == order.OrderNumber);
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
                if (File.Exists(_repositoryLocation + "/" + orderFile))
                {

                    ReadFile(orderDate, _repositoryLocation + "/" + orderFile);
                    checkOrder = _orders[orderDate].OrderByDescending(o => o.OrderNumber).First();
                    order.OrderNumber = checkOrder.OrderNumber + 1;
                    _orders[orderDate].Add(order);
                }

                else { 
                    order.OrderNumber = 1;
                    _orders.Add(orderDate, new List<Order> { order });
                }
            }

            WriteFile(_repositoryLocation + "/" + orderFile, _orders[orderDate]);

            return true;
        }


        private bool ReadFile(string orderDate, string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    _fileHeader = sr.ReadLine();
                    string line;

                    Order order;
                    while ((line = sr.ReadLine()) != null)
                    {
                        order = new Order();

                        string[] columns = line.Split(',');

                        order.OrderNumber = Convert.ToInt32(columns[0]);
                        order.CustomerName = columns[1];
                        order.State = columns[2];
                        order.TaxRate = Convert.ToDecimal(columns[3]);
                        order.ProductType = columns[4];
                        order.Area = Convert.ToDecimal(columns[5]);
                        order.CostPerSquareFoot = Convert.ToDecimal(columns[6]);
                        order.LaborCostPerSquare = Convert.ToDecimal(columns[7]);
                        order.MaterialCost = Convert.ToDecimal(columns[8]);
                        order.LaborCost = Convert.ToDecimal(columns[9]);
                        order.Tax = Convert.ToDecimal(columns[10]);
                        order.Total = Convert.ToDecimal(columns[11]);

                        if (!_orders.ContainsKey(orderDate))
                            _orders.Add(orderDate, new List<Order> { order });
                        else _orders[orderDate].Add(order);
                    }

                }
                return true;
            }
            else return false;
        }


        private void WriteFile(string filePath, List<Order> orders)
        {
         

            if (!(orders.Count == 0)) {
                using (StreamWriter sw = new StreamWriter(filePath, false))
                {
                    sw.WriteLine(_fileHeader);

                    

                    foreach (var order in orders)
                    {
                        sw.Write(order.OrderNumber + ",");
                        sw.Write(order.CustomerName + ",");
                        sw.Write(order.State + ",");
                        sw.Write(order.TaxRate + ",");
                        sw.Write(order.ProductType + ",");
                        sw.Write(order.Area + ",");
                        sw.Write(order.CostPerSquareFoot + ",");
                        sw.Write(order.LaborCostPerSquare + ",");
                        sw.Write(order.MaterialCost + ",");
                        sw.Write(order.LaborCost + ",");
                        sw.Write(order.Tax + ",");
                        sw.WriteLine(order.Total);


                    }

                }
                
            }
            else
            {
                if (File.Exists(filePath))
                {
                    
                    File.Delete(filePath);
                }
            }

            
        }
    }
}
