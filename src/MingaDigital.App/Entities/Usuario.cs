using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    [Table("usuario")]
    public class Usuario
    {
        public Int32 Id { get; set; }
    }
}