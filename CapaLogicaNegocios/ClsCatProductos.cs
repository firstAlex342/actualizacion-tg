using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaLogicaNegocios
{
   public class ClsCatProductos
    {
        public string m_descripcion { get; set; }
        public double m_precio { get; set; }
        public int m_idProducto { get; set; }
        
        ClsManejador M = new ClsManejador();

        public string catProductosInsert()
        {
            string respuesta = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@descripcion", m_descripcion));
                lst.Add(new ClsParametros("@precio", m_precio));

                /*Mensaje de salida*/
                lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 40));
                M.Ejecutar_sp("catProductos_insert", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[2].Valor.ToString();/////.valor 

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }


        public string catProductosUpdate()
        {
            string respuesta = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@idProducto", m_idProducto));
                lst.Add(new ClsParametros("@descripcion", m_descripcion));
                lst.Add(new ClsParametros("@precio", m_precio));

                /*Mensaje de salida*/
                lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 40));
                M.Ejecutar_sp("catProductos_update", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[3].Valor.ToString();/////.valor 

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public string catProductosDelete()
        {
            string respuesta = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@idProducto", m_idProducto));

                /*Mensaje de salida*/
                lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 40));
                M.Ejecutar_sp("catProductos_delete", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[1].Valor.ToString();/////.valor 

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public DataTable catProductosSelect()
        {
            try
            {
                return M.Listado("catProductos_select", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }

           
        }
    }
}
