using System;

using R5T.T0131;
using R5T.T0159;
using R5T.T0184;


namespace R5T.L0037
{
    [ValuesMarker]
    public partial interface IRepositoryContextConstructors : IValuesMarker,
        L0042.F000.IRepositoryContextConstructors
    {
        public Func<IRepositoryContext> Default(
            IRepositoryName repositoryName,
            IRepositoryOwnerName ownerName,
            ITextOutput textOutput)
        {
            return () => new RepositoryContext
            {
                RepositoryName = repositoryName,
                OwnerName = ownerName,
                TextOutput = textOutput,
            };
        }
    }
}
