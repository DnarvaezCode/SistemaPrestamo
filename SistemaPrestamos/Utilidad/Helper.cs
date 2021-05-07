using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrestamos.Utilidad
{
    public class Helper
    {
        public enum ESTADOPRESTAMO { NODEFINIDO = 1, PAGADO = 2, PENDIENTE = 3, CANCELADO = 4, MORA = 5, PROCESOPAGO = 6 }
        public enum ESTADOCOMISION { NODEFINIDO = 1, PAGADO = 2, PENDIENTE = 3 }
    }
}
