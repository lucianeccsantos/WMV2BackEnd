using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;

namespace Rumo.WebMetasV2.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Perfil")]
    public class PerfilController : ApiController
    {
        private readonly IPerfilAppService _perfilAppService;
        int pageSize = 10;

        public PerfilController(IPerfilAppService perfilAppService,
                                   INotificationHandler<DomainNotification> notifications,
                                   IMediatorHandler mediator) : base(notifications, mediator)
        {
            _perfilAppService = perfilAppService;
        }

        //api/GetPerfil
        [HttpGet(Name = "GetPerfil")]
        [Route("GetPerfil")]
        public IActionResult Get()
        {
            return Response(_perfilAppService.GetAll());
        }

        //api/GetPerfilPaged/page
        [HttpGet("{page}", Name = "GetPerfilPaged")]
        [Route("GetPerfilPaged/{page:int}")]
        public IActionResult Get(int page)
        {
            return Response(_perfilAppService.ListForPaging(page, pageSize));
        }

        //GET: api/Perfil/GetPerfilId/id
        [HttpGet("{id}", Name = "GetPerfilId")]
        [Route("GetPerfilId/{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_perfilAppService.GetById(id));
        }

        [HttpPost]
        [Route("GetBy")]
        public IActionResult GetBy([FromBody]PerfilViewModel perfil)
        {
            return Response(_perfilAppService.GetBy(perfil, 1, pageSize));
        }

        //POST: api/Perfil
        [HttpPost]
        public IActionResult Post([FromBody]PerfilViewModel perfil)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                Response(perfil);
            }

            _perfilAppService.Register(perfil);
            return Response(perfil);
        }

        //DELETE: api/Perfil/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _perfilAppService.Remove(id);
            return Response();
        }

        [HttpPut]
        public IActionResult Put([FromBody]PerfilViewModel perfil)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                Response(perfil);
            }
            _perfilAppService.Update(perfil);
            return Response(perfil);
        }
    }
}