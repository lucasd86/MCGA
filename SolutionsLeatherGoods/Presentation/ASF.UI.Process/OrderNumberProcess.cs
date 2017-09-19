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
   
         public class OrderNumberProcess : ProcessComponent
    {
        const String baseUrl = "rest/OrderNumber/";

        public List<OrderNumber> SelectList()
        {
            var response = HttpGet<AllResponse>(baseUrl + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.OrderNumberResult;
        }

        public OrderNumber FindByID(int id)
        {
            var response = HttpGet<FindResponse>(baseUrl + "Find", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.OrderNumberResult;
        }


        public void Add(OrderNumber ordernumber)
        {
            var response = HttpPost<OrderNumber>(baseUrl + "Add/", ordernumber, MediaType.Json);

        }

        public void Edit(OrderNumber ordernumber)
        {
            var response = HttpPost<OrderNumber>(baseUrl + "Edit/", ordernumber, MediaType.Json);

        }

        public void Delete(OrderNumber ordernumber)
        {
            var response = HttpPost<OrderNumber>(baseUrl + "Remove/" + ordernumber.Id, ordernumber, MediaType.Json);

        }

    }
}