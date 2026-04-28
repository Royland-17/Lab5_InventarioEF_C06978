using Lab5_InventarioEF_C06978.Models;

namespace Lab5_InventarioEF_C06978.Data
{
    public interface IProductoRepository
    {

        IEnumerable<Producto> ObtenerTodos();
        Producto ObtenerPorId(int id);
        void Agregar(Producto p);
        void Editar(Producto p);
        void Eliminar(int id);
    }
}