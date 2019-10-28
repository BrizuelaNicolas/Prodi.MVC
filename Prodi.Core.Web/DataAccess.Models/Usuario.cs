using System;
using System.Collections.Generic;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clasificador = new HashSet<Clasificador>();
            Deportista = new HashSet<Deportista>();
            Participa = new HashSet<Participa>();
            Torneo = new HashSet<Torneo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int IdTipoDoc { get; set; }
        public string NumeroDoc { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int IdGenero { get; set; }
        public int? NumeroTelefonico { get; set; }
        public int IdNacionalidad { get; set; }
        public int IdProvincia { get; set; }
        public int IdRol { get; set; }

        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Nacionalidad IdNacionalidadNavigation { get; set; }
        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
        public virtual TipoDocumento IdTipoDocNavigation { get; set; }
        public virtual ICollection<Clasificador> Clasificador { get; set; }
        public virtual ICollection<Deportista> Deportista { get; set; }
        public virtual ICollection<Participa> Participa { get; set; }
        public virtual ICollection<Torneo> Torneo { get; set; }
    }
}
