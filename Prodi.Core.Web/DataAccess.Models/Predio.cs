using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class Predio
    {
        public Predio()
        {
            Torneo = new HashSet<Torneo>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int? IdProvincia { get; set; }

        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual ICollection<Torneo> Torneo { get; set; }
    }
}
