using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.DiretoriaCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Service
{
    public class DiretoriaAppService : IDiretoriaAppService
    {
        private readonly IMapper _mapper;
        private readonly IDiretoriaRepository _diretoriaRepository;
        private readonly IMediatorHandler Bus;

        public DiretoriaAppService(IMapper mapper,
                                   IDiretoriaRepository diretoriaRepository,
                                   IMediatorHandler bus)
        {
            _mapper = mapper;
            _diretoriaRepository = diretoriaRepository;
            Bus = bus;
        }

        public IEnumerable<DiretoriaViewModel> GetAll()
        {
            return _diretoriaRepository.GetAll().ProjectTo<DiretoriaViewModel>();
        }

        public DiretoriaViewModel GetById(Guid id)
        {
            return _mapper.Map<DiretoriaViewModel>(_diretoriaRepository.GetById(id));
        }

        public void Register(DiretoriaViewModel diretoriaViewModel)
        {
            var registerCommand = _mapper.Map<CadastrarDiretoriaCommand>(diretoriaViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(DiretoriaViewModel diretoriaViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarDiretoriaCommand>(diretoriaViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoverDiretoriaCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PagedResult<DiretoriaViewModel> ListForPaging(int page, int pageSize)
        {
            return _mapper.Map<PagedResult<DiretoriaViewModel>>(_diretoriaRepository.ListForEntity(page, pageSize));
        }
    }
}
