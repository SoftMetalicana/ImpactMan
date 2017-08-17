namespace ImpactMan.Interfaces.Models.Enemies
{
    using ImpactMan.Interfaces.Globals;
    using ImpactMan.Interfaces.Models.Levels;
    using ImpactMan.Utils;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;
    
    public static class IEnemyExtensionMethods
    {
        public static bool TryUpdate(this IEnemy enemy, GameTime gameTime, KeyboardState keyboardState, ILevel level)
        {
            (Rectangle desired, Rectangle helper) calculatedDesiredAndHelperRectangle =
                                        Movement.CalculateDesiredAndHelperRectangle(enemy.Rectangle, enemy.Texture, gameTime, keyboardState);

            Rectangle desiredRectangle = calculatedDesiredAndHelperRectangle.desired;
            Rectangle helperRectangle = calculatedDesiredAndHelperRectangle.helper;

            IConsequence consequence = level.GetAffectedObjectConsequence(helperRectangle);

            if (consequence != null && consequence.PlayerCanMove)
            {
                enemy.Rectangle = desiredRectangle;
                return true;
            }

            return false;
        }
    }
}
