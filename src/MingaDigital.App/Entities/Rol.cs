using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Rol
    {
        public Int32 Id { get; set; }
        
        public String Nombre { get; set; }
    }
}