using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    [Table("activity")]
    public class Activity
    {
        public Int32 Id { get; set; }
    }
}