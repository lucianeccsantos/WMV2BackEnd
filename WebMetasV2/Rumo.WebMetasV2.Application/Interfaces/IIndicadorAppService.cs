using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rumo.WebMetasV2.Application.Interfaces
{
    public interface IIndicadorAppService : IDisposable
    {
        void Register(IndicadorViewModel indicadorViewModel);
        IEnumerable<IndicadorViewModel> GetAll();
        IndicadorViewModel GetById(Guid id);
        void Update(IndicadorViewModel indicadorViewModel);
        PagedResult<IndicadorViewModel> ListForPaging(int page, int pageSize, params Expression<Func<Indicador, object>>[] includes);
        void Remove(Guid id);
    }
}
