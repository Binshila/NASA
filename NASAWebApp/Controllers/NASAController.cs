using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NASAWebApp.AppModels;
using NASAWebApp.Models;
using NASAWebApp.Models.AssetDetails;
using NASAWebApp.Models.DONKI;
using NASAWebApp.Models.EarthAssetModels;
using NASAWebApp.Models.EpicImagesModels;
using NASAWebApp.Models.FLR;
using NASAWebApp.Models.Mars;
using NASAWebApp.Models.NasaSearch;
using NASAWebApp.Models.NEO;
using NASAWebApp.ViewModels;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;

namespace NASAWebApp.Controllers
{
    public class NASAController : Controller
    {
        string apiKey = "9u1mwSQr5URVzMfzvfB1H0Krkvn4NDJCVS5NdqPx";
        //Follow the link to get your own NASA api key: 

        NasaContext _nasaContext;

        private readonly HttpClient _httpClient;


        public NASAController(IHttpClientFactory httpClientFactory, NasaContext nasaContext)
        {
            _httpClient = httpClientFactory.CreateClient();
            _nasaContext = nasaContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Astronomical Picture Of The Day
        //http://..../NASA/Apod
        //[Authorize]
        public async Task<IActionResult> Apod(bool isHome=false)
        {

            string apiUrl = $"https://api.nasa.gov/planetary/apod?api_key={apiKey}";

            ViewBag.isHome = isHome;

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

        [Authorize]
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
        [Authorize]
        public IActionResult NEO()
        {
            return View(new Dictionary<string, List<Models.NEO.NearEarthObject>>());
        }

        [HttpPost]
        [Authorize]
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
                return View(neoData?.NearEarthObjects);
            }
            catch (Exception ex)
            {
                // Log the exception and show an error message
                string str = $"Error fetching NEO data: {ex.Message}";
                return Content(str);
            }
        }

        [Authorize]
        public IActionResult CME()//DONKI
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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

        //Get and post togather
        [Authorize]
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
       // [Authorize(Roles ="Manager")]
        [Authorize]
        public IActionResult EarthAsset()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
        public IActionResult EpicImages()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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

            return View(images);
        }


        //get and post together
        [Authorize]
        public async Task<IActionResult> Search(string searchKey, string clearSearch)
        {
            int userId = (int)GetLoggedInUserId();

            if(clearSearch  != null)
            {

                // Retrieve all search histories for the specified user
                var userSearchHistory = _nasaContext.SearchHistories.Where(sh => sh.UserId == userId);

                if (!userSearchHistory.Any())
                {
                    // If no records are found, you can return a message or redirect
                    TempData["Message"] = "No search history found for the specified user.";
                    return RedirectToAction("Search");
                }

                // Remove the retrieved search histories
                _nasaContext.SearchHistories.RemoveRange(userSearchHistory);

                // Save changes to the database
                await _nasaContext.SaveChangesAsync();

                // Redirect or return a response
                TempData["Message"] = "Search history deleted successfully.";
                return RedirectToAction("Search");
            }

            // Fetch previous search terms for the user
            var searchHistory = _nasaContext.SearchHistories
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.SearchDate) // Optional: Order by most recent
                .Select(s => s.SearchTerm)
                .Distinct() // Remove duplicates
                .ToList();

            ViewBag.SearchHistories = searchHistory ;

            ViewBag.SearchKey = searchKey;
            if (string.IsNullOrEmpty(searchKey))
            {
                return View();
            }


            string apiUrl = "https://images-api.nasa.gov/search?q=" + searchKey;
            NasaApiResponse apiResponse = null;



            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    HttpContext.Session.SetString("SearchJson", json);

                    apiResponse = JsonSerializer.Deserialize<NasaApiResponse>(json);

