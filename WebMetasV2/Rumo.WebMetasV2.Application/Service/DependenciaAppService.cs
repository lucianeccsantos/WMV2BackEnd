using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.DependenciaCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Service
{
    public class DependenciaAppService : IDependenciaAppService
    {
        private readonly IMapper _mapper;
        private readonly IDependenciaRepository _dependenciaRepository;
        private readonly IMediatorHandler Bus;

        public DependenciaAppService(IMapper mapper,
                                     IDependenciaRepository dependenciaRepository,
                                     IMediatorHandler bus)
        {
            _mapper = mapper;
            _dependenciaRepository = dependenciaRepository;
            Bus = bus;
        }

        public IEnumerable<DependenciaViewModel> GetAll()
        {
            return _dependenciaRepository.GetAll().ProjectTo<DependenciaViewModel>();
        }

        public DependenciaViewModel GetById(Guid id)
        {
            return _mapper.Map<DependenciaViewModel>(_dependenciaRepository.GetById(id));
        }

        public void Register(DependenciaViewModel dependenciaViewModel)
        {
            var registerCommand = _mapper.Map<CadastrarDependenciaCommand>(dependenciaViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(DependenciaViewModel dependenciaViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarDependenciaCommand>(dependenciaViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoverDependenciaCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PagedResult<DependenciaViewModel> ListForPaging(int page, int pageSize)
        {
            return _mapper.Map<PagedResult<DependenciaViewModel>>(_dependenciaRepository.ListForEntity(page, pageSize));
        }
    }
}
