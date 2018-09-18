using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Interfaces
{
    public interface IAreaAppService : IDisposable
    {
        void Register(AreaViewModel areaViewModel);
        IEnumerable<AreaViewModel> GetAll();
        AreaViewModel GetById(Guid id);
        void Update(AreaViewModel areaViewModel);
        PagedResult<AreaViewModel> ListForPaging(int page, int pageSize);
        void Remove(Guid id);
    }
}
