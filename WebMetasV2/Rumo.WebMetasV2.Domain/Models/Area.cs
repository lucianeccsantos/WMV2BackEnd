﻿using Rumo.WebMetasV2.Domain.Core.Models;
using System;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class Area : Entity
    {
        public Area(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Area() { }

        public string Nome { get; set; }
    }
}
