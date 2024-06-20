using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Papeleria.MVC.Controllers
{
    public class MovimientoStockController : Controller
    {
        // GET: MovimientoStockController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovimientoStockController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovimientoStockController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovimientoStockController/Create
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

        // GET: MovimientoStockController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovimientoStockController/Edit/5
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

        // GET: MovimientoStockController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovimientoStockController/Delete/5
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
