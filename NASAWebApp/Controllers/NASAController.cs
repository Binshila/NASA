using Microsoft.AspNetCore.Mvc;
using NASAWebApp.Models;
using System.Text.Json;

namespace NASAWebApp.Controllers
{
    public class NASAController : Controller
    {
        string apiKey = "9u1mwSQr5URVzMfzvfB1H0Krkvn4NDJCVS5NdqPx";
        public IActionResult Index()
        {
            return View();
        }

        //Astronomical Picture Of The Day
        //http://..../NASA/Apod
        public async Task<IActionResult> Apod()
        {
        
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

                   return View(apod);
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





            return View();
        }


        public async Task<IActionResult> MarsPhotos()
        {
           
            int sol = 1000; // Example sol (Martian day)
            string camera = "fhaz"; // Example camera
            string apiUrl = $"https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol={sol}&camera={camera}&api_key={apiKey}";

            using HttpClient client = new HttpClient();

            try
            {
                // Make GET request
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Read and deserialize JSON response
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    MarsPhotoResponse marsPhotoResponse = JsonSerializer.Deserialize<MarsPhotoResponse>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                   
                    return View(marsPhotoResponse.Photos);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return Content("Error");
        }

    }
}
