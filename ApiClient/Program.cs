using System;
using System.Net;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace ApiClient
{
    internal class Program
    {
        static List<City> Cities;
        const string ApiKey = "c0d742978a8416e1cbf7281a66896fd1";
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Start");
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            //Cities = await ParseJsonAsync();
            ////Cities = ParseJson();
            //watch.Stop();
            //Console.WriteLine($"{watch.Elapsed.TotalMilliseconds}");
            //Console.WriteLine("Enter city name");
            var cityName = "Kremenchuk";
            string requestCityData = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=5&appid={ApiKey}";
            var result = await GetResponseText(requestCityData);
            var city = ParseCityData(result).FirstOrDefault();
            if (city == null)
            {
                Console.WriteLine("City not found!");
                return;
            }
            string requestWeatherDataByGeo = $"https://api.openweathermap.org/data/2.5/weather?lat={city.lat}&lon={city.lon}&units=metric&lang=uk&appid={ApiKey}";
            result = await GetResponseText(requestWeatherDataByGeo);
            var forecast = ParseForecastData(result);
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestCityData);
            //HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            //HttpWebResponse response = await GetHttpResponce(request);
            //response.GetResponseStream();


                //Newtonsoft.Json.JsonConvert.DeserializeObject<List<City>>(result);
        }

        //static async Task GetCities()
        //{
        //    Cities = await Task<List<City?>>.Run(() => ParseJson());
        //}
        static List<City> ParseJson()
        {
            List<City> cities = new List<City>();
            using (FileStream fs = new FileStream("city.list.json", FileMode.Open))
            {
                cities = JsonSerializer.Deserialize<List<City>>(fs);
            }
            return cities;
        }

        static async Task<List<City>> ParseJsonAsync()
        {
            List<City> cities = new List<City>();
            using (FileStream fs = new FileStream("city.list.json", FileMode.Open))
            {
                cities = await JsonSerializer.DeserializeAsync<List<City>>(fs);
            }
            return cities;
        }

        static List<City?> ParseCityData(string httpResult)
        {
            return JsonSerializer.Deserialize<List<City?>>(httpResult);
        }

        static Forecast? ParseForecastData(string httpResult)
        {
            return JsonSerializer.Deserialize<Forecast?>(httpResult);
        }

        static async Task<HttpWebResponse> GetHttpResponce(HttpWebRequest request)
        {
            return (HttpWebResponse)await request.GetResponseAsync();
        }

        private static readonly HttpClient httpClient = new HttpClient();

        public static async Task<string> GetResponseText(string address)
        {
            return await httpClient.GetStringAsync(address);
        }
    }
}