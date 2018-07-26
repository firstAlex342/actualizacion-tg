using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaLogicaNegocios
{
   public class ClsClvMembresias
    {
        public int m_idClaveMembresias { get; set; }
        public char m_clvMembresia { get; set; }
        public string m_Descripcion { get; set; }

        ClsManejador M = new ClsManejador();

        public DataTable seleccionarClvMembresias()
        {
            return M.Listado("seleccionar_ClvMembresias",null);
        }

        public string clvMembresiasIngresar()
        {
            string respuesta = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@clvMembresia", m_clvMembresia));
                lst.Add(new ClsParametros("@Descripcion", m_Descripcion));

                /*Mensaje de salida*/
                lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 40));
                M.Ejecutar_sp("ClvMembresias_ingresar", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[2].Valor.ToString();/////.valor 

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public string clvMembresiasEliminar()
        {
            string respuesta = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@idClaveMembresias", m_idClaveMembresias));

                /*Mensaje de salida*/
                lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 40));
                M.Ejecutar_sp("ClvMembresias_eliminar", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[1].Valor.ToString();/////.valor 

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }
    }
}
