namespace ImpactMan.ArtificialIntelligence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ImpactMan.Interfaces.ArtificialIntelligence;
    using ImpactMan.Interfaces.Models.Enemies;
    using ImpactMan.Interfaces.Models.Levels;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public class EnemyArtificialIntelligence : IArtificialIntelligence
    {
        private readonly List<Keys> directionKeys;
        private readonly Random random;
        private readonly ILevel level;
        private readonly IDictionary<IEnemy, Keys> enemiesAndCurrentDirections;

        public EnemyArtificialIntelligence(ILevel level, params Keys[] directionKeys)
        {
            this.enemiesAndCurrentDirections = new Dictionary<IEnemy, Keys>();
            this.random = new Random();

            this.directionKeys = directionKeys.ToList();
            this.level = level;
        }

        public void MoveTheEnemies(IEnumerable<IEnemy> allEnemies, GameTime gameTime)
        {
            foreach (IEnemy enemy in allEnemies)
            {
                if (this.enemiesAndCurrentDirections.ContainsKey(enemy) &&
                    enemy.TryUpdate(gameTime, new KeyboardState(this.enemiesAndCurrentDirections[enemy]), this.level))
                {
                    continue;
                }

                int currentKey = this.random.Next(0, 4);
                Keys key = this.directionKeys[currentKey];
                while (!enemy.TryUpdate(gameTime, new KeyboardState(key), this.level))
                {
                    currentKey = this.random.Next(0, 4);
                    key = this.directionKeys[currentKey];
                }

                this.enemiesAndCurrentDirections[enemy] = key;
            }
        }
    }
}
