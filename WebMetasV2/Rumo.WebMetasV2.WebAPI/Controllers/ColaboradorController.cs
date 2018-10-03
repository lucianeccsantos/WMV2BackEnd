using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Rumo.WebMetasV2.Application.Interfaces;
using MediatR;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Application.ViewModels;

namespace Rumo.WebMetasV2.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Colaborador")]
    public class ColaboradorController : ApiController
    {        
        private readonly IColaboradorAppService _colaboradorAppService;
        int pageSize = 10;

        public ColaboradorController(IColaboradorAppService colaboradorAppService,
                                     INotificationHandler<DomainNotification> notifications,
                                     IMediatorHandler mediator) : base(notifications, mediator)
        {
            _colaboradorAppService = colaboradorAppService;
        }

        //GET: api/GetColaborador
        [HttpGet(Name = "GetColaborador")]
        [Route("GetColaborador")]
        public IActionResult Get()
        {
            return Response(_colaboradorAppService.GetAll(c => c.Cargo, c => c.Perfil, c => c.SuperiorImediato, c => c.Unidade).OrderBy(c => c.Nome));
        }

        //GET: api/GetColaboradorPaged/id
        [HttpGet("{id}", Name = "GetColaboradorPaged")]
        [Route("GetColaboradorPaged/{id:int}")]
        public IActionResult Get(int id)
        {  
            return Response(_colaboradorAppService.ListForPaging(id, pageSize, c => c.Cargo, c => c.Perfil));
        }

        // GET: api/Colaborador/GetColaboradorId/id
        [HttpGet("{id}", Name = "GetColaboradorId")]
        [Route("GetColaboradorId/{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var cargo = _colaboradorAppService.GetById(id);
            return Response(cargo);
        }

        // POST: api/Colaborador
        [HttpPost]
        public IActionResult Post([FromBody]ColaboradorViewModel colaborador)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(colaborador);
            }

            _colaboradorAppService.Register(colaborador);

            return Response(colaborador);
        }

        // PUT: api/Colaborador
        [HttpPut]
        public IActionResult Put([FromBody]ColaboradorViewModel colaborador)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(colaborador);
            }

            _colaboradorAppService.Update(colaborador);

            return Response(colaborador);
        }

        // DELETE: api/Colaborador/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if(_colaboradorAppService.ColaboradorESuperiorImediato(id) != null)
            {
                NotifyError("501", "Colaborador não pode ser excluído porque é superior imediato");
                return Response();
            }

            _colaboradorAppService.Remove(id);

            return Response();
        }
    }
}