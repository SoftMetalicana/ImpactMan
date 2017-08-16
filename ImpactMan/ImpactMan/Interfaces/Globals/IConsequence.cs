namespace ImpactMan.Interfaces.Globals
{
    /// <summary>
    /// Everything that is seen in the map inherits returns this interface from a method.
    /// When the player object wants to step somewhere he always steps on something that has consquences.
    /// The consequences are than applied on the player object.
    /// </summary>
    public interface IConsequence
    {
        /// <summary>
        /// The bonus points that are consequenial from the current object.
        /// </summary>
        int BonusPoints { get; }
        
        /// <summary>
        /// Flag which tells the player if he can move or not.
        /// </summary>
        bool PlayerCanMove { get; }

        /// <summary>
        /// The sender of the consequence.
        /// </summary>
        IConsequential Sender { get; }
    }
}
