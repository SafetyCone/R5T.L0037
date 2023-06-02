using System;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0159;
using R5T.T0184;


namespace R5T.L0037
{
    [FunctionalityMarker]
    public partial interface IRepositoryContextOperator : IFunctionalityMarker,
        L0042.F000.IRepositoryContextOperator
    {
        public Task In_RepositoryContext(
            IRepositoryName repositoryName,
            IRepositoryOwnerName ownerName,
            ITextOutput textOutput,
            params Func<IRepositoryContext, Task>[] operations)
        {
            return Instances.ContextOperator.In_Context(
                Instances.RepositoryContextConstructors.Default(
                    repositoryName,
                    ownerName,
                    textOutput),
                operations,
                Instances.ActionOperations.DoNothing);
        }
    }
}
