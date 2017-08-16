namespace ImpactMan.Interfaces.Globals
{
    using Microsoft.Xna.Framework;
    
    /// <summary>
    /// Everything seen in the map inherits from this interface.
    /// It returns the consequences 
    /// </summary>
    public interface IConsequential : IGameplayUnit
    {
        /// <summary>
        /// This method always gives info about a consequence.
        /// </summary>
        /// <returns>The consequences from the current object that you step on.</returns>
        IConsequence GiveConsequence();

        bool TryToAffect(Rectangle invaderRectangle);
    }
}
