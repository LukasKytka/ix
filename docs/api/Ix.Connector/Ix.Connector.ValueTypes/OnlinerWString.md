# OnlinerWString class

Class providing access to the WSTRING type online variable.

```csharp
public class OnlinerWString : OnlinerBase<string>, IOnlineWString, IShadowWString
```

## Public Members

| name | description |
| --- | --- |
| [OnlinerWString](OnlinerWString/OnlinerWString.md)() | Initializes a new instance of the [`OnlinerWString`](./OnlinerWString.md) class. |
| [OnlinerWString](OnlinerWString/OnlinerWString.md)(…) | Initializes a new instance of the [`OnlinerWString`](./OnlinerWString.md) class. |
| override [Cyclic](OnlinerWString/Cyclic.md) { get; set; } | Gets tranlated and interpolated string of [`Cyclic`](./OnlinerWString/Cyclic.md) value. Sets [`Cyclic`](./OnlinerWString/Cyclic.md) value. |
| override [InstanceMaxValue](OnlinerWString/InstanceMaxValue.md) { get; } | Gets the max value for this instance. |
| override [InstanceMinValue](OnlinerWString/InstanceMinValue.md) { get; } | Gets the min value for this instance. |
| override [GetAsync](OnlinerWString/GetAsync.md)() | Get the value of this [`OnlinerWString`](./OnlinerWString.md). |
| override [SetAsync](OnlinerWString/SetAsync.md)(…) | Sets the value of this [`OnlinerWString`](./OnlinerWString.md). |

## See Also

* class [OnlinerBase&lt;T&gt;](./OnlinerBase-1.md)
* interface [IOnlineWString](../Ix.Connector.ValueTypes.Online/IOnlineWString.md)
* interface [IShadowWString](../Ix.Connector.ValueTypes.Shadows/IShadowWString.md)
* namespace [Ix.Connector.ValueTypes](../Ix.Connector.md)

<!-- DO NOT EDIT: generated by xmldocmd for Ix.Connector.dll -->
