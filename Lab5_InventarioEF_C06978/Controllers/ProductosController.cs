using Lab5_InventarioEF_C06978.Data;
using Lab5_InventarioEF_C06978.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab5_InventarioEF_C06978.Controllers
{

    public class ProductosController : Controller
    {
        private readonly IProductoRepository _repo;
        public ProductosController(IProductoRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index() => View(_repo.ObtenerTodos());
      
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _repo.Agregar(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        public IActionResult Edit(int id)
        {
            var producto = _repo.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repo.Editar(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        public IActionResult Delete(int id)
        {
            var producto = _repo.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}