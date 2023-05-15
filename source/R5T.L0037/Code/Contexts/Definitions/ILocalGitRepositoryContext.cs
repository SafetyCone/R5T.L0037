using System;

using R5T.T0137;


namespace R5T.L0037
{
    /// <summary>
    /// Context for local repository operations.
    /// </summary>
    [ContextDefinitionMarker]
    public interface ILocalGitRepositoryContext : IContextDefinitionMarker,
        N001.ILocalRepositoryContext
    {
        public new ILocalGitRepositoryDirectoryPath DirectoryPath { get; }
    }
}
