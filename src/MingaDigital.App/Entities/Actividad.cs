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
        
        public DateTimeOffset TiempoInicio { get; set; }
        
        public DateTimeOffset TiempoFin { get; set; }
        
        public Boolean Realizado { get; set; }
        
        public Int32 TipoActividadId { get; set; }
        
        public Int32 UsuarioCreadorId { get; set; }
        
        public Int32 PersonaEncargadaId { get; set; }
        
        public Int32 UnidadEducativaId { get; set; }
        
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