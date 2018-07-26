using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaLogicaNegocios
{
    public class ClsProductos
    {
        public int m_idProducto { get; set; }
        public string m_descripcion { get; set; }
        public double m_precio { get; set; }

        ClsManejador M = new ClsManejador();

        public DataTable SeleccionarProductos()
        {
            return M.Listado("seleccionar_productos", null);
        }

        public DataTable buscarProducto()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@idProducto", m_idProducto));
            return M.Listado("buscarProducto", lst);
        }
    }
}
