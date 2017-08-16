using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
using ImpactMan.Context.Db;
using ImpactMan.Context.Models;
using ImpactMan.Interfaces.Core;
using ImpactMan.Interfaces.Models.Levels;
using ImpactMan.Interfaces.Models.Players;
using ImpactMan.Interfaces.Models.User;

namespace ImpactMan.Core
{
    public class PlayerDeathHandler : IPlayerDeathHandler
    {
        private ImpactManContext context;

        public PlayerDeathHandler(ImpactManContext context)
        {
            this.context = context;
        }

        public void OnPlayerDead(ILevel sender, PlayerAffectedEnemyEventArgs eventArgs)
        {
            IPlayer player = eventArgs.Player;

            IUser user = context.Users.FirstOrDefault(u => u.Name == CurrentUser.User.Name);

            if (user != null && user.HighScore < player.Points)
            {
                user.HighScore = player.Points;

                context.Entry(user).State = EntityState.Modified;

                context.SaveChanges();
            }
        }
    }
}
