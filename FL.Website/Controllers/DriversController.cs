using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FL.Website.Controllers
{
    public class DriversController : Controller
    {
        // GET: DriversController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DriversController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DriversController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriversController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DriversController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DriversController/Edit/5
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

        // GET: DriversController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DriversController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
