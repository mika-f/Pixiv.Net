Sagitta
----
pixiv API wrapper for .NET.  


## Usage

### Authorization

**Note**: This library doesn't contains pixiv's Client ID and Client Secret.

```csharp
var client = new Sagitta.PixivClient("CLIENT_ID", "CLIENT_SECRET");
var tokens = await client.OAuth.TokenAsync("username", "password");
```

