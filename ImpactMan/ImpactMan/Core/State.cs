namespace ImpactMan.Core
{
    using ImpactMan.Enumerations.Game;

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
