using Lab5_InventarioEF_C06978.Data;
using Lab5_InventarioEF_C06978.Models;

namespace Lab5_InventarioEF_C06978.Data
{

    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        // Inyectamos el DbContext por el constructor
        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            return _context.Productos.ToList();
        }

        public Producto ObtenerPorId(int id)
        {
            // Buscamos el producto por su llave primaria
            return _context.Productos.Find(id);
        }

        public void Agregar(Producto p)
        {
            _context.Productos.Add(p);
            _context.SaveChanges(); // ¡Muy importante para persistir en la BD!
        }

        public void Editar(Producto p)
        {
            _context.Productos.Update(p);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var producto = ObtenerPorId(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
        }
    }
}