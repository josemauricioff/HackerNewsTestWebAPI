using HackerNewsTestWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsTestWebAPI.Repositories.Singleton
{
    public static class HackerNewsRepositorySingleton
    {
        private static List<IItem> listOfBestsItems = new List<IItem>();
        private static readonly object lockList = new object();

        public static List<IItem> ListOfBestsItems 
        { 
            get
            {
                return listOfBestsItems;
            }
        }
        public static void SetItemsIdsBestsScores(List<IItem> lBestsItems)
        {
            lock (lockList)
            {
                listOfBestsItems = lBestsItems;
            }
        }
    }
}
