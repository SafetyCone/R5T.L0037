using System;

using R5T.T0137;
using R5T.T0184;


namespace R5T.L0037
{
    /// <summary>
    /// Name and owner name based repository context.
    /// </summary>
    [ContextDefinitionMarker]
    public interface IRepositoryContext : IContextDefinitionMarker,
        L0042.T000.IRepositoryContext
    {
        public IRepositoryOwnerName OwnerName { get; }
    }
}
