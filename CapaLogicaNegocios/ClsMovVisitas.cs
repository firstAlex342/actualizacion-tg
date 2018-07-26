using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
namespace CapaLogicaNegocios
{
   public class ClsMovVisitas
    {
        public char m_tipo { get; set; }
        public int m_folioVenta { get; set; }
        
        ClsManejador M = new ClsManejador();

        public string movVisitasInsert()
        {
            try
            {
                string respuesta;
                List<ClsParametros> lst = new List<ClsParametros>();

                //Parametro de entrada
                lst.Add(new ClsParametros("@tipo", m_tipo));
                lst.Add(new ClsParametros("@folioVenta", m_folioVenta));
                //PArametro de salida
                lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 40));
                M.Ejecutar_sp("movVisitas_insert", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[2].Valor.ToString();/////.valor 
                return respuesta;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
