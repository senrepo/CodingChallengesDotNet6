using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengesTest
{
    [TestFixture]
    public class JasonDataTests
    {
        [SetUp]
        public void Setup()
        {

        }

        /* Requirements
         * make a json webserivce call
         * do the manipulation in the json response
         * 
         */

        [Test]
        public void TestJsonWebServiceCall()
     // public async Task TestJsonWebServiceCall()
        {
            string url = "https://dummyjson.com/products";
            var jsonData = new JsonData();
            var json = jsonData.GetWeatherJsonFromService(url).Result;
            //await didn't work some scenarios because await asynchronouslly unwrapping the resutl, but Result blocks thread to get the result
            //in test method context, the calling thread completed before worker thread returns the result.
            //var json = await jsonData.GetWeatherJsonFromService(url); 
            Assert.IsNotEmpty(json);
        }

        [Test]
        public void TestJsonManipulation()
        {
            var json = new JsonData().GetWeatherJson();

            //By Matching the Property Name
            var weather = JsonConvert.DeserializeObject<WeatherForecast>(json);
            Assert.That(weather,Is.InstanceOf<WeatherForecast>());
            Assert.True(!String.IsNullOrEmpty(weather.Summary));

            //If Property names are not mached, then use the DTO
            var weatherDto = JsonConvert.DeserializeObject<WeatherForecastDTO>(json);
            Assert.That(weatherDto, Is.InstanceOf<WeatherForecastDTO>());
            Assert.True(!String.IsNullOrEmpty(weatherDto.Details));

            //Covert DTO object to json
            var json1 = JsonConvert.SerializeObject(weather);
            Assert.IsNotEmpty(json1);
        }

        public class WeatherForecast
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string? Summary { get; set; }
        }

        public class WeatherForecastDTO
        {
            [JsonProperty("Date")]
            public string? CurrentDate { get; set; }
            [JsonProperty("TemperatureCelsius")]
            public int Temperature { get; set; }
            [JsonProperty("Summary")]
            public string? Details { get; set; }
        }
    }
}
