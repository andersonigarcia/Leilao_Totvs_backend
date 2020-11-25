using FluentValidation;
using LeilaoNet.Domain.Core.Models;
using System;

namespace LeilaoNet.Domain.Models
{
    public class Produto : Entity<Produto>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Usado { get; set; }
        public decimal Valor { get; set; }
        public Guid LeilaoId { get; set; }
        public Leilao Leilao { get; set; }

        public override bool IsValid()
        {
            RuleFor(c => c.Nome)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(c => c.Descricao)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(c => c.Valor)
                .NotNull();

            return base.IsValid();
        }

    }
}
