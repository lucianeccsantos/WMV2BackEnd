using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rumo.WebMetasV2.Application.Interfaces
{
    public interface ICargoAppService : IDisposable
    {
        void Register(CargoViewModel cargoViewModel);
        CargoViewModel GetById(Guid id);
        void Update(CargoViewModel cargoViewModel);
        PagedResult<CargoViewModel> ListForPaging(int page, int pageSize);
        void Remove(Guid id);
        IQueryable<CargoViewModel> GetAll(params Expression<Func<Cargo, object>>[] includes);
    }
}
