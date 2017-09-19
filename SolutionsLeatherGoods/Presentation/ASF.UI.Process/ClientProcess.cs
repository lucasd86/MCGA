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
    public class ClientProcess : ProcessComponent
    {
        const String baseUrl = "rest/Client/";

        public List<Client> SelectList()
        {
            var response = HttpGet<AllResponse>(baseUrl + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.ClientResult;
        }

        public Client FindByID(int id)
        {
            var response = HttpGet<FindResponse>(baseUrl + "Find", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.ClientResult;
        }


        public void Add(Client cli)
        {
            var response = HttpPost<Client>(baseUrl + "Add/", cli, MediaType.Json);

        }

        public void Edit(Client cli)
        {
            var response = HttpPost<Client>(baseUrl + "Edit/", cli, MediaType.Json);

        }

        public void Delete(Client cli)
        {
            var response = HttpPost<Client>(baseUrl + "Remove/" + cli.Id, cli, MediaType.Json);

        }

    }
}