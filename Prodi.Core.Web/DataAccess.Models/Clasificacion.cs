using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class Clasificacion
    {
        public int Id { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int IdDeportista { get; set; }
        public int IdClasificador { get; set; }
        public int? IdEstudiosMedicos { get; set; }
        public int IdTipoClasificacion { get; set; }
        public int Clasificacion1 { get; set; }

        public virtual Clasificador IdClasificadorNavigation { get; set; }
        public virtual Deportista IdDeportistaNavigation { get; set; }
        public virtual EstudiosMedicos IdEstudiosMedicosNavigation { get; set; }
        public virtual TipoClasificacion IdTipoClasificacionNavigation { get; set; }
    }
}
