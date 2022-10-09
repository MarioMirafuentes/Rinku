using System;
using System.Collections.Generic;

#nullable disable

namespace RinkuWeb.Models
{
    public partial class TipoEmpleado
    {
        public TipoEmpleado()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public int CvTipoEmpleado { get; set; }
        public string NombreTipo { get; set; }
        public decimal? TabuladorHora { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
