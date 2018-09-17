using System;
using Microsoft.AspNetCore.Mvc;
using Rumo.WebMetasV2.Application.Interfaces;
using MediatR;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Core.Bus;

namespace Rumo.WebMetasV2.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Escopo")]
    public class EscopoController : ApiController
    {
        private readonly IEscopoAppService _escopoAppService;
        int pageSize = 10;

        public EscopoController(IEscopoAppService escopoAppService,
                              INotificationHandler<DomainNotification> notifications,
                              IMediatorHandler mediator) : base(notifications, mediator)
        {
            _escopoAppService = escopoAppService;
        }

        //GET: api/GetEscopo
        [HttpGet(Name = "GetEscopo")]
        [Route("GetEscopo")]
        public IActionResult Get()
        {
            return Response(_escopoAppService.GetAll());
        }

        //GET: api/GetEscopoPaged/id
        [HttpGet("{id}", Name = "GetEscopoPaged")]
        [Route("GetEscopoPaged/{id:int}")]
        public IActionResult Get(int id)
        {
            return Response(_escopoAppService.ListForPaging(id, pageSize));
        }

        // GET: api/Escopo/id
        [HttpGet("{id}", Name = "GetEscopoId")]
        [Route("GetEscopoId/{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var grupoPool = _escopoAppService.GetById(id);
            return Response(grupoPool);
        }

        // POST: api/Escopo
        [HttpPost]
        public IActionResult Post([FromBody]EscopoViewModel escopo)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(escopo);
            }

            _escopoAppService.Register(escopo);

            return Response(escopo);
        }

        // PUT: api/Escopo
        [HttpPut]
        public IActionResult Put([FromBody]EscopoViewModel escopo)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(escopo);
            }

            _escopoAppService.Update(escopo);

            return Response(escopo);
        }

        // DELETE: api/Escopo/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _escopoAppService.Remove(id);

            return Response();
        }
    }
}