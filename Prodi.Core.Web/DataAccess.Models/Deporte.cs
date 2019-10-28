using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class Deporte
    {
        public Deporte()
        {
            Marca = new HashSet<Marca>();
            Torneo = new HashSet<Torneo>();
        }

        public int Id { get; set; }
        public int IdTipoClasificacion { get; set; }
        public string Descripcion { get; set; }
        public string Prueba { get; set; }

        public virtual TipoClasificacion IdTipoClasificacionNavigation { get; set; }
        public virtual ICollection<Marca> Marca { get; set; }
        public virtual ICollection<Torneo> Torneo { get; set; }
    }
}
