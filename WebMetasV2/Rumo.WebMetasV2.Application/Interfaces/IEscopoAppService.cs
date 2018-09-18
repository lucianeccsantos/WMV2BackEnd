using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Interfaces
{
    public interface IEscopoAppService : IDisposable
    {
        void Register(EscopoViewModel escopoViewModel);
        IEnumerable<EscopoViewModel> GetAll();
        EscopoViewModel GetById(Guid id);
        void Update(EscopoViewModel escopoViewModel);
        PagedResult<EscopoViewModel> ListForPaging(int page, int pageSize);
        void Remove(Guid id);
    }
}
