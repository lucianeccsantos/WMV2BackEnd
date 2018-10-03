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
    [Route("api/Diretoria")]
    public class DiretoriaController : ApiController
    {
        private readonly IDiretoriaAppService _diretoriaAppService;
        int pageSize = 10;

        public DiretoriaController(IDiretoriaAppService diretoriaAppService,
                                   INotificationHandler<DomainNotification> notifications,
                                   IMediatorHandler mediator) : base(notifications, mediator)
        {
            _diretoriaAppService = diretoriaAppService;
        }

        //GET: api/GetDiretoria
        [HttpGet(Name = "GetDiretoria")]
        [Route("GetDiretoria")]
        public IActionResult Get()
        {
            return Response(_diretoriaAppService.GetAll());
        }

        //GET: api/GetDiretoriaPaged/id
        [HttpGet("{id}", Name = "GetDiretoriaPaged")]
        [Route("GetDiretoriaPaged/{id:int}")]
        public IActionResult Get(int id)
        {
            return Response(_diretoriaAppService.ListForPaging(id, pageSize));
        }

        // GET: api/Escopo/id
        [HttpGet("{id}", Name = "GetDiretoriaId")]
        [Route("GetDiretoriaId/{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var diretoria = _diretoriaAppService.GetById(id);
            return Response(diretoria);
        }

        // POST: api/Escopo
        [HttpPost]
        public IActionResult Post([FromBody]DiretoriaViewModel diretoria)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(diretoria);
            }

            _diretoriaAppService.Register(diretoria);

            return Response(diretoria);
        }

        // PUT: api/Escopo
        [HttpPut]
        public IActionResult Put([FromBody]DiretoriaViewModel diretoria)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(diretoria);
            }

            _diretoriaAppService.Update(diretoria);

            return Response(diretoria);
        }

        // DELETE: api/Escopo/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _diretoriaAppService.Remove(id);

            return Response();
        }
    }
}