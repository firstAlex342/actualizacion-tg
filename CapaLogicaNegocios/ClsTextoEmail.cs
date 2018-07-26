using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
    public class ClsTextoEmail
    {
        public String m_TextoCorreo { get; set; }
        public String m_TextoCumpleAnos { get; set; }
        public String m_AsuntoDeudas { get; set; }
        public String m_AsuntoCumpleanos { get; set; }
        public string m_correoEnviarEmail { get; set; }

        ClsManejador M = new ClsManejador();
        public DataTable TextosEmails()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            return M.Listado("mostrar_textoEmails", lst);
        }
        public string modificarTextosEmails()
        {
            string mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@TextoCorreo", m_TextoCorreo));
            lst.Add(new ClsParametros("@TextoCumpleAnos", m_TextoCumpleAnos));
            lst.Add(new ClsParametros("@AsuntoDeudas", m_AsuntoDeudas));
            lst.Add(new ClsParametros("@AsuntoCumpleanos", m_AsuntoCumpleanos));
            lst.Add(new ClsParametros("@Mensaje", SqlDbType.VarChar, 50));
            M.Ejecutar_sp("modificar_textosEmails", lst);
            //Retornamos el mensaje  de salida del SP
            mensaje = lst[4].Valor.ToString();/////.valor 
            return mensaje;
        }

        public string textoEmailModificarCorreo()
        {
            string mensaje = "";
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@correo", m_correoEnviarEmail));
            lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 255));
            M.Ejecutar_sp("texto_email_modificar_correo", lst);
            //Retornamos el mensaje  de salida del SP
            mensaje = lst[1].Valor.ToString();/////.valor 
            return mensaje;
        }
    }
}
