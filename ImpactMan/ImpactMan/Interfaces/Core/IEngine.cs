﻿namespace ImpactMan.Interfaces.Core
{
    using System;
    
    public interface IEngine : IDisposable
    {
        void Run();

        void ChangeGameMenuCurrentStatus();

        void Quit();
    }
}
