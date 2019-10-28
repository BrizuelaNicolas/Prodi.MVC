using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class TipoClasificacion
    {
        public TipoClasificacion()
        {
            Clasificacion = new HashSet<Clasificacion>();
            Clasificador = new HashSet<Clasificador>();
            Deporte = new HashSet<Deporte>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Clasificacion> Clasificacion { get; set; }
        public virtual ICollection<Clasificador> Clasificador { get; set; }
        public virtual ICollection<Deporte> Deporte { get; set; }
    }
}
