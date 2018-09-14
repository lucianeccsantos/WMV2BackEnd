using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Interfaces
{
    public interface IGrupoPoolAppService : IDisposable
    {
        void Register(GrupoPoolViewModel grupoPoolViewModel);
        IEnumerable<GrupoPoolViewModel> GetAll();
        GrupoPoolViewModel GetById(Guid id);
        void Update(GrupoPoolViewModel grupoPoolViewModel);
        PagedResult<GrupoPoolViewModel> ListForPaging(int page, int pageSize);
        void Remove(Guid id);
    }
}
