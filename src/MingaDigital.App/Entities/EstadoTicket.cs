using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MingaDigital.App.Entities
{
    public enum EstadoTicket
    {
        Pendiente = 0,
        Atendido = 1,
        Cerrado = 2
    }
}
