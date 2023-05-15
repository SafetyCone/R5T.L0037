using System;

using R5T.T0137;


namespace R5T.L0037.N001
{
    /// <summary>
    /// Context for local repository operations.
    /// </summary>
    [ContextDefinitionMarker]
    public interface ILocalRepositoryContext : IContextDefinitionMarker,
        IRepositoryContext
    {
        public ILocalRepositoryDirectoryPath DirectoryPath { get; }
    }
}
