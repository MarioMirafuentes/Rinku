using System;
using System.Collections.Generic;

#nullable disable

namespace RinkuWeb.Models
{
    public partial class Nomina
    {
        public int CvNomina { get; set; }
        public int? CvMovimiento { get; set; }
        public decimal? Retenciones { get; set; }
        public int? CvPeriodo { get; set; }
        public decimal? ValesDespensa { get; set; }
        public decimal? BonoEntregas { get; set; }
        public decimal? BonoPuesto { get; set; }
        public decimal? SueldoNeto { get; set; }
        public decimal? SueldoBruto { get; set; }
        public int? HorasTrabajadas { get; set; }

        public virtual Movimiento CvMovimientoNavigation { get; set; }
        public virtual Periodo CvPeriodoNavigation { get; set; }
    }
}
