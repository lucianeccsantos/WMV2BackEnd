using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.Interfaces
{
    public interface IDiretoriaAppService : IDisposable
    {
        void Register(DiretoriaViewModel diretoriaViewModel);
        IEnumerable<DiretoriaViewModel> GetAll();
        DiretoriaViewModel GetById(Guid id);
        void Update(DiretoriaViewModel diretoriaViewModel);
        PagedResult<DiretoriaViewModel> ListForPaging(int page, int pageSize);
        void Remove(Guid id);
    }
}
