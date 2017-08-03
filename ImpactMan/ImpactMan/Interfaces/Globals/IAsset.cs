namespace ImpactMan.Interfaces.Globals
{
    /// <summary>
    /// Objects that use asset from the game pipeline must inherit this interface.
    /// </summary>
    public interface IAsset
    {
        /// <summary>
        /// The name of the asset which is usually taken from the game pipeline.
        /// For textures you can use .Content.Load<AssetName>()
        /// </summary>
        string AssetName { get; }
    }
}
