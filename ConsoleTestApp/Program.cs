using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleTestApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string apiKey = "9u1mwSQr5URVzMfzvfB1H0Krkvn4NDJCVS5NdqPx";
            string apiUrl = $"https://api.nasa.gov/planetary/apod?api_key={apiKey}";

            using HttpClient client = new HttpClient();

            try
            {
                // Make GET request
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read and deserialize JSON response
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    ApodResponse apod = JsonSerializer.Deserialize<ApodResponse>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    // Display data
                    Console.WriteLine($"Title: {apod.Title}");
                    Console.WriteLine($"Date: {apod.Date}");
                    Console.WriteLine($"Media Type: {apod.MediaType}");
                    Console.WriteLine($"Service Version: {apod.ServiceVersion}");
                    Console.WriteLine($"Explanation: {apod.Explanation}");
                    Console.WriteLine($"URL: {apod.Url}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }


            Console.ReadKey();
        }


        public class ApodResponse
        {
            public string Date { get; set; }
            public string Explanation { get; set; }
            [JsonPropertyName("media_type")]
            public string MediaType { get; set; }

            [JsonPropertyName("service_version")]
            public string ServiceVersion { get; set; }
            public string Title { get; set; }
            public string Url { get; set; }
        }

    }
}
