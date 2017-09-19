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
     
   public class RatingProcess : ProcessComponent
    {
        const String baseUrl = "rest/Rating/";

        public List<Rating> SelectList()
        {
            var response = HttpGet<AllResponse>(baseUrl + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.RatingResult;
        }

        public Rating FindByID(int id)
        {
            var response = HttpGet<FindResponse>(baseUrl + "Find", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.RatingResult;
        }


        public void Add(Rating rating)
        {
            var response = HttpPost<Rating>(baseUrl + "Add/", rating, MediaType.Json);

        }

        public void Edit(Rating rating)
        {
            var response = HttpPost<Rating>(baseUrl + "Edit/", rating, MediaType.Json);

        }

        public void Delete(Rating rating)
        {
            var response = HttpPost<Rating>(baseUrl + "Remove/" + rating.Id, rating, MediaType.Json);

        }

    }
}