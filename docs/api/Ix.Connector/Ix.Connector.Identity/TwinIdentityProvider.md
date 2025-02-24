# TwinIdentityProvider class

Provides access to the objects by their identities.

```csharp
public class TwinIdentityProvider
```

## Public Members

| name | description |
| --- | --- |
| [TwinIdentityProvider](TwinIdentityProvider/TwinIdentityProvider.md)(…) | Creates an instance of |
| [Identities](TwinIdentityProvider/Identities.md) { get; } | Get dictionary of identities. |
| [IdentitiesCount](TwinIdentityProvider/IdentitiesCount.md) { get; } | Get count of identities. |
| [AddIdentity](TwinIdentityProvider/AddIdentity.md)(…) | Adds twin object to the list of identities. |
| [GetTwinByIdentity](TwinIdentityProvider/GetTwinByIdentity.md)(…) | Gets twin object by identity, if the object implements [`ITwinIdentity`](./ITwinIdentity.md). If object does not implements [`ITwinIdentity`](./ITwinIdentity.md) the same object is returned. (3 methods) |
| [ReadIdentities](TwinIdentityProvider/ReadIdentities.md)() | Reads twin objects identities. |
| [RefreshIdentities](TwinIdentityProvider/RefreshIdentities.md)() | Refreshes and sorts identities. |
| [SortIdentities](TwinIdentityProvider/SortIdentities.md)() | Sorts identities. |

## See Also

* namespace [Ix.Connector.Identity](../Ix.Connector.md)

<!-- DO NOT EDIT: generated by xmldocmd for Ix.Connector.dll -->
