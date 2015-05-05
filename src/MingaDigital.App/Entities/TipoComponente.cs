using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public enum TipoComponente
    {
        Carcaza,
        Procesador,
        Memoria,
        DiscoDuro,
        Monitor,
        Teclado,
        Mouse
    }
}
