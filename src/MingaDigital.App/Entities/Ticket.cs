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
        
        public Int32 EquipoId { get; set; }
        
        public Int32 CreadorId { get; set; }
        
        public Nullable<Int32> EncargadoId { get; set; }
        
        [ForeignKey(nameof(TipoIncidenciaId))]
        public virtual TipoIncidencia TipoIncidencia { get; set; }
        
        [ForeignKey(nameof(TelecentroId))]
        public virtual Telecentro Telecentro { get; set; }
        
        [ForeignKey(nameof(EquipoId))]
        public virtual Equipo Equipo { get; set; }
        
        [ForeignKey(nameof(CreadorId))]
        public virtual PersonaFisica Creador { get; set; }
        
        [ForeignKey(nameof(EncargadoId))]
        public virtual PersonaFisica Encargado { get; set; }
    }
}
