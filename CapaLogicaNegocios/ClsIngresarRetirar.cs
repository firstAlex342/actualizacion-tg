using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
    public class ClsIngresarRetirar
    {
        public int m_usuario { get; set; }
        public double m_cantidad { get; set; }
        public string m_observacion { get; set; }
        public int m_tipoMovCaja { get; set; }
        public DateTime m_fecha { get; set; }

        ClsManejador M = new ClsManejador();
        public string guardarMovimientoCaja()
        {
            string mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@cantidad", m_cantidad));
                lst.Add(new ClsParametros("@detalle", m_observacion));
                lst.Add(new ClsParametros("@tipoMovimiento", m_tipoMovCaja));
                lst.Add(new ClsParametros("@idUsuario", m_usuario));
                lst.Add(new ClsParametros("@mensaje", SqlDbType.VarChar, 50));
                M.Ejecutar_sp("movimientos_caja", lst);
                mensaje = lst[4].Valor.ToString();
                return mensaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable buscarCortesCajaXFecha()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@Fecha", m_fecha));
            return M.Listado("buscar_MovCajaFecha", lst);
        }
        public DataTable buscarCortesCajaXUsuario()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@idUsuario", m_usuario));
            return M.Listado("buscar_MovCajaUsuario", lst);
        }
    }
}
