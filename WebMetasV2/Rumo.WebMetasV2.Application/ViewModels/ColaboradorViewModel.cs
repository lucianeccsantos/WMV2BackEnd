using System;

namespace Rumo.WebMetasV2.Application.ViewModels
{
    public class ColaboradorViewModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public Guid CargoId { get; set; }
        public string CPF { get; set; }
        public Guid DependenciaId { get; set; }
        public string Email { get; set; }
        public Guid PerfilId { get; set; }
        public Guid UnidadeId { get; set; }
        public Nullable<Guid> SuperiorImediatoId { get; set; }
        public bool CadastroIncompleto { get; set; }
        public bool Ativo { get; set; }

        public CargoViewModel Cargo { get; set; }
        public DependenciaViewModel Dependencia { get; set; }
        public PerfilViewModel Perfil { get; set; }
        public UnidadeViewModel Unidade { get; set; }
        public ColaboradorViewModel SuperiorImediato { get; set; }
    }
}
