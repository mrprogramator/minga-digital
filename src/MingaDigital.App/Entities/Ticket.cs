using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    [Table("ticket")]
    public class Ticket
    {
        public Int32 Id { get; set; }
        public Int32 EstadoTicketId { get; set; }
        
        [ForeignKey("EstadoTicketId")]
        public virtual EstadoTicket EstadoTicket { get; set; }
    }
}
