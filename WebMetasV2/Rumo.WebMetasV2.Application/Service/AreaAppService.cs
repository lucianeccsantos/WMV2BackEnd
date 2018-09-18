using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.AreaCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Service
{
    public class AreaAppService : IAreaAppService
    {
        private readonly IMapper _mapper;
        private readonly IAreaRepository _areaRepository;
        private readonly IMediatorHandler Bus;

        public AreaAppService(IMapper mapper,
                              IAreaRepository areaRepository,
                              IMediatorHandler bus)
        {
            _mapper = mapper;
            _areaRepository = areaRepository;
            Bus = bus;
        }

        public IEnumerable<AreaViewModel> GetAll()
        {
            return _areaRepository.GetAll().ProjectTo<AreaViewModel>();
        }

        public AreaViewModel GetById(Guid id)
        {
            return _mapper.Map<AreaViewModel>(_areaRepository.GetById(id));
        }

        public void Register(AreaViewModel areaViewModel)
        {
            var registerCommand = _mapper.Map<CadastrarAreaCommand>(areaViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(AreaViewModel areaViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarAreaCommand>(areaViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoverAreaCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PagedResult<AreaViewModel> ListForPaging(int page, int pageSize)
        {
            return _mapper.Map<PagedResult<AreaViewModel>>(_areaRepository.ListForEntity(page, pageSize));
        }
    }
}
