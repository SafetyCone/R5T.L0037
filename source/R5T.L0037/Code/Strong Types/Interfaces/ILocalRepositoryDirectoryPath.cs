using System;

using R5T.T0178;


namespace R5T.L0037
{
    /// <summary>
    /// <inheritdoc cref="ILocalGitRepositoryDirectoryPath" path="/summary"/>
    /// <para>
    /// Quality-of-life name for <see cref="ILocalGitRepositoryDirectoryPath"/>.
    /// </para>
    /// </summary>
    [StrongTypeMarker]
    public interface ILocalRepositoryDirectoryPath : IStrongTypeMarker,
        ILocalGitRepositoryDirectoryPath
    {
    }
}
