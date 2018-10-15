using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Interfaces
{
    public interface IFluxoAprovacaoAppService : IDisposable
    {
        void Register(FluxoAprovacaoViewModel fluxoAprovacaoViewModel);
        IEnumerable<FluxoAprovacaoViewModel> GetAll();
        FluxoAprovacaoViewModel GetById(Guid id);
        void Update(FluxoAprovacaoViewModel fluxoAprovacaoViewModel);
        PagedResult<FluxoAprovacaoViewModel> ListForPaging(int page, int pageSize);
        void Remove(Guid id);
    }
}
