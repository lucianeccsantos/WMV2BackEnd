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
            CreateMap<Cargo, CargoViewModel>();
            CreateMap<PagedResult<Cargo>, PagedResult<CargoViewModel>>();
            CreateMap<Colaborador, ColaboradorViewModel>();
            CreateMap<PagedResult<Colaborador>, PagedResult<ColaboradorViewModel>>();
            CreateMap<Dependencia, DependenciaViewModel>();
            CreateMap<PagedResult<Dependencia>, PagedResult<DependenciaViewModel>>();
            CreateMap<Diretoria, DiretoriaViewModel>();
            CreateMap<PagedResult<Diretoria>, PagedResult<DiretoriaViewModel>>();
            CreateMap<Escopo, EscopoViewModel>();
            CreateMap<PagedResult<Escopo>, PagedResult<EscopoViewModel>>();
            CreateMap<GrupoPool, GrupoPoolViewModel>();            
            CreateMap<PagedResult<GrupoPool>, PagedResult<GrupoPoolViewModel>>();
            CreateMap<Indicador, IndicadorViewModel>();
            CreateMap<PagedResult<Indicador>, PagedResult<IndicadorViewModel>>();
            CreateMap<IndicadorEscopoArea, IndicadorEscopoAreaViewModel>();
            CreateMap<PagedResult<Indicador>, PagedResult<IndicadorViewModel>>();
            CreateMap<Perfil, PerfilViewModel>();
            CreateMap<PagedResult<Perfil>, PagedResult<PerfilViewModel>>();
            CreateMap<Unidade, UnidadeViewModel>();
            CreateMap<PagedResult<Unidade>, PagedResult<UnidadeViewModel>>();
        }
    }
}
