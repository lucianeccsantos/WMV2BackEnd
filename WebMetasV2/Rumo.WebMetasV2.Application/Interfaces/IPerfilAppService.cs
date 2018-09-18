using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Application.Interfaces
{
    public interface IPerfilAppService : IDisposable
    {
        void Register(PerfilViewModel perfilViewModel);
        IEnumerable<PerfilViewModel> GetAll();
        PerfilViewModel GetById(Guid id);
        void Update(PerfilViewModel perfilViewModel);
        PagedResult<PerfilViewModel> ListForPaging(int page, int pageSize);
        void Remove(Guid id);
    }
}
