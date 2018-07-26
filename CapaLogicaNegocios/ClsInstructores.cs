using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogicaNegocios
{
   public class ClsInstructores
    {
        /**************Estructura*************/

        public string m_idEntrenador { get; set; }
        public string m_NombreCompleto { get; set; }
        public string m_Especialidad { get; set; }
        public string m_LugarNacimiento { get; set; }
        public DateTime m_HoraEntrada { get; set; }
        public bool m_Activo { get; set; }
        public int m_TipoBusqueda { get; set; }

        /**************Estructura*************/

        ClsManejador M = new ClsManejador();  // Referenciamos la clase para poder armar la estructura del SP
                                              // Checamos que exista el usuario

        public string guardarInstructor()
        {
            string mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@idEntrenador", m_idEntrenador));
                lst.Add(new ClsParametros("@NombreCompleto", m_NombreCompleto));
                lst.Add(new ClsParametros("@Especialidad", m_Especialidad));
                lst.Add(new ClsParametros("@LugarNacimiento", m_LugarNacimiento));
                lst.Add(new ClsParametros("@HoraEntrada", m_HoraEntrada));
                lst.Add(new ClsParametros("@Activo", m_Activo));

                /*Mensaje de salida*/
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 40));
                M.Ejecutar_sp("agregar_entrenador", lst);
                //Retornamos el mensaje  de salida del SP
                mensaje = lst[6].Valor.ToString();/////.valor 

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string modificarIntructor()
        {
            string mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@idEntrenador", m_idEntrenador));
            lst.Add(new ClsParametros("@NombreCompleto", m_NombreCompleto));
            lst.Add(new ClsParametros("@Especialidad", m_Especialidad));
            lst.Add(new ClsParametros("@LugarNacimiento", m_LugarNacimiento));
            lst.Add(new ClsParametros("@HoraEntrada", m_HoraEntrada));
            lst.Add(new ClsParametros("@Activo", m_Activo));

            lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 50));
            M.Ejecutar_sp("modificar_entrenador", lst);
            //Retornamos el mensaje  de salida del SP
            mensaje = lst[6].Valor.ToString();/////.valor 
            return mensaje;
        }

        public DataTable buscarInstructor()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@idEntrenador", m_idEntrenador));
            lst.Add(new ClsParametros("@TipoBusqueda", m_TipoBusqueda));
            return M.Listado("buscar_instructor", lst);
        }
    }
}
