using FL.Infrastructure.Messaging.Response.Driver;
using FL.Infrastructure.Messaging.Response.Lap;
using FL.Infrastructure.Models.Request;
using FL.Infrastructure.Models.Response;
using FL.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FL.Website.Controllers
{
    public class LapsController : Controller
    {
        private Uri baseAddress = new("http://localhost:5159/api/laps");
        private readonly HttpClient _client;
        public LapsController()
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

        // GET: LapsController
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
            var json = JsonConvert.DeserializeObject<GetLapResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var laps = json.Laps.ToList();

            return View(laps);
        }

        // GET: LapsController/Details/5
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
            var json = JsonConvert.DeserializeObject<GetLapResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var lap = json.Laps.FirstOrDefault();

            return View(lap);
        }

        // GET: LapsController/Create
        public async Task<ActionResult> Create()
        {
            var token = await GetToken();
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);

            var response = await _client.GetAsync("http://localhost:5159/api/drivers/all");
            if (!response.IsSuccessStatusCode)
            {
                return View();
            }

            var data = await response.Content.ReadAsStringAsync() ?? "";
            var json = JsonConvert.DeserializeObject<GetDriverResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var drivers = json.Drivers.ToList();
            var dictionary = new Dictionary<int, string>();
            foreach (var driver in drivers)
            {
                dictionary.Add(driver.Id, $"{driver.FirstName} {driver.LastName}");
            }
            var lapModel = new CreateLapViewModel();
            lapModel.Drivers = dictionary;
            return View(lapModel);
        }

        // POST: LapsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLapViewModel lap)
        {
            try
            {
                var token = await GetToken();
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);
                var model = new LapModel()
                {
                    Sector1 = lap.Sector1,
                    Sector2 = lap.Sector2,
                    Sector3 = lap.Sector3,
                    LapTime = lap.LapTime,
                    DriverId = lap.DriverId
                };
                var response = await _client.PostAsJsonAsync<LapModel>(_client.BaseAddress, model);
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

        // GET: LapsController/Edit/5
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
            var lapJson = JsonConvert.DeserializeObject<GetLapResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var lap = lapJson.Laps.FirstOrDefault();


            response = await _client.GetAsync("http://localhost:5159/api/drivers/all");
            if (!response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            data = await response.Content.ReadAsStringAsync() ?? "";
            var driverJson = JsonConvert.DeserializeObject<GetDriverResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var drivers = driverJson.Drivers.ToList();
            var dictionary = new Dictionary<int, string>();
            foreach (var driver in drivers)
            {
                dictionary.Add(driver.Id, $"{driver.FirstName} {driver.LastName}");
            }
            var lapModel = new EditLapViewModel();
            lapModel.Drivers = dictionary;
            lapModel.DriverId = lap.DriverId;
            lapModel.LapTime = lap.LapTime;
            lapModel.Id = lap.Id;
            lapModel.Sector1 = (TimeSpan)lap.Sector1;
            lapModel.Sector2 = (TimeSpan)lap.Sector2;
            lapModel.Sector3 = (TimeSpan)lap.Sector3;

            return View(lapModel);
        }

        // POST: LapsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditLapViewModel lap)
        {
            try
            {
                var token = await GetToken();
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);

                var body = new LapModel()
                {
                    Sector1 = lap.Sector1,
                    Sector2 = lap.Sector2,
                    Sector3 = lap.Sector3,
                    LapTime = lap.LapTime,
                    DriverId = lap.DriverId
                };

                var response = await _client.PutAsJsonAsync(_client.BaseAddress + $"/{lap.Id}", body);
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

        // GET: LapsController/Delete/5
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
            var json = JsonConvert.DeserializeObject<GetLapResponse>(data) ?? throw new ArgumentNullException("Deserialization Issue");
            var lap = json.Laps.FirstOrDefault();

            return View(lap);
        }

        // POST: LapsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(LapViewModel lap)
        {
            try
            {
                var token = await GetToken();
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Token);
                var response = await _client.DeleteAsync(_client.BaseAddress + $"/{lap.Id}");
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
