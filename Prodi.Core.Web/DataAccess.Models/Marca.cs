using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class Marca
    {
        public int Id { get; set; }
        public int IdDeportista { get; set; }
        public int IdTorneo { get; set; }
        public int IdDeporte { get; set; }
        public int? Marca1 { get; set; }
        public string TipoMarca { get; set; }
        public int Ranking { get; set; }

        public virtual Deporte IdDeporteNavigation { get; set; }
        public virtual Deportista IdDeportistaNavigation { get; set; }
        public virtual Torneo IdTorneoNavigation { get; set; }
    }
}
