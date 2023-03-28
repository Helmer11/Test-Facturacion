using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_Schad.Controllers
{
    public class CustomeTypeController : Controller
    {
        // GET: CustomeTypeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomeTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomeTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomeTypeController/Create
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

        // GET: CustomeTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomeTypeController/Edit/5
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

        // GET: CustomeTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomeTypeController/Delete/5
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
