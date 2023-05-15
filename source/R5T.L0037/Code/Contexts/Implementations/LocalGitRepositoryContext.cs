using System;

using R5T.T0137;
using R5T.T0159;
using R5T.T0184;


namespace R5T.L0037
{
    /// <inheritdoc cref="ILocalGitRepositoryContext"/>
    [ContextImplementationMarker]
    public class LocalRepositoryContext : IContextImplementationMarker,
        ILocalRepositoryContext
    {
        public ILocalGitRepositoryDirectoryPath DirectoryPath { get; set; }
        public IRepositoryName RepositoryName { get; set; }

        public ITextOutput TextOutput { get; set; }

        N001.ILocalRepositoryDirectoryPath N001.ILocalRepositoryContext.DirectoryPath => this.DirectoryPath;
    }
}
