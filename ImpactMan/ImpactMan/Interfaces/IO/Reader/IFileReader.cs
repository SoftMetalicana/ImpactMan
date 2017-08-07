namespace ImpactMan.Interfaces.IO.Reader
{
    using System;

    /// <summary>
    /// Reads from files and should be disposed when work is done.
    /// </summary>
    public interface IFileReader : IReader, IDisposable
    {
    }
}
