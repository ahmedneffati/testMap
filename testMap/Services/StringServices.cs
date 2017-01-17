using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testMap.Models;
using testMap.RestClient;

namespace testMap.Services
{
    class StringServices<t>
    {
        RestClientString<t> restClient;
        public StringServices(string ch)
        {
            restClient = new RestClientString<t>(ch);
        }
        // RestClientString<t> restClient = new RestClientString<t>("http://takwira.azurewebsites.net/api/Models");
        public async Task<List<t>> getModelsAsync()
        {

            var Model = await restClient.GetAsync();
            return Model;

        }


        public async Task PostAsync(t e)
        {

            var Model = await restClient.PostAsync(e);

        }
        public async Task PutModelsAsync(string id, t e)
        {

            var Model = await restClient.PutAsync(id, e);

        }
        public async Task DeleteModelsAsync(string id)
        {

            var Model = await restClient.DeleteAsync(id);


        }

    }

}