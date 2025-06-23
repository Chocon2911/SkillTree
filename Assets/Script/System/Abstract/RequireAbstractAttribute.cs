using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class RequireAbstractAttribute : PropertyAttribute
{
    public readonly Type AbstractType;

    public RequireAbstractAttribute(Type abstractType)
    {
        Debug.Assert(abstractType.IsAbstract && !abstractType.IsInterface,
            $"{nameof(abstractType)} must be an abstract class (not an interface).");

        AbstractType = abstractType;
    }
}
