using System;
using System.Net;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace ApiClient
{
    internal class Program
    {
        static List<City> Cities;
        const string ApiKey = "insert your api key for OpenWeather";
        private static readonly HttpClient httpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter city name");
                var cityName = Console.ReadLine();
                string requestCityData = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=5&appid={ApiKey}";
                var result = await GetResponseText(requestCityData);
                var city = ParseCityData(result).FirstOrDefault();
                if (city == null)
                {
                    Console.WriteLine("City not found!");
                    Console.ReadKey();
                    continue;
                }
                string requestWeatherDataByGeo = $"https://api.openweathermap.org/data/2.5/weather?lat={city.lat}&lon={city.lon}&units=metric&appid={ApiKey}";
                result = await GetResponseText(requestWeatherDataByGeo);
                var forecast = ParseForecastData(result);
                Console.Clear();
                Console.WriteLine($"Forecast for {cityName}\n" + forecast.ToString());
                Console.WriteLine("For new forecast press any key, Escape for exit");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    return;
            }
        }

        public static async Task<string> GetResponseText(string address)
        {
            return await httpClient.GetStringAsync(address);
        }

        static List<City?> ParseCityData(string httpResult)
        {
            return JsonSerializer.Deserialize<List<City?>>(httpResult);
        }

        static Forecast? ParseForecastData(string httpResult)
        {
            return JsonSerializer.Deserialize<Forecast?>(httpResult);
        }
    }
}