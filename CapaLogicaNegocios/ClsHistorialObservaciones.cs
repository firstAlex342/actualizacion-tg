using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
    public class ClsHistorialObservaciones
    {
        public DateTime m_FechaHistorial { get; set; }
        public int m_IdUsuario { get; set; }
        public DateTime m_FechaInicioBusquedaH { get; set; }
        public DateTime m_FechaFinBusquedaH { get; set; }

        ClsManejador M = new ClsManejador();

        public DataTable buscarHisObGenerales()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@IdSocio", m_IdUsuario));
            lst.Add(new ClsParametros("@FechaInicioBusqueda", m_FechaInicioBusquedaH));
            lst.Add(new ClsParametros("@FechaFinBusqueda", m_FechaFinBusquedaH));
            return M.Listado("buscar_hisObGenerales", lst);
        }
        public DataTable buscarHisObCaja()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@IdSocio", m_IdUsuario));
            lst.Add(new ClsParametros("@FechaInicioBusqueda", m_FechaInicioBusquedaH));
            lst.Add(new ClsParametros("@FechaFinBusqueda", m_FechaFinBusquedaH));
            return M.Listado("buscar_hisObCaja", lst);
        }
        public DataTable buscarHisObGeneralesID()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@IdSocio", m_IdUsuario));
            return M.Listado("buscar_hisObGeneralesID", lst);
        }
        public DataTable buscarHisObCajaID()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@IdSocio", m_IdUsuario));
            return M.Listado("buscar_hisObCajaID", lst);
        }
        public DataTable buscarHisObGeneralesFecha()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@FechaInicioBusqueda", m_FechaInicioBusquedaH));
            lst.Add(new ClsParametros("@FechaFinBusqueda", m_FechaFinBusquedaH));
            return M.Listado("buscar_hisObGeneralesFecha", lst);
        }
        public DataTable buscarHisObCajaFecha()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@FechaInicioBusqueda", m_FechaInicioBusquedaH));
            lst.Add(new ClsParametros("@FechaFinBusqueda", m_FechaFinBusquedaH));
            return M.Listado("buscar_hisObCajaFecha", lst);
        }
    }
}
