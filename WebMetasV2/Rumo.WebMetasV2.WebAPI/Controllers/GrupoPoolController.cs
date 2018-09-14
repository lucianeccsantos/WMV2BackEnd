using System;
using Microsoft.AspNetCore.Mvc;
using Rumo.WebMetasV2.Application.Interfaces;
using MediatR;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Application.ViewModels;

namespace Rumo.WebMetasV2.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/GrupoPool")]
    public class GrupoPoolController : ApiController
    {
        private readonly IGrupoPoolAppService _grupoPoolAppService;
        int pageSize = 10;

        public GrupoPoolController(IGrupoPoolAppService grupoPoolAppService,
                                   INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _grupoPoolAppService = grupoPoolAppService;
        }

        //GET: api/GetGrupoPool
        [HttpGet(Name = "GetGrupoPool")]
        [Route("GetGrupoPool")]
        public IActionResult Get()
        {
            return Response(_grupoPoolAppService.GetAll());
        }

        //GET: api/GetGrupoPoolPaged/id
        [HttpGet("{id}", Name = "GetGrupoPoolPaged")]
        [Route("GetGrupoPoolPaged/{id:int}")]
        public IActionResult Get(int id)
        {
            return Response(_grupoPoolAppService.ListForPaging(id, pageSize));
        }

        // GET: api/Module/id
        [HttpGet("{id}", Name = "GetGrupoPoolId")]
        [Route("GetGrupoPoolId/{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var grupoPool = _grupoPoolAppService.GetById(id);
            return Response(grupoPool);
        }

        // POST: api/GrupoPool
        [HttpPost]
        public IActionResult Post([FromBody]GrupoPoolViewModel grupoPool)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(grupoPool);
            }

            _grupoPoolAppService.Register(grupoPool);

            return Response(grupoPool);
        }

        // PUT: api/GrupoPool
        [HttpPut]
        public IActionResult Put([FromBody]GrupoPoolViewModel grupoPool)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(grupoPool);
            }

            _grupoPoolAppService.Update(grupoPool);

            return Response(grupoPool);
        }

        // DELETE: api/GrupoPool/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _grupoPoolAppService.Remove(id);

            return Response();
        }
    }
}