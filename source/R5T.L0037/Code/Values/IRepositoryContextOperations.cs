using System;
using System.Threading.Tasks;

using R5T.L0047.T000;
using R5T.T0131;
using R5T.T0186;
using R5T.T0186.Extensions;


namespace R5T.L0037
{
    [ValuesMarker]
    public partial interface IRepositoryContextOperations : IValuesMarker,
        L0042.O001.IRepositoryContextOperations
    {
        public Func<IRepositoryContext, Task> In_GitHubRepositoryContext(
            params Func<L0036.T000.N001.IGitHubRepositoryContext, Task>[] operations)
            =>
                context => Instances.GitHubRepositoryContextOperator.In_GitHubRepositoryContext(
                    context.RepositoryName.Value.ToGitHubRepositoryName(),
                    context.OwnerName.Value.ToGitHubRepositoryOwnerName(),
                    context.TextOutput,
                    operations);
    }
}
