namespace ImpactMan.Models.Menu.MenuCommands
{
    using Core;
    using Enumerations.Game;
    using Context.Models;
    using Interfaces.Core;
    using Interfaces.Models.Menu;

    /// <summary>
    /// These commands are executed when a menu button is clicked on. They invoke directly methods of the receiver casses.
    /// </summary>
    public abstract class MenuCommand : IMenuCommand
    {
        private IEngine engine;

        protected MenuCommand(IEngine engine)
        {
            this.Engine = engine;
        }

        public IEngine Engine
        {
            get { return engine; }
            protected set { engine = value; }
        }

        public abstract void Execute(User user);

        /*            this.InitializeMenu(user);
            this.ChangeGamestate(user);
            this.ChangeErrorMessage(user);
            this.ClearCurrentUserDetails();
            this.ChangeUserInputState(user);
            this.PlayMusic();
            this.End(user);*/

        /*       public abstract void InitializeMenu(User user);
               public abstract void ChangeGamestate(User user);
               public virtual void ChangeErrorMessage(User user)
               {
               }
               public virtual void ClearCurrentUserDetails()
               {
                   this.Engine.ClearCurrentUserDetails();
               }
               public virtual void ChangeUserInputState(User user)
               {
                   State.UserInputState = UserInputState.NameInput;
               }
               public virtual void PlayMusic()
               {
               }
               public virtual void End(User user)
               {
               }*/

    }
}