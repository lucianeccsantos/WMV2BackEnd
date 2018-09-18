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
    [Route("api/Area")]
    public class AreaController : ApiController
    {
        private readonly IAreaAppService _areaAppService;
        int pageSize = 10;

        public AreaController(IAreaAppService areaAppService,
                              INotificationHandler<DomainNotification> notifications,
                              IMediatorHandler mediator) : base(notifications, mediator)
        {
            _areaAppService = areaAppService;
        }

        //GET: api/GetArea
        [HttpGet(Name = "GetArea")]
        [Route("GetArea")]
        public IActionResult Get()
        {
            return Response(_areaAppService.GetAll());
        }

        //GET: api/GetAreaPaged/id
        [HttpGet("{id}", Name = "GetAreaPaged")]
        [Route("GetAreaPaged/{id:int}")]
        public IActionResult Get(int id)
        {
            return Response(_areaAppService.ListForPaging(id, pageSize));
        }

        // GET: api/Area/id
        [HttpGet("{id}", Name = "GetAreaId")]
        [Route("GetAreaId/{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var grupoPool = _areaAppService.GetById(id);
            return Response(grupoPool);
        }

        // POST: api/GrupoPool
        [HttpPost]
        public IActionResult Post([FromBody]AreaViewModel area)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(area);
            }

            _areaAppService.Register(area);

            return Response(area);
        }

        // PUT: api/GrupoPool
        [HttpPut]
        public IActionResult Put([FromBody]AreaViewModel area)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(area);
            }

            _areaAppService.Update(area);

            return Response(area);
        }

        // DELETE: api/Area/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _areaAppService.Remove(id);

            return Response();
        }
    }
}
