using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    [Table("accion")]
    public class Accion
    {
        public String Id { get; set; }
    }
}