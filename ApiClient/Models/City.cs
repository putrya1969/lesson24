using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{ 
    internal class City
    {
        public string name { get; set; }
        //public Dictionary<string, string> local_names { get; set; } = new();
        public double lat { get; set; }
        public double lon { get; set; }
        public string country { get; set; }
        public string state { get; set; }
    }
}
