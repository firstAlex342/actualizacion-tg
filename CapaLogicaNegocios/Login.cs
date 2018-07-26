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
    public class Login
    {
        // estructura de la tabla  atributos de la tabla
        public string M_Login { get; set; }
        public string M_Pass { get; set; }
        public static int num_ticket { get; set; }
        public static int idUsuario { get; set; }
        public static int idSuperUsuario { get; set; }
        public static string nombre { get; set; }
        public static string Supernombre { get; set; }
        public static double dineroEntrada { get; set; }
        public static double dineroTarjeta { get; set; }
        public static bool cajaAbierta { get; set; }
        public static int opcionReporte { get; set; }
        public static int tipoObservacion { get; set; }
        public static double cantidadDescuento { get; set; }
        public static bool Pago { get; set; }
        public static int tipoPago { get; set; }
        public static int idSocio { get; set; }
        public static bool cerrarSesion { get; set; }
        public static bool superUsuario { get; set; }

        //public string m_Existe { get; set; }

        ClsManejador M = new ClsManejador();  // Referenciamos la clase para poder armar la estructura del SP
                                           // Checamos que exista el usuario
        public string ExisteUsr()
        {
            
            string Existe = "0";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // pasamos los parametros para armar el SP de entrada
                lst.Add(new ClsParametros("@Login", M_Login));
                lst.Add(new ClsParametros("@Password", M_Pass));
                //lst.Add(new ClsParametros("@Encontrado", null ));

                // pasamos los parametros para armar el SP de salida 1 si es encontrado 0 si no es encontrado
                lst.Add(new ClsParametros("@Encontrado", SqlDbType.VarChar, 1));

                M.Ejecutar_sp("VerificarUsuario", lst);

                Existe = lst[2].Valor.ToString();/////.valor 

       
            }
            catch (Exception ex)
            {
                throw ex;
                
            }



            return Existe;
        }

        public DataTable buscarUsuario()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@Login", M_Login));
            lst.Add(new ClsParametros("@Password", M_Pass));
            return M.Listado("VerificarUsuario", lst);

        }

        public DataTable buscarSuperUsuario()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@Login", M_Login));
            lst.Add(new ClsParametros("@Password", M_Pass));
            return M.Listado("buscar_super_usuario", lst);
        }


    }
}
