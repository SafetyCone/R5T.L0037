using System;

using R5T.T0137;
using R5T.T0159;


namespace R5T.L0037.N001
{
    /// <summary>
    /// An empty context for repository operations.
    /// </summary>
    [ContextDefinitionMarker]
    public interface IRepositoryContext : IContextDefinitionMarker
    {
        public ITextOutput TextOutput { get; }
    }
}
