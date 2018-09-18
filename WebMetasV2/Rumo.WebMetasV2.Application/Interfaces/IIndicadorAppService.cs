using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Interfaces
{
    public interface IIndicadorAppService : IDisposable
    {
        void Register(IndicadorViewModel indicadorViewModel);
        IEnumerable<IndicadorViewModel> GetAll();
        IndicadorViewModel GetById(Guid id);
        void Update(IndicadorViewModel indicadorViewModel);
        PagedResult<IndicadorViewModel> ListForPaging(int page, int pageSize);
        void Remove(Guid id);
    }
}
