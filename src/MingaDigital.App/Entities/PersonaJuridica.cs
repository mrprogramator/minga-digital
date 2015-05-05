using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class PersonaJuridica
    {
        public Int32 PersonaJuridicaId { get; set; }
        
        public String Nombre { get; set; }
    }
}