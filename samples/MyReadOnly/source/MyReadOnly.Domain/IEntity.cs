namespace MyReadOnly.Domain
{
    using System;

    public interface IEntity
    {
        Guid Id { get; }
    }
}