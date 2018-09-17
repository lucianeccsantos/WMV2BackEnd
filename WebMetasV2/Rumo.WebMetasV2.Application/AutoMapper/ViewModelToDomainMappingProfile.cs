using AutoMapper;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands;
using Rumo.WebMetasV2.Domain.Commands.UnidadeCommands;

namespace Rumo.WebMetasV2.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<GrupoPoolViewModel, CadastrarGrupoPoolCommand>()
                .ConstructUsing(c => new CadastrarGrupoPoolCommand(c.Nome));

            CreateMap<GrupoPoolViewModel, AtualizarGrupoPoolCommand>()
                .ConstructUsing(c => new AtualizarGrupoPoolCommand(c.Id, c.Nome));

            CreateMap<UnidadeViewModel, CadastrarUnidadeCommand>()
                .ConstructUsing(c => new CadastrarUnidadeCommand(c.Nome));

            CreateMap<UnidadeViewModel, AtualizarUnidadeCommand>()
                .ConstructUsing(c => new AtualizarUnidadeCommand(c.Id, c.Nome));

            CreateMap<UnidadeViewModel, RemoverUnidadeCommand>()
                .ConstructUsing(c => new RemoverUnidadeCommand(c.Id));
        }
    }
}
