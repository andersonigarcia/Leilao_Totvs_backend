using LeilaoNet.Domain.Core.Messaging;
using System;

namespace LeilaoNet.Application.Clients.Commands
{
    public class LeilaoCreateCommand : Command
    {
        public string Titulo { get; set; }
        public string Responsavel { get; set; }

        public DateTime Abertura { get; set; }
        public DateTime Encerramento { get; set; }
        public int StatusId { get; set; }
    }
}