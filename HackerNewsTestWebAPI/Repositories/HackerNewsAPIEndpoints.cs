using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsTestWebAPI.Repositories
{
    public class HackerNewsAPIEndpoints
    {
        public string URI { get; set; }
        public IDictionary<string, string> Actions { get; set; }
    }
}
