using System;

namespace Rumo.WebMetasV2.Application.ViewModels
{
    public class CargoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid GrupoPoolId { get; set; }
        public GrupoPoolViewModel GrupoPool { get; set; }
    }
}
