using System;
using System.Collections.Generic;

#nullable disable

namespace RinkuWeb.Models
{
    public partial class Periodo
    {
        public Periodo()
        {
            Nominas = new HashSet<Nomina>();
        }

        public int CvPeriodo { get; set; }
        public int? NumMesPeriodo { get; set; }
        public string MesPeriodo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Nomina> Nominas { get; set; }
    }
}
