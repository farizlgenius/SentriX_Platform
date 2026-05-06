using System;

namespace Core.Domain.Attributes;

// Messaging/Attributes/RoutingKeyAttribute.cs
using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class RoutingKeyAttribute : Attribute
{
    public string Key { get; }

    public RoutingKeyAttribute(string key)
    {
        Key = key;
    }
}