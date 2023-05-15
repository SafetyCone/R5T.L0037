using System;

using R5T.T0137;


namespace R5T.L0037
{
    /// <summary>
    /// Quality-of-life overload for <see cref="ILocalGitRepositoryContext"/>.
    /// </summary>
    [ContextDefinitionMarker]
    public interface ILocalRepositoryContext : IContextDefinitionMarker,
        ILocalGitRepositoryContext
    {
    }
}
