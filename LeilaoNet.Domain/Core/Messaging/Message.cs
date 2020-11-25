using LeilaoNet.Domain.Models;
using System;

namespace LeilaoNet.Domain.Core.Messaging
{
    public abstract class Message 
    {
        public string MessageType { get; protected set; }

        public Guid AggregateId { get; protected set; }

        public Usuario User { get; private set; }        

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}