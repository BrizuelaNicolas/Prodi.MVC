using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Deportista = new HashSet<Deportista>();
            Torneo = new HashSet<Torneo>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Deportista> Deportista { get; set; }
        public virtual ICollection<Torneo> Torneo { get; set; }
    }
}
