using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogicaNegocios
{
    public class ClsLockers
    {
        /**************Estructura*************/

        public int m_idLocker { get; set; }
        public string m_Descripcion { get; set; }
        public char m_TipoLocker { get; set; }
        public char m_Sexo { get; set; }
        public char m_Ocupado{ get; set; }
        public char m_Status { get; set; }
        public DateTime m_Fecha_modif { get; set; }
        public string m_User_modif { get; set; }
        public int m_idSocio { get; set; }
        public DateTime m_fechaVencimiento { get; set; }
        public int Tipo { get; set; }
        public int numeroDias { get; set; }
        public int periodoLocker { get; set; }
        public int idLockerNuevo { get; set; }

        ClsManejador M = new ClsManejador();

        
        public DataTable verLockers()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@Tipo", Tipo));
            return M.Listado("seleccionar_lockers", lst);
        }

        public DataTable catLockersSelectId()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@idSocio", m_idSocio));
            return M.Listado("cat_lockers_select_id", lst);
        }


        public DataTable unSociosLockersBuscarSocio()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@idSocio", m_idSocio));
            return M.Listado("un_socios_lockers_buscar_socio", lst);
        }

        public DataTable seleccinarMembresiaTipoLockers()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            return M.Listado("seleccionar_membresia_tipo_lockers", lst);
        }

        public DataTable buscarLockerSocio()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@idSocio", m_idSocio));
            return M.Listado("buscar_locker_socio", lst);
        }

        public void modificar_locker()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@idLocker", m_idLocker));
            lst.Add(new ClsParametros("@Descripcion", m_Descripcion));
            lst.Add(new ClsParametros("@Sexo", m_Sexo));
            lst.Add(new ClsParametros("@FechaVencimiento", m_fechaVencimiento));          
            lst.Add(new ClsParametros("@Status", m_Status));
            lst.Add(new ClsParametros("@idSocio", m_idSocio));
            lst.Add(new ClsParametros("@numeroDias", numeroDias));
            lst.Add(new ClsParametros("@User_modif", m_User_modif));
            lst.Add(new ClsParametros("@Tipo", Tipo));
            M.Ejecutar_sp("modificar_locker", lst);
        }

        public string buscar_lockers_ocupados()
        {
             string respuesta;
             List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@idSocio", m_idSocio));
                //Parametros de salida
                lst.Add(new ClsParametros("@Respuesta", SqlDbType.VarChar, 1));


                M.Ejecutar_sp("buscar_lockers_ocupados", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[1].Valor.ToString(); /////.valor 

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public string catLockersInsert()
        {
            string respuesta;
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@Descripcion", m_Descripcion));
                lst.Add(new ClsParametros("@Sexo", m_Sexo));
                lst.Add(new ClsParametros("@User_modif", m_User_modif));
                //Parametros de salida
                lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 40));


                M.Ejecutar_sp("cat_lockers_insert", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[3].Valor.ToString(); /////.valor 

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public string catLockersUpdate()
        {
            string respuesta;
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@idLocker", m_idLocker));
                lst.Add(new ClsParametros("@numDescripcion", m_Descripcion));
                lst.Add(new ClsParametros("@Sexo", m_Sexo));
                lst.Add(new ClsParametros("@Ocupado", m_Ocupado));
                lst.Add(new ClsParametros("@Status", m_Status));
                lst.Add(new ClsParametros("@User_modif", m_User_modif));
                lst.Add(new ClsParametros("@idSocio", m_idSocio));
                //Parametros de salida
                lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 40));


                M.Ejecutar_sp("cat_lockers_update", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[7].Valor.ToString(); /////.valor 

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public string catLockersUpdateLocker()
        {
            string respuesta;
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@idLocker", m_idLocker));
                lst.Add(new ClsParametros("@idLockerNuevo", idLockerNuevo));
                //Parametros de salida
                lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 40));


                M.Ejecutar_sp("cat_lockers_update_locker", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[2].Valor.ToString(); /////.valor 

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return respuesta;
        }

        public DataTable catLockersSelectOcupados()
        {
            return M.Listado("cat_lockers_select_ocupados", null);
        }

        public DataTable catLockersSelectLibres()
        {
            return M.Listado("cat_lockers_select_libres", null);
        }

        public DataTable catLockersSelectTodo()
        {
            return M.Listado("cat_lockers_select_todo", null);
        }



    }
}
