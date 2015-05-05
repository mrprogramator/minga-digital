using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Ticket
    {
        public Int32 TicketId { get; set; }
        
        [Required]
        public String Descripcion { get; set; }
        
        public Int32 Prioridad { get; set; }
        
        public EstadoTicket EstadoTicket { get; set; }
        
        public DateTimeOffset FechaHoraCreado { get; set; }
        
        public Nullable<DateTimeOffset> FechaHoraAtendido { get; set; }
        
        public Nullable<DateTimeOffset> FechaHoraCerrado { get; set; }
        
        public Int32 TipoIncidenciaId { get; set; }
        
        public Int32 TelecentroId { get; set; }
        
        public Int32 UsuarioId { get; set; }
        
        public Nullable<Int32> EncargadoId { get; set; }
        
        public virtual TipoIncidencia TipoIncidencia { get; set; }
        
        public virtual Telecentro Telecentro { get; set; }
        
        public virtual Equipo Equipo { get; set; }
        
        public virtual Usuario Usuario { get; set; }
        
        public virtual Usuario Encargado { get; set; }
    }
}
