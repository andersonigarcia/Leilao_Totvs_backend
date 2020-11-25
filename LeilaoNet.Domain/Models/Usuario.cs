using FluentValidation;
using LeilaoNet.Domain.Core.Models;
using System.Collections.Generic;

namespace LeilaoNet.Domain.Models
{
    public class Usuario : Entity<Usuario>
    {
        public string Nome { get; set; }
        public string Senha { get; set; }                
        public List<Leilao> Leilao { get; set; }
        public bool Ativo { get; set; }
        public override bool IsValid()
        {
            RuleFor(c => c.Nome)
                .MinimumLength(8)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(c => c.Senha)
                .MinimumLength(8)
                .MaximumLength(20)                
                .NotEmpty();

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
