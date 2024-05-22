using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FL.Website.Controllers
{
    public class LapsController : Controller
    {
        // GET: LapsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LapsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LapsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LapsController/Create
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

        // GET: LapsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LapsController/Edit/5
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

        // GET: LapsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LapsController/Delete/5
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
