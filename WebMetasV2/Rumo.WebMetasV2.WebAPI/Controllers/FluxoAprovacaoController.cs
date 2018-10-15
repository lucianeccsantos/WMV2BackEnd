using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;

namespace Rumo.WebMetasV2.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/FluxoAprovacao")]
    public class FluxoAprovacaoController : ApiController
    {
        private readonly IFluxoAprovacaoAppService _fluxoAprovacaoAppService;
        int pageSize = 10;

        public FluxoAprovacaoController(IFluxoAprovacaoAppService fluxoAprovacaoAppService,
                                        INotificationHandler<DomainNotification> notifications,
                                        IMediatorHandler mediator) : base(notifications, mediator)
        {
            _fluxoAprovacaoAppService = fluxoAprovacaoAppService;
        }

        //GET: api/GetArea
        [HttpGet(Name = "GetFluxoAprovacao")]
        [Route("GetFluxoAprovacao")]
        public IActionResult Get()
        {
            return Response(_fluxoAprovacaoAppService.GetAll());
        }

        //GET: api/GetAreaPaged/id
        [HttpGet("{id}", Name = "GetFluxoAprovacaoPaged")]
        [Route("GetFluxoAprovacaoPaged/{id:int}")]
        public IActionResult Get(int id)
        {
            return Response(_fluxoAprovacaoAppService.ListForPaging(id, pageSize));
        }

        // GET: api/Area/id
        [HttpGet("{id}", Name = "GetFluxoAprovacaoId")]
        [Route("GetFluxoAprovacaoId/{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var fluxoAprovacao = _fluxoAprovacaoAppService.GetById(id);
            return Response(fluxoAprovacao);
        }

        // POST: api/FluxoAprovacao
        [HttpPost]
        public IActionResult Post([FromBody]FluxoAprovacaoViewModel fluxoAprovacao)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(fluxoAprovacao);
            }

            _fluxoAprovacaoAppService.Register(fluxoAprovacao);

            return Response(fluxoAprovacao);
        }

        // PUT: api/FluxoAprovacao
        [HttpPut]
        public IActionResult Put([FromBody]FluxoAprovacaoViewModel fluxoAprovacao)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(fluxoAprovacao);
            }

            _fluxoAprovacaoAppService.Update(fluxoAprovacao);

            return Response(fluxoAprovacao);
        }

        // DELETE: api/FluxoAprovacao/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _fluxoAprovacaoAppService.Remove(id);

            return Response();
        }
    }
}