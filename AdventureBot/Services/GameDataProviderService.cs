using AdventureBot.BaseModules;
using AdventureBot.Interfaces;
using MODiX.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBot.Services
{
    public class GameDataProviderService : IDataProvider, IDisposable
    {
        public Result<string, string>? SetPlayerProfessionAvatar(string? profession)
        {
            var result = profession switch
            {
                "hunter" => Result<string, string>.Ok("https://cdn.gilcdn.com/MediaChannelUpload/8607290cae1361b957161eb1e52a8ce5-Full.webp?w=2500&h=2500"),
                "farmer" => Result<string, string>.Ok("https://cdn.gilcdn.com/MediaChannelUpload/3eeb017873617479bba09e9ffe3efe03-Full.webp?w=2500&h=2500"),
                "fisherman" => Result<string, string>.Ok("https://cdn.gilcdn.com/MediaChannelUpload/cd6a7a1f76cae432778f9a21e2b3a6b0-Full.webp?w=2500&h=2500"),
                "miner" => Result<string, string>.Ok("https://cdn.gilcdn.com/MediaChannelUpload/1c6ce0e83a6055b242152328af85fe8c-Full.webp?w=2500&h=2500"),
                "tailor" => Result<string, string>.Ok("https://cdn.gilcdn.com/MediaChannelUpload/f50a9ed2e4be131d4d9f48b6aa58a2e5-Full.webp?w=2500&h=2500"),
                "carpenter" => Result<string, string>.Ok("https://cdn.gilcdn.com/MediaChannelUpload/f86623c05ed7ca1deafa3eecabb16b26-Full.webp?w=2500&h=2500"),
                "blacksmith" => Result<string, string>.Ok("https://cdn.gilcdn.com/MediaChannelUpload/9bf4b59bce97444f6e16fe2c7eb57ee9-Full.webp?w=2500&h=2500"),
                "diplomat" => Result<string, string>.Ok("https://cdn.gilcdn.com/MediaChannelUpload/c04c60229fe7601854deff212e744444-Full.webp?w=2500&h=2500"),
                _ => Result<string, string>.Err("could not set player profession")
            };
            return result!;
        }

        #region DISPOSE
        public void Dispose()
        {
            DisposableBase disposableBase = new();
            disposableBase.Dispose();
        }
        #endregion
    }
}
