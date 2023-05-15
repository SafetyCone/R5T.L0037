using System;

using R5T.T0137;
using R5T.T0159;
using R5T.T0184;

namespace R5T.L0037.N001
{
    /// <summary>
    /// An empty context for repository operations.
    /// </summary>
    [ContextDefinitionMarker]
    public interface IRepositoryContext : IContextDefinitionMarker
    {
        public IRepositoryName RepositoryName { get; }

        public ITextOutput TextOutput { get; }
    }
}
