using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using NASAWebApp.Models;
using NASAWebApp.Models.AssetDetails;
using NASAWebApp.Models.DONKI;
using NASAWebApp.Models.EarthAssetModels;
using NASAWebApp.Models.EpicImagesModels;
using NASAWebApp.Models.FLR;
using NASAWebApp.Models.NasaSearch;
using NASAWebApp.Models.NEO;
using System.Net.Http;
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

        public IActionResult CME()//DONKI
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CME(string startDate, string endDate)
        {
           
            var url = $"https://api.nasa.gov/DONKI/CME?startDate={startDate}&endDate={endDate}&api_key={apiKey}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Failed to fetch data from NASA API.";
                return View("Index");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var cmes = JsonSerializer.Deserialize<List<CME>>(jsonData);

            return View("Results", cmes);
        }


        public async Task<IActionResult> SolarFlares(string startDate, string endDate)
        {
            if (startDate == null || endDate == null)
            {
                return View();
            }

            string apiUrl = $"https://api.nasa.gov/DONKI/FLR?startDate={startDate}&endDate={endDate}&api_key={apiKey}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error", new { Message = "Unable to fetch data from NASA API." });
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var solarFlares = JsonSerializer.Deserialize<List<SolarFlare>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(solarFlares);
        }


        [HttpGet]
        public IActionResult EarthAsset()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EarthAsset(string date)
        {
            string apiUrl = $"https://api.nasa.gov/planetary/earth/assets?lon=89&lat=23&date={date}&dim=1&api_key=9u1mwSQr5URVzMfzvfB1H0Krkvn4NDJCVS5NdqPx";
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                ViewData["Error"] = "Unable to fetch data from NASA API. Please check the input date or try again later.";
                return View("Index");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var earthAsset = JsonSerializer.Deserialize<EarthAsset>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(earthAsset);
        }


        [HttpGet]
        public IActionResult EpicImages()
        {
            return View();
        }

        [HttpPost]
        [ActionName("EpicImages")]
        public async Task<IActionResult> EpicImagesPost()
        {
            string apiUrl = "https://api.nasa.gov/EPIC/api/natural/images?api_key=9u1mwSQr5URVzMfzvfB1H0Krkvn4NDJCVS5NdqPx";
            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                ViewData["Error"] = "Unable to fetch data from NASA API. Please try again later.";
                return View("Index");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var images = JsonSerializer.Deserialize<List<EpicImage>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View( images);
        }

        public async Task<IActionResult> LaunchImages()
        {
            string apiUrl = "https://images-api.nasa.gov/search?q=Mission";
            NasaApiResponse apiResponse = null;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    apiResponse = JsonSerializer.Deserialize<NasaApiResponse>(json);
                }
            }
            catch
            {
                // Handle exceptions (e.g., log errors or display an error message)
            }

            if (apiResponse?.Collection?.Items == null)
            {
                ViewBag.ErrorMessage = "No data available.";
                return View("Error");
            }

            return View(apiResponse.Collection.Items);
        }


        public async Task<IActionResult> AssetDetails(string nasaId)
        {
            if (string.IsNullOrEmpty(nasaId))
            {
                return BadRequest("NASA ID is required.");
            }

            string apiUrl = $"https://images-api.nasa.gov/asset/{nasaId}";
            NasaAsset nasaAsset = null;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    // Use JsonSerializer with relaxed options to handle special characters
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true, // Case insensitive deserialization
                        ReadCommentHandling = JsonCommentHandling.Skip,
                        AllowTrailingCommas = true
                    };

                    nasaAsset = JsonSerializer.Deserialize<NasaAsset>(json, options);
                }
            }
            catch (JsonException ex)
            {
                // Log error and display a friendly message
                Console.WriteLine($"JSON Parsing Error: {ex.Message}");
                ViewBag.ErrorMessage = "An error occurred while processing the NASA data.";
                return View("Error");
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Console.WriteLine($"Error: {ex.Message}");
                ViewBag.ErrorMessage = "An unexpected error occurred.";
                return View("Error");
            }

            if (nasaAsset?.Collection?.Items == null || !nasaAsset.Collection.Items.Any())
            {
                ViewBag.ErrorMessage = "No assets available for this NASA ID.";
                return View("Error");
            }

            return View(nasaAsset.Collection.Items);
        }


    }
}
