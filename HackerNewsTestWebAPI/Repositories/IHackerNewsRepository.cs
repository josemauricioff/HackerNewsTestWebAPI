using HackerNewsTestWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsTestWebAPI.Repositories
{
    public interface IHackerNewsRepository
    {
        Task<IEnumerable<int>> GetIdsBest();
        Task<IItem> GetItem(int itemId);
        Task<List<IItem>> GetBestItems();

    }
}
