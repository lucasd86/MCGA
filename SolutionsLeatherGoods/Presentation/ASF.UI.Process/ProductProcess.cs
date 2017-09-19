using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;
using ASF.UI.Process;

namespace ASF.UI.Process
{
   

 public class ProductProcess : ProcessComponent
    {
        const String baseUrl = "rest/Product/";

        public List<Product> SelectList()
        {
            var response = HttpGet<AllResponse>(baseUrl + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ProductResult;
        }

        public Product FindByID(int id)
        {
            var response = HttpGet<FindResponse>(baseUrl + "Find", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ProductResult;
        }


        public void Add(Product product)
        {
            var response = HttpPost<Product>(baseUrl + "Add/", product, MediaType.Json);

        }

        public void Edit(Product product)
        {
            var response = HttpPost<Product>(baseUrl + "Edit/", product, MediaType.Json);

        }

        public void Delete(Product product)
        {
            var response = HttpPost<Product>(baseUrl + "Remove/" + product.Id, product, MediaType.Json);

        }

    }
}