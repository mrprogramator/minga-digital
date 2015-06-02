using System;

namespace MingaDigital.App.Entities
{
    public class SesionUsuario
    {
        public String Id { get; set; }
        
        public Int32 UsuarioId { get; set; }
        
        public DateTimeOffset FechaHoraCreacion { get; set; }
        
        public DateTimeOffset FechaHoraExpiracion { get; set; }
        
        public virtual Usuario Usuario { get; set; }
    }
}