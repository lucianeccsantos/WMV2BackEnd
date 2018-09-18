using System;
using Microsoft.AspNetCore.Mvc;
using Rumo.WebMetasV2.Application.Interfaces;
using MediatR;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Application.ViewModels;

namespace Rumo.WebMetasV2.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Indicador")]
    public class IndicadorController : ApiController
    {
        private readonly IIndicadorAppService _indicadorAppService;
        int pageSize = 10;

        public IndicadorController(IIndicadorAppService indicadorAppService,
                                   INotificationHandler<DomainNotification> notifications,
                                   IMediatorHandler mediator) : base(notifications, mediator)
        {
            _indicadorAppService = indicadorAppService;
        }

        //GET: api/GetIndicador
        [HttpGet(Name = "GetIndicador")]
        [Route("GetIndicador")]
        public IActionResult Get()
        {
            return Response(_indicadorAppService.GetAll());
        }

        //GET: api/GetIndicadorPaged/id
        [HttpGet("{id}", Name = "GetIndicadorPaged")]
        [Route("GetIndicadorPaged/{id:int}")]
        public IActionResult Get(int id)
        {
            return Response(_indicadorAppService.ListForPaging(id, pageSize));
        }

        // GET: api/Indicador/id
        [HttpGet("{id}", Name = "GetIndicadorId")]
        [Route("GetIndicadorId/{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var indicador = _indicadorAppService.GetById(id);
            return Response(indicador);
        }

        // POST: api/Indicador
        [HttpPost]
        public IActionResult Post([FromBody]IndicadorViewModel indicador)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(indicador);
            }

            _indicadorAppService.Register(indicador);

            return Response(indicador);
        }

        // PUT: api/Indicador
        [HttpPut]
        public IActionResult Put([FromBody]IndicadorViewModel indicador)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(indicador);
            }

            _indicadorAppService.Update(indicador);

            return Response(indicador);
        }

        // DELETE: api/Indicador/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _indicadorAppService.Remove(id);

            return Response();
        }
    }
}