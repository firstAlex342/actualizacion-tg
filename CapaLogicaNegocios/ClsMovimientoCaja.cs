using CapaAccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocios
{
   public class ClsMovimientoCaja
   {
        ClsManejador M = new ClsManejador();
        public DataTable seleccionarMovimientoCaja()
        {

            return M.Listado("seleccionar_movimiento_caja", null);
        }
    }
}
