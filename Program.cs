// My API Key: fa3871e648f64a0a978a7bc78d9c35c1

using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace WeatherConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            Console.Write("Welcome to the Open Weather API!\nPlease input your API Key: ");
            var apiKey = Console.ReadLine();

            Console.Write("\nThank you.\n\nEnter the city: ");
            var cityName = Console.ReadLine().ToLower();

            var userURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";

            var weatherResponse = client.GetStringAsync(userURL).Result;

            dynamic formattedResponse = JsonConvert.DeserializeObject(weatherResponse);

            var temp = formattedResponse.main.temp;

            Console.WriteLine($"\n{temp} degrees Celsius.");
        }
    }
}
