using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    internal class Forecast
    {
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
    }
}
