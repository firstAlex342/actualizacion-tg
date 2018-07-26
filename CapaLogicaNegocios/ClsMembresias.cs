using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using System.Data;

namespace CapaLogicaNegocios
{
   public class ClsMembresias
   {
        public int m_idMembresia { get; set; }
        public int Tipo { get; set; }
        public string m_Descripcion { get; set; }
        public char m_Tipo { get; set; }
        public double m_Costo { get; set; }
        public int m_Perdiodo{ get; set; }
        public string m_User_modif { get; set; }
        public int m_Dom { get; set; }
        public int m_Lun { get; set; }
        public int m_Mar { get; set; }
        public int m_Mier { get; set; }
        public int m_Jue { get; set; }
        public int m_Vie { get; set; }
        public int m_Sab { get; set; }
        public int m_Matutino { get; set; }
        public string m_HoraInicioiMaT { get; set; }
        public string m_HoraFinalMat { get; set; }
        public int m_Vespertino { get; set; }
        public string m_HoraInicioVesp { get; set; }
        public string m_HoraFinalVesp { get; set; }
        public int m_Activa { get; set; }
        public char m_Viajero { get; set; }
        public int m_ConteoViajero { get; set; }
        public int m_Grupal { get; set; }
        public int m_numeroPersonasGrupal { get; set; }
        public string m_prefijo { get; set; }
        public int m_BanderaPrefijo { get; set; }

        ClsManejador M = new ClsManejador();


        public DataTable seleccionarMembresias()
        {
            List<ClsParametros> lst = new List<ClsParametros>();
            lst.Add(new ClsParametros("@Tipo", Tipo));
            lst.Add(new ClsParametros("@IdMembresia", m_idMembresia));
            return M.Listado("select_membresias", lst);
        }

        public DataTable catTipoMembresia()
        {
            return M.Listado("cat_tipo_membresia", null);
        }

        public string catTipoMembresiaUpdate()
        {
            string respuesta = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                lst.Add(new ClsParametros("@idMembresia", m_idMembresia));
                lst.Add(new ClsParametros("@Descripcion", m_Descripcion));
                lst.Add(new ClsParametros("@Tipo", m_Tipo));
                lst.Add(new ClsParametros("@Costo", m_Costo));
                lst.Add(new ClsParametros("@Periodo", m_Perdiodo));
                lst.Add(new ClsParametros("@User_modif", m_User_modif));
                lst.Add(new ClsParametros("@Dom", m_Dom));
                lst.Add(new ClsParametros("@Lun", m_Lun));
                lst.Add(new ClsParametros("@Mar", m_Mar));
                lst.Add(new ClsParametros("@Mier", m_Mier));
                lst.Add(new ClsParametros("@Jue", m_Jue));
                lst.Add(new ClsParametros("@Vie", m_Vie));
                lst.Add(new ClsParametros("@Sab", m_Sab));
                lst.Add(new ClsParametros("@Matutino", m_Matutino));
                lst.Add(new ClsParametros("@HoraInicioi", m_HoraInicioiMaT));
                lst.Add(new ClsParametros("@HoraFinalMat", m_HoraFinalMat));
                lst.Add(new ClsParametros("@Activa", m_Activa));
                lst.Add(new ClsParametros("@Viajero", m_Viajero));
                lst.Add(new ClsParametros("@ConteoViajero", m_ConteoViajero));
                lst.Add(new ClsParametros("@Grupal", m_Grupal));
                lst.Add(new ClsParametros("@numeroPersonasGrupal", m_numeroPersonasGrupal));
                lst.Add(new ClsParametros("@prefijo", m_prefijo));
                lst.Add(new ClsParametros("@BanderaPrefijo", m_BanderaPrefijo));

                /*Mensaje de salida*/
                lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 40));
                M.Ejecutar_sp("cat_tipo_membresia_update", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[23].Valor.ToString();/////.valor 

            }
            catch (Exception ex)
            {
                respuesta = ex.ToString();
            }

            return respuesta;
        }

        public string altaMembresias()
        {
            string respuesta = "";
            List<ClsParametros> lst = new List<ClsParametros>();

            try
            {
                // armamos la clase para el cuerpo del procedimiento
                // Parametros de entrada
                
                lst.Add(new ClsParametros("@Descripcion", m_Descripcion));
                lst.Add(new ClsParametros("@Tipo", m_Tipo));
                lst.Add(new ClsParametros("@Costo", m_Costo));
                lst.Add(new ClsParametros("@Periodo", m_Perdiodo));
                lst.Add(new ClsParametros("@User_modif", m_User_modif));
                lst.Add(new ClsParametros("@Dom", m_Dom));
                lst.Add(new ClsParametros("@Lun", m_Lun));
                lst.Add(new ClsParametros("@Mar", m_Mar));
                lst.Add(new ClsParametros("@Mier", m_Mier));
                lst.Add(new ClsParametros("@Jue", m_Jue));
                lst.Add(new ClsParametros("@Vie", m_Vie));
                lst.Add(new ClsParametros("@Sab", m_Sab));
                lst.Add(new ClsParametros("@Matutino", m_Matutino));
                lst.Add(new ClsParametros("@HoraInicioiMaT", m_HoraInicioiMaT));
                lst.Add(new ClsParametros("@HoraFinalMat", m_HoraFinalMat));
                lst.Add(new ClsParametros("@Vespertino", m_Vespertino));
                lst.Add(new ClsParametros("@HoraInicioVesp", m_HoraInicioVesp));
                lst.Add(new ClsParametros("@HoraFinalVesp", m_HoraFinalVesp));
                lst.Add(new ClsParametros("@Activa", m_Activa));
                lst.Add(new ClsParametros("@Viajero", m_Viajero));
                lst.Add(new ClsParametros("@ConteoViajero", m_ConteoViajero));
                lst.Add(new ClsParametros("@Grupal", m_Grupal));
                lst.Add(new ClsParametros("@numeroPersonasGrupal", m_numeroPersonasGrupal));
                lst.Add(new ClsParametros("@prefijo", m_prefijo));
                lst.Add(new ClsParametros("@BanderaPrefijo", m_BanderaPrefijo));

                /*Mensaje de salida*/
                lst.Add(new ClsParametros("@respuesta", SqlDbType.VarChar, 40));
                M.Ejecutar_sp("alta_membresias", lst);
                //Retornamos el mensaje  de salida del SP
                respuesta = lst[25].Valor.ToString();/////.valor 

            }
            catch (Exception ex)
            {
                respuesta =  ex.ToString();
            }

            return respuesta;
        }
    }
}
