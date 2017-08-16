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
        private readonly IMenuInitializer menuInitializer;
        private readonly ContentManager content;

        public PlayerDeathHandler(ImpactManContext context, IMenuInitializer menuInitializer, ContentManager content)
        {
            this.context = context;
            this.menuInitializer = menuInitializer;
            this.content = content;
        }

        public void OnPlayerDead(ILevel sender, PlayerAffectedEnemyEventArgs eventArgs)
        {
            UpdatePlayerHighScore(eventArgs.Player);

            ResetCurrentLevel(sender);

            ChangeGameState();
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

        private void ChangeGameState()
        {
            this.menuInitializer.Initialize("MainMenu");
            this.menuInitializer.Load(this.content);

            State.GameState = GameState.MainMenu;
        }

        private void ResetCurrentLevel(ILevel currentLevel)
        {
            currentLevel.LevelReset();;
        }
    }
}
