using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcorewebapp.Controllers
{
    public class MyTestHomeController : Controller
    {
        // GET: MyTestHomeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyTestHomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyTestHomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyTestHomeController/Create
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

        // GET: MyTestHomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyTestHomeController/Edit/5
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

        // GET: MyTestHomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyTestHomeController/Delete/5
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
