using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Consumer;
using Veterinaria.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Veterinaria.MVC.Controllers
{
    public class CitasController : Controller
    {
        // GET: CitasController
        public ActionResult Index()
        {
            var citas = Crud<Citas>.GetAll();
            return View(citas);
        }

        // GET: CitasController/Details/5
        public ActionResult Details(int id)
        {
            var cita = Crud<Citas>.GetById(id);
            if(cita == null)
            {
                return NotFound();
            }
            return View(cita);

        }
        private List<SelectListItem> GetDueños()
        {
            var dueños = Crud<Dueños>.GetAll();
            return dueños.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nombre_dueño
            }).ToList();
        }

        private List<SelectListItem> GetEspecies()
        {
            var especies = Crud<Especies>.GetAll();
            return especies.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nombre_especie
            }).ToList();
        }


        // GET: CitasController/Create
        public ActionResult Create()
        {
            ViewBag.Dueños = GetDueños();
            ViewBag.Especies = GetEspecies();
            return View();
        }

        // POST: CitasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Citas Cita)
        {
            try
            {
                Crud<Citas>.Create(Cita);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: CitasController/Edit/5
        public ActionResult Edit(int id)
        {
            var cita = Crud<Citas>.GetById(id);
            ViewBag.Dueños = GetDueños();
            ViewBag.Especies = GetEspecies();
            if(cita == null)
            {
                return NotFound();
            }
            return View(cita);
        }

        // POST: CitasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Citas cita)
        {
            try
            {
                Crud<Citas>.Update(id, cita);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View(cita);
            }
        }

        // GET: CitasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CitasController/Delete/5
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
