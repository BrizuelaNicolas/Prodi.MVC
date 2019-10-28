using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class EstudiosMedicos
    {
        public EstudiosMedicos()
        {
            Clasificacion = new HashSet<Clasificacion>();
        }

        public int Id { get; set; }
        public string Ruta { get; set; }
        public DateTime? FechaAlta { get; set; }

        public virtual ICollection<Clasificacion> Clasificacion { get; set; }
    }
}
