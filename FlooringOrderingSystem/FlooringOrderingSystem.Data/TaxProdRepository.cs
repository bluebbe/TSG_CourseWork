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
    public class TaxProdRepository : ITaxRepository
    {
        
        private string _taxFile = "Taxes.txt";
        private string _repositoryLocation;

        public TaxProdRepository(string repositoryLocation)
        {
            this._repositoryLocation = repositoryLocation;
        }

        public Tax RetrieveTaxInfo(string stateAbbreviation)
        {
           
            Tax tax = null;
            using (StreamReader sr = new StreamReader(_repositoryLocation + "\\" +_taxFile))
            {
                sr.ReadLine();
                string line;
             

                while ((line = sr.ReadLine()) != null)
                {
                    

                    string[] columns = line.Split(',');

                    if (columns[0] == stateAbbreviation)
                    {
                        tax = new Tax();
                        tax.StateAbbreviation = columns[0];
                        tax.StateName = columns[1];
                        tax.TaxRate = Convert.ToDecimal(columns[2]);
                        break;
                    }



                }


            }

            return tax;
        }
    }
}
