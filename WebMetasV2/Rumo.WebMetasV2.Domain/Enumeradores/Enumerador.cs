namespace Rumo.WebMetasV2.Domain.Enumeradores
{
    public class Enumerador
    {
        public enum TipoIndicador {
            Soma = 1,
            MediaSimples = 2,
            Acumulado
        }

        public enum DirecaoIndicador
        {
            MaiorMelhor = 1,
            MenorMelhor = 2,
            Igual = 3,
            MaisMenos = 4
        }

        public enum Mes
        {
            Janeiro = 1,
            Fevereiro = 2,
            Marco = 3,
            Abril = 4,
            Maio = 5,
            Junho = 6,
            Julho = 7,
            Agosto = 8,
            Setembro = 9,
            Outubro = 10,
            Novembro = 11,
            Dezembro = 12
        }
    }
}
