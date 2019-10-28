using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Predio = new HashSet<Predio>();
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public int? Codigo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Predio> Predio { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
