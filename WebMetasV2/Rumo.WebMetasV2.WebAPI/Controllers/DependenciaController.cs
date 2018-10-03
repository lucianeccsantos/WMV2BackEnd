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
    [Route("api/Dependencia")]
    public class DependenciaController : ApiController
    {
        private readonly IDependenciaAppService _dependenciaAppService;
        int pageSize = 10;

        public DependenciaController(IDependenciaAppService dependenciaAppService,
                                     INotificationHandler<DomainNotification> notifications,
                                     IMediatorHandler mediator) : base(notifications, mediator)
        {
            _dependenciaAppService = dependenciaAppService;
        }

        //GET: api/Dependencia
        [HttpGet(Name = "GetDependencia")]
        [Route("GetDependencia")]
        public IActionResult Get()
        {
            return Response(_dependenciaAppService.GetAll());
        }

        //GET: api/GetEscopoPaged/id
        [HttpGet("{id}", Name = "GetDependenciaPaged")]
        [Route("GetDependenciaPaged/{id:int}")]
        public IActionResult Get(int id)
        {
            return Response(_dependenciaAppService.ListForPaging(id, pageSize));
        }

        // GET: api/Escopo/id
        [HttpGet("{id}", Name = "GetDependenciaId")]
        [Route("GetDependenciaId/{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var dependencia = _dependenciaAppService.GetById(id);
            return Response(dependencia);
        }

        // POST: api/Dependencia
        [HttpPost]
        public IActionResult Post([FromBody]DependenciaViewModel dependencia)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(dependencia);
            }

            _dependenciaAppService.Register(dependencia);

            return Response(dependencia);
        }

        // PUT: api/Dependencia
        [HttpPut]
        public IActionResult Put([FromBody]DependenciaViewModel dependencia)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(dependencia);
            }

            _dependenciaAppService.Update(dependencia);

            return Response(dependencia);
        }

        // DELETE: api/Dependencia/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _dependenciaAppService.Remove(id);

            return Response();
        }
    }
}