using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class Clasificador
    {
        public Clasificador()
        {
            Clasificacion = new HashSet<Clasificacion>();
        }

        public int Id { get; set; }
        public string Matricula { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoClasificacion { get; set; }

        public virtual TipoClasificacion IdTipoClasificacionNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Clasificacion> Clasificacion { get; set; }
    }
}
