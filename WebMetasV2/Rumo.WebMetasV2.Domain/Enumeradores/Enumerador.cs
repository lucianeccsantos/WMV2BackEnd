namespace Rumo.WebMetasV2.Domain.Enumeradores
{
    public class Enumerador
    {
        public enum TipoIndicador {
            Soma = 1,
            MediaSimples = 2,
            Acumulado = 3,
            UltimoMes = 4
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

        public enum Periodicidade
        {
            Acumulado = 1,
            Bimestral = 2,
            Trimestral = 3,
            Quadrimestral = 4,
            Semestral = 5
        }

        public enum Entidades
        {
            MetasIndividuais = 1,
            Indicador = 2,
            ValoresIndicador = 3,
            ValoresRealizados = 4,
            ValoresRealizadosRetroativos = 5
        }

        public enum Responsavel
        {
            Proprietario = 1,
            SuperiorImediato = 2,
            Perfil = 3
        }

        public enum TipoEtapa
        {
            E = 1,
            OU = 2
        }
    }
}
