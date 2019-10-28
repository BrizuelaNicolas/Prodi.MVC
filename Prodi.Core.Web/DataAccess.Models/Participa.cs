using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class Participa
    {
        public int Id { get; set; }
        public int? Acreditado { get; set; }
        public int IdUsuario { get; set; }
        public int IdTorneo { get; set; }

        public virtual Torneo IdTorneoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
