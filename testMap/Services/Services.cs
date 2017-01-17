using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testMap.Models;
using testMap.RestClient;

namespace testMap.Services
{
    class Services<t>
    {
        RestClient<t> restClient;
        public Services(string ch)
        {
            restClient = new RestClient<t>(ch);
        }
        //  RestClient<Model> restClient = new RestClient<Model>("http://takwira.azurewebsites.net/api/Models/");
        public async Task<List<t>> getModelsAsync()
        {


            var Models = await restClient.GetAsync();
            return Models;

        }


        public async Task PostModelsAsync(t e)
        {

            var Models = await restClient.PostAsync(e);



        }
        public async Task PutModelsAsync(int id, t e)
        {

            var Models = await restClient.PutAsync(id, e);


        }
        public async Task DeleteModelsAsync(int id)
        {

            var Models = await restClient.DeleteAsync(id);


        }

    }

}