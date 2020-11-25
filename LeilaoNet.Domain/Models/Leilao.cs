using FluentValidation;
using LeilaoNet.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace LeilaoNet.Domain.Models
{
    public class Leilao : Entity<Leilao>
    {
        public string Titulo { get; set; }
        public string Responsavel { get; set; }
        public DateTime Abertura { get; set; }
        public DateTime Encerramento { get; set; }
        public decimal LanceMinimo { get; set; }
        public StatusLeilao Status { get; set; }
        public List<Produto> Produto { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public bool Ativo { get; set; }

        public override bool IsValid()
        {
            RuleFor(c => c.Titulo)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(c => c.Responsavel)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(c => c.Status)
                .IsInEnum()
                .NotEmpty();

            RuleFor(c => c.LanceMinimo)
                .NotNull();

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}