using System;
using Flunt.Notifications;

namespace ContextoDePagamento.Kernel.Entidades
{
    public abstract class Entidade: Notifiable
    {
        public Entidade() => Id = Guid.NewGuid();

        public Guid Id { get; private set; }
    }
}