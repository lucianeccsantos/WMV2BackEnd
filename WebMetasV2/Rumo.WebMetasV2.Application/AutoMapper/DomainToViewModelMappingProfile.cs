using AutoMapper;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Area, AreaViewModel>();
            CreateMap<PagedResult<Area>, PagedResult<AreaViewModel>>();
            CreateMap<Escopo, EscopoViewModel>();
            CreateMap<PagedResult<Escopo>, PagedResult<EscopoViewModel>>();
            CreateMap<GrupoPool, GrupoPoolViewModel>();
            CreateMap<Unidade, UnidadeViewModel>();
            CreateMap<Perfil, PerfilViewModel>();
            CreateMap<PagedResult<Perfil>, PagedResult<PerfilViewModel>>();
        }
    }
}
