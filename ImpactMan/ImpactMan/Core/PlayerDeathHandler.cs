using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace ImpactMan.Core
{
    using Context.Db;
    using Enumerations.Game;
    using Interfaces.Core;
    using Interfaces.Models.Levels;
    using Interfaces.Models.Players;
    using Interfaces.Models.User;
    using Microsoft.Xna.Framework.Content;
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// This class handles the events after player's death. This includes highScore management, rediretion to MainMenu and reload of last played level.
    /// </summary>
    public class PlayerDeathHandler : IPlayerDeathHandler
    {

        private readonly ImpactManContext context;
        private IEngine engine;

        public PlayerDeathHandler(ImpactManContext context, IEngine engine)
        {
            this.context = context;
            this.engine = engine;
        }

        public void OnPlayerDead(ILevel sender, PlayerAffectedEnemyEventArgs eventArgs)
        {
            UpdatePlayerHighScore(eventArgs.Player);

            this.engine.Quit();
        }

        private void UpdatePlayerHighScore(IPlayer player)
        {
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
