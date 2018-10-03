using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Rumo.WebMetasV2.Application.Interfaces
{
    public interface IColaboradorAppService : IDisposable
    {
        void Register(ColaboradorViewModel colaboradorViewModel);
        ColaboradorViewModel GetById(Guid id);
        void Update(ColaboradorViewModel colaboradorViewModel);
        PagedResult<ColaboradorViewModel> ListForPaging(int page, int pageSiz, params Expression<Func<Colaborador, object>>[] includes);
        void Remove(Guid id);
        IQueryable<ColaboradorViewModel> GetAll(params Expression<Func<Colaborador, object>>[] includes);
        ColaboradorViewModel GetByLogin(string login);
        ColaboradorViewModel ColaboradorESuperiorImediato(Guid id);
    }
}
