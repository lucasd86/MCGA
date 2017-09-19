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
   
    public class SettingProcess : ProcessComponent
    {
        const String baseUrl = "rest/Setting/";

        public List<Setting> SelectList()
        {
            var response = HttpGet<AllResponse>(baseUrl + "All", new Dictionary<string, object>(), MediaType.Json);
            return response.SettingResult;
        }

        public Setting FindByID(int id)
        {
            var response = HttpGet<FindResponse>(baseUrl + "Find", new Dictionary<string, object>() { { "id", id } }, MediaType.Json);
            return response.SettingResult;
        }


        public void Add(Setting setting)
        {
            var response = HttpPost<Setting>(baseUrl + "Add/", setting, MediaType.Json);

        }

        public void Edit(Setting setting)
        {
            var response = HttpPost<Setting>(baseUrl + "Edit/", setting, MediaType.Json);

        }

        public void Delete(Setting setting)
        {
            var response = HttpPost<Setting>(baseUrl + "Remove/" + setting.Id, setting, MediaType.Json);

        }

    }
}