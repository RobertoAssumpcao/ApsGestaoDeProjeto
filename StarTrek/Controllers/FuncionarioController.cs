using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarTrek.Data;
using StarTrek.Models;

namespace StarTrek.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FuncionarioController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Funcionario> objFuncionarioList = _db.Funcionarios.ToList();
            return View(objFuncionarioList);
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
        public IActionResult Adicionar(Funcionario obj)
        {
            if (ModelState.IsValid)
            {
                _db.Funcionarios.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Funcionario adicionado com sucesso";
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
                var funcionarioFromDb = _db.Funcionarios.Find(id);
                if (funcionarioFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(funcionarioFromDb);
                }
            }
        }
        [Authorize]
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Funcionario obj)
        {
            if (ModelState.IsValid)
            {
                _db.Funcionarios.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Funcionario alterado com sucesso";
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
                var funcionarioFromDb = _db.Funcionarios.Find(id);
                if (funcionarioFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(funcionarioFromDb);
                }
            }
        }
        [Authorize]
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarPost(int? id)
        {
            var obj = _db.Funcionarios.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _db.Funcionarios.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Funcionario excluido com sucesso";
                return RedirectToAction("Index");
            }
        }
    }
}