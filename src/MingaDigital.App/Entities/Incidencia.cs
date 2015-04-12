using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Incidencia
    {
        public Int32 Id { get; set; }
        
        [Required]
        public String Descripcion { get; set; }
        
        public Int32 Prioridad { get; set; }
        
        public Int32 AreaIncidenciaId { get; set; }
        
        public Int32 TicketId { get; set; }
        
        public Int32 TipoIncidenciaId { get; set; }
        
        public Int32 TelecentroId { get; set }
        
        public Int32 EquipoId { get; set; }
        
        public Int32 UsuarioId { get; set; }
        
        public Int32 EncargadoId { get; set; }
        
        [ForeignKey("AreaIncidenciaId")]
        public virtual AreaIncidencia AreaIncidencia { get; set; }
        
        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }
        
        [ForeignKey("TipoIncidenciaId")]
        public virtual TipoIncidencia TipoIncidencia { get; set; }
        
        [ForeignKey("TelecentroId")]
        public virtual Telecentro Telecentro { get; set; }
        
        [ForeignKey("EquipoId")]
        public virtual Equipo Equipo { get; set; }
        
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
        
        [ForeignKey("EncargadoId")]
        public virtual Usuario Usuario { get; set; }
    }
}
