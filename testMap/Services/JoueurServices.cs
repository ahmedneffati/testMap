using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testMap.Models;
using testMap.RestClient;

namespace testMap.Services
{
    class JoueurServices<t>
    {
        RestClientString<t> restClient;
        public JoueurServices(string ch)
        {
             restClient = new RestClientString<t>(ch);
        }
       // RestClientString<t> restClient = new RestClientString<t>("http://takwira.azurewebsites.net/api/Joueurs");
        public async Task<List<t>> getJoueursAsync()
        {

            var Joueur = await restClient.GetAsync();
            return Joueur;

        }


        public async Task PostJoueursAsync(t e)
        {

            var Joueur = await restClient.PostAsync(e);

        }
        public async Task PutJoueursAsync(string id, t e)
        {

            var Joueur = await restClient.PutAsync(id, e);

        }
        public async Task DeleteJoueursAsync(string id)
        {

            var Joueur = await restClient.DeleteAsync(id);


        }

    }

}