using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;
using MingaDigital.App.Services;

namespace MingaDigital.App.Controllers
{
    [Route("incidencias/tickets")]
    public class TicketController
        : BasicCrudController<
            MainContext,
            Ticket,
            TicketIndexModel,
            TicketIndexTableRow,
            TicketDetailModel,
            TicketEditorModel
        >
    {
        [FromServices]
        public UserSessionService UserSession { get; set; }

        protected override IEnumerable<TicketIndexTableRow> GetIndexRows(TicketIndexModel model)
        {
            var query =
                Db.Ticket
                .Select(x => new TicketIndexTableRow
                {
                    TicketId = x.TicketId,
                    TipoIncidenciaNombre = x.TipoIncidencia.Nombre
                });

            var result = query.ToArray();

            return result;
        }

        protected override TicketDetailModel EntityToDetailModel(Ticket entity)
        {
            return new TicketDetailModel
            {
                TicketId = entity.TicketId
            };
        }

        protected override TicketEditorModel GetInitialEditorModel()
        {
            return new TicketEditorModel();
        }

        protected override TicketEditorModel EntityToEditorModel(Ticket entity)
        {
            return new TicketEditorModel
            {
                TipoIncidencia = entity.TipoIncidencia,
                Descripcion = entity.Descripcion,
                Telecentro = entity.TelecentroId,
                Equipo = entity.EquipoId
            };
        }

        protected override Ticket EditorModelToEntity(TicketEditorModel model)
        {
            var entity = new Ticket()
            {
                Creador = UserSession.ActiveUser.PersonaFisica,
                FechaHoraCreado = DateTimeOffset.UtcNow
            };

            ApplyEditorModel(model, entity);
            return entity;
        }

        protected override void ApplyEditorModel(TicketEditorModel model, Ticket entity)
        {
            entity.TipoIncidencia = model.TipoIncidencia;
            entity.Descripcion = model.Descripcion;
            entity.TelecentroId = model.Telecentro;
            entity.EquipoId = model.Equipo;
        }
    }
}
