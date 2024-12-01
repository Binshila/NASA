﻿using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using NASAWebApp.Models;
using NASAWebApp.Models.NEO;
using System.Text.Json;

namespace NASAWebApp.Controllers
{
    public class NASAController : Controller
    {
        string apiKey = "9u1mwSQr5URVzMfzvfB1H0Krkvn4NDJCVS5NdqPx";

        private readonly HttpClient _httpClient;
       

        public NASAController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        //Astronomical Picture Of The Day
        //http://..../NASA/Apod
        public async Task<IActionResult> Apod()
        {
        
            string apiUrl = $"https://api.nasa.gov/planetary/apod?api_key={apiKey}";

            //using HttpClient client = new HttpClient();

            try
            {
                // Make GET request
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

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

            //using HttpClient client = new HttpClient();

            try
            {
                // Make GET request
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

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


        [HttpGet]
        public IActionResult NEO()
        {
            return View(new Dictionary<string, List<Models.NEO.NearEarthObject>>());
        }

        [HttpPost]
        public async Task<IActionResult> NEO(DateTime startDate, DateTime endDate)
        {
            // Validate dates
            if (startDate > endDate)
            {
                ViewBag.Error = "Start date cannot be after end date.";
                return View(new Dictionary<string, List<Models.NEO.NearEarthObject>>());
            }

            // Format the dates
            string start = startDate.ToString("yyyy-MM-dd");
            string end = endDate.ToString("yyyy-MM-dd");

            // Construct the API URL
            string url = $"https://api.nasa.gov/neo/rest/v1/feed?start_date={start}&end_date={end}&api_key={apiKey}";

            try
            {
                // Fetch data from the API
                var neoData = await _httpClient.GetFromJsonAsync<Models.NEO.NeoResponse>(url);

                // Pass the data to the view
             //   return View(neoData?.NearEarthObjects ?? new Dictionary<string, List<NearEarthObject>>());
                return View(neoData?.NearEarthObjects );
            }
            catch (Exception ex)
            {
                // Log the exception and show an error message
                string str = $"Error fetching NEO data: {ex.Message}";
                return Content(str);
            }
        }
    }
}
