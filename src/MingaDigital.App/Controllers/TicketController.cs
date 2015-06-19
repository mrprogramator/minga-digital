using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

using Microsoft.AspNet.Mvc;

using MingaDigital.App.EF;
using MingaDigital.App.Entities;
using MingaDigital.App.Models;
using MingaDigital.App.Services;

namespace MingaDigital.App.Controllers
{
    [Route("tickets")]
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
                .Include(x => x.Telecentro);

            var result =
              query.ToArray()
              .Select(x => new TicketIndexTableRow
              {
                  TicketId = x.TicketId,
                  TipoIncidenciaNombre = x.TipoIncidencia.Nombre,
                  TelecentroNombre = x.Telecentro.Nombre,
                  FechaCreado = x.FechaHoraCreado.ToString("d"),
                  FechaAtendido = x.FechaHoraAtendido?.ToString("d"),
                  FechaCerrado = x.FechaHoraCerrado?.ToString("d")
              });

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
                Telecentro = entity.Telecentro,
                Equipo = entity.Equipo
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
            entity.Telecentro = model.Telecentro;
            entity.Equipo = model.Equipo;
        }
    }
}
