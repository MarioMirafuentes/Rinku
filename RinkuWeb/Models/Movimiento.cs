using System;
using System.Collections.Generic;

#nullable disable

namespace RinkuWeb.Models
{
    public partial class Movimiento
    {
        public Movimiento()
        {
            Nominas = new HashSet<Nomina>();
        }

        public int CvMovimiento { get; set; }
        public int? Mes { get; set; }
        public int? NumEntregas { get; set; }
        public int CvTipoEmpleado { get; set; }
        public int? CvEmpleado { get; set; }
        public string Descripcion { get; set; }
        public int HDesc { get; set; }
        public int CvPeriodo { get; set; }

        public virtual Empleado CvEmpleadoNavigation { get; set; }
        public virtual TipoEmpleado CvTipoEmpleadoNavigation { get; set; }
        public virtual ICollection<Nomina> Nominas { get; set; }
    }
}
