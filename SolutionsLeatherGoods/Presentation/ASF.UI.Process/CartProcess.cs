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


    public class CartProcess : ProcessComponent
    {
        const String baseUrl = "rest/Cart/";

        public List<Cart> SelectList()
        {
            var response = HttpGet<AllResponse>(baseUrl + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.CartResult;
        }

        public Cart FindByID(int id)
        {
            var response = HttpGet<FindResponse>(baseUrl + "Find", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.CartResult;
        }


        public void Add(Cart cart)
        {
            var response = HttpPost<Cart>(baseUrl + "Add/", cart, MediaType.Json);

        }

        public void Edit(Cart cart)
        {
            var response = HttpPost<Cart>(baseUrl + "Edit/", cart, MediaType.Json);

        }

        public void Delete(Cart cart)
        {
            var response = HttpPost<Cart>(baseUrl + "Remove/" + cart.Id, cart, MediaType.Json);

        }

    }
}