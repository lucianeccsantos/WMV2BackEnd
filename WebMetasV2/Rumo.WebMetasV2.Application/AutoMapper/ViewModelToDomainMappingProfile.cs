using AutoMapper;
using Rumo.WebMetasV2.Application.ViewModels;
using Rumo.WebMetasV2.Domain.Commands.AreaCommands;
using Rumo.WebMetasV2.Domain.Commands.EscopoCommands;
using Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands;
using Rumo.WebMetasV2.Domain.Commands.PerfilCommands;
using Rumo.WebMetasV2.Domain.Commands.IndicadorCommands;
using Rumo.WebMetasV2.Domain.Commands.UnidadeCommands;
using Rumo.WebMetasV2.Domain.Commands.CargoCommands;
using Rumo.WebMetasV2.Domain.Commands.DependenciaCommands;
using Rumo.WebMetasV2.Domain.Commands.DiretoriaCommands;
using Rumo.WebMetasV2.Domain.Commands.ColaboradorCommands;
using Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands;

namespace Rumo.WebMetasV2.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Area
            CreateMap<AreaViewModel, CadastrarAreaCommand>()
                .ConstructUsing(c => new CadastrarAreaCommand(c.Nome));
            CreateMap<AreaViewModel, AtualizarAreaCommand>()
                .ConstructUsing(c => new AtualizarAreaCommand(c.Id, c.Nome));
            #endregion

            #region Cargo
            CreateMap<CargoViewModel, CadastrarCargoCommand>()
                .ConstructUsing(c => new CadastrarCargoCommand(c.Nome, c.GrupoPoolId));
            CreateMap<CargoViewModel, AtualizarCargoCommand>()
                .ConstructUsing(c => new AtualizarCargoCommand(c.Id, c.Nome, c.GrupoPoolId));
            #endregion

            #region Colaborador
            CreateMap<ColaboradorViewModel, CadastrarColaboradorCommand>()
                .ConstructUsing(c => new CadastrarColaboradorCommand(c.Login, c.Nome, c.CargoId, c.CPF, c.DependenciaId, c.PerfilId, 
                                                                     c.Email, c.UnidadeId, c.SuperiorImediatoId, c.CadastroIncompleto, c.Ativo));
            CreateMap<ColaboradorViewModel, AtualizarColaboradorCommand>()
                .ConstructUsing(c => new AtualizarColaboradorCommand(c.Id, c.Login, c.Nome, c.CargoId, c.CPF, c.DependenciaId, c.PerfilId,
                                                                     c.Email, c.UnidadeId, c.SuperiorImediatoId, c.CadastroIncompleto, c.Ativo));
            #endregion

            #region Dependencia
            CreateMap<DependenciaViewModel, CadastrarDependenciaCommand>()
                .ConstructUsing(c => new CadastrarDependenciaCommand(c.Nome));
            CreateMap<DependenciaViewModel, AtualizarDependenciaCommand>()
                .ConstructUsing(c => new AtualizarDependenciaCommand(c.Id, c.Nome));
            #endregion

            #region Diretoria
            CreateMap<DiretoriaViewModel, CadastrarDiretoriaCommand>()
                .ConstructUsing(c => new CadastrarDiretoriaCommand(c.Nome));
            CreateMap<DiretoriaViewModel, AtualizarDiretoriaCommand>()
                .ConstructUsing(c => new AtualizarDiretoriaCommand(c.Id, c.Nome));
            #endregion

            #region Escopo
            CreateMap<EscopoViewModel, CadastrarEscopoCommand>()
                .ConstructUsing(c => new CadastrarEscopoCommand(c.Nome));
            CreateMap<EscopoViewModel, AtualizarEscopoCommand>()
                .ConstructUsing(c => new AtualizarEscopoCommand(c.Id, c.Nome));
            #endregion

            #region GrupoPool
            CreateMap<GrupoPoolViewModel, CadastrarGrupoPoolCommand>()
                .ConstructUsing(c => new CadastrarGrupoPoolCommand(c.Nome));
            CreateMap<GrupoPoolViewModel, AtualizarGrupoPoolCommand>()
                .ConstructUsing(c => new AtualizarGrupoPoolCommand(c.Id, c.Nome));
            #endregion

            #region Indicador
            CreateMap<IndicadorViewModel, CadastrarIndicadorCommand>()
                .ConstructUsing(c => new CadastrarIndicadorCommand(c.Nome, c.DirecaoIndicador, c.TipoIndicador, c.MesInicio, c.MesFim,
                                                                   c.Descricao, c.FormulaCalculo, c.Periodicidade));
            CreateMap<IndicadorViewModel, AtualizarIndicadorCommand>()
                .ConstructUsing(c => new AtualizarIndicadorCommand(c.Id, c.Nome, c.DirecaoIndicador, c.TipoIndicador, c.MesInicio, c.MesFim,
                                                                   c.Descricao, c.FormulaCalculo, c.Periodicidade));
            #endregion

            #region Indicador Escopo Área
            CreateMap<IndicadorEscopoAreaViewModel, CadastrarIndicadorEscopoAreaCommand>()
                .ConstructUsing(c => new CadastrarIndicadorEscopoAreaCommand(c.IndicadorId, c.EscopoId, c.AreaId));
            CreateMap<IndicadorEscopoAreaViewModel, AtualizarIndicadorEscopoAreaCommand>()
                .ConstructUsing(c => new AtualizarIndicadorEscopoAreaCommand(c.Id, c.IndicadorId, c.EscopoId, c.AreaId));
            #endregion

            #region Unidade
            CreateMap<UnidadeViewModel, CadastrarUnidadeCommand>()
                .ConstructUsing(c => new CadastrarUnidadeCommand(c.Nome));
            CreateMap<UnidadeViewModel, AtualizarUnidadeCommand>()
                .ConstructUsing(c => new AtualizarUnidadeCommand(c.Id, c.Nome));

            CreateMap<UnidadeViewModel, RemoverUnidadeCommand>()
                .ConstructUsing(c => new RemoverUnidadeCommand(c.Id));
            #endregion

            #region Perfil
            CreateMap<PerfilViewModel, CadastrarPerfilCommand>()
                .ConstructUsing(c => new CadastrarPerfilCommand(c.Nome, c.Situacao));

            CreateMap<PerfilViewModel, AtualizarPerfilCommand>()
                .ConstructUsing(c => new AtualizarPerfilCommand(c.Id, c.Nome, c.Situacao));

            CreateMap<PerfilViewModel, RemoverPerfilCommand>()
                .ConvertUsing(c => new RemoverPerfilCommand(c.Id));

            #endregion

            
        }
    }
}
