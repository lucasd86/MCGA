using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using ASF.Services.Contracts;

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

        

        public List<Country> FindByID(int id)
        {
            var response = HttpGet<AllResponse>(baseUrl + "Find/" + id, new Dictionary<string, object>(), MediaType.Json);
            return response.CountryResult;
        }


        public void Add(Country country)
        {
            var response = HttpPost<Country>(baseUrl + "Add/", country, MediaType.Json);

        }

    }
}
