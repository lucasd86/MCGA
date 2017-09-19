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
     
    public class DealerProcess : ProcessComponent
    {
        const String baseUrl = "rest/Dealer/";

        public List<Dealer> SelectList()
        {
            var response = HttpGet<AllResponse>(baseUrl + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.DealerResult;
        }

        public Dealer FindByID(int id)
        {
            var response = HttpGet<FindResponse>(baseUrl + "Find", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.DealerResult;
        }


        public void Add(Dealer dealer)
        {
            var response = HttpPost<Dealer>(baseUrl + "Add/", dealer, MediaType.Json);

        }

        public void Edit(Dealer dealer)
        {
            var response = HttpPost<Dealer>(baseUrl + "Edit/", dealer, MediaType.Json);

        }

        public void Delete(Dealer dealer)
        {
            var response = HttpPost<Dealer>(baseUrl + "Remove/" + dealer.Id, dealer, MediaType.Json);

        }

    }
}