using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Model.Interfaces;
using FlooringOrderingSystem.Model.Responses;
using FlooringOrderingSystem.Data;

namespace FlooringOrderingSystem.BLL
{
    public class ProductManager
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductListResponse ProductsAvailable()
        {
            ProductListResponse response = new ProductListResponse();

            response.Products = _productRepository.RetrieveProducts();

            if (response.Products == null)
            {
                response.Success = false;
                response.Message = "Unable to retrieve List of Products. Contact IT.";

            }
            else
            {

                response.Success = true;
            }

            return response;
        }

        public ProductInformationResponse ProductInformation(string product)
        {
            ProductInformationResponse response = new ProductInformationResponse();

            response.Product = _productRepository.ProductInformation(product);

            if (response.Product == null)
            {
                response.Success = false;
                response.Message = $"Unable to product information for {product}";

            }
            else
            {
                response.Success = true;

            }

            return response;
        }
       
    }
}
