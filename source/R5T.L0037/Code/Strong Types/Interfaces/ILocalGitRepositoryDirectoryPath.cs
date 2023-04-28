using System;

using R5T.T0178;


namespace R5T.L0037
{
    /// <summary>
    /// Strongly-types a string as a local Git repository directory path.
    /// </summary>
    [StrongTypeMarker]
    public interface ILocalGitRepositoryDirectoryPath : IStrongTypeMarker,
        N001.ILocalRepositoryDirectoryPath
    {
    }
}
