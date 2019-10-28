using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Torneo = new HashSet<Torneo>();
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Torneo> Torneo { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
