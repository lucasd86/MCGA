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
     
    public class CartItemProcess : ProcessComponent
    {
        const String baseUrl = "rest/CartItem/";

        public List<CartItem> SelectList()
        {
            var response = HttpGet<AllResponse>(baseUrl + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.CartItemResult;
        }

        public CartItem FindByID(int id)
        {
            var response = HttpGet<FindResponse>(baseUrl + "Find", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.CartItemResult;
        }


        public void Add(CartItem cartitem)
        {
            var response = HttpPost<CartItem>(baseUrl + "Add/", cartitem, MediaType.Json);

        }

        public void Edit(CartItem cartitem)
        {
            var response = HttpPost<CartItem>(baseUrl + "Edit/", cartitem, MediaType.Json);

        }

        public void Delete(CartItem cartitem)
        {
            var response = HttpPost<CartItem>(baseUrl + "Remove/" + cartitem.Id, cartitem, MediaType.Json);

        }

    }
}