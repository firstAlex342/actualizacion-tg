using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogicaNegocios
{
    public class ClsSerial
    {
        //--------------------------properties
        public string ClaveConexion { set; get; }
        public bool EstadoClaveConexion { set; get; }
        public DateTime FechaVencimientoClaveConexion { set; get; }
        public int NumeroMensajesSMS { set; get; }
        public bool EstadoMensajesSMS { set; get; }
        

        ClsManejador2 M = new ClsManejador2();

        public DataTable RecuperarSerial()
        {
            List<ClsParametros2> lst = new List<ClsParametros2>();
            lst.Add(new ClsParametros2("@claveConexionBuscada", ClaveConexion));
            
            return M.Listado("pa_RecuperarSerial", lst);
        }

        public string ModificarEnSerial_FechaVencimientoDeClave_EstadoClave()
        {
            List<ClsParametros2> lst = new List<ClsParametros2>();

            //parametros de entrada
            lst.Add(new ClsParametros2("@claveBuscada", ClaveConexion));
            lst.Add(new ClsParametros2("@nuevoEstadoClave", EstadoClaveConexion));

            //parametros de salida
            lst.Add(new ClsParametros2("@respuesta", SqlDbType.VarChar, 100));

            M.Ejecutar_sp("pa_ModificarEnSerial_FechaVencimientoDeClave_EstadoClave", lst);
            string respuesta = lst[2].Valor.ToString();

            return (respuesta);
        }


        public DataTable RecuperarFecha()
        {
            List<ClsParametros2> lst = new List<ClsParametros2>();

            return M.Listado("pa_RecuperarFecha", lst);
        }

        public string ModificarEnSerial_EstadoMensajesSMS()
        {
            List<ClsParametros2> lst = new List<ClsParametros2>();

            //parametros de entrada
            lst.Add(new ClsParametros2("@claveBuscada", ClaveConexion));
            lst.Add(new ClsParametros2("@nuevoEstadoSMS", EstadoMensajesSMS));
            //parametros de salida
            lst.Add(new ClsParametros2("@respuesta", SqlDbType.VarChar, 100));

            M.Ejecutar_sp("pa_ModificarEnSerial_EstadoMensajesSMS", lst);
            string respuesta = lst[2].Valor.ToString();

            return (respuesta);

        }

    }
}
