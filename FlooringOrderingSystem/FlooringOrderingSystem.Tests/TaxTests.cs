using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringOrderingSystem.Model;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Model.Responses;

namespace FlooringOrderingSystem.Tests
{
    [TestFixture]
    public  class TaxTests
    {
        [Test]
        public void CanRestrieveTaxInformationTest()
        {

            TaxManager manager = TaxManagerFactory.Create();
            TaxLookUpResponse response = new TaxLookUpResponse();

            response = manager.TaxLookUp("OH");

            Assert.IsTrue(response.Success);
            Assert.AreEqual("OH", response.TaxInformation.StateAbbreviation);


        }

    }
}
