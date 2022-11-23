using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarTrek.Data;
using StarTrek.Models;

namespace StarTrek.Controllers
{
    public class NaveController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NaveController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Nave> objNaveList = _db.Naves.ToList();
            return View(objNaveList);
        }

        [Authorize]
        // GET
        public IActionResult Adicionar()
        {
            return View();
        }
        [Authorize]
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Nave obj)
        {
            if (ModelState.IsValid)
            {
                _db.Naves.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Nave adicionada com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        [Authorize]
        // GET
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var naveFromDb = _db.Naves.Find(id);
                if (naveFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(naveFromDb);
                }
            }
        }
        [Authorize]
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Nave obj)
        {
            if (ModelState.IsValid)
            {
                _db.Naves.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Nave alterada com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        [Authorize]
        // GET
        public IActionResult Deletar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                var naveFromDb = _db.Naves.Find(id);
                if (naveFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(naveFromDb);
                }
            }
        }
        [Authorize]
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarPost(int? id)
        {
            var obj = _db.Naves.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _db.Naves.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Nave excluida com sucesso";
                return RedirectToAction("Index");
            }
        }
    }
}