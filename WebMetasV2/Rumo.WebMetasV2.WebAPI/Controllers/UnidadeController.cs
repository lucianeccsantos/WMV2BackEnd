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
    [Route("api/Unidade")]
    public class UnidadeController : ApiController
    {
        private readonly IUnidadeAppService _unidadeAppService;
        int pageSize = 10;

        public UnidadeController(IUnidadeAppService unidadeAppService,
                                    INotificationHandler<DomainNotification> notifications, 
                                    IMediatorHandler mediator) : base(notifications, mediator)
        {
            _unidadeAppService = unidadeAppService;
        }

        //GET: api/GetUnidade
        [HttpGet(Name = "GetUnidade")]
        [Route("GetUnidade")]
        public IActionResult Get()
        {
            return Response(_unidadeAppService.GetAll());
        }

        //GET: api/GetUnidadePaged/page
        [HttpGet("{page}", Name = "GetUnidadePaged")]
        [Route("GetUnidadePaged/{page:int}")]
        public IActionResult Get(int page)
        {
            return Response(_unidadeAppService.ListForPaging(page, pageSize));
        }

        //GET: api/GetUnidadeId/id
        [HttpGet("{id}", Name ="GetUnidadeId")]
        [Route("GetUnidadeId/{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            return Response(_unidadeAppService.GetById(id));
        }

        //POST: api/Unidade
        [HttpPost]
        public IActionResult Post([FromBody]UnidadeViewModel unidade) {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(unidade);
            }

            _unidadeAppService.Register(unidade);
            return Response(unidade);
        }

        //DELETE: api/Unidade/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _unidadeAppService.Remove(id);
            return Response();
        }

    }
}