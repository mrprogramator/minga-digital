using System;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public class Actividad
    {
        public Int32 ActividadId { get; set; }
        
        [Required]
        public String Titulo { get; set; }
        
        public String Descripcion { get; set; }
        
        public DateTimeOffset TiempoInicio { get; set; }
        
        public DateTimeOffset TiempoFin { get; set; }
        
        public Boolean Realizado { get; set; }
        
        public Int32 TipoActividadId { get; set; }
        
        public Int32 UsuarioCreadorId { get; set; }
        
        public Int32 PersonaEncargadaId { get; set; }
        
        public Int32 TelecentroId { get; set; }
        
        [ForeignKey(nameof(TipoActividadId))]
        public virtual TipoActividad TipoActividad { get; set; }
        
        [ForeignKey(nameof(UsuarioCreadorId))]
        public virtual Usuario UsuarioCreador { get; set; }
        
        [ForeignKey(nameof(PersonaEncargadaId))]
        public virtual PersonaFisica PersonaEncargada { get; set; }
        
        [ForeignKey(nameof(TelecentroId))]
        public virtual Telecentro Telecentro { get; set; }
    }
}