﻿using Rumo.WebMetasV2.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class Unidade : Entity
    {
        public Unidade(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        protected Unidade() { }

        public string Nome { get; private set; }
        public IEnumerable<Colaborador> Colaboradores { get; set; }
    }
}
