using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
    public class ClsMovCortesCaja
    {
        public DateTime m_FechaHora { get; set; }
        public int m_idUsuario { get; set; }
        ClsManejador M = new ClsManejador();
        public DataTable buscarCortesCajaXFecha()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@FechaHora", m_FechaHora));
            return M.Listado("buscar_CortesCajaXFecha", lst);
        }
        public DataTable buscarCortesCajaXUsuario()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@idUsuario", m_idUsuario));
            return M.Listado("buscar_CortesCajaXUsuario", lst);
        }
    }
}
