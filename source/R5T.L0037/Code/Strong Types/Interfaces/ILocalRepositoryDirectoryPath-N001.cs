using System;

using R5T.T0178;
using R5T.T0180;


namespace R5T.L0037.N001
{
    /// <summary>
    /// Strongly-types a string as a local repository directory path.
    /// </summary>
    [StrongTypeMarker]
    public interface ILocalRepositoryDirectoryPath : IStrongTypeMarker,
        IDirectoryPath
    {
    }
}
