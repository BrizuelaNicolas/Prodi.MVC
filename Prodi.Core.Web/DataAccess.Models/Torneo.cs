using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class Torneo
    {
        public Torneo()
        {
            Marca = new HashSet<Marca>();
            Participa = new HashSet<Participa>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? Capacidad { get; set; }
        public int IdPredio { get; set; }
        public int IdOrganizador { get; set; }
        public int IdGenero { get; set; }
        public int IdCategoria { get; set; }
        public int IdDeporte { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Deporte IdDeporteNavigation { get; set; }
        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Usuario IdOrganizadorNavigation { get; set; }
        public virtual Predio IdPredioNavigation { get; set; }
        public virtual ICollection<Marca> Marca { get; set; }
        public virtual ICollection<Participa> Participa { get; set; }
    }
}
