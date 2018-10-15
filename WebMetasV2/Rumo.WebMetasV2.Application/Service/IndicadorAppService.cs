using AutoMapper;
using AutoMapper.QueryableExtensions;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.IndicadorCommands;
using Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rumo.WebMetasV2.Application.Service
{
    public class IndicadorAppService : IIndicadorAppService
    {
        private readonly IMapper _mapper;
        private readonly IIndicadorRepository _indicadorRepository;
        private readonly IMediatorHandler Bus;

        public IndicadorAppService(IMapper mapper,
                                   IIndicadorRepository indicadorRepository,
                                   IMediatorHandler bus)
        {
            _mapper = mapper;
            _indicadorRepository = indicadorRepository;
            Bus = bus;
        }

        public IEnumerable<IndicadorViewModel> GetAll()
        {
            return _indicadorRepository.GetAll().ProjectTo<IndicadorViewModel>();
        }

        public IndicadorViewModel GetById(Guid id)
        {
            return _mapper.Map<IndicadorViewModel>(_indicadorRepository.GetById(id));
        }

        public void Register(IndicadorViewModel indicadorViewModel)
        {
            IEnumerable<IndicadorEscopoAreaViewModel> listIndicadorEscopoArea = new List<IndicadorEscopoAreaViewModel>();
            var registerCommand = _mapper.Map<CadastrarIndicadorCommand>(indicadorViewModel);
            registerCommand.Id = Guid.NewGuid();

            var result = Bus.SendCommand(registerCommand);

            if (result.IsCompleted)
            {
                listIndicadorEscopoArea = TransformaIndicadorEmIndicadorEscopoArea(indicadorViewModel);
            }

            foreach(var indicadorEscopoArea in listIndicadorEscopoArea)
            {
                indicadorEscopoArea.IndicadorId = registerCommand.Id;
                var registerEscopoAreaCommand = _mapper.Map<CadastrarIndicadorEscopoAreaCommand>(indicadorEscopoArea);
                Bus.SendCommand(registerEscopoAreaCommand);
            }
        }

        public void Update(IndicadorViewModel indicadorViewModel)
        {
            var updateCommand = _mapper.Map<AtualizarIndicadorCommand>(indicadorViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoverIndicadorCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public PagedResult<IndicadorViewModel> ListForPaging(int page, int pageSize, params Expression<Func<Indicador, object>>[] includes)
        {
            return _mapper.Map<PagedResult<IndicadorViewModel>>(_indicadorRepository.ListForEntity(page, pageSize, includes));
        }

        public IEnumerable<IndicadorEscopoAreaViewModel> TransformaIndicadorEmIndicadorEscopoArea(IndicadorViewModel indicador)
        {
            var lista = new List<IndicadorEscopoAreaViewModel>();

            foreach(var indicadorEscopoAreaFor in indicador.IndicadorEscopoAreas)
            {
                var indicadorEscopoArea = new IndicadorEscopoAreaViewModel();
                indicadorEscopoArea.IndicadorId = indicadorEscopoAreaFor.Id;
                indicadorEscopoArea.EscopoId = indicadorEscopoAreaFor.EscopoId;
                indicadorEscopoArea.AreaId = indicadorEscopoAreaFor.AreaId;

                lista.Add(indicadorEscopoArea);
            }

            return lista;
        }
    }
}
