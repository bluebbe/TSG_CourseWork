using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model.Interfaces;
using FlooringOrderingSystem.Model.Responses;

namespace FlooringOrderingSystem.BLL
{
  

    public class TaxManager
    {

        private ITaxRepository _taxRepository;

        public TaxManager(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }


        

        public TaxLookUpResponse TaxLookUp(string stateAbbreviation)
        {
            TaxLookUpResponse response = new TaxLookUpResponse();

            response.TaxInformation = _taxRepository.RetrieveTaxInfo(stateAbbreviation);

            if (response.TaxInformation == null)
            {

                response.Success = false;
                response.Message = $"There was no Tax Information found {stateAbbreviation}. Contact IT.";
            }
            else
            {
                response.Success = true;

            }
            
            return response;
        }
    }
}
