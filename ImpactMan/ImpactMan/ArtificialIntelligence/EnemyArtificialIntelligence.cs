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

                int currentKey = 0;
                while (true)
                {
                    Keys key = this.directionKeys[currentKey++];
                    int indexOfKey = this.directionKeys.IndexOf(key);
                    if (this.enemiesAndCurrentDirections.ContainsKey(enemy) &&
                        this.enemiesAndCurrentDirections[enemy].Equals(this.directionKeys[(indexOfKey + 2) % this.directionKeys.Count]))
                    {
                        continue;
                    }

                    bool enemyMovedSuccessfully = enemy.TryUpdate(gameTime, new KeyboardState(key), this.level);

                    if (enemyMovedSuccessfully)
                    {
                        this.enemiesAndCurrentDirections[enemy] = key;
                        break;
                    }
                }
            }
        }
    }
}
