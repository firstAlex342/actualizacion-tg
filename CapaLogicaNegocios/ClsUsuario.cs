using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using System.Data;
using System.Data.SqlClient;


namespace CapaLogicaNegocios
{
   public class ClsUsuario
    {
        public int m_IdUsuario { get; set; }
        public string m_Nombre { get; set; }
        public string m_Puesto { get; set; }
        public string m_Login { get; set; }
        public string m_Password { get; set; }
        public char m_Fingerprint { get; set; }
        public int m_Nivel { get; set; }
        public DateTime m_FechaAlta { get; set; }
        public DateTime m_Fecha_modif { get; set; }
        public string m_User_modif { get; set; }
        public int m_TipoBusqueda { get; set; }

        /**************Estructura*************/

        ClsManejador M = new ClsManejador();  // Referenciamos la clase para poder armar la estructura del SP
                                              // Checamos que exista el usuario

        public string guardarUsuario()
        {
            string mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@IdUsuario", m_IdUsuario));
                lst.Add(new ClsParametros("@Nombre", m_Nombre));
                lst.Add(new ClsParametros("@Puesto", m_Puesto));
                lst.Add(new ClsParametros("@Login", m_Login));
                lst.Add(new ClsParametros("@Password", m_Password));
                lst.Add(new ClsParametros("@Fingerprint", m_Fingerprint));
                lst.Add(new ClsParametros("@Nivel", m_Nivel));
                lst.Add(new ClsParametros("@FechaAlta", m_FechaAlta));
                lst.Add(new ClsParametros("@Fecha_modif", m_Fecha_modif));
                lst.Add(new ClsParametros("@User_modif", m_User_modif));

                /*Mensaje de salida*/
                lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 40));
                M.Ejecutar_sp("agregar_usuario", lst);
                //Retornamos el mensaje  de salida del SP
                mensaje = lst[10].Valor.ToString();/////.valor 

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string modificarUsuario()
        {
            string mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@IdUsuario", m_IdUsuario));
            lst.Add(new ClsParametros("@Nombre", m_Nombre));
            lst.Add(new ClsParametros("@Puesto", m_Puesto));
            lst.Add(new ClsParametros("@Login", m_Login));
            lst.Add(new ClsParametros("@Password", m_Password));
            lst.Add(new ClsParametros("@Fingerprint", m_Fingerprint));
            lst.Add(new ClsParametros("@Nivel", m_Nivel));
            lst.Add(new ClsParametros("@Fecha_modif", m_Fecha_modif));
            lst.Add(new ClsParametros("@User_modif", m_User_modif));

            lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 50));
            M.Ejecutar_sp("modificar_usuario", lst);
            //Retornamos el mensaje  de salida del SP
            mensaje = lst[9].Valor.ToString();/////.valor 
            return mensaje;
        }

        public DataTable buscarUsuario()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@IdUsuario", m_IdUsuario));
            lst.Add(new ClsParametros("@TipoBusqueda", m_TipoBusqueda));
            return M.Listado("buscar_usuario", lst);
        }

       
    }
}