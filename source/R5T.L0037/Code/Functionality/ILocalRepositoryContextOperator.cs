using System;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0159;
using R5T.T0184;


namespace R5T.L0037
{
    [FunctionalityMarker]
    public partial interface ILocalRepositoryContextOperator : IFunctionalityMarker
    {
        public Task In_LocalRepositoryContext(
            IRepositoryName repositoryName,
            ILocalRepositoryDirectoryPath repositoryDirectoryPath,
            ITextOutput textOutput,
            params Func<ILocalRepositoryContext, Task>[] operations)
        {
            return Instances.ContextOperator.In_Context(
                () => new LocalRepositoryContext
                {
                    RepositoryName = repositoryName,
                    DirectoryPath = repositoryDirectoryPath,
                    TextOutput = textOutput,
                },
                operations,
                Instances.RepositoryContextDestructors.Default);
        }
    }
}
