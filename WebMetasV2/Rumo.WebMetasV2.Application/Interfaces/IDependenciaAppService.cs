using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Interfaces
{
    public interface IDependenciaAppService : IDisposable
    {
        void Register(DependenciaViewModel dependenciaViewModel);
        IEnumerable<DependenciaViewModel> GetAll();
        DependenciaViewModel GetById(Guid id);
        void Update(DependenciaViewModel dependenciaViewModel);
        PagedResult<DependenciaViewModel> ListForPaging(int page, int pageSize);
        void Remove(Guid id);
    }
}
