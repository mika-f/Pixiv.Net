# Pixiv.Net

Pixiv.Net は、イラスト投稿サービス pixiv のクライアント API ラッパーライブラリです。  
API キーさえ用意すれば、簡単に pixiv の API を使うことが出来ます。


## Getting Started

[NuGet](https://nuget.org/packages/Pixiv.Net) から、 Pixiv.Net とその依存ライブラリをプロジェクトへ追加します。  
追加方法については、[公式ドキュメント](https://docs.microsoft.com/ja-jp/nuget/quickstart/install-and-use-a-package-using-the-dotnet-cli)を参照してください。

プロジェクトへ追加したら、下記の `using` ステートメントを、 Pixiv.Net を使用したいファイルの先頭へ追加します。

```csharp
using Pixiv;
using Pixiv.Enum;
```

次に、 API キーおよび認証用 Hash Secret をパラメータとして、 `PixivClient` インスタンスを作成します。  
なお、 `CLIENT_ID`, `CLIENT_SECRET`, `AUTH_HASH_SECRET` は **Pixiv.Net には含まれていません**。

```csharp
var pixiv = new PixivClient("CLIENT_ID", "CLIENT_SECRET", "AUTH_HASH_SECRET");
```

最後に、任意の API を呼び出します。  
例えば、ユーザー認証を行いたい場合は、次のようにします。

```csharp
var tokens = await pixiv.Authentication.LoginAsync("YOUR_USERNAME", "YOUR_PASSWORD");
```