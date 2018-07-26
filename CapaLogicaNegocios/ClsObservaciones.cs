using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
	 public class ClsObservaciones
	{
		public int m_IdObservacion { get; set; }
		public DateTime m_Fecha { get; set; }
		public String m_Observacion { get; set; }
		public int m_IdSocio { get; set; }
		ClsManejador M = new ClsManejador();
		public DataTable BuscarObservacion()
		{
			List<ClsParametros> lst = new List<ClsParametros>();
			lst.Add(new ClsParametros("@IdSocio", m_IdSocio));
			return M.Listado("buscar_observacion", lst);
		}
        public string guardarObservacion()
        {
            string mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@Fecha", m_Fecha));
                lst.Add(new ClsParametros("@Observacion", m_Observacion));
                lst.Add(new ClsParametros("@idSocio", m_IdSocio));

                /*Mensaje de salida*/
                lst.Add(new ClsParametros("@mensaje", SqlDbType.VarChar, 40));
                M.Ejecutar_sp("insertar_observacion", lst);
                //Retornamos el mensaje  de salida del SP
                mensaje = lst[3].Valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }
    }
}
