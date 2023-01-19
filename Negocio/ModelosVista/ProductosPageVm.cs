using Negocio.Entidades;

namespace Negocio.ModelosVista
{
    public class ProductosPage
    {
        public int Pagina { get; set; }
        public int Paginas { get; set; }
        public int Total { get; set; }
        public List<Producto>? Items { get; set; }
    }
}