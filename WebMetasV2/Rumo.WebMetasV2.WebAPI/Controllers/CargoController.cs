using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Core.Bus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Rumo.WebMetasV2.Application.ViewModels;

namespace Rumo.WebMetasV2.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Cargo")]
    public class CargoController : ApiController
    {
        private readonly ICargoAppService _cargoAppService;
        int pageSize = 10;

        public CargoController(ICargoAppService cargoAppService,
                               INotificationHandler<DomainNotification> notifications,
                               IMediatorHandler mediator) : base(notifications, mediator)
        {
            _cargoAppService = cargoAppService;
        }

        //GET: api/GetCargo
        [HttpGet(Name = "GetCargo")]
        [Route("GetCargo")]
        public IActionResult Get()
        {
            return Response(_cargoAppService.GetAll(c => c.GrupoPool).OrderBy(c => c.Nome));
        }

        //GET: api/GetCargoPaged/id
        [HttpGet("{id}", Name = "GetCargoPaged")]
        [Route("GetCargoPaged/{id:int}")]
        public IActionResult Get(int id)
        {
            return Response(_cargoAppService.ListForPaging(id, pageSize));
        }

        // GET: api/Cargo/GetCargoId/id
        [HttpGet("{id}", Name = "GetCargoId")]
        [Route("GetCargoId/{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            var cargo = _cargoAppService.GetById(id);
            return Response(cargo);
        }

        // POST: api/Cargo
        [HttpPost]
        public IActionResult Post([FromBody]CargoViewModel cargo)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(cargo);
            }

            _cargoAppService.Register(cargo);

            return Response(cargo);
        }

        // PUT: api/Cargo
        [HttpPut]
        public IActionResult Put([FromBody]CargoViewModel cargo)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(cargo);
            }

            _cargoAppService.Update(cargo);

            return Response(cargo);
        }

        // DELETE: api/Cargo/id
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _cargoAppService.Remove(id);

            return Response();
        }
    }
}