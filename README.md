# Sagitta

pixiv API wrapper for .NET.  


## Platforms
Sagitta has been created as .NET Standard 1.4.  
.NET Standard 1.4 supports below platforms:

* .NET Core 1.0
* .NET Framework 4.6.1
* Mono/Xamarin
* UWP 10.0

## Usage

Import namespaces.

```csharp
using Sagitta;
using Sagitta.Enum;
```

### Authorization

**Note**: This library doesn't contains pixiv's Client ID and Client Secret.

```csharp
var client = new PixivClient("CLIENT_ID", "CLIENT_SECRET");

// Login
var tokens = await client.OAuth.TokenAsync("username", "password");
```

### Illust

```csharp
var illust = await client.Illust.DetailAsync(61463577);

// Recommends
var illusts = await client.Illust.RecommendedAsync();

// Ranking
var illusts = await client.Illust.RankingAsync(RankingMode.Day);

// Add to bookmark
await pixivClient.Illust.Bookmark.AddAsync(61463577, tags: new string[] {"艦これ", "ゆるい艦これ"});
```

### Search

**Note**: Sort by popularity can only be used premium users.

```csharp
var response = await client.Search.IllustAsync("二宮飛鳥", SortOrder.PopularDesc, Duration.LastWeek);
response.Illusts.First(); // -> Id: 61424296
```

### Trends

```csharp
var trends = await client.TrendingTags.IllustAsync();
var trends = await client.TrendingTags.NovelAsync();
```