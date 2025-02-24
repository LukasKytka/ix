# ReflectionHelpers.GetObjectOfType method (1 of 2)

Retrieves recursivelly list of objects that satisfy [`IsRequiredTypeDelegate`](../ReflectionHelpers.IsRequiredTypeDelegate.md) and are contained in reflected object.

```csharp
public static IEnumerable<object> GetObjectOfType(object reflectedObject, 
    IsRequiredTypeDelegate isRequiredType, List<object> listOfObjects = null)
```

| parameter | description |
| --- | --- |
| reflectedObject | Object that will be searched for objects that match [`IsRequiredTypeDelegate`](../ReflectionHelpers.IsRequiredTypeDelegate.md). |
| isRequiredType | Delegate to evaluate whether the type matches the requirements. |
| listOfObjects | Pre-existing list of objects. |

## Return Value

List of object of given type.

## See Also

* delegate [IsRequiredTypeDelegate](../ReflectionHelpers.IsRequiredTypeDelegate.md)
* class [ReflectionHelpers](../ReflectionHelpers.md)
* namespace [Ix.Connector.Reflections](../../Ix.Connector.md)

---

# ReflectionHelpers.GetObjectOfType method (2 of 2)

Retrieves recursivelly list of objects of given type that are contained in reflected object.

```csharp
public static IEnumerable<object> GetObjectOfType(object reflectedObject, Type requiredType, 
    List<object> listOfObjects = null)
```

| parameter | description |
| --- | --- |
| reflectedObject | Object that will be searched for reuired type of objects. |
| requiredType | Required type |
| listOfObjects | Pre-existing list of objects. |

## Return Value

List of object of given type.

## See Also

* class [ReflectionHelpers](../ReflectionHelpers.md)
* namespace [Ix.Connector.Reflections](../../Ix.Connector.md)

<!-- DO NOT EDIT: generated by xmldocmd for Ix.Connector.dll -->
