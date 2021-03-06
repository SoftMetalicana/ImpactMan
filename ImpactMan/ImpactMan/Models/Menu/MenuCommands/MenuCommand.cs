﻿using System;

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

        public virtual void Execute(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(Constants.ExceptionMessages.UserNullException);
            }
        }
    }
}