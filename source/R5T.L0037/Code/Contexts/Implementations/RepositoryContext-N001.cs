using System;

using R5T.T0137;
using R5T.T0159;


namespace R5T.L0037.N001
{
    /// <inheritdoc cref="IRepositoryContext"/>
    [ContextImplementationMarker]
    public class RepositoryContext : IContextImplementationMarker,
        IRepositoryContext
    {
        public ITextOutput TextOutput { get; set; }
    }
}
