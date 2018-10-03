using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.CargoCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rumo.WebMetasV2.Application.Service
{
    public class CargoAppService : ICargoAppService
    {
        private readonly IMapper _mapper;
        private readonly ICargoRepository _cargoRepository;
        private readonly IMediatorHandler Bus;

        public CargoAppService(IMapper mapper,
                               ICargoRepository cargoRepository,
                               IMediatorHandler bus)
        {
            _mapper = mapper;
            _cargoRepository = cargoRepository;
            Bus = bus;
        }

        public CargoViewModel GetById(Guid id)
        {
            return _mapper.Map<CargoViewModel>(_cargoRepository.GetById(id));
        }

        public void Register(CargoViewModel cargoViewModel)
        {
            var registerCommand = _mapper.Map<CadastrarCargoCommand>(cargoViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(CargoViewModel cargoViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarCargoCommand>(cargoViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoverCargoCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PagedResult<CargoViewModel> ListForPaging(int page, int pageSize)
        {
            return _mapper.Map<PagedResult<CargoViewModel>>(_cargoRepository.ListForEntity(page, pageSize));
        }

        public IQueryable<CargoViewModel> GetAll(params Expression<Func<Cargo, object>>[] includes)
        {
            return _cargoRepository.GetAll(includes).ProjectTo<CargoViewModel>();
        }

    }
}
