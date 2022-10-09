using System;
using System.Collections.Generic;

#nullable disable

namespace RinkuWeb.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public int CvEmpleado { get; set; }
        public string NumeroEmpleado { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
