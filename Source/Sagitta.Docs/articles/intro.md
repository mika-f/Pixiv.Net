# Sagitta

Sagitta が、イラスト投稿サービス pixiv のクライアント API ラッパーライブラリーです。  
API キーさえ用意すれば、簡単に pixiv の API を使うことが出来ます。


## Getting Started

[NuGet](https://nuget.org/packages/Sagitta) から、 Sagitta とその依存ライブラリをプロジェクトへ追加します。  
追加方法については、[公式ドキュメント](https://docs.microsoft.com/ja-jp/nuget/quickstart/install-and-use-a-package-using-the-dotnet-cli)を参照してください。

プロジェクトへ追加したら、下記の `using` ステートメントを、 Sagitta を使用したいファイルの先頭へ追加します。

```csharp
using Sagitta;
using Sagitta.Enum;
```

次に、 API キーをパラメータとして、 `PixivClient` インスタンスを作成します。

```csharp
var pixiv = new PixivClient("CLIENT_ID", "CLIENT_SECRET");
```

最後に、任意の API を呼び出します。  
例えば、ユーザー認証を行いたい場合は、次のようにします。

```csharp
var tokens = await pixiv.Authentication.LoginAsync("YOUR_USERNAME", "YOUR_PASSWORD");
```