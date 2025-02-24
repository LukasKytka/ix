# OnlinerBase&lt;T&gt;.AttributeMaximum property

Gets or sets max. value allowed for this tag. If the value is not set the max. value will be the maximum allowed for this type.

The value is typically set by attribute in the PLC code

This example demonstrates how to set value boundaries for a numerical value. [`AttributeMinimum`](./AttributeMinimum.md) and `AttributeMaximum`. Notice that the name of the 'added property' is prefixed with 'Attribute' when trans-piled into .net class.

```csharp
{attribute addProperty Minimum 10}
{attribute addProperty Maximum 50}
_integerVar : INT;
```

```csharp
public T AttributeMaximum { get; set; }
```

## See Also

* class [OnlinerBase&lt;T&gt;](../OnlinerBase-1.md)
* namespace [Ix.Connector.ValueTypes](../../Ix.Connector.md)

<!-- DO NOT EDIT: generated by xmldocmd for Ix.Connector.dll -->
