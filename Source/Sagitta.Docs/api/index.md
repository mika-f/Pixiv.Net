
# "Sagitta" API documentation
Sagitta の API ドキュメントです。  
なお、 Sagitta の API は全て `Task<TResult>` を返します。


## Preparation

```csharp
using Sagitta;
using Sagitta.Enum;

var pixivClient = new PixivClient("CLIENT_ID", "CLIENT_SECRET");
```

