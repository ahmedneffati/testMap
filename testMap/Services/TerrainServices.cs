using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testMap.Models;
using testMap.RestClient;

namespace testMap.Services
{
    class TerrainServices<t>
    {
        RestClient<t> restClient;
        public TerrainServices(string ch)
        {
             restClient = new RestClient<t>(ch);
        }
        //  RestClient<Terrain> restClient = new RestClient<Terrain>("http://takwira.azurewebsites.net/api/Terrains/");
        public async Task<List<t>> getTerrainsAsync()
        {


            var Terrains = await restClient.GetAsync();
            return Terrains;

        }


        public async Task PostTerrainsAsync(t e)
        {

            var Terrains = await restClient.PostAsync(e);



        }
        public async Task PutTerrainsAsync(int id, t e)
        {

            var Terrains = await restClient.PutAsync(id, e);


        }
        public async Task DeleteTerrainsAsync(int id)
        {

            var Terrains = await restClient.DeleteAsync(id);


        }

    }

}