using ImpactMan.Enumerations.Game;

namespace ImpactMan.Core
{
    public class State
    {
        private static GameState gameState;
        private static UserInputState userInputState;

        public static GameState GameState
        {
            get { return gameState; }
            set { gameState = value; }
        }

        public static UserInputState UserInputState
        {
            get { return userInputState; }
            set { userInputState = value; }
        }
    }
}
