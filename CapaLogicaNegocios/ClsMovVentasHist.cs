using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaLogicaNegocios
{
   public class ClsMovVentasHist
    {
        public int m_FolioVenta { get; set; }
        public int m_Recnum { get; set; }
        public string m_Item { get; set; }
        public char m_Tipo { get; set; }
        public double m_Monto { get; set; }
        public string m_User_modif { get; set; }
        public int m_claveTipoMembresia { get; set; }
        public int m_acivo { get; set; }
        public bool m_diasViajero { get; set; }
        public int m_numDiasViajero { get; set; }
        public int m_numeroSumaFechaVencimiento { get; set; }
        public int m_idSocio { get; set; }
        public DateTime fechaVencimiento { get; set; }
        ClsManejador M = new ClsManejador();

        public void guardarMovimientoVenta()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@FolioVenta", m_FolioVenta));
                lst.Add(new ClsParametros("@Item", m_Item));
                lst.Add(new ClsParametros("@Tipo", m_Tipo));
                lst.Add(new ClsParametros("@Monto", m_Monto));
                lst.Add(new ClsParametros("@User_modif", m_User_modif));
                lst.Add(new ClsParametros("@claveTipoMembresia", m_claveTipoMembresia));
                lst.Add(new ClsParametros("@idSocio", m_idSocio));
                lst.Add(new ClsParametros("@diasViajero", m_diasViajero));
                lst.Add(new ClsParametros("@numDiasViajero", m_numDiasViajero));
                lst.Add(new ClsParametros("@FechaVencimiento", fechaVencimiento));


                M.Ejecutar_sp("guardar_movimiento_venta", lst);
                //Retornamos el mensaje  de salida del SP

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable movVentasHistBuscarVenta()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@Recnum", m_Recnum));
            return M.Listado("movVentasHist_buscar_venta", lst);
        }
    }
}
