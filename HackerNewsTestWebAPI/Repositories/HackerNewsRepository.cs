using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HackerNewsTestWebAPI.Models;
using HackerNewsTestWebAPI.Models.Interfaces;
using HackerNewsTestWebAPI.Repositories.Singleton;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HackerNewsTestWebAPI.Repositories
{
    public class HackerNewsRepository : IHackerNewsRepository
    {
        private IOptions<HackerNewsAPIEndpoints> endPoints;
        private readonly HttpClient client = new HttpClient();
        public HackerNewsRepository(IOptions<HackerNewsAPIEndpoints> endPoints)
        {
            this.endPoints = endPoints;
            client.BaseAddress = new Uri(endPoints.Value.URI);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<int>> GetIdsBest()
        {
            HttpResponseMessage resp = await client.GetAsync(endPoints.Value.Actions["BestScores"]);

            var best = await resp.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<int>>(best);
        }

        public async Task<IItem>GetItem(int itemId)
        {
            HttpResponseMessage resp = await client.GetAsync(string.Format(endPoints.Value.Actions["Item"], itemId.ToString()));

            var best = await resp.Content.ReadAsStringAsync();

            var item = JsonConvert.DeserializeObject<Item>(best);

            return item;
        }

        public async Task<List<IItem>> GetBestItems()
        {
            if (HackerNewsRepositorySingleton.ListOfBestItems.Count == 0)
            {
                var idsBest = await GetIdsBest();

                var lItem = new List<IItem>();
                foreach (var id in idsBest)
                {
                    lItem.Add(await GetItem(id));
                }

                HackerNewsRepositorySingleton.SetItemsIdsBestScores(lItem);
            }

            return HackerNewsRepositorySingleton.ListOfBestItems;
        }
    }
}
