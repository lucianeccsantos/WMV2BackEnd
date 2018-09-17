using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.UnidadeCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Application.Service
{
    public class UnidadeAppService : IUnidadeAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnidadeRepository _unidadeRepository;
        private readonly IMediatorHandler _bus;

        public UnidadeAppService(IMapper mapper,
                                IUnidadeRepository unidadeRepository,
                                IMediatorHandler bus)
        {
            _mapper = mapper;
            _unidadeRepository = unidadeRepository;
            _bus = bus;
        }
        public IEnumerable<UnidadeViewModel> GetAll()
        {
            return _unidadeRepository.GetAll().ProjectTo<UnidadeViewModel>();
        }

        public UnidadeViewModel GetById(Guid id)
        {
            return _mapper.Map<UnidadeViewModel>(_unidadeRepository.GetById(id));
        }

        public PagedResult<UnidadeViewModel> ListForPaging(int page, int pagesize)
        {
            return _mapper.Map<PagedResult<UnidadeViewModel>>(_unidadeRepository.ListForEntity(page, pagesize));
        }

        public void Register(UnidadeViewModel unidadeViewModel)
        {
            var registerCommand = _mapper.Map<CadastrarUnidadeCommand>(unidadeViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoverUnidadeCommand(id);
            _bus.SendCommand(removeCommand);
        }

        public void Update(UnidadeViewModel unidadeViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarUnidadeCommand>(unidadeViewModel);
            _bus.SendCommand(updateCommand);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
