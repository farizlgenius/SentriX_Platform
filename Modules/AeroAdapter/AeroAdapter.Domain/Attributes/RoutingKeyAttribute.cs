using System;

namespace AeroAdapter.Domain.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class RoutingKeyAttribute : Attribute
{
    public string Key { get; }

    public RoutingKeyAttribute(string key)
    {
        Key = key;
    }
}
