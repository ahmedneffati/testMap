using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testMap.Models;
using testMap.RestClient;

namespace testMap.Services
{
    class ProprietaireServices
    {
        RestClientString<Proprietaire> restClient = new RestClientString<Proprietaire>("http://takwira.azurewebsites.net/api/Proprietaires");
        public async Task<List<Proprietaire>> getProprietairesAsync()
        {

            var Proprietaire = await restClient.GetAsync();
            return Proprietaire;

        }


        public async Task PostProprietairesAsync(Proprietaire e)
        {

            var Proprietaire = await restClient.PostAsync(e);

        }
        public async Task PutProprietairesAsync(string id, Proprietaire e)
        {

            var Proprietaire = await restClient.PutAsync(id, e);

        }
        public async Task DeleteProprietairesAsync(string id)
        {

            var Proprietaire = await restClient.DeleteAsync(id);


        }

    }

}