using AdventureBot.Services;
using Guilded.Base;
using Guilded.Base.Embeds;
using Guilded.Commands;
using System.Drawing;

namespace AdventureBot.Commands
{
    public class GameCommands: CommandModule
    {
        #region NEW GAME
        [Command(Aliases = [ "newgame" ])]
        [Description("starts a new adventure game")]
        public async Task NewGame(CommandEvent invokator)
        {

            var authorId = invokator.Message.CreatedBy;
            var serverId = invokator.ServerId;
            var author = await invokator.ParentClient.GetMemberAsync((HashId)serverId!, authorId);
            var embed = new Embed();
            embed.SetThumbnail(new EmbedMedia("https://cdn.gilcdn.com/MediaChannelUpload/3ff733a8d5b84a4a4203e4969d360abc-Full.webp?w=1500&h=1500"));
            embed.SetTitle("Title of the Game will be here");
            embed.SetAuthor($"{author.Name}");
            embed.SetFooter("Adventure Bot adventuring ");
            embed.SetTimestamp(DateTime.Now);
            embed.SetColor(Color.SlateBlue);
            await invokator.ReplyAsync(embed);
        }
        #endregion

        #region ADD NEW PLAYER
        [Command(Aliases = [ "addplayer", "addp" ])]
        [Description("add a new player to the database")]
        public async Task AddNewPlayer(CommandEvent invokator, string name = "", string race = "", string profession = "")
        {
            if (name.Equals("") || race.Equals("") || profession.Equals(""))
            {
                await invokator.ReplyAsync("unable to add new player, please provide [NAME] [RACE] [PROFESSION]");
            }
            else
            {
                using var gameDataProvider = new GameDataProviderService();
                var prof = gameDataProvider.SetPlayerProfessionAvatar(profession);
                if (prof.HasValue)
                {
                    var embed = new Embed();
                    embed.SetThumbnail(prof.GetValueOrDefault().Value);
                    await invokator.ReplyAsync(embed);
                }
                
            }
        }
        #endregion
    }
}
