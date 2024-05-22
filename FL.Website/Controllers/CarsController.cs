using FL.Infrastructure.Messaging.Response;
using FL.Infrastructure.Models.Request;
using FL.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FL.Website.Controllers
{
    public class CarsController : Controller
    {
        private Uri baseAddress = new("http://localhost:5159/api");
        private readonly HttpClient _client;
        public CarsController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        // GET: CarsController
        public async Task<ActionResult> Index()
        {
            var token = await GetToken();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);

            var response = await _client.GetAsync(_client.BaseAddress + "/cars?currentPage=1&elementsPerPage=5");
            if (!response.IsSuccessStatusCode)
            {
                return View();
            }

            var data = await response.Content.ReadAsStringAsync() ?? "";
            var json = JsonConvert.DeserializeObject<GetCarResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var cars = json.Cars.ToList();

            return View(cars);
        }
        private static async Task<TokenModel> GetToken()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new("http://localhost:5159/api/auth?clientId=test&secret=test");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                HttpResponseMessage response = await client.GetAsync("");
                var data = await response.Content.ReadAsStringAsync() ?? "";
                var token = JsonConvert.DeserializeObject<TokenModel>(data) ?? throw new ArgumentNullException("Idk Check somthing token is null...");
                return token;
            }
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CarModel car)
        {
            try
            {
                var token = await GetToken();
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);
                var response = await _client.PostAsJsonAsync<CarModel>(_client.BaseAddress + "/cars", car);
                if (!response.IsSuccessStatusCode)
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var token = await GetToken();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);

            var response = await _client.GetAsync(_client.BaseAddress + $"/cars?id={id}");
            if (!response.IsSuccessStatusCode)
            {
                return View();
            }

            var data = await response.Content.ReadAsStringAsync() ?? "";
            var json = JsonConvert.DeserializeObject<GetCarResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var cars = json.Cars.ToList();

            return View(cars.FirstOrDefault());
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, CarModel car)
        {
            try
            {
                var token = await GetToken();
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);
                var response = await _client.DeleteAsync(_client.BaseAddress + $"/cars?id={id}");
                if (!response.IsSuccessStatusCode)
                {
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
