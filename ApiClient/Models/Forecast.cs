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

        public override string ToString()
        {
            return $"at {DateTime.Now.ToString("dd-MM-yy HH:mm")}\nWeather is: {weather.First().description}\n" +
                $"Temperature: {main.temp}\nFeels like: {main.feels_like}\nPressure: {main.pressure}\nHumidity: {main.humidity}";
        }
    }
}
