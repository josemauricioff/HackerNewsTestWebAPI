using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsTestWebAPI.Models.Interfaces
{
    public interface IItem
    {
        int Id { get; set; }
        bool? Deleted { get; set; }
        string Type { get; set; }
        string By { get; set; }
        int? Time { get; set; }
        string Text { get; set; }
        bool? Dead { get; set; }
        IEnumerable<int> Kids { get; set; }
        string Url { get; set; }
        int Score { get; set; }
        string Title { get; set; }
        int Descendants { get; set; }
    }
}
