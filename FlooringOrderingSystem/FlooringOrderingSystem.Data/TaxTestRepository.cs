using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model;
using FlooringOrderingSystem.Model.Interfaces;

namespace FlooringOrderingSystem.Data
{
    public class TaxTestRepository : ITaxRepository
    {

        private Dictionary<string, Tax> _tax = new Dictionary<string, Tax>();
     
        public TaxTestRepository()
        {
            _tax["OH"] = new Tax { StateAbbreviation = "OH", StateName = "Ohio", TaxRate = 6.25m };
        }


        public Tax RetrieveTaxInfo(string stateAbbreviation)
        {
            if (_tax.ContainsKey(stateAbbreviation))
            {
                return _tax[stateAbbreviation];

            }

            return null;
        }
    }
}
