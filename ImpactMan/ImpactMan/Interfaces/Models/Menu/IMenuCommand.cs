namespace ImpactMan.Interfaces.Models.Menu
{
    using Context.Models;

    public interface IMenuCommand
    {
        void Execute(User user);
    }
}
