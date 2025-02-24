# TwinObjectExtensions.SubscribeEditValueChange method

Subscribes a delegate to be invoked when any [`Edit`](../../Ix.Connector.ValueTypes/OnlinerBase-1/Edit.md) value on given object changes its value.[`ITwinObject`](../ITwinObject.md)

```csharp
public static IEnumerable<ITwinPrimitive> SubscribeEditValueChange(this ITwinObject obj, 
    ValueChangeDelegate valueChangeDelegate)
```

| parameter | description |
| --- | --- |
| obj | Observed object. |
| valueChangeDelegate | Delegate to be invoked on Edit value change. |

## Examples

```csharp
class EditValueChangeObserver
{
    public EditValueChangeObserver()
    {
        Connector.MAIN.SubscribeEditValueChange(DetectEditValueChange);                 
    }
    
    private void DetectEditValueChange(IValueTag valueTag, dynamic original, dynamic newValue)
    {
        Console.WriteLine($"Value '{valueTag.Symbol}' has changed form {original} to {newValue}.")
    }
     
}
```

## See Also

* interface [ITwinPrimitive](../ITwinPrimitive.md)
* interface [ITwinObject](../ITwinObject.md)
* delegate [ValueChangeDelegate](../../Ix.Connector.ValueTypes/OnlinerBase.ValueChangeDelegate.md)
* class [TwinObjectExtensions](../TwinObjectExtensions.md)
* namespace [Ix.Connector](../../Ix.Connector.md)

<!-- DO NOT EDIT: generated by xmldocmd for Ix.Connector.dll -->
