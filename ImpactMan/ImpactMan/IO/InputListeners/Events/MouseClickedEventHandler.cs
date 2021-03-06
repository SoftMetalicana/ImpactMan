﻿namespace ImpactMan.IO.InputListeners.Events
{
    using Interfaces.IO.InputListeners;

    /// <summary>
    /// Holds pointers to all the methods of the objects that are interested of the corresponding event.
    /// </summary>
    /// <param name="sender">The input listener itself.</param>
    /// <param name="eventArgs">Basic mouse state info at the moment the event is raised.</param>
    public delegate void MouseClickedEventHandler(IInputListener sender, MouseClickedEventArgs eventArgs);
}
