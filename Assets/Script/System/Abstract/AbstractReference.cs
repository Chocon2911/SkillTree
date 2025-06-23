using System;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class AbstractReference<TAbstract, TObject>
    where TObject : Object
    where TAbstract : class
{
    [SerializeField, HideInInspector] TObject underlyingValue;

    public TAbstract Value
    {
        get => underlyingValue switch
        {
            null => null,
            TAbstract abstractObj => abstractObj,
            _ => throw new InvalidOperationException($"{underlyingValue} must derive from {typeof(TAbstract)}.")
        };
        set => underlyingValue = value switch
        {
            null => null,
            TObject castValue => castValue,
            _ => throw new ArgumentException($"{value} must be of type {typeof(TObject)}.", string.Empty)
        };
    }

    public TObject UnderlyingValue
    {
        get => underlyingValue;
        set => underlyingValue = value;
    }

    public AbstractReference() { }

    public AbstractReference(TObject obj) => underlyingValue = obj;

    public AbstractReference(TAbstract @abstract) => underlyingValue = @abstract as TObject;

    public static implicit operator TAbstract(AbstractReference<TAbstract, TObject> obj) => obj.Value;
}

[Serializable]
public class AbstractReference<TAbstract> : AbstractReference<TAbstract, Object> where TAbstract : class { }
