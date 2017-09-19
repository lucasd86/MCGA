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
        public class OrderProcess : ProcessComponent
        {
            const String baseUrl = "rest/Order/";

            public List<Order> SelectList()
            {
                var response = HttpGet<AllResponse>(baseUrl + "All", new Dictionary<string, object>(), MediaType.Json);
                return response.OrderResult;
            }

            public Order FindByID(int id)
            {
                var response = HttpGet<FindResponse>(baseUrl + "Find", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
                return response.OrderResult;
            }


            public void Add(Order order)
            {
                var response = HttpPost<Order>(baseUrl + "Add/", order, MediaType.Json);

            }

            public void Edit(Order order)
            {
                var response = HttpPost<Order>(baseUrl + "Edit/", order, MediaType.Json);

            }

            public void Delete(Order order)
            {
                var response = HttpPost<Order>(baseUrl + "Remove/" + order.Id, order, MediaType.Json);

            }

        }
    }