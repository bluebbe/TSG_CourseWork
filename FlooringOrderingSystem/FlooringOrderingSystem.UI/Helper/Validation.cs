using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model.Responses;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Model;

namespace FlooringOrderingSystem.UI.Helper
{
    public static class Validation
    {
        public static bool OrderDateValidation(string input, bool futureDatesOnly, out string output)
        {
            DateTime caputureDate;

            if (DateTime.TryParseExact(input, "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out caputureDate))
            {
               
                    // must be in the future date
                    if (futureDatesOnly ? (caputureDate.CompareTo(DateTime.Today) >= 0):true)
                    {
                        output = caputureDate.ToString("MM/dd/yyyy");
                        return true;
                    }

                
            }
            Console.WriteLine("Please enter a valid date");
            output = "";
            return false;
        }

        public static bool CustomerNameValidation(string input)
        {

            // May not be blank, allowed to contain [a-z][0-9] as well as periods and
            // comma characters. "Acme, Inc." is a valid name.

            bool validateName = true;
            if (!string.IsNullOrEmpty(input))
            {
                foreach (char temp in input.ToLower())
                {

                    if (temp == '.' || temp == ',') continue;
                    if (temp >= 'a' && temp <= 'z') continue;

                    validateName = false;
                }

            }
            else validateName = false;
            
            return validateName;
        }


        public static bool StateValidation(string input)
        {
            bool result = false;

            TaxLookUpResponse taxResponse = TaxManagerFactory.Create().TaxLookUp(input);
            if (taxResponse.Success) result = true ;


            return result;
        }

        public static bool AreaValidation(string input, out decimal result)
        {
            
            if (Decimal.TryParse(input, out result))
            {
                if (result >= 100.0m)
                {
                    result = Math.Round(result, 2);
                    return true;
                }
            }

            return false;
        }

        public static bool DoesEditedOrderNeedRecaluation(Order editOrder,Order originalOrder)
        {
            bool needToReCalculate = false;

            if (editOrder.State != originalOrder.State) needToReCalculate = true;
            if (editOrder.ProductType != originalOrder.ProductType) needToReCalculate = true;
            if (editOrder.Area != originalOrder.Area) needToReCalculate = true;

            return needToReCalculate;
        }
    }
}
