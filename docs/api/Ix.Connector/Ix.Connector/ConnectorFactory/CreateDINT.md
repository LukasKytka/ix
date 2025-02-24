# ConnectorFactory.CreateDINT method (1 of 2)

Creates Int32 tag of a value type DINT;

```csharp
public abstract OnlinerDInt CreateDINT(ITwinObject parent, string readableTail, string symbolTail)
```

| parameter | description |
| --- | --- |
| parent | Parent object of [`ITwinObject`](../ITwinObject.md) type. |
| readableTail | Human readable tail of this value tag. |
| symbolTail | Symbol tail of this value tag. |

## Return Value

New instance of [`OnlinerDInt`](../../Ix.Connector.ValueTypes/OnlinerDInt.md)

## See Also

* class [OnlinerDInt](../../Ix.Connector.ValueTypes/OnlinerDInt.md)
* interface [ITwinObject](../ITwinObject.md)
* class [ConnectorFactory](../ConnectorFactory.md)
* namespace [Ix.Connector](../../Ix.Connector.md)

---

# ConnectorFactory.CreateDINT method (2 of 2)

Creates Int32 empty tag of a value type DINT;

```csharp
public static OnlinerDInt CreateDINT()
```

## See Also

* class [OnlinerDInt](../../Ix.Connector.ValueTypes/OnlinerDInt.md)
* class [ConnectorFactory](../ConnectorFactory.md)
* namespace [Ix.Connector](../../Ix.Connector.md)

<!-- DO NOT EDIT: generated by xmldocmd for Ix.Connector.dll -->
