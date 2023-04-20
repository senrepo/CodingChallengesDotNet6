using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges
{
    public class JsonData
    {

        public class WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string? Summary { get; set; }
        }


        public string GetWeatherJson()
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };
            var json = JsonConvert.SerializeObject(weatherForecast);
            return json;
        }

        public async Task<string> GetWeatherJsonFromService(string url)
        {
            var json = string.Empty;
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();
                json = await response.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return json;
        }

    }
}
