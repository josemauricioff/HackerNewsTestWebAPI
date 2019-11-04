using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackerNewsTestWebAPI.Models.Interfaces;
using HackerNewsTestWebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsTestWebAPI.Controllers
{
    public class ItemController : Controller
    {
        private readonly IHackerNewsRepository repository;

        public ItemController(IHackerNewsRepository repository)
        {
            this.repository = repository;
        }

        [Route("/item/GetFist20Best")]
        public async Task<IEnumerable<IItem>> GetFist20Best()
        {
            var bestItems = await repository.GetBestItems();

            return bestItems.Take(20).OrderByDescending(i => i.Score);
        }
    }
}