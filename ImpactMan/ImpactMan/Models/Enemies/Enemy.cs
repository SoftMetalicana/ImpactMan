namespace ImpactMan.Models.Enemies
{
    using System;
    using Models.Consequences;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    using Constants.Consequential;
    using ImpactMan.Interfaces.Models.Enemies;

    public class Enemy : Consequential, IEnemy
    {
        public Enemy(int x, int y, string assetName)
            : this(x, y, assetName, ConsequentialConstants.EnemyBonusPoints)
        {
        }

        public Enemy(int x, int y, string assetName, int bonusPoints)
            : base(x, y, assetName, bonusPoints)
        {
        }

        public override void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            throw new NotImplementedException();
        }
    }
}
