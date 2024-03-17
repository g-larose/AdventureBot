using AdventureBot.Interfaces;
using MODiX.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBot.Services
{
    public class GameDataProviderService : IDataProvider
    {
        public Result<string, string>? SetPlayerProfessionAvatar(string? profession)
        {
            var result = profession switch
            {
                "hunter" => Result<string, string>.Ok("https://cdn.gilcdn.com/MediaChannelUpload/8607290cae1361b957161eb1e52a8ce5-Full.webp?w=2500&h=2500"),
                _ =>  Result<string, string>.Err("could not set player profession")
            };
            return result!;
        }
    }
}
