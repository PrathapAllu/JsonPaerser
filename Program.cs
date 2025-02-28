
using System.Text.Json;

namespace JsonPaerser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stringData = CallthisFunction();
            JsonDeserialthisFunction(stringData);
            FormatJson();
        }

        //Nested JSON Data
        private async static void FormatJson()
        {
            try 
            {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/posts");

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "");

                // Send the HTTP request and get the response
                HttpResponseMessage response =  httpClient.Send(httpRequestMessage);

                if(response.IsSuccessStatusCode) 
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    var toJson = JsonSerializer.Deserialize<List<Post>>(responseContent);

                    var ListPostData = new List<Post>();

                    foreach (var post in toJson)
                    {
                        ListPostData.Add(post);
                    }

                    Console.WriteLine("OK");
                }
            }
            catch(Exception ex) 
            {
                return;
            }
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

            //validate if JSON is well-formed
            var IsjsonValid = CheckJsonIsValid(jsonString);

            return jsonString;
        }

        private static bool CheckJsonIsValid(string jsonString)
        {
            try
            {
                using (JsonDocument doc = JsonDocument.Parse(jsonString))
                {
                    // dispose any created doc
                }
                return true;
            }
            catch (JsonException)
            {
                return false;
            }
        }

        private static void JsonDeserialthisFunction(string jsonData)
        {
            var deserializeData = JsonSerializer.Deserialize<Weather>(jsonData);

            var weather = new Weather
            {
                City = deserializeData.City,
                Temperature = deserializeData.Temperature,
                FeelsLike = deserializeData.FeelsLike,
                Humidity = deserializeData.Humidity,
                WindSpeed = deserializeData.WindSpeed,
                Condition = deserializeData.Condition,
                LastUpdated = DateTime.Now
            };

            switch (weather.City)
            {
                case "Seattle":
                    Console.WriteLine(weather.Temperature); 
                    break;

                default: 
                    Console.WriteLine(weather.Temperature);
                    break;
            }

            string dJsonData = weather.ToString();
            Console.WriteLine(jsonData);
        }
    }
}