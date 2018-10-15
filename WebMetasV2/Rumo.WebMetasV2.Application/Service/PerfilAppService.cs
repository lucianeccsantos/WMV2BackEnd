using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.PerfilCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Application.Service
{
    public class PerfilAppService : IPerfilAppService
    {
        private readonly IMapper _mapper;
        private readonly IPerfilRepository _perfilrepository;
        private readonly IMediatorHandler _bus;

        public PerfilAppService(IMapper mapper, 
                                 IPerfilRepository perfilRepository,
                                 IMediatorHandler bus)
        {
            _mapper = mapper;
            _perfilrepository = perfilRepository;
            _bus = bus;
        }

        public void Dispose()
        {
            _perfilrepository.Dispose();
        }

        public IEnumerable<PerfilViewModel> GetAll()
        {
            return _perfilrepository.GetAll().ProjectTo<PerfilViewModel>();
        }

        public PerfilViewModel GetById(Guid id)
        {
            return _mapper.Map<PerfilViewModel>(_perfilrepository.GetById(id));
        }

        public PagedResult<PerfilViewModel> ListForPaging(int page, int pageSize)
        {
            return _mapper.Map<PagedResult<PerfilViewModel>>(_perfilrepository.ListForEntity(page, pageSize));
        }

        public void Register(PerfilViewModel perfilViewModel)
        {
            var registerCommand = _mapper.Map<CadastrarPerfilCommand>(perfilViewModel);
            _bus.SendCommand(registerCommand);

        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoverPerfilCommand(id);
            _bus.SendCommand(removeCommand);
        }

        public void Update(PerfilViewModel perfilViewModel)
        {
            var updateCommand = new AtualizarPerfilCommand(perfilViewModel.Id, perfilViewModel.Nome, perfilViewModel.Situacao);
            _bus.SendCommand(updateCommand);
        }

        public PagedResult<PerfilViewModel> GetBy(PerfilViewModel perfil, int page, int pageSize)
        {
            

            return _mapper.Map<PagedResult<PerfilViewModel>>(_perfilrepository.GetBy(_mapper.Map<Perfil>(perfil), page, pageSize));
        }
    }
}
