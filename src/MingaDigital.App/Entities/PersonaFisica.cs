using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class PersonaFisica
    {
        public Int32 Id { get; set; }
        
        public String Nombres { get; set; }
        
        public String Apellidos { get; set; }
    }
}