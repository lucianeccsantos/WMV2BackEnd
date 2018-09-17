using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.EscopoCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Service
{
    public class EscopoAppService : IEscopoAppService
    {
        private readonly IMapper _mapper;
        private readonly IEscopoRepository _escopoRepository;
        private readonly IMediatorHandler Bus;

        public EscopoAppService(IMapper mapper,
                                IEscopoRepository escopoRepository,
                                IMediatorHandler bus)
        {
            _mapper = mapper;
            _escopoRepository = escopoRepository;
            Bus = bus;
        }

        public IEnumerable<EscopoViewModel> GetAll()
        {
            return _escopoRepository.GetAll().ProjectTo<EscopoViewModel>();
        }

        public EscopoViewModel GetById(Guid id)
        {
            return _mapper.Map<EscopoViewModel>(_escopoRepository.GetById(id));
        }

        public void Register(EscopoViewModel escopoViewModel)
        {
            var registerCommand = _mapper.Map<CadastrarEscopoCommand>(escopoViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(EscopoViewModel escopoViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarEscopoCommand>(escopoViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoverEscopoCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PagedResult<EscopoViewModel> ListForPaging(int page, int pageSize)
        {
            return _mapper.Map<PagedResult<EscopoViewModel>>(_escopoRepository.ListForEntity(page, pageSize));
        }
    }
}
