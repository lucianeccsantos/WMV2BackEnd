using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.ColaboradorCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Rumo.WebMetasV2.Application.Service
{
    public class ColaboradorAppService : IColaboradorAppService
    {
        private readonly IMapper _mapper;
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IMediatorHandler Bus;

        public ColaboradorAppService(IMapper mapper,
                                     IColaboradorRepository colaboradorRepository,
                                     IMediatorHandler bus)
        {
            _mapper = mapper;
            _colaboradorRepository = colaboradorRepository;
            Bus = bus;
        }

        public ColaboradorViewModel GetById(Guid id)
        {
            return _mapper.Map<ColaboradorViewModel>(_colaboradorRepository.GetById(id));
        }

        public void Register(ColaboradorViewModel cargoViewModel)
        {
            var registerCommand = _mapper.Map<CadastrarColaboradorCommand>(cargoViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ColaboradorViewModel cargoViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarColaboradorCommand>(cargoViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoverColaboradorCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PagedResult<ColaboradorViewModel> ListForPaging(int page, int pageSize, params Expression<Func<Colaborador, object>>[] includes)
        {
            return _mapper.Map<PagedResult<ColaboradorViewModel>>(_colaboradorRepository.ListForEntity(page, pageSize, includes));
        }

        public IQueryable<ColaboradorViewModel> GetAll(params Expression<Func<Colaborador, object>>[] includes)
        {
            return _colaboradorRepository.GetAll(includes).ProjectTo<ColaboradorViewModel>();
        }

        public ColaboradorViewModel GetByLogin(string login)
        {
            return _mapper.Map<ColaboradorViewModel>(_colaboradorRepository.GetByLogin(login));
        }

        public ColaboradorViewModel ColaboradorESuperiorImediato(Guid id)
        {
            return _mapper.Map<ColaboradorViewModel>(_colaboradorRepository.ColaboradorESuperiorImediato(id));
        }
    }
}
