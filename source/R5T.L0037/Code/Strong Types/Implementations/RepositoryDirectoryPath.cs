using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.L0037
{
    /// <inheritdoc cref="IRepositoryDirectoryPath"/>
    [StrongTypeImplementationMarker]
    public class RepositoryDirectoryPath : TypedBase<string>, IStrongTypeMarker,
        IRepositoryDirectoryPath
    {
        public RepositoryDirectoryPath(string value)
            : base(value)
        {
        }
    }
}
