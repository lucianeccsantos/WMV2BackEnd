using Rumo.WebMetasV2.Domain.Core.Events;
using System;

namespace Rumo.WebMetasV2.Domain.Events.ColaboradorEvents
{
    public class ColaboradorRegisteredEvent : Event
    {
        public ColaboradorRegisteredEvent(Guid id, string login, string nome, Guid cargoId, string cpf, Guid dependenciaId, Guid perfilId, 
                                          string email, Guid unidadeId, Nullable<Guid> superiorImediatoId, bool cadastroIncompleto, bool ativo)
        {
            Id = id;
            Login = login;
            Nome = nome;
            CargoId = cargoId;
            CPF = cpf;
            DependenciaId = dependenciaId;
            Email = email;
            PerfilId = perfilId;
            UnidadeId = unidadeId;
            SuperiorImediatoId = superiorImediatoId;
            CadastroIncompleto = cadastroIncompleto;
            Ativo = ativo;
        }

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
    }
}
