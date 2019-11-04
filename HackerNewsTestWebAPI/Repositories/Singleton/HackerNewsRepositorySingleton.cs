using HackerNewsTestWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsTestWebAPI.Repositories.Singleton
{
    public static class HackerNewsRepositorySingleton
    {
        private static List<IItem> listOfBestItems = new List<IItem>();
        private static readonly object lockList = new object();

        public static List<IItem> ListOfBestItems 
        { 
            get
            {
                return listOfBestItems;
            }
        }
        public static void SetItemsIdsBestScores(List<IItem> lBestItems)
        {
            lock (lockList)
            {
                listOfBestItems = lBestItems;
            }
        }
    }
}
