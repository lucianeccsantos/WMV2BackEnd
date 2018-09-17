using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Interfaces
{
    public interface IUnidadeAppService : IDisposable
    {
        void Register(UnidadeViewModel unidadeViewModel);
        IEnumerable<UnidadeViewModel> GetAll();
        UnidadeViewModel GetById(Guid id);
        void Update(UnidadeViewModel unidadeViewModel);
        PagedResult<UnidadeViewModel> ListForPaging(int page, int pagesize);
        void Remove(Guid id);
    }
}
