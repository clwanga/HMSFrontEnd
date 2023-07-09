    using InterviewFrontEnd.Endpoints;
using InterviewFrontEnd.Models;
using InterviewWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using static InterviewWebAPI.Models.Requests;
using static InterviewWebAPI.Models.Responses;

namespace InterviewFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LandingPage()
        {
            return View();
        }

        public IActionResult RegisterPatient()
        {
            return View();
        }

        public IActionResult AddVitals()
        {
            return View();
        }

        public IActionResult Reports()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> AddPatient(PatientRegRequest param)
        {
            RestClient _client = new(Connections.BaseURL);
            int code = 0;
            string message = String.Empty;

            try
            {
                PatientRegRequest requestParameters = new()
                {
                    DOB = param.DOB,
                    FirstName = param.FirstName,
                    LastName = param.LastName,
                    Gender = param.Gender,
                };

                string serializedReqParameters = JsonConvert.SerializeObject(requestParameters);

                var request = new RestRequest(Connections.AddNewPatient).AddJsonBody(serializedReqParameters);

                var response = await _client.ExecutePostAsync<PatientRegResponse>(request);

                if (!response.IsSuccessful)
                {
                    code = (int)response.StatusCode;
                    message = "Failed to Send Request";
                }

                try
                {
                    var json = JsonConvert.DeserializeObject<PatientRegResponse>(response.Content);

                    code = (int)json.code;
                    message = json.message.ToString();

                    string stringjson1 = JsonConvert.SerializeObject(json);

                    return stringjson1;
                }
                catch (JsonSerializationException exx)
                {
                    code = (int)response.StatusCode;
                    message = exx.Message;

                    return message;
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}