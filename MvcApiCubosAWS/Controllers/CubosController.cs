using Microsoft.AspNetCore.Mvc;
using MvcApiCubosAWS.Models;
using MvcApiCubosAWS.Repositories;

namespace MvcApiCubosAWS.Controllers
{
    public class CubosController : Controller
    {
        private RepositoryCubos repo;

        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Cubo> cubos = await this.repo.GetCubosAsync();
            return View(cubos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Cubo cubo = await this.repo.FindCuboAsync(id);
            return View(cubo);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string nombre, string marca, string imagen, int precio)
        {
            await this.repo.CreateCuboAsync(nombre, marca, imagen, precio);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Cubo cubo = await this.repo.FindCuboAsync(id);
            return View(cubo);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, string nombre, string marca, string imagen, int precio)
        {
            await this.repo.UpdateCuboAsync(id, nombre, marca, imagen, precio);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.repo.DeleteCuboAsync(id);
            return RedirectToAction("Index");
        }
    }
}
