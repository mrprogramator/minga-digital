using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    [Table("persona")]
    public class Persona
    {
        public Int32 Id { get; set; }
    }
}