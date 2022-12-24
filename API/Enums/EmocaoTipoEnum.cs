using System.ComponentModel;

namespace API.Enums
{
    public enum EmocaoTipoEnum
    {
        [Description("Alegria, felicidade, contentamento, satisfação, bem-estar")]
        Alegria = 1,

        [Description("Tristeza, decepção, falta de esperança ou interesse, insatisfação")]
        Tristeza = 2,

        [Description("Medo, resposta a uma situação de ameaça ou perigo")]
        Medo = 3,

        [Description("Nojo, repulsa, aversão")]
        Nojo = 4,

        [Description("Raiva, hostilidade, frustração, irritação, ressentimento")]
        Raiva = 5,

        [Description("Surpresa, resposta a uma situação inesperada que pode ser negativa ou positiva")]
        Surpresa = 6,

        [Description("Neutro, se abstém de tomar partido, não se posiciona")]
        Neutro = 7,

        [Description("Outro, qualquer outro sentimento não listado")]
        Outro = 99
    }
}
