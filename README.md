baelor-dotnet
===

An Api Client for the [Baelor Api](https://baelor.io).

### Example Usage
``` csharp
using BaelorNet;

var baelorClient = new BaelorClient("api-key");
var songs = await baelorClient.Songs();
foreach(var song in songs)
{
	Console.WriteLine($"{song.Tite} is in the album {song.Album.Name}");
}
```
