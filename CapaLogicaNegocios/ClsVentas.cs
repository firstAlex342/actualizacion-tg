using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
    public class ClsVentas
    {
        ClsManejador M = new ClsManejador();
        public DateTime m_FechaInicioBusqueda { get; set; }
        public DateTime m_FechaFinBusqueda { get; set; }
        public DataTable buscarVentas()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@FechaInicioBusqueda", m_FechaInicioBusqueda));
            lst.Add(new ClsParametros("@FechaFinBusqueda", m_FechaFinBusqueda));
            return M.Listado("buscar_ventas", lst);
        }
    }
}
