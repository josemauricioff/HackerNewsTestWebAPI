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

        [Route("/item/GetBests20")]
        public async Task<IEnumerable<IItem>> GetBests20()
        {
            var bestsItems = await repository.GetBestsItem();

            return bestsItems.OrderByDescending(i => i.Score).Take(20);
        }
    }
}