using System;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public struct Password
    {
        [Required]
        public Byte[] Hash { get; set; }
        
        [Required]
        public Byte[] Salt { get; set; }
        
        [Required]
        public String Algorithm { get; set; }
    }
}