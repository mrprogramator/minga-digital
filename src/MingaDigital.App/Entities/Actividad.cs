using System;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    [Table("actividad")]
    public class Actividad
    {
        public Int32 Id { get; set; }
        
        [Required]
        public String Titulo { get; set; }
        
        public String Descripcion { get; set; }
        
        [Required]
        public DateTimeOffset TiempoInicio { get; set; }
        
        [Required]
        public DateTimeOffset TiempoFin { get; set; }
        
        [Required]
        public bool Realizado { get; set; }
        
        [Required]
        public int TipoActividadId { get; set; }
        
        [Required]
        public int UsuarioCreadorId { get; set; }
        
        [Required]
        public int PersonaEncargadaId { get; set; }
        
        [Required]
        public int UnidadEducativaId { get; set; }
        
        [ForeignKey("TipoActividadId")]
        public virtual TipoActividad TipoActividad { get; set; }
        
        [ForeignKey("UsuarioCreadorId")]
        public virtual Usuario UsuarioCreador { get; set; }
        
        [ForeignKey("PersonaEncargadaId")]
        public virtual Persona PersonaEncargada { get; set; }
        
        [ForeignKey("UnidadEducativaId")]
        public virtual UnidadEducativa UnidadEducativa { get; set; }
    }
}