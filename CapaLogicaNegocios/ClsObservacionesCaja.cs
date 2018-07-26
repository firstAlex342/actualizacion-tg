using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using System.Data;


namespace CapaLogicaNegocios
{
    public class ClsObservacionesCaja
    {
        public string m_texto { get; set; }
        public int m_idUsuario { get; set; }
        ClsManejador M = new ClsManejador();

        public string agregarObservacion()
        {
            string respuesta = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // pasamos los parametros para armar el SP de entrada
                lst.Add(new ClsParametros("@texto", m_texto));
                lst.Add(new ClsParametros("@idUsuario", m_idUsuario));
                //lst.Add(new ClsParametros("@Encontrado", null ));

                // pasamos los parametros para armar el SP de salida 1 si es encontrado 0 si no es encontrado
                lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 40));

                M.Ejecutar_sp("agregar_observaciones_caja", lst);

                respuesta = lst[2].Valor.ToString();/////.valor 


            }
            catch (Exception ex)
            {
                respuesta = ex.ToString();

            }



            return respuesta;
        }
    }
}
