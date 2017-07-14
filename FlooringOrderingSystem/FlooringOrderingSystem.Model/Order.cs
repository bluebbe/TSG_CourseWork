using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Model
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquare { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public void Copy(Order order)
        {
            this.OrderNumber = order.OrderNumber;
            this.CustomerName = order.CustomerName;
            this.State = order.State;
            this.TaxRate = order.TaxRate;
            this.ProductType = order.ProductType;
            this.Area = order.Area;
            this.CostPerSquareFoot = order.CostPerSquareFoot;
            this.LaborCostPerSquare = order.LaborCostPerSquare;
            this.MaterialCost = order.MaterialCost;
            this.LaborCost = order.LaborCost;
            this.Tax = order.Tax;
            this.Total = order.Total;


        }
        
    }
}
