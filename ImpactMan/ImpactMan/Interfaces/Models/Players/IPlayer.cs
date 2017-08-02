namespace ImpactMan.Interfaces.Models.Players
{
    using ImpactMan.Interfaces.Globals;
    using ImpactMan.Interfaces.IO.InputListeners;
    using ImpactMan.IO.InputListeners.Events;

    public interface IPlayer : IUnit
    {
        string Name { get; }

        int Points { get; }

        void OnKeyPressed(IInputListener sender, KeyPressedEventArgs eventArgs);
    }
}
