namespace ImpactMan.Interfaces.Globals
{
    public interface IConsequential : IUnit
    {
        int BonusPoints { get; }

        IConsequence GiveConsequence();
    }
}
