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
    public class CountryProcess : ProcessComponent
    {

        const String baseUrl = "rest/Country/";

        public List<Country> SelectList()
        {
            var response = HttpGet<AllResponse>(baseUrl + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.CountryResult;
        }
        public Country FindByID(int id)
        {
            var response = HttpGet<FindResponse>(baseUrl + "Find", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.CountryResult;
        }
        public void Edit(Country country)
        {
            var response = HttpPost<Country>(baseUrl + "Edit/", country, MediaType.Json);

        }
        public void Add(Country country)
        {
            var response = HttpPost<Country>(baseUrl + "Add/", country, MediaType.Json);

        }

        public void Delete(Country country)
        {
            var response = HttpPost<Country>(baseUrl + "Remove/" + country.Id, country, MediaType.Json);

        }

    }
}
