using System;

using R5T.T0131;
using R5T.T0159;
using R5T.T0184;


namespace R5T.L0037
{
    [ValuesMarker]
    public partial interface IRepositoryContextConstructors : IValuesMarker
    {
        public Func<IRepositoryName, IRepositoryOwnerName, ITextOutput, Func<IRepositoryContext>> Default =>
            (repositoryName, ownerName, textOutput) =>
                () => new RepositoryContext
                {
                    RepositoryName = repositoryName,
                    OwnerName = ownerName,
                    TextOutput = textOutput,
                };
    }
}
