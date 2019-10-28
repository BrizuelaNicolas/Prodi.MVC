using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class Deportista
    {
        public Deportista()
        {
            Clasificacion = new HashSet<Clasificacion>();
            Marca = new HashSet<Marca>();
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Clasificacion> Clasificacion { get; set; }
        public virtual ICollection<Marca> Marca { get; set; }
    }
}
