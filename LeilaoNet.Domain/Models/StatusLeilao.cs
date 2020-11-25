using System.ComponentModel;

namespace LeilaoNet.Domain.Models
{
    public enum StatusLeilao
    {
        [Description("Aberto")]
        Aberto = 1,

        [Description("Encerrado")]
        Encerrado = 2,

        [Description("Cancelado")]
        Cancelado = 3
    }
}
