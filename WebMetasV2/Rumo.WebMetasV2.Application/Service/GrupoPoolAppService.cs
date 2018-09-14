using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Service
{
    public class GrupoPoolAppService : IGrupoPoolAppService
    {
        private readonly IMapper _mapper;
        private readonly IGrupoPoolRepository _grupoPoolRepository;
        private readonly IMediatorHandler Bus;

        public GrupoPoolAppService(IMapper mapper,
                                   IGrupoPoolRepository grupoPoolRepository,
                                   IMediatorHandler bus)
        {
            _mapper = mapper;
            _grupoPoolRepository = grupoPoolRepository;
            Bus = bus;
        }

        public IEnumerable<GrupoPoolViewModel> GetAll()
        {
            return _grupoPoolRepository.GetAll().ProjectTo<GrupoPoolViewModel>();
        }

        public GrupoPoolViewModel GetById(Guid id)
        {
            return _mapper.Map<GrupoPoolViewModel>(_grupoPoolRepository.GetById(id));
        }

        public void Register(GrupoPoolViewModel grupoPoolViewModel)
        {
            var registerCommand = _mapper.Map<CadastrarGrupoPoolCommand>(grupoPoolViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(GrupoPoolViewModel grupoPoolViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarGrupoPoolCommand>(grupoPoolViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoverGrupoPoolCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PagedResult<GrupoPoolViewModel> ListForPaging(int page, int pageSize)
        {
            return _mapper.Map<PagedResult<GrupoPoolViewModel>>(_grupoPoolRepository.ListForEntity(page, pageSize));
        }
    }
}
