// My API Key: fa3871e648f64a0a978a7bc78d9c35c1

using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherConsoleClient
{
    public class WeatherData
    {
        public MainData Main { get; set; }
    }

    public class MainData
    {
        public double Temp { get; set; }
    }

    public class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            Console.Write("Welcome to the Open Weather API!\nPlease input your API Key: ");
            var apiKey = Console.ReadLine();

            Console.Write("\nThank you.\n\nEnter the city: ");
            var cityName = Console.ReadLine().ToLower();

            var userURL = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=metric";

            var weatherResponse = await client.GetStringAsync(userURL);

            var weatherData = JsonConvert.DeserializeObject<WeatherData>(weatherResponse);

            var tempCelsius = weatherData.Main.Temp;
            var tempFahrenheit = CelsiusToFahrenheit(tempCelsius);

            Console.WriteLine($"\nTemperature in Celsius: {tempCelsius}°C");
            Console.WriteLine($"Temperature in Fahrenheit: {tempFahrenheit}°F");
        }

        static double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }
    }
}
