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
  
       public class OrderDetailProcess : ProcessComponent
    {
        const String baseUrl = "rest/OrderDetail/";

        public List<OrderDetail> SelectList()
        {
            var response = HttpGet<AllResponse>(baseUrl + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.OrderDetailResult;
        }

        public OrderDetail FindByID(int id)
        {
            var response = HttpGet<FindResponse>(baseUrl + "Find", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.OrderDetailResult;
        }


        public void Add(OrderDetail orderdetail)
        {
            var response = HttpPost<OrderDetail>(baseUrl + "Add/", orderdetail, MediaType.Json);

        }

        public void Edit(OrderDetail orderdetail)
        {
            var response = HttpPost<OrderDetail>(baseUrl + "Edit/", orderdetail, MediaType.Json);

        }

        public void Delete(OrderDetail orderdetail)
        {
            var response = HttpPost<OrderDetail>(baseUrl + "Remove/" + orderdetail.Id, orderdetail, MediaType.Json);

        }

    }
}