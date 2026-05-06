using System;

namespace AeroAdapter.Domain.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class ExchangeAttribute : Attribute
{
    public string Name { get; }

    public ExchangeAttribute(string name)
    {
        Name = name;
    }
}

