using Rumo.WebMetasV2.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class Colaborador : Entity
    {
        public Colaborador(Guid id, string login, string nome, Guid cargoId, string cpf, Guid dependenciaId, Guid perfilId, 
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

        public Colaborador() {  }

        public string Login { get; private set; }
        public string Nome { get; private set; }
        public Guid CargoId { get; private set; }
        public string CPF { get; private set; }
        public Guid DependenciaId { get; private set; }
        public string Email { get; private set; }
        public Guid PerfilId { get; private set; }
        public Guid UnidadeId { get; private set; }
        public Nullable<Guid> SuperiorImediatoId { get; private set; }
        public bool CadastroIncompleto { get; private set; }
        public bool Ativo { get; private set; }

        public virtual Cargo Cargo { get; set; }
        public virtual Dependencia Dependencia { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual Unidade Unidade { get; set; }
        public virtual Colaborador SuperiorImediato { get; set; }
        public virtual IEnumerable<Colaborador> Colaboradores { get; set; }
    }
}
