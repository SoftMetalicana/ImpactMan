namespace ImpactMan.Interfaces.IO.Reader
{
    /// <summary>
    /// Reads from e certain source.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads a single line.
        /// </summary>
        /// <returns>The single line read.</returns>
        string ReadLine();
    }
}
