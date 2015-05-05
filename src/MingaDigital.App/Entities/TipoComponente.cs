using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public enum TipoComponente
    {
        Carcaza = 0,
        Procesador = 1,
        Memoria = 2,
        DiscoDuro = 3,
        Monitor = 4,
        Teclado = 5,
        Mouse = 6
    }
}