                    if (apiResponse?.Collection?.Items == null)
                    {
                        ViewBag.ErrorMessage = "No data available.";
                        return View("Error");
                    }
                    else
                    {
                        //save the search as history

                      

                        _nasaContext.SearchHistories.Add(new SearchHistory() {UserId= userId, SearchTerm=searchKey, SearchDate=DateTime.Now});
                        await _nasaContext.SaveChangesAsync();

                        return View(apiResponse.Collection.Items);
                    }
                }
            }
            catch(Exception ex)
            {
                // Handle exceptions (e.g., log errors or display an error message)
                ViewBag.Error = "Error in searching: " + ex.Message;
              
            }


            return View();

        }

        [Authorize]
        public IActionResult SearchHistory()
        {
            int userId = (int)GetLoggedInUserId();

             
            // Fetch previous search terms for the user
            var searchHistory = _nasaContext.SearchHistories
                .Where(s => s.UserId == userId)
                .OrderByDescending(s => s.SearchDate) // Optional: Order by most recent                
                .ToList();

            return View(searchHistory);
        }

        public IActionResult DownloadResult(string searchKey)
        {
            // Retrieve the JSON data from the session
            string? json = HttpContext.Session.GetString("SearchJson");

            // Check if the session data exists
            if (string.IsNullOrEmpty(json))
            {
                // If no data is found, return a 404 Not Found response
                return NotFound("No search results found to download.");
            }

            try
            {
                // Parse and reformat the JSON data to be indented
                var parsedJson = System.Text.Json.JsonSerializer.Deserialize<object>(json);
                var formattedJson = System.Text.Json.JsonSerializer.Serialize(parsedJson, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true // Enable indentation
                });

                // Convert the formatted JSON string to a byte array
                byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(formattedJson);

                // Create a file name for the download
                string fileName = $"SearchResults-{searchKey}-{DateTime.Now.ToString("MMM-dd-yyyy hh:mm:ss tt")}.json";

                // Return the JSON data as a downloadable file
                return File(jsonBytes, "application/json", fileName);
            }
            catch (System.Text.Json.JsonException)
            {
                // Handle any issues with JSON parsing
                return BadRequest("Invalid JSON data found in the session.");
            }
        }



        [Authorize]
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



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Find the user by email
                var user = _nasaContext.Users.FirstOrDefault(u => u.Email == model.Email);



                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                    ViewBag.Msg = "Invalid email or password.";
                    return View(model);
                }

                // Verify the password
                var passwordHasher = new PasswordHasher<string>();
                var passwordVerificationResult = passwordHasher.VerifyHashedPassword(null, user.PasswordHash, model.Password);

                if (passwordVerificationResult != PasswordVerificationResult.Success)
                {
                    ModelState.AddModelError("", "Invalid email or password.");
                    return View(model);
                }



                // Create a claims identity for the user
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim("FullName", user.FullName ?? string.Empty), // FullName as custom claim
                //new Claim(ClaimTypes.Role, "Admin"),
                //new Claim(ClaimTypes.Role, "Manager"),
            };

                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");//CookieAuth is the authentication type

                // Sign in the user and create the cookie
                await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity));

                TempData["SuccessMessage"] = "Login successful!";






                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

               return View("Error", new ErrorViewModel {RequestId=Guid.NewGuid().ToString() , ErrorMessage=ex.Message});
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Save user to the database (hashed password, etc.)
                // Check if the email is already registered
                var existingUser = _nasaContext.Users.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email is already in use.");
                    return View(model);
                }

                // Hash the password
                var passwordHasher = new PasswordHasher<string>();
                var hashedPassword = passwordHasher.HashPassword(null, model.Password);

                // Create a new User object
                var newUser = new User
                {
                    Email = model.Email,
                    PasswordHash = hashedPassword,
                    FullName = model.FullName,
                    CreatedAt = DateTime.Now
                };

                // Save the user to the database
                _nasaContext.Users.Add(newUser);
                _nasaContext.SaveChanges();
                // Redirect to login or home page
                TempData["SuccessMessage"] = "Registration successful. You can now log in.";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {

                return View("Error", new ErrorViewModel {RequestId=Guid.NewGuid().ToString() , ErrorMessage=ex.Message});
            }
        }




        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            return View();
        }

        [HttpPost]
        [ActionName("Logout")]
        public async Task<IActionResult> LogoutPost()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            TempData["SuccessMessage"] = "You have been logged out.";
            return RedirectToAction("Login");
        }



        public IActionResult AccessDenied(string returnURL)
        {
            ViewBag.ReturnURL = returnURL;  
            return View();
        }

        private int? GetLoggedInUserId()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return int.TryParse(userIdClaim, out var userId) ? userId : null;
        }

    }
}
