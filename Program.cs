
using System.Text.Json;

namespace JsonPaerser 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stringData = CallthisFunction();
            JsonDeserialthisFunction(stringData);
        }

        private static string CallthisFunction()
        {
            // Create a weather object
            var weather = new Weather
            {
                City = "Seattle",
                Temperature = 18.5,
                FeelsLike = 17.2,
                Humidity = 65,
                WindSpeed = 10.4,
                Condition = "Partly Cloudy",
                LastUpdated = DateTime.Now
            };

            // Serialize to JSON
            string jsonString = JsonSerializer.Serialize(weather);
            return jsonString;
        }

        private static void JsonDeserialthisFunction(string jsonData)
        {
            var deserializeData = JsonSerializer.Deserialize<Weather>(jsonData);
            Console.WriteLine(deserializeData);
        }
    }
}