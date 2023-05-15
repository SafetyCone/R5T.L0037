using System;
using System.Linq;
using System.Threading.Tasks;

using R5T.F0000.Extensions;
using R5T.L0039.T000;
using R5T.L0032.T000;
using R5T.L0032.T000.Extensions;
using R5T.T0131;
using R5T.T0187;


namespace R5T.L0037
{
    [ValuesMarker]
    public partial interface ILocalRepositoryContextOperations : IValuesMarker
    {
        public delegate Func<ILocalRepositoryContext, Task> In_SolutionContext_N001_Params(
            ISolutionName solutionName,
            params Func<N001.ISolutionContext, Task>[] operations);

        public In_SolutionContext_N001_Params In_SolutionContext_N001 =>
            (solutionName, operations) =>
                context => Instances.LocalRepositoryContextOperator_Internal.In_SolutionContext_N001(
                    context,
                    solutionName,
                    operations);

        public delegate Func<N001.ILocalRepositoryContext, Task> In_SolutionContext_Params(
            ISolutionName solutionName,
            params Func<ISolutionContext, Task>[] operations);

        public In_SolutionContext_Params In_SolutionContext =>
            (solutionName, operations) =>
                context => Instances.LocalRepositoryContextOperator_Internal.In_SolutionContext(
                    context,
                    solutionName,
                    operations);

        public In_SolutionContext_Params In_NewSolutionContext =>
            (solutionName, operations) =>
                context => Instances.LocalRepositoryContextOperator_Internal.In_SolutionContext(
                    context,
                    solutionName,
                    operations
                        .Prepend(Instances.SolutionContextOperations.Create_New_SolutionFile));

        public Task<IRepositoryUrl> Get_RepositoryUrl(ILocalGitRepositoryContext context)
        {
            var repositoryUrlString = Instances.GitOperator.GetRepositoryRemoteUrl(
                context.DirectoryPath.Value);

            var repositoryUrl = repositoryUrlString.ToRepositoryUrl();

            return Task.FromResult(repositoryUrl);
        }
    }
}
