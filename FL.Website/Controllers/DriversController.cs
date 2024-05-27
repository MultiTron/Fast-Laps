using FL.Infrastructure.Messaging.Response;
using FL.Infrastructure.Messaging.Response.Driver;
using FL.Infrastructure.Models.Request;
using FL.Infrastructure.Models.Response;
using FL.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FL.Website.Controllers
{
    public class DriversController : Controller
    {
        private Uri baseAddress = new("http://localhost:5159/api/drivers");
        private readonly HttpClient _client;
        public DriversController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
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

        // GET: DriversController
        public async Task<ActionResult> Index()
        {
            var token = await GetToken();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);

            var response = await _client.GetAsync(_client.BaseAddress + $"?currentPage={1}&elementsPerPage={5}");
            if (!response.IsSuccessStatusCode)
            {
                return View();
            }

            var data = await response.Content.ReadAsStringAsync() ?? "";
            var json = JsonConvert.DeserializeObject<GetDriverResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var drivers = json.Drivers.ToList();

            return View(drivers);
        }

        // GET: DriversController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var token = await GetToken();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);

            var response = await _client.GetAsync(_client.BaseAddress + $"/find/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View();
            }

            var data = await response.Content.ReadAsStringAsync() ?? "";
            var json = JsonConvert.DeserializeObject<GetDriverResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var driver = json.Drivers.FirstOrDefault();

            return View(driver);
        }

        // GET: DriversController/Create
        public async Task<ActionResult> Create()
        {
            var token = await GetToken();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);

            var response = await _client.GetAsync("http://localhost:5159/api/cars/all");
            if (!response.IsSuccessStatusCode)
            {
                return View();
            }

            var data = await response.Content.ReadAsStringAsync() ?? "";
            var json = JsonConvert.DeserializeObject<GetCarResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var cars = json.Cars.ToList();
            var dictionary = new Dictionary<int, string>();
            foreach (var car in cars)
            {
                dictionary.Add(car.Id, $"{car.Brand} {car.Model}");
            }
            var driverModel = new CreateDriverViewModel();
            driverModel.Cars = dictionary;
            return View(driverModel);
        }

        // POST: DriversController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateDriverViewModel driver)
        {
            try
            {
                var token = await GetToken();
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);
                var model = new DriverModel()
                {
                    FirstName = driver.FirstName,
                    LastName = driver.LastName,
                    CarId = driver.CarId
                };
                var response = await _client.PostAsJsonAsync<DriverModel>(_client.BaseAddress, model);
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

        // GET: DriversController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var token = await GetToken();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);

            var response = await _client.GetAsync(_client.BaseAddress + $"/find/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var data = await response.Content.ReadAsStringAsync() ?? "";
            var driverJson = JsonConvert.DeserializeObject<GetDriverResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var driver = driverJson.Drivers.FirstOrDefault();


            response = await _client.GetAsync("http://localhost:5159/api/cars/all");
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            data = await response.Content.ReadAsStringAsync() ?? "";
            var carsJson = JsonConvert.DeserializeObject<GetCarResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var cars = carsJson.Cars.ToList();
            var dictionary = new Dictionary<int, string>();
            foreach (var car in cars)
            {
                dictionary.Add(car.Id, $"{car.Brand} {car.Model}");
            }
            var driverModel = new EditDriverViewModel();
            driverModel.Cars = dictionary;
            driverModel.FirstName = driver.FirstName;
            driverModel.LastName = driver.LastName;
            driverModel.Id = driver.Id;
            driverModel.CarId = driver.CarId;

            return View(driverModel);
        }

        // POST: DriversController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditDriverViewModel driver)
        {
            try
            {
                var token = await GetToken();
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);

                var body = new DriverModel()
                {
                    FirstName = driver.FirstName,
                    LastName = driver.LastName,
                    CarId = driver.CarId,
                };

                var response = await _client.PutAsJsonAsync(_client.BaseAddress + $"/{driver.Id}", body);
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

        // GET: DriversController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var token = await GetToken();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);

            var response = await _client.GetAsync(_client.BaseAddress + $"/find/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return View();
            }

            var data = await response.Content.ReadAsStringAsync() ?? "";
            var json = JsonConvert.DeserializeObject<GetDriverResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var driver = json.Drivers.FirstOrDefault();

            return View(driver);
        }

        // POST: DriversController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(DriverViewModel driver)
        {
            try
            {
                var token = await GetToken();
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);
                var response = await _client.DeleteAsync(_client.BaseAddress + $"/{driver.Id}");
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
