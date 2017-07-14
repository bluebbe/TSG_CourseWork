using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlooringOrderingSystem.Model.Interfaces
{
    public interface IProductRepository
    {
        List<Product> RetrieveProducts();
        Product ProductInformation(string product);
    }
}
