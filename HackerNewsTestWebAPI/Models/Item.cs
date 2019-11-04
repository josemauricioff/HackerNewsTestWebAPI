using HackerNewsTestWebAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsTestWebAPI.Models
{
    public class Item: IItem
    {
        public int Id { get; set; }
        public bool? Deleted { get; set; }
        public string Type { get; set; }
        public string By { get; set; }
        public int? Time { get; set; }
        public string Text { get; set; }
        public bool? Dead { get; set; }
        public IEnumerable<int> Kids { get; set; }
        public string Url { get; set; }
        public int Score { get; set; }
        public string Title { get; set; }
        public int Descendants { get; set; }
    }
}
