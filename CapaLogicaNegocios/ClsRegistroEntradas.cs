using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
    public class ClsRegistroEntradas
    {
        public DateTime m_FechaRegistro { get; set; }
        public int m_IdSocio { get; set; }
        public DateTime m_FechaInicioBusqueda { get; set; }
        public DateTime m_FechaFinBusqueda { get; set; }

        ClsManejador M = new ClsManejador();

        public void guardarRegistro()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@idSocio", m_IdSocio));
                lst.Add(new ClsParametros("@fechaRegistro", m_FechaRegistro));
                M.Ejecutar_sp("insertar_registroEntrada", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable buscarRegistrosEntradas()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@IdSocio", m_IdSocio));
            lst.Add(new ClsParametros("@FechaInicioBusqueda", m_FechaInicioBusqueda));
            lst.Add(new ClsParametros("@FechaFinBusqueda", m_FechaFinBusqueda));
            return M.Listado("buscar_entradas", lst);
        }
    }
}
