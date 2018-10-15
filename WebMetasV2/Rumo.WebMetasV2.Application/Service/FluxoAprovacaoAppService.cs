using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Service
{
    public class FluxoAprovacaoAppService : IFluxoAprovacaoAppService
    {
        private readonly IMapper _mapper;
        private readonly IFluxoAprovacaoRepository _fluxoAprovacaoRepository;
        private readonly IMediatorHandler Bus;

        public FluxoAprovacaoAppService(IMapper mapper,
                              IFluxoAprovacaoRepository fluxoAprovacaoRepository,
                              IMediatorHandler bus)
        {
            _mapper = mapper;
            _fluxoAprovacaoRepository = fluxoAprovacaoRepository;
            Bus = bus;
        }

        public IEnumerable<FluxoAprovacaoViewModel> GetAll()
        {
            return _fluxoAprovacaoRepository.GetAll().ProjectTo<FluxoAprovacaoViewModel>();
        }

        public FluxoAprovacaoViewModel GetById(Guid id)
        {
            return _mapper.Map<FluxoAprovacaoViewModel>(_fluxoAprovacaoRepository.GetById(id));
        }

        public void Register(FluxoAprovacaoViewModel fluxoAprovacaoViewModel)
        {
            var registerCommand = _mapper.Map<CadastrarFluxoAprovacaoCommand>(fluxoAprovacaoViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(FluxoAprovacaoViewModel fluxoAprovacaoViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarFluxoAprovacaoCommand>(fluxoAprovacaoViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoverFluxoAprovacaoCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PagedResult<FluxoAprovacaoViewModel> ListForPaging(int page, int pageSize)
        {
            return _mapper.Map<PagedResult<FluxoAprovacaoViewModel>>(_fluxoAprovacaoRepository.ListForEntity(page, pageSize));
        }
    }
}
