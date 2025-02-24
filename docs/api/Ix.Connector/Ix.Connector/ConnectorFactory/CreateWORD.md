# ConnectorFactory.CreateWORD method (1 of 2)

Creates UInt16 tag of a value type WORD;

```csharp
public abstract OnlinerWord CreateWORD(ITwinObject parent, string readableTail, string symbolTail)
```

| parameter | description |
| --- | --- |
| parent | Parent object of [`ITwinObject`](../ITwinObject.md) type. |
| readableTail | Human readable tail of this value tag. |
| symbolTail | Symbol tail of this value tag. |

## Return Value

New instance of [`OnlinerWord`](../../Ix.Connector.ValueTypes/OnlinerWord.md)

## See Also

* class [OnlinerWord](../../Ix.Connector.ValueTypes/OnlinerWord.md)
* interface [ITwinObject](../ITwinObject.md)
* class [ConnectorFactory](../ConnectorFactory.md)
* namespace [Ix.Connector](../../Ix.Connector.md)

---

# ConnectorFactory.CreateWORD method (2 of 2)

Creates UInt16 empty tag of a value type WORD;

```csharp
public static OnlinerWord CreateWORD()
```

## See Also

* class [OnlinerWord](../../Ix.Connector.ValueTypes/OnlinerWord.md)
* class [ConnectorFactory](../ConnectorFactory.md)
* namespace [Ix.Connector](../../Ix.Connector.md)

<!-- DO NOT EDIT: generated by xmldocmd for Ix.Connector.dll -->
